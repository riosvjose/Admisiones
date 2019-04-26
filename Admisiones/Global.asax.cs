using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Admisiones
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender, EventArgs e)
        {

            Session["UsuarioLogin"] = "";
            Session["Servidor"] = "ucbp";
            Session["bEnviarNotificaciones"] = false;
            Session["strConexion"] = "";
            Session["UsuarioPersonaNumSec"] = "";
            Session["strDeptoUsuario"] = "";
            Session["strRol"] = "0"; // 1 administrativo, 0 externo

            // ***** PARAMETROS ENVIO DE CORREOS DE TAREAS ÚNICAS
            Session["Email_IPHost"] = "";
            Session["Email_Cuenta"] = "";
            Session["Email_Usuario"] = "";
            Session["Email_Clave"] = "";
            Session["EnviarCorreo"] = "1";       // 0:no enviar;  1: enviar

        }
    }
}