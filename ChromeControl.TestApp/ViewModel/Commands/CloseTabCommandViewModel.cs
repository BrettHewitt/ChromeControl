namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class CloseTabCommandViewModel : CommandBase
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
            get => "Close the specified Tab";
        }

        public override string CommandName
        {
            get => "Close Tab";
        }

        public override void Execute()
        {
            if (ChromeCommands.CloseTab(TabId))
            {
                OutputText = $"Tab {TabId} Closed";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
