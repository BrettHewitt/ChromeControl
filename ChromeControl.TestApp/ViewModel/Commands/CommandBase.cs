using ChromeControl.TestApp.Commands;
using ChromeControl.TestApp.Utils;

namespace ChromeControl.TestApp.ViewModel.Commands
{
    public abstract class CommandBase : ViewModelBase
    {
        private ActionCommand _executeCommand;
        public ActionCommand ExecuteCommand
        {
            get
            {
                return _executeCommand ?? (_executeCommand = new ActionCommand()
                {
                    ExecuteAction = () =>
                    {
                        if (PreExecute())
                        {
                            Execute();
                        }
                        else
                        {
                            OutputText = "Can't find instance of chrome";
                        }
                    }
                });
            }
        }

        private string _outputText;
        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;

                NotifyPropertyChanged();
            }
        }

        public abstract string CommandName { get; }

        public abstract string CommandDescription { get; }

        public virtual bool PreExecute() => Util.IsChromeRunning();

        public abstract void Execute();
    }
}
