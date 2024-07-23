
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

public delegate void Resolver(Action resolve, Action<Exception> reject);

public enum PromiseState
{
    Pending = 0,
    Fulfilled = 1,
    Rejected = 2,
}

public class Promise
{
    static int _lastId = 0;
    public PromiseState State { get; private set; }
    public int ID { get; private set; }
    private List<Action> _fulfilledCallbacks = new();
    private List<Action<Exception>> _rejectedCallbacks = new();
    private Exception? _exception;

    private readonly object _lock = new object();

    public Promise() : this(PromiseState.Pending)
    {
        ID = ++_lastId;
    }

    private Promise(PromiseState state)
    {
        State = state;
    }

    private Promise(Exception ex) : this(PromiseState.Rejected)
    {
        _exception = ex;
    }

    public Promise(Resolver resolver) : this()
    {
        try
        {
            resolver(Resolve, Reject);
        }
        catch (Exception ex)
        {
            Reject(ex);
        }
    }

    public void Resolve()
    {
        if (State != PromiseState.Pending)
        {
            throw new InvalidOperationException($"Attempted to resolve a promise in state {State}");
        }

        State = PromiseState.Fulfilled;
        foreach (Action callback in _fulfilledCallbacks)
        {
            callback();
        }
    }

    public void Reject(Exception exception)
    {
        if (State != PromiseState.Pending)
        {
            throw new InvalidOperationException($"Attempted to reject a promise in state {State}");
        }

        State = PromiseState.Rejected;
        _exception = exception;
        foreach (var callback in _rejectedCallbacks)
        {
            callback(exception);
        }
    }

    public Promise Then(Action onFulfilled, Action<Exception>? onRejected = null)
    {
        if (State == PromiseState.Fulfilled)
        {
            try
            {
                onFulfilled();
                return Promise.Resolved();
            }
            catch (Exception ex)
            {
                return Promise.Rejected(ex);
            }
        }

        var promise = new Promise();

        var resolved = () =>
        {
            onFulfilled();
            promise.Resolve();
        };

        var rejected = (Exception ex) =>
        {
            if (onRejected != null)
            {
                onRejected(ex);
            }
            promise.Reject(ex);
        };

        AddResolvedHandler(resolved);
        AddRejectedHandler(rejected);

        return promise;
    }

    public Promise Catch(Action<Exception> onRejected)
    {
        if (State == PromiseState.Fulfilled)
        {
            return this;
        }

        var promise = new Promise();
        AddResolvedHandler(promise.Resolve);
        AddRejectedHandler((ex) =>
        {
            onRejected(ex);
            promise.Reject(ex);
        });
        return promise;
    }

    public Promise Finally(Action onComplete)
    {
        if (State == PromiseState.Fulfilled)
        {
            try
            {
                onComplete();
                return this;
            }
            catch (Exception ex)
            {
                return Rejected(ex);
            }
        }

        var promise = new Promise();
        this.Then(promise.Resolve);
        this.Catch((ex) =>
        {
            try
            {
                onComplete();
                promise.Reject(ex);
            }
            catch (Exception ex2)
            {
                promise.Reject(ex2);
            }
        });

        return promise.Then(() => onComplete());

    }

    internal static Promise resolvedPromise = new Promise(PromiseState.Fulfilled);

    public static Promise Resolved() => resolvedPromise;

    public static Promise Rejected(Exception ex) => new Promise(ex);

    public PromiseAwaiter GetAwaiter() => new PromiseAwaiter(this);


    public override string ToString()
    {
        return $"{{ ID = {ID}, State = {State} }}";
    }

    private void AddResolvedHandler(Action onResolved)
    {
        if (State == PromiseState.Fulfilled)
        {
            onResolved();
        }
        else
        {
            _fulfilledCallbacks.Add(onResolved);
        }
    }

    private void AddRejectedHandler(Action<Exception> onRejected)
    {
        if (State == PromiseState.Rejected)
        {
            onRejected(_exception!);
        }
        else
        {
            _rejectedCallbacks.Add(onRejected);
        }
    }

    private void Wait()
    {
        ManualResetEventSlim? mres = null;
        lock (_lock)
        {
            if (State == PromiseState.Pending)
            {
                mres = new ManualResetEventSlim();
                _fulfilledCallbacks.Add(mres.Set);
            }
        }

        mres?.Wait();

        if (_exception is not null)
        {
            ExceptionDispatchInfo.Throw(_exception);
        }
    }

    public class PromiseAwaiter(Promise promise) : INotifyCompletion
    {
        public bool IsCompleted => promise.State == PromiseState.Fulfilled || promise.State == PromiseState.Rejected;

        public void OnCompleted(Action continuation)
        {
            promise.AddResolvedHandler(continuation);
        }

        public void GetResult()
        {
            promise.Wait();
        }

        public PromiseAwaiter GetAwaiter() => this;
    }
}