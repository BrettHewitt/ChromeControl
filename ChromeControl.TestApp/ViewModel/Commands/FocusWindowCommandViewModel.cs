namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class FocusWindowCommandViewModel : CommandBase
    {
        public override string CommandDescription
        {
            get => "Focus a chrome window with the specified ID";
        }

        public override string CommandName
        {
            get => "Focus Window";
        }


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


        public override void Execute()
        {
            if (ChromeCommands.FocusWindow(WindowId))
            {
                OutputText = $"Focused Window: {WindowId}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
