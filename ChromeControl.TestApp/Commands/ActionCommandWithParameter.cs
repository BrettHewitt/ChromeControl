using System;
using System.Windows.Input;

namespace ChromeControl.TestApp.Commands
{
    public class ActionCommandWithParameter : ICommand
    {
        private Func<bool> _canExecuteAction = () => true;

        public event EventHandler CanExecuteChanged;

        public Action<object> ExecuteAction { get; set; }

        public Func<bool> CanExecuteAction
        {
            get => _canExecuteAction;            
            set
            {
                _canExecuteAction = value;

                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        public bool CanExecute(object parameter) => CanExecuteAction();

        public void Execute(object parameter) => ExecuteAction(parameter);
        
        public void RaiseCanExecuteChangedNotification()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
