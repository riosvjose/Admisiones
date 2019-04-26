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
    public partial class ADMIS_BuscarPersona : System.Web.UI.Page
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
                /*libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_ALM_AdministrarAlmacenes"))
                {
                    lisubdeptos = new BD_GEN_Subdeptos();
                    lisubdeptos.StrConexion = axVarSes.Lee<string>("strConexion");
                    ddlSubdeptos.DataSource = lisubdeptos.DTVerSubdeptos();
                    ddlSubdeptos.DataTextField = "NOMBRE";
                    ddlSubdeptos.DataValueField = "NUM_SEC_subdepartamento";
                    ddlSubdeptos.DataBind();
                    if (!string.IsNullOrEmpty(ddlSubdeptos.SelectedValue))
                    {
                        llenartabla();
                    }
                }
                else
                {
                    axVarSes.Escribe("MostrarMensajeError", "1");
                    Response.Redirect("Index.aspx");
                }*/
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void llenartabla()
        {
            
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
            }            
        }
        protected void ddlSubdeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            llenartabla();
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            //pnbuscar.Visible = true;
        }


        /*protected void btnAdmUsu_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if ((ddlAlmacenes.Items.Count != 0)&&(ddlPlantilla.Items.Count != 0))
            {
                pnAdmUsuarios.Visible = true;
                pnPrincipal.Visible = true;
                libPasosUsu.StrConexion = axVarSes.Lee<string>("strConexion");
                libPasosUsu.NumSecPaso = Convert.ToInt64(ddlPasos.SelectedValue);
                gvDatos1.Visible = true;
                gvDatos1.Columns[0].Visible = true;
                gvDatos1.Columns[2].Visible = true;
                gvDatos1.Columns[4].Visible = true;
                gvDatos1.DataSource = libPasosUsu.VerUsuariosPaso();
                gvDatos1.DataBind();
                gvDatos1.Columns[0].Visible = false;
                gvDatos1.Columns[2].Visible = false;
                gvDatos1.Columns[4].Visible = false;
                pnDeptos.Visible = true;
                libsubdeptos = new BD_GEN_Subdeptos();
                libsubdeptos.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlDeptos.DataSource = libsubdeptos.DTVerSubdeptos();
                ddlDeptos.DataTextField = "NOMBRE";
                ddlDeptos.DataValueField = "NUM_SEC_subdepartamento";
                ddlDeptos.DataBind();
            }
            else
            {
                pnMensajeError.Visible = true;
                lblMensajeError.Text = "No existe ningún almacen creado o falta seleccionar un paso. ";
            }
        }*/

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            /*pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnsugeridos.Visible = true;
            libusu.StrConexion = axVarSes.Lee<string>("strConexion");
            gvUsuarios.Visible = true;
            gvUsuarios.Columns[0].Visible = true;
            gvUsuarios.DataSource = libusu.ObtenerUsuariosSugeridos(tbusuario.Text.ToUpper());
            gvUsuarios.DataBind();
            gvUsuarios.Columns[0].Visible = false;*/
        }


        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnCancelarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ALM_AdministrarPasos.aspx");
        }
        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           /* int indice = Convert.ToInt32(e.CommandArgument);
            bool blOpCorrecta = false;
            
            libSubdeptoPer.NumSecSubdepto = Convert.ToInt64(ddlSubdeptos.SelectedValue);
            libSubdeptoPer.StrConexion = axVarSes.Lee<string>("strConexion");
            if (e.CommandName == "agregar")
            {
                libSubdeptoPer.NumSecPersona = Convert.ToInt64(gvUsuarios.Rows[indice].Cells[3].Text);
                libSubdeptoPer.NumSecPersonaAutoriza = Convert.ToInt64(gvUsuarios.Rows[indice].Cells[3].Text);
                if (!libSubdeptoPer.Insertar())
                {
                       
                        pnMensajeError.Visible = true;
                        lblMensajeError.Text = "No se pudo agregar la persona. " + Convert.ToInt64(gvUsuarios.Rows[indice].Cells[2].Text) + ". " + libSubdeptoPer.Mensaje;
                        pnMensajeOK.Visible = false;
                }
                else
                {
                    blOpCorrecta = true;
                }
            }
            if (e.CommandName == "eliminar")
            {
                libSubdeptoPer.NumSecPersona = Convert.ToInt64(gvDatos1.Rows[indice].Cells[3].Text);
                libSubdeptoPer.NumSecPersonaAutoriza = Convert.ToInt64(gvDatos1.Rows[indice].Cells[3].Text);
                if (!libSubdeptoPer.Borrar())
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "No se pudo eliminar la persona. " + Convert.ToInt64(gvDatos1.Rows[indice].Cells[2].Text) + ". " + libSubdeptoPer.Mensaje; 
                    pnMensajeOK.Visible = false;
                }
                else
                {
                    blOpCorrecta = true;
                }
            }
            if (blOpCorrecta)
            {
                pnMensajeError.Visible = false;
            }
            else
            {
                pnVacio.Focus();
            }
            if (!string.IsNullOrEmpty(ddlSubdeptos.SelectedValue))
            {
                llenartabla();
            }*/

        } 

        #endregion

    }
}