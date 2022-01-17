namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class OpenTabCommandViewModel : CommandBase
    {
        private int _windowId;
        public int WindowId
        {
            get => _windowId;
            set
            {
                if (Equals(_windowId, value))
                {
                    return;
                }

                _windowId = value;

                NotifyPropertyChanged();
            }
        }

        private string _url;
        public string Url
        {
            get => _url;
            set
            {
                if (Equals(_url, value))
                {
                    return;
                }

                _url = value;

                NotifyPropertyChanged();
            }
        }

        public override string CommandDescription
        {
            get => "Open a new tab in the chrome window";
        }

        public override string CommandName
        {
            get => "Open Tab";
        }

        public override void Execute()
        {
            if (ChromeCommands.OpenTab(WindowId, Url, out int tabId))
            {
                OutputText = $"Opened {Url} in Tab: {tabId}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
