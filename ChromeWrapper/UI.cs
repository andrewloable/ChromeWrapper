using System;
using System.Collections.Generic;

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

            Chrome.NewChromeWithArgs(Chrome.LocateChrome(), args, waitForExit);
        }
    }
}
