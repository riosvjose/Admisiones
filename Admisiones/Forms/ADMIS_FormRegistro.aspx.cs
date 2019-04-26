using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;

namespace Admisiones.Forms
{
    public partial class ADMIS_FormRegistro : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"

        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strConexion").Trim()))
                {
                    CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }            
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            
        }

        protected void ddlPaisNac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEstadoNac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCiudadNac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPaisBach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEstadoBach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCiudadBach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}