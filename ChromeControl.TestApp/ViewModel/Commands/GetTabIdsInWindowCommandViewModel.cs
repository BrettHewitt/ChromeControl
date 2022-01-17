namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class GetTabIdsInWindowCommandViewModel : CommandBase
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

        public override string CommandDescription
        {
            get => "Get the Ids of all Tabs in the specified Window";
        }

        public override string CommandName
        {
            get => "Get Tab Ids from Window";
        }

        public override void Execute()
        {
            if (ChromeCommands.GetTabIdsInWindow(WindowId, out int[] ids))
            {
                OutputText = string.Join(", ", ids);
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
