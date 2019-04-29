using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;

namespace Admisiones.Forms
{
    public partial class Salir : System.Web.UI.Page
    {

        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["strRol"] = "0"; // 1 administrativo, 0 externo
            Session["strOperacion"] = "0"; // 0 registrar, 1 consolidar
            Session["strPersonaRegistrar"] = "0"; // num_sec_dator_personale tabla admins datos personales
            Response.Write(@"<script language='javascript'>window.close();</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}