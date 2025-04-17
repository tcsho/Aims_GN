<%@ WebHandler Language="C#" Class="DownloadFile" %>

using System;
using System.Web;

public class DownloadFile : IHttpHandler {


    string rootFolder =System.Web.HttpContext.Current.Server.MapPath(@"\PresentationLayer\TimeTableDataExportDir\");

    public void ProcessRequest (HttpContext context) {
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

        string fileName = context.Request.QueryString["Pt"];
        string comfilepath=System.Web.HttpContext.Current.Server.MapPath(@"\PresentationLayer\TimeTableDataExportDir\" + fileName);
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/.xml";
        response.AddHeader("Content-Disposition",
                           "attachment; filename=" +fileName+ ";");
        response.TransmitFile(comfilepath);
        response.Flush();
        System.IO.File.Delete(comfilepath);
        response.End();


    }

    public bool IsReusable {
        get {
            return false;
        }
    }




}