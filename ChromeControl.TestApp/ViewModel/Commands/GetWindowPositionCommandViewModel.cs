namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class GetWindowPositionCommandViewModel : CommandBase
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
            get => "Get the top and left co-ordinate of the specified window";
        }

        public override string CommandName
        {
            get => "Get Window Position";
        }

        public override void Execute()
        {
            if (ChromeCommands.GetWindowPosition(WindowId, out int left, out int top))
            {
                OutputText = $"Left: {left} - Top: {top}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
