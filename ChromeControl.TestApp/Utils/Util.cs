using System.Diagnostics;

namespace ChromeControl.TestApp.Utils
{
    public static class Util
    {
        public static bool IsChromeRunning() => Process.GetProcessesByName("Chrome").Length > 0;
    }
}
