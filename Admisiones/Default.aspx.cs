using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_Java;
using nsGEN_VarSession;
using nsGEN_WebForms;
using nsGEN_AutenticacionBD;
using System.Data;


namespace ATENEA
{
    public partial class Default : System.Web.UI.Page
    {


        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        GEN_AutenticacionBD AutenticacionBD = new GEN_AutenticacionBD();
 

        #endregion

        #region "Clase de tablas de la Base de Datos"

        #endregion

        #region "Variables Globales"

        string strConexion = string.Empty;
        string strSql = string.Empty;

        #endregion

        #region "Funciones y Procedimientos"


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
                Request.Browser.Adapters.Clear();
            if (Page.IsPostBack == false)
            {
                axVarSes.Escribe("strMensaje_Inicial_Pagina", string.Empty);
                tbUsuario.Focus();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            AutenticacionBD.Login = tbUsuario.Text.Trim();
            AutenticacionBD.Password = tbPassword.Text.Trim();
            AutenticacionBD.Servidor = axVarSes.Lee<string>("Servidor");
            AutenticacionBD.Pagina = this.Page;
            AutenticacionBD.MostrarError = false;
            AutenticacionBD.AutenticarSAM();

            axVarSes.Escribe("Servidor", axVarSes.Lee<string>("Servidor"));
            axVarSes.Escribe("StrConexion", AutenticacionBD.StrConexion);
            axVarSes.Escribe("UsuarioNumSec", AutenticacionBD.NumSec.ToString());
            axVarSes.Escribe("UsuarioLogin", AutenticacionBD.Login);
            axVarSes.Escribe("UsuarioPersonaNumSec", AutenticacionBD.Persona_NumSec.ToString());
            axVarSes.Escribe("UsuarioPersonaCI", AutenticacionBD.Persona_CI);
            axVarSes.Escribe("UsuarioPersonaNombre", AutenticacionBD.Persona_Nombre);
            

            if (AutenticacionBD.Autenticado)
            {
                lblMensaje.Visible = false;
                axVarSes.Escribe("Path", webForms.Determinar_Path_App());

                if (AutenticacionBD.CambioPwd)
                {
                    axVarSes.Escribe("UsuarioLogin", "");
                    axVarSes.Escribe("usuario_login_cambiopwd", AutenticacionBD.Login);
                    Response.Redirect("~/Forms/SACAD_CambioPassword.aspx");
                }
                else
                {
                    axVarSes.Escribe("TipoUsuario", AutenticacionBD.Persona_Nombre);
                    Response.Redirect("~/Forms/Index.aspx");
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = AutenticacionBD.Mensaje;
            }
        }
    }
}