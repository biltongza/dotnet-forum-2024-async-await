using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

public class MyAwaitable<T>
{
    private bool _completed = false;
    private Exception? _exception;
    private Action? _continuation;
    private ExecutionContext? _executionContext;
    private T? _result;
    public MyAwaiter GetAwaiter() => new MyAwaiter(this);
    private readonly object _lock = new object();

    public bool IsCompleted
    {
        get
        {
            lock (_lock)
            {
                return _completed;
            }
        }
    }

    public void SetException(Exception exception) => Complete(default(T), exception);

    public void SetResult(T result) => Complete(result, null);

    public void Wait()
    {
        ManualResetEventSlim? mres = null;
        lock (_lock)
        {
            if (!_completed)
            {
                mres = new ManualResetEventSlim();
                ContinueWith(mres.Set);
            }
        }

        mres?.Wait();

        if (_exception is not null)
        {
            ExceptionDispatchInfo.Throw(_exception);
        }
    }

    public void ContinueWith(Action action)
    {
        lock (_lock)
        {
            if (_completed)
            {
                ThreadPool.QueueUserWorkItem((object? state) => ((Action)state!).Invoke(), action);
            }
            else
            {
                _continuation = action;
                _executionContext = ExecutionContext.Capture();
            }
        }
    }

    private void Complete(T? result, Exception? exception)
    {
        lock (_lock)
        {
            if (_completed)
            {
                throw new InvalidOperationException("Already complete!");
            }

            _completed = true;
            _result = result;
            _exception = exception;

            if (_continuation is not null)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    if (_executionContext is null)
                    {
                        _continuation();
                    }
                    else
                    {
                        ExecutionContext.Run(_executionContext, (object? state) => ((Action)state!).Invoke(), _continuation);
                    }
                });
            }
        }
    }

    public class MyAwaiter(MyAwaitable<T> awaitable) : INotifyCompletion
    {
        public bool IsCompleted => awaitable.IsCompleted;

        public T? GetResult()
        {
            awaitable.Wait();
            return awaitable._result;
        }

        public void OnCompleted(Action continuation) => awaitable.ContinueWith(continuation);

        public MyAwaiter GetAwaiter() => this;
    }
}
