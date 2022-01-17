namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class ChangeTabUrlCommandViewModel : CommandBase
    {
        public override string CommandDescription
        {
            get => "Change the URL of the specified Tab";
        }

        public override string CommandName
        {
            get => "Change Tab URL";
        }
        
        private int _tabId;
        public int TabId
        {
            get =>  _tabId;
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


        public override void Execute()
        {
            if (ChromeCommands.ChangeTabUrl(TabId, Url))
            {

                OutputText = $"Changed Tab {TabId} URL to {Url}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
