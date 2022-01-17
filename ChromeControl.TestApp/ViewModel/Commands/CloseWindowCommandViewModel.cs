namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class CloseWindowCommandViewModel : CommandBase
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
            get => "Close the specified Window";
        }

        public override string CommandName
        {
            get => "Close Window";
        }

        public override void Execute()
        {
            if (ChromeCommands.CloseWindow(WindowId))
            {
                OutputText = $"Window {WindowId} Closed";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
