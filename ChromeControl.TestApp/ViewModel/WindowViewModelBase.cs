namespace ChromeControl.TestApp.ViewModel
{
    public abstract class WindowViewModelBase : ViewModelBase
    {
        private bool _close;

        public bool Close
        {
            get => _close;
            set
            {
                if (Equals(_close, value))
                {
                    return;
                }

                _close = value;

                NotifyPropertyChanged();
            }
        }

        public WindowExitResult ExitResult
        {
            get;
            protected set;
        } = WindowExitResult.Notset;

        protected void CloseWindow()
        {
            Close = true;
        }
    }

    public enum WindowExitResult
    {
        Notset,
        Ok,
        Cancel,
    }
}
