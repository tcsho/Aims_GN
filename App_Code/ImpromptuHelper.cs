﻿using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for ImpromptuHelper
/// </summary>

namespace ADG.JQueryExtenders.Impromptu
{
    public static class ImpromptuHelper
    {
        public static void ShowPrompt(string message)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "text", "CallToastr('" + message + "','true', '" + 1 + "')\n", true);
            }
        }

        public static void ShowPromptGeneric(string message, int MessageType)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "text", "CallToastr('" + message + "','true', '" + MessageType + "')\n", true);
            }
        }
    }
}
