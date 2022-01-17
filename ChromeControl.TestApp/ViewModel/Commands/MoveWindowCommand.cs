namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class MoveWindowCommand : CommandBase
    {
        public override string CommandDescription
        {
            get => "Move window to a specified position";
        }

        public override string CommandName
        {
            get => "Move Window";
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
        
        private int _xPos;
        public int XPos
        {
            get => _xPos;
            set
            {
                if (Equals(_xPos, value))
                {
                    return;
                }

                _xPos = value;

                NotifyPropertyChanged();
            }
        }

        private int _yPos;
        public int YPos
        {
            get => _yPos;
            set
            {
                if (Equals(_yPos, value))
                {
                    return;
                }

                _yPos = value;

                NotifyPropertyChanged();
            }
        }
        
        public override void Execute()
        {
            if (ChromeCommands.MoveWindow(WindowId, XPos, YPos))
            {
                OutputText = $"Window Moved to {XPos} {YPos}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
