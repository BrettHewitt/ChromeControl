using ChromeControl.TestApp.Utils;
using System.Diagnostics;

namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class OpenWindowCommand : CommandBase
    {
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

        public override string CommandDescription
        {
            get => "Opens a new window with the specified URL";
        }

        public override string CommandName
        {
            get => "Open Window";
        }

        public override void Execute()
        {
            if (ChromeCommands.OpenWindow(Url, out int windowId, out int tabId))
            {
                OutputText = $"Opened {Url} in Window: {windowId} and Tab: {tabId}";
            }
            else
            {
                OutputText = "Command failed";
            }
        }

        public override bool PreExecute()
        {
            if (!Util.IsChromeRunning())
            {
                //Chrome isn't running, open process manually and return false so native code doesn't run
                Process chromeProcess = new Process();
                chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                chromeProcess.StartInfo.Arguments = Url;
                chromeProcess.Start();

                return false;
            }

            return true;
        }
    }
}
