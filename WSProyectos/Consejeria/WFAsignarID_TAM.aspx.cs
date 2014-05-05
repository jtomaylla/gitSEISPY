using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using ClassData;
using ClassBusiness;
using System.Threading;

namespace WSProyectos.Consejeria
{
    public partial class WFAsignarID_TAM : System.Web.UI.Page
    {
        CBVisitas objCBVisitas = new CBVisitas();
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtListaS = new DataTable();
        DataTable dtMostrar = new DataTable();
        DataTable dtRegistro = new DataTable();
        string vIdPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                vIdPaciente = Request.QueryString["CodigoPaciente"].ToString();
                lblIdP.Text = vIdPaciente;
                Session["vIdPaciente"] = vIdPaciente;
                Session["CodigoProyecto"] = Request["CodigoProyecto"].ToString();
                Session["CodigoLocal"] = Request["CodigoLocal"].ToString();
                Session["vCodigoUsuario"] = Request["vCodigoUsuario"].ToString();

                Mostrar_Cabecera();
            }
        }

        private void Mostrar_Cabecera()
        {
            dtMostrar = objCBVisitas.ListarDatosxPaciente(int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), Session["vIdPaciente"].ToString());

            if (dtMostrar.Rows.Count > 0)
            {
                txtPaciente.Text = dtMostrar.Rows[0]["NombreCompleto"].ToString();
                Session["TipoTAM"] = dtMostrar.Rows[0]["TipoTAM"].ToString();
                txtIdTAM.Text = dtMostrar.Rows[0]["IdTAM"].ToString();

                if (txtIdTAM.Text == "")
                {
                    lkbAceptar.Visible = true;
                }
                else
                {
                    lkbAceptar.Visible = false;
                }
                if (int.Parse(Session["TipoTAM"].ToString()) == 2)
                {
                    txtIdTAM.ReadOnly = true;
                    lkbAceptar.Text = "Asignar automáticamente";
                }
                if (int.Parse(Session["TipoTAM"].ToString()) == 0 || int.Parse(Session["TipoTAM"].ToString()) == 1)
                {
                    txtIdTAM.ReadOnly = false;
                }
            }
        }

        protected void lkbAceptar_Click(object sender, EventArgs e)
        {
            if (Session["TipoTAM"].ToString() == "0" || Session["TipoTAM"].ToString() == "1")
            {
                if (txtIdTAM.Text == "")
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Ingresar el ID y Aceptar...";
                }
                else
                {
                    int idUser = int.Parse(Session["vCodigoUsuario"].ToString());
                    dtRegistro = objCBVisitas.RegistrarIdTAM(int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), Session["vIdPaciente"].ToString(), txtIdTAM.Text, idUser);

                    if (dtRegistro.Rows.Count > 0)
                    {
                        if (dtRegistro.Rows[0]["Respuesta"].ToString() == "3")
                        {
                            Mostrar_Cabecera();
                            lblMensaje.Visible = true;
                            lblMensaje.Text = "El ID se asignó correctamente...";
                        }
                        if (dtRegistro.Rows[0]["Respuesta"].ToString() == "1")
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Text = dtRegistro.Rows[0]["Texto"].ToString();
                            Mostrar_Cabecera();
                        }
                    }
                }
            }
            if (Session["TipoTAM"].ToString() == "2")
            {
                int idUser = int.Parse(Session["vCodigoUsuario"].ToString());
                dtRegistro = objCBVisitas.RegistrarIdTAMauto(int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), Session["vIdPaciente"].ToString(), idUser);

                if (dtRegistro.Rows.Count > 0)
                {
                    if (dtRegistro.Rows[0]["Respuesta"].ToString() == "3")
                    {
                        Mostrar_Cabecera();
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "El ID se asignó correctamente...";
                    }
                    if (dtRegistro.Rows[0]["Respuesta"].ToString() == "1")
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = dtRegistro.Rows[0]["Texto"].ToString();
                        Mostrar_Cabecera();
                    }
                }
            }
        }

    }
}