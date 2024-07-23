namespace WinformsAsyncExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            syncButton.Enabled = false;
            DoSomeWork((int)delaySelector.Value * 1000);
            syncButton.Enabled = true;
        }

        // yes, this is async void
        // yes, we know we just told you this is bad
        // it's because the delegate type for click events says the return type must be void
        // hooray for winforms
        private async void asyncButton_Click(object sender, EventArgs e)
        {
            asyncButton.Enabled = false;
            await DoSomeWorkAsync((int)delaySelector.Value * 1000);
            asyncButton.Enabled = true;
        }

        private void DoSomeWork(int howLong)
        {
            // simulate doing some hard work
            Thread.Sleep(howLong);
        }

        private async Task DoSomeWorkAsync(int howLongMillis)
        {
            await Task.Delay(howLongMillis);
        }
    }
}
