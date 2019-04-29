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
using nsBD_GEN;

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
                CargarDdlPaisBach();
                ddlPaisBach.SelectedValue = "1";// por defecto carga bolivia
                CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
                ddlEstadoBach.SelectedValue = "1";// por defecto carga la paz
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
                ddlCiudadBach.SelectedValue = "1";// por defecto carga la paz
                CargarDdlPaisNac();
                ddlPaisNac.SelectedValue = "1"; //por defecto carga bolivia
                CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
                ddlEstadoNac.SelectedValue = "1"; // por defecto carga la paz
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
                ddlCiudadNac.SelectedValue = "1"; // por defecto carga la paz
                CargarDdlNacionalidad();
                ddlNacionalidad.SelectedValue = "1";// por defecto carga boliviana
                CargarDdlColegio();
                CargarDdlViveCon();
                CargarDdlParentesco();
                CargarDdlGenero();
                CargarDdlGeneroTutor();
                CargarDdlSangre();
                CargarDdlTipoColegio();
                CargarDdlTurnoColegio();
                CargarDdlAreaColegio();
                CargarDdlParentesco();
                CargarDdlEstadoCivil();
                CargarDdlSubdeptoAcad();
                CargarDdlDiscapacidad();
                CargarDdlTipoDocTutor();
                CargarDdlTipoDoc();
                CargarDdlAnios();
                if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strMensajeExito")))
                {
                    pnMensajeOK.Visible = true;
                    lblMensajeOK.Text = axVarSes.Lee<string>("strMensajeExito");
                    axVarSes.Escribe("strMensajeExito", string.Empty);
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        public void CargarDdlAnios()
        {
            BD_ADMIS_DatosPersonales libDatos = new BD_ADMIS_DatosPersonales();
            libDatos.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlAnio.DataSource = libDatos.dtAnios();
            ddlAnio.DataTextField = "anio";
            ddlAnio.DataValueField = "anio";
            ddlAnio.DataBind();
        }
        public void CargarDdlSubdeptoAcad()
        {
            BD_GEN_SubDepartamentos libSubdepto = new BD_GEN_SubDepartamentos();
            libSubdepto.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlCarreras.DataSource = libSubdepto.dtCarrerasInscripciones();
            ddlCarreras.DataTextField = "carrera";
            ddlCarreras.DataValueField = "num_sec_subdepartamento";
            ddlCarreras.DataBind();
        }
        public void CargarDdlEstadoCivil()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "ESTADO_CIVIL";
            ddlEstadoCivil.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlEstadoCivil.DataTextField = "DESCRIPCION";
            ddlEstadoCivil.DataValueField = "VALOR";
            ddlEstadoCivil.DataBind();
        }
        public void CargarDdlDiscapacidad()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_DISCAPACIDAD";
            ddlDiscapacidad.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlDiscapacidad.DataTextField = "DESCRIPCION";
            ddlDiscapacidad.DataValueField = "VALOR";
            ddlDiscapacidad.DataBind();
        }
        public void CargarDdlTipoColegio()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_COLEGIO";
            ddlTipoColegio.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlTipoColegio.DataTextField = "DESCRIPCION";
            ddlTipoColegio.DataValueField = "VALOR";
            ddlTipoColegio.DataBind();
        }
        public void CargarDdlTurnoColegio()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TURNO_COLEGIO";
            ddlTurno.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlTurno.DataTextField = "DESCRIPCION";
            ddlTurno.DataValueField = "VALOR";
            ddlTurno.DataBind();
        }
        public void CargarDdlAreaColegio()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_LUGAR";
            ddlAreaColegio.DataSource = libDominios.DTDominiosAbr("0", axVarSes.Lee<string>("strConexion"));
            ddlAreaColegio.DataTextField = "DESCRIPCION";
            ddlAreaColegio.DataValueField = "VALOR";
            ddlAreaColegio.DataBind();
        }
        public void CargarDdlColegio()
        {
            BD_Colegios libColegio = new BD_Colegios();
            libColegio.StrConexion = axVarSes.Lee<string>("strConexion");
            libColegio.NumSecLocalidad = Convert.ToInt64(ddlCiudadBach.SelectedValue);
            ddlColegio.DataSource = libColegio.dtColegiosLocalidad();
            ddlColegio.DataTextField = "colegio";
            ddlColegio.DataValueField = "NUM_SEC_COLEGIO";
            ddlColegio.DataBind();
        }

        public void CargarDdlSangre()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_SANGRE";
            ddlGrupoSangre.DataSource = libDominios.DTDominiosAbr( "", axVarSes.Lee<string>("strConexion"));
            ddlGrupoSangre.DataTextField = "DESCRIPCION";
            ddlGrupoSangre.DataValueField = "VALOR";
            ddlGrupoSangre.DataBind();
        }
        public void CargarDdlGenero()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "SEXO";
            ddlGenero.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlGenero.DataTextField = "DESCRIPCION";
            ddlGenero.DataValueField = "VALOR";
            ddlGenero.DataBind();
        }
        public void CargarDdlGeneroTutor()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "SEXO";
            ddlGeneroTutor.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlGeneroTutor.DataTextField = "DESCRIPCION";
            ddlGeneroTutor.DataValueField = "VALOR";
            ddlGeneroTutor.DataBind();
        }
        public void CargarDdlPaisNac()
        {
            BD_Paises libPaises = new BD_Paises();
            libPaises.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlPaisNac.DataSource = libPaises.ListaPaises();
            ddlPaisNac.DataTextField = "nombre";
            ddlPaisNac.DataValueField = "num_sec";
            ddlPaisNac.DataBind();
        }
        public void CargarDdlEstadosNac(string pais)
        {
            if (ddlPaisNac.SelectedValue != string.Empty)
            {
                BD_Estados libEstados = new BD_Estados();
                libEstados.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlEstadoNac.DataSource = libEstados.ListaEstados(pais);
                ddlEstadoNac.DataTextField = "nombre";
                ddlEstadoNac.DataValueField = "num_sec";
                ddlEstadoNac.DataBind();
            }
            else
            {
                ddlEstadoNac.Items.Clear();
            }
        }
        public void CargarDdlLocalidadesNac(string estado)
        {
            if (ddlEstadoNac.SelectedValue != string.Empty)
            {
                BD_Localidades libLocalidades = new BD_Localidades();
                libLocalidades.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlCiudadNac.DataSource = libLocalidades.ListaLocalidades(estado);
                ddlCiudadNac.DataTextField = "nombre";
                ddlCiudadNac.DataValueField = "num_sec";
                ddlCiudadNac.DataBind();
            }
            else
            {
                ddlCiudadNac.Items.Clear();
            }
        }
        public void CargarDdlNacionalidad()
        {
            BD_Paises libPaises = new BD_Paises();
            libPaises.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlNacionalidad.DataSource = libPaises.ListaPaises();
            ddlNacionalidad.DataTextField = "nacionalidad";
            ddlNacionalidad.DataValueField = "num_sec";
            ddlNacionalidad.DataBind();
        }
        public void CargarDdlPaisBach()
        {
            BD_Paises libPaises = new BD_Paises();
            libPaises.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlPaisBach.DataSource = libPaises.ListaPaises();
            ddlPaisBach.DataTextField = "nombre";
            ddlPaisBach.DataValueField = "num_sec";
            ddlPaisBach.DataBind();
        }
        public void CargarDdlEstadosBach(string pais)
        {
            if (ddlPaisBach.SelectedValue != string.Empty)
            {
                BD_Estados libEstados = new BD_Estados();
                libEstados.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlEstadoBach.DataSource = libEstados.ListaEstados(pais);
                ddlEstadoBach.DataTextField = "nombre";
                ddlEstadoBach.DataValueField = "num_sec";
                ddlEstadoBach.DataBind();
            }
            else
            {
                ddlEstadoBach.Items.Clear();
            }
        }
        public void CargarDdlLocalidadesBach(string estado)
        {
            if (ddlEstadoBach.SelectedValue != string.Empty)
            {
                BD_Localidades libLocalidades = new BD_Localidades();
                libLocalidades.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlCiudadBach.DataSource = libLocalidades.ListaLocalidades(estado);
                ddlCiudadBach.DataTextField = "nombre";
                ddlCiudadBach.DataValueField = "num_sec";
                ddlCiudadBach.DataBind();
            }
            else
            {
                ddlCiudadBach.Items.Clear();
            }
        }
        public void CargarDdlParentesco()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_FAMILIAR";
            ddlParentesco.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlParentesco.DataTextField = "DESCRIPCION";
            ddlParentesco.DataValueField = "VALOR";
            ddlParentesco.DataBind();
        }
        public void CargarDdlViveCon()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "VIVE_CON";
            ddlViveCon.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlViveCon.DataTextField = "DESCRIPCION";
            ddlViveCon.DataValueField = "VALOR";
            ddlViveCon.DataBind();
        }
        public void CargarDdlTipoDoc()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_DOC";
            ddlTipoDocIdentidad.DataSource = libDominios.DTDominiosAbr("2", axVarSes.Lee<string>("strConexion"));
            ddlTipoDocIdentidad.DataTextField = "DESCRIPCION";
            ddlTipoDocIdentidad.DataValueField = "VALOR";
            ddlTipoDocIdentidad.DataBind();
        }
        public void CargarDdlTipoDocTutor()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_DOC";
            ddlTipoDocIdentidadTutor.DataSource = libDominios.DTDominiosAbr("2", axVarSes.Lee<string>("strConexion"));
            ddlTipoDocIdentidadTutor.DataTextField = "DESCRIPCION";
            ddlTipoDocIdentidadTutor.DataValueField = "VALOR";
            ddlTipoDocIdentidadTutor.DataBind();
        }
        public void CargarDdlColegios()
        {
            if (ddlCiudadBach.SelectedValue != string.Empty)
            {
                BD_Colegios libColegios = new BD_Colegios();
                libColegios.StrConexion = axVarSes.Lee<string>("strConexion");
                libColegios.NumSecLocalidad = Convert.ToInt64(ddlCiudadBach.SelectedValue);
                ddlColegio.DataSource = libColegios.dtColegiosLocalidad();
                ddlColegio.DataTextField = "DESCRIPCION";
                ddlColegio.DataValueField = "VALOR";
                ddlColegio.DataBind();
            }
            else
            {
                ddlColegio.Items.Clear();
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
        protected void ddlPaisNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaisNac.SelectedValue != string.Empty)
            {
                CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
            }
            else
            {
                ddlEstadoNac.Items.Clear();
            }
        }

        protected void ddlEstadoNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstadoNac.SelectedValue != string.Empty)
            {
                CargarDdlLocalidadesNac(ddlPaisNac.SelectedValue);
            }
            else
            {
                ddlCiudadNac.Items.Clear();
            }
        }

        protected void ddlCiudadNac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPaisBach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaisBach.SelectedValue != string.Empty)
            {
                CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
            }
            else
            {
                ddlEstadoBach.Items.Clear();
            }
        }

        protected void ddlEstadoBach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstadoBach.SelectedValue != string.Empty)
            {
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
            }
            else
            {
                ddlCiudadBach.Items.Clear();
            }
        }

        protected void ddlCiudadBach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            BD_ADMIS_DatosPersonales libDatosPer = new BD_ADMIS_DatosPersonales();
            libDatosPer.StrConexion = axVarSes.Lee<string>("strConexion");
            if (axVarSes.Lee<string>("strOperacion").Equals("0"))
            {
                libDatosPer.GenerarNS();
            }
            else
            {
                libDatosPer.NumSecDatosPer = Convert.ToInt64(axVarSes.Lee<string>("strPersonaRegistrar"));
            }
            libDatosPer.PrimerApellido = tbPrimerApellido.Text;
            libDatosPer.SegundoApellido = tbSegundoApellido.Text;
            libDatosPer.Nombres = tbNombres.Text;
            libDatosPer.DocIdentidad = tbDocIdentidad.Text;
            libDatosPer.TipoDocIdentidad = Convert.ToInt16(ddlTipoDocIdentidad.SelectedValue);
            libDatosPer.Genero = Convert.ToInt16(ddlGenero.SelectedValue);
            libDatosPer.GrupoSangre = Convert.ToInt16(ddlGrupoSangre.SelectedValue);
            libDatosPer.EstadoCivil = Convert.ToInt16(ddlEstadoCivil.SelectedValue);
            libDatosPer.TipoDiscapacidad = Convert.ToInt16(ddlDiscapacidad.SelectedValue);
            libDatosPer.AvenidaCalle = tbCalleAvenida.Text;
            libDatosPer.Numero = tbNumeroDom.Text;
            libDatosPer.Zona = tbZona.Text;
            libDatosPer.Edificio = tbNombreEdificio.Text;
            libDatosPer.Piso = tbPiso.Text;
            libDatosPer.Depto = tbNumeroDepto.Text;
            libDatosPer.Telefono = Convert.ToInt32(tbTelefonoDomicilio.Text);
            libDatosPer.Celular = tbCelular.Text;
            libDatosPer.Email = tbEmail.Text;
            libDatosPer.ViveCon = Convert.ToInt16(ddlViveCon.SelectedValue);
            libDatosPer.FechaNacimiento = Convert.ToDateTime(tbFechaNac.Text.Trim()).ToString("dd/MM/yyyy");
            libDatosPer.NumSecNacionalidad = Convert.ToInt64(ddlNacionalidad.SelectedValue);
            libDatosPer.NumSecLocalidadNac = Convert.ToInt64(ddlCiudadNac.SelectedValue);
            libDatosPer.NumSecLocalidadBachillerato = Convert.ToInt64(ddlCiudadBach.SelectedValue);
            libDatosPer.NumSecColegio = Convert.ToInt64(ddlColegio.SelectedValue);
            libDatosPer.AnioBachillerato = Convert.ToInt32(ddlAnio.SelectedValue);
            libDatosPer.TipoColegio = Convert.ToInt16(ddlTipoColegio.SelectedValue);
            libDatosPer.AreaColegio = Convert.ToInt16(ddlAreaColegio.SelectedValue);
            libDatosPer.Turno = Convert.ToInt16(ddlTurno.SelectedValue);
            libDatosPer.Estado = 1;
            libDatosPer.NumSecSubdepartamento = Convert.ToInt64(ddlCarreras.SelectedValue);
            libDatosPer.NumSecSemestre = 0;
            libDatosPer.NumSecPersona = 0;
            libDatosPer.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");

            BD_ADMIS_DatosTutor libtutor = new BD_ADMIS_DatosTutor();
            libtutor.StrConexion = axVarSes.Lee<string>("strConexion");
            libtutor.NumSecDatosPer = libDatosPer.NumSecDatosPer;
            libtutor.PrimerApellido = tbPrimerApTutor.Text;
            libtutor.SegundoApellido = tbSegundoApTutor.Text;
            libtutor.Nombres = tbNombreTutor.Text;
            libtutor.DocIdentidad = tbDocIdentidadTutor.Text;
            libtutor.TipoDocIdentidad = Convert.ToInt16(ddlTipoDocIdentidadTutor.SelectedValue);
            libtutor.Genero = Convert.ToInt16(ddlGeneroTutor.SelectedValue);
            libtutor.AvenidaCalle = tbCalleAvenidaTutor.Text;
            libtutor.Numero = tbNumeroDomTutor.Text;
            libtutor.Zona = tbZonaTutor.Text;
            libtutor.Telefono = Convert.ToInt32(tbTelefonoTutor.Text);
            libtutor.Celular = tbCelularTutor.Text;
            libtutor.Email = tbEmailTutor.Text;
            libtutor.InstitucionTrabajo = tbInstitucionLaboralTutor.Text;
            libtutor.Cargo = tbCargoTutor.Text;
            libtutor.TelefonoTrabajo = tbTelefonoOficina.Text;
            if (rbSi.Checked)
            {
                libtutor.AutSeguimiento = 1;
            }
            if (rbNo.Checked)
            {
                libtutor.AutSeguimiento = 0;
            }
            libtutor.NumSecPersona = 0;
            libtutor.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");

            BD_ADMIS_ContactoEmergencia libContacto = new BD_ADMIS_ContactoEmergencia();
            libContacto.StrConexion = axVarSes.Lee<string>("strConexion");
            libContacto.NumSecDatosPer = libDatosPer.NumSecDatosPer;
            libContacto.NombreCompleto = tbNombreCompleto.Text;
            libContacto.TelefonoContacto1 = tbTelefonoContacto1.Text;
            libContacto.TelefonoContacto2 = tbTelefonoContacto2.Text;
            libContacto.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");
            string[] sqls = new string[10];
            int numsqls = 0;
            if (axVarSes.Lee<string>("strRol").Equals("1"))
            {
                if (axVarSes.Lee<string>("strOperacion").Equals("0"))
                {
                    sqls[0] = libDatosPer.CadsqlInsert();
                    numsqls++;
                    sqls[1] = libtutor.cadSqlInsertar();
                    numsqls++;
                    sqls[2] = libContacto.cadSqlInsertar();
                    numsqls++;
                }
                else
                {
                    if (axVarSes.Lee<string>("strOperacion").Equals("1"))
                    {
                        sqls[0] = libDatosPer.CadsqlActualizar();
                        numsqls++;
                        sqls[1] = libtutor.cadSqlActualizar();
                        numsqls++;
                        sqls[2] = libContacto.cadSqlActualizar();
                        numsqls++;
                    }
                }
            }
            else
            {
                if (axVarSes.Lee<string>("strOperacion").Equals("0"))
                {
                    sqls[0] = libDatosPer.CadsqlInsert();
                    numsqls++;
                    sqls[1] = libtutor.cadSqlInsertar();
                    numsqls++;
                    sqls[2] = libContacto.cadSqlInsertar();
                    numsqls++;
                }
            }
            if(libDatosPer.InsertarVarios(sqls, numsqls))
            {
                axVarSes.Escribe("strMensajeExito", "Registro exitoso.");
                Response.Redirect("ADMIS_FormRegistro.aspx");
            }
            else
            {
                pnMensajeError.Visible = true;
                pnMensajeOK.Visible = false;
                lblMensajeError.Text = "No se pudo almacenar el formulario. " + libDatosPer.Mensaje;
            }
        }
        #endregion

        protected void rbContactoEmerTutorSi_CheckedChanged(object sender, EventArgs e)
        {
            tbNombreCompleto.Text= tbNombreTutor.Text.Trim() + " " + tbPrimerApTutor.Text.Trim() + " " + tbSegundoApTutor.Text.Trim();
            tbTelefonoContacto1.Text = tbTelefonoTutor.Text;
            tbTelefonoContacto2.Text = tbCelularTutor.Text;
        }

        protected void rbContactoEmerTutorNo_CheckedChanged(object sender, EventArgs e)
        {
            tbNombreCompleto.Text = string.Empty;
            tbTelefonoContacto1.Text = string.Empty;
            tbTelefonoContacto2.Text = string.Empty;
        }
    }
}