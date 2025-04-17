<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Http" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Net.Http.Formatting" %>
<%@ Import Namespace="Newtonsoft.Json" %>
<%@ Import Namespace="Newtonsoft.Json.Serialization" %>


<script RunAt="server">
    //public void RegisterGlobalFilters(GlobalFilterCollection filters)
    //{
    //    filters.Add(new HandleErrorAttribute());
    //}

    //public static void RegisterRoutes (RouteCollection routes)
    //{
    //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //    routes.MapRoute("Home", "home/{action}/id",
    //        new { Controller = "Home", action = "Index", id = UrlParameter.Optional }
    //        );
    //}
    void Application_Start(object sender, EventArgs e)
    {
        log4net.Config.XmlConfigurator.Configure();
        // set the route for the api
        RouteTable.Routes.MapHttpRoute(
            "DefaultApi",
            "api/{controller}/{action}/{id}",
            new { id = System.Web.Http.RouteParameter.Optional }
        );
        // set the configuration


        GlobalConfiguration.Configuration.Formatters.Clear();
        GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            }
        });

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
