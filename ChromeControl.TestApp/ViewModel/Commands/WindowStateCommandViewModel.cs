using System.Collections.ObjectModel;
using System.Linq;

namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class WindowStateCommandViewModel : CommandBase
    {
        public override string CommandDescription
        {
            get => "Change the Window State";
        }

        public override string CommandName
        {
            get => "Window State";
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

        private ChromeWindowStates _selectedWindowState;
        public ChromeWindowStates SelectedWindowState
        {
            get
            {
                return _selectedWindowState;
            }
            set
            {
                if (Equals(_selectedWindowState, value))
                {
                    return;
                }

                _selectedWindowState = value;

                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<ChromeWindowStates> _windowStates;
        public ObservableCollection<ChromeWindowStates> WindowStates
        {
            get
            {
                return _windowStates;
            }
            set
            {
                if (Equals(_windowStates, value))
                {
                    return;
                }

                _windowStates = value;

                NotifyPropertyChanged();
            }
        }

        public WindowStateCommandViewModel()
        {
            ObservableCollection<ChromeWindowStates> windowStates = new ObservableCollection<ChromeWindowStates>();
            windowStates.Add(ChromeWindowStates.Maximized);
            windowStates.Add(ChromeWindowStates.Minimized);
            windowStates.Add(ChromeWindowStates.Fullscreen);
            windowStates.Add(ChromeWindowStates.Normal);
            WindowStates = windowStates;
            SelectedWindowState = windowStates.First();
        }

        public override void Execute()
        {
            if (ChromeCommands.ChangeWindowState(WindowId, SelectedWindowState))
            {
                OutputText = $"Changed Window {WindowId} state to {SelectedWindowState}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
