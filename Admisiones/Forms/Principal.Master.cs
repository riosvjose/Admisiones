using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;

namespace ATENEA.Forms
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();

        #endregion
        #region "Procedimientos y Funciones Locales"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (axVarSes.Lee<string>("strConexion") == "" || axVarSes.Lee<string>("strConexion") == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Convert.ToInt32(axVarSes.Lee<string>("strRol")) == 1) 
                sbInicio.Visible = true;
            if (Convert.ToInt32(axVarSes.Lee<string>("strRol")) == 0)
                sbBuscarPersona.Visible = true;
            if (Convert.ToInt32(axVarSes.Lee<string>("strRol")) == 0)
                sbRegistrarPersona.Visible = true;
            if (Convert.ToInt32(axVarSes.Lee<string>("strRol")) == 0)
                sbCerrarSesion.Visible = true;
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
                if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                {
                    Request.Browser.Adapters.Clear();
                }

            }
        }
        #endregion

        #region "Procedimientos y Funciones Públicos"
        #endregion
        #region "Eventos"
        protected void lbnAtenea_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(axVarSes.Lee<string>("strRol").Trim()) % 2 == 0)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("STRS_Salir");
            }
        }
        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_Salir.aspx");
        }
        #endregion
    }
}