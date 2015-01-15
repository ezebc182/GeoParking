using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Web2;

namespace Web2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Código que se ejecuta al cerrarse la aplicación

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando se produce un error sin procesar

        }
    }
}
