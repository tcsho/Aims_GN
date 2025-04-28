using System.Web;
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



        public static void ShowError(string message)
        {
            ShowPromptWithColor(message, 1); // Error type is 1
        }

        public static void ShowSuccess(string message)
        {
            ShowPromptWithColor(message, 2); // Success type is 2
        }

        public static void ShowWarning(string message)
        {
            ShowPromptWithColor(message, 3); // Warning type is 3
        }

        public static void ShowInfo(string message)
        {
            ShowPromptWithColor(message, 4); // Info type is 4
        }

        private static void ShowPromptWithColor(string message, int messageType)
        {
            var toastrType = GetToastrType(messageType);
            ShowPromptGeneric(message, messageType);
        }

        private static string GetToastrType(int messageType)
        {
            switch (messageType)
            {
                case 1:
                    return "error";
                case 2:
                    return "success";
                case 3:
                    return "warning";
                case 4:
                    return "info";
                default:
                    return "info";
            }
        }

        public static void ShowPromptGeneric(string message, int messageType)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "text", "CallToastrnew('" + message + "','true', '" + messageType + "')\n", true);
            }
        }
    }


}
