namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class GetUrlInTabCommandViewModel : CommandBase
    {
        private int _tabId;
        public int TabId
        {
            get => _tabId;
            set
            {
                if (Equals(_tabId, value))
                {
                    return;
                }

                _tabId = value;

                NotifyPropertyChanged();
            }
        }

        public override string CommandDescription
        {
            get => "Get the current URL from the specified Tab";
        }

        public override string CommandName
        {
            get => "Get URL from Tab";
        }

        public override void Execute()
        {
            if (ChromeCommands.GetUrl(TabId, out string url))
            {
                OutputText = $"Url of Tab {TabId} is {url}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
