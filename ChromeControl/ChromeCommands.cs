using Newtonsoft.Json.Linq;
using System;
using System.IO.Pipes;
using System.Security.Principal;

namespace ChromeControl
{
    public class ChromeCommands
    {
        public static bool FocusWindow(int windowId)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"focuswindow {windowId}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                return response == $"Window Id: {windowId} focused";
            }

            return false;
        }

        public static bool CloseWindow(int windowId)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"closewindow {windowId}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                return response == $"Window {windowId} removed";
            }

            return false;
        }

        public static bool CloseTab(int tabId)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"closetab {tabId}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                return response == $"Tab {tabId} removed";
            }

            return false;
        }

        public static bool OpenWindow(string url, out int windowId, out int tabId)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"openwindow {url}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var ro = JObject.Parse(responseObject["text"].ToString());

                var windowIdString = ro["windowId"];
                var tabIdString = ro["tabId"];

                windowId = int.Parse(windowIdString.ToString());
                tabId = int.Parse(tabIdString.ToString());
                return true;
            }

            windowId = -1;
            tabId = -1;
            return false;
        }

        public static bool OpenTab(int windowId, string url, out int tabId)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"opentab {windowId} {url}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();
                tabId = int.Parse(response);
                return true;
            }

            tabId = -1;
            return false;
        }

        public static bool ChangeTabUrl(int tabId, string url)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"changetaburl {tabId} {url}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                return response == "Tab URL updated";
            }

            return false;
        }

        public static bool GetWindowIds(out int[] ids)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"getwindows");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                try
                {
                    var stringIds = response.Split(',');

                    var finalIds = new int[stringIds.Length];
                    for (var i = 0; i < stringIds.Length; i++)
                    {
                        finalIds[i] = int.Parse(stringIds[i]);
                    }

                    ids = finalIds;
                    return true;
                }
                catch (Exception)
                {
                    ids = null;
                    return false;
                }
            }

            ids = null;
            return false;
        }

        public static bool GetTabIds(out int[] ids)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"gettabs");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                try
                {
                    var stringIds = response.Split(',');

                    var finalIds = new int[stringIds.Length];
                    for (var i = 0; i < stringIds.Length; i++)
                    {
                        finalIds[i] = int.Parse(stringIds[i]);
                    }

                    ids = finalIds;
                    return true;
                }
                catch (Exception)
                {
                    ids = null;
                    return false;
                }
            }

            ids = null;
            return false;
        }

        public static bool GetTabIdsInWindow(int windowId, out int[] ids)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"gettabsinwindow {windowId}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                try
                {
                    var stringIds = response.Split(',');

                    var finalIds = new int[stringIds.Length];
                    for (var i = 0; i < stringIds.Length; i++)
                    {
                        finalIds[i] = int.Parse(stringIds[i]);
                    }

                    ids = finalIds;
                    return true;
                }
                catch (Exception)
                {
                    ids = null;
                    return false;
                }
            }

            ids = null;
            return false;
        }

        public static bool GetUrl(int tabId, out string url)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"geturl {tabId}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                url = response;
                return !response.Contains("does not exist");
            }

            url = "";
            return false;
        }

        public static bool MoveWindow(int windowId, int xPos, int yPos)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"movewindow {windowId} {xPos} {yPos}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                return !response.Contains("invalid");
            }

            return false;
        }

        public static bool ChangeWindowState(int windowId, ChromeWindowStates windowState)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"changestate {windowId} {windowState.ToString().ToLower()}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                return !response.Contains("invalid");
            }

            return false;
        }

        public static bool GetWindowPosition(int windowId, out int x, out int y)
        {
            var pipeClient = new NamedPipeClientStream(".", "dataDyneChromeServerPipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

            pipeClient.Connect();

            var serverCommunication = new ServerCommunication(pipeClient);
            if (serverCommunication.ReadMessage() == "dataDyne Chrome Server")
            {
                serverCommunication.SendMessage($"getwindowpos {windowId}");

                var responseObject = serverCommunication.ReadMessageAsJObject();

                var response = responseObject["text"].ToString();

                if (response.Contains("does not exist"))
                {
                    x = -9999;
                    y = -9999;
                    return false;
                }

                var ro = JObject.Parse(response);

                var left = ro["Left"];
                var top = ro["Top"];

                x = int.Parse(left.ToString());
                y = int.Parse(top.ToString());
                return true;
            }

            x = -9999;
            y = -9999;
            return false;
        }
    }

    public enum ChromeWindowStates
    {
        Normal,
        Minimized,
        Maximized,
        Fullscreen,
    }
}