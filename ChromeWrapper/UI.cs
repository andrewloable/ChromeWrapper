using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ChromeWrapper
{
    public class UI
    {
        public static void New(string url, int width, int height, bool waitForExit = false, List<string> customArgs = null)
        {
            if (string.IsNullOrWhiteSpace(url))
                url = "data:text/html,<html></html>";

            List<string> args = Chrome.DefaultChromeArgs();
            args.Add($"-app=\"data:text/html,<html><body><script>window.resizeTo({width},{height});window.location='{url}';</script></body></html>\"");
            if (customArgs != null)
                args.AddRange(customArgs);
            var chromeLocation = Chrome.LocateChrome();
            if (string.IsNullOrWhiteSpace(chromeLocation))
            {
                Console.WriteLine("Chrome not found. Please install it before running this app.");
                var chromeLink = "https://www.google.com/chrome/";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {chromeLink}") { CreateNoWindow = true });
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    Process.Start("open", chromeLink);
                else
                    Process.Start("xdg-open", chromeLink);
            }
            else
                Chrome.NewChromeWithArgs(chromeLocation, args, waitForExit);
        }
    }
}
