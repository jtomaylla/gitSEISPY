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

namespace WSProyectos.Paciente
{
    public partial class WFGenerarVisitas : System.Web.UI.Page
    {
        CBVisitas objCBVisitas = new CBVisitas();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtDatosPaciente = new DataTable();
        DataTable dtCargarLocal = new DataTable();
        DataTable dtCargarProyecto = new DataTable();
        DataTable dtCargarVisita = new DataTable();
        DataTable dtAuto = new DataTable();

        string strCod;
        string strDes;
        string vIdPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                vIdPaciente = Request.QueryString["CodigoPaciente"].ToString();
                Session["CodigoPaciente"] = vIdPaciente;
                lblIdP.Text = vIdPaciente;
                txtFecha.Text = DateTime.Today.ToShortDateString();
                txtHora.Text = DateTime.Now.ToString("HH:mm");
                Cabecera(vIdPaciente);
                Listar_Locales();
            }
        }

        private void Listar_Datos()
        {
            lblMensaje.Text = "";

            dtDatos = objCBPaciente.GetMostrarDatosLocalProy(Session["CodigoPaciente"].ToString(), int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue));

            if (dtDatos.Rows.Count > 0)
            {
                Session["GenerarAuto"] = dtDatos.Rows[0]["GenerarAuto"].ToString();

                if (dtDatos.Rows[0]["GenerarAuto"].ToString() == "True")
                {
                    ddlGrupo.Visible = false;
                    ddlVisita.Visible = false;
                    lblVisita.Visible = false;
                    btnCrear.Visible = false;
                    btnGenerar.Visible = true;
                }
                else
                {
                    ddlGrupo.Visible = true;
                    ddlVisita.Visible = true;
                    lblVisita.Visible = true;
                    btnCrear.Visible = true;
                    btnGenerar.Visible = false;

                    ddlGrupo.DataSource = dtDatos;
                    ddlGrupo.DataValueField = dtDatos.Columns["CodigoGrupoVisita"].ToString();
                    ddlGrupo.DataTextField = dtDatos.Columns["NombreGrupoVisita"].ToString();
                    ddlGrupo.DataBind();

                    ddlVisita.DataSource = dtDatos;
                    ddlVisita.DataValueField = dtDatos.Columns["CodigoVisita"].ToString();
                    ddlVisita.DataTextField = dtDatos.Columns["DescripcionVisita"].ToString();
                    ddlVisita.DataBind();

                }
            }
            else
            {
                btnCrear.Visible = false;
                btnGenerar.Visible = false;

                ddlGrupo.Items.Clear();
                ddlGrupo.Items.Add(new ListItem("Grupos no registrados", "0"));

                ddlVisita.Items.Clear();
                ddlVisita.Items.Add(new ListItem("Visitas no registradas", "0"));
            }
        }

        private void Listar_Locales()
        {
            dtCargarLocal = objCBLocal.ListarLocales();
            ddlLocal.Items.Clear();
            ddlLocal.Items.Add(new ListItem("Seleccionar Local", "0"));

            if (dtCargarLocal.Rows.Count > 0)
            {
                for (int i = 0; i < dtCargarLocal.Rows.Count; i++)
                {
                    strCod = dtCargarLocal.Rows[i][0].ToString();
                    strDes = dtCargarLocal.Rows[i][1].ToString();
                    ddlLocal.Items.Add(new ListItem(strDes, strCod));
                }
                if (ddlLocal.Items.Count > -1)
                {
                    Listar_Proyectos();
                }
            }
            else
            {
                ddlLocal.Items.Clear();
                ddlLocal.Items.Add(new ListItem("Locales no registrados", "0"));
                btnCrear.Visible = false;
                btnGenerar.Visible = false;

            }
        }

        private void Listar_Proyectos()
        {
            dtCargarProyecto = objCBLocal.ListarProyectoxLocal(int.Parse(ddlLocal.SelectedValue));
            ddlProyecto.Items.Clear();
            ddlProyecto.Items.Add(new ListItem("Seleccionar Proyecto", "0"));

            if (dtCargarProyecto.Rows.Count > 0)
            {
                for (int i = 0; i < dtCargarProyecto.Rows.Count; i++)
                {
                    strCod = dtCargarProyecto.Rows[i][0].ToString();
                    strDes = dtCargarProyecto.Rows[i][1].ToString();
                    ddlProyecto.Items.Add(new ListItem(strDes, strCod));
                }
                if (ddlProyecto.Items.Count > -1)
                {
                    Listar_Datos();
                }
            }
            else
            {
                btnCrear.Visible = false;
                btnGenerar.Visible = false;

                ddlProyecto.Items.Clear();
                ddlProyecto.Items.Add(new ListItem("No hay Proyectos asignados a este local", "0"));

                ddlGrupo.Items.Clear();
                ddlGrupo.Items.Add(new ListItem("Grupos no registrados", "0"));

                ddlVisita.Items.Clear();
                ddlVisita.Items.Add(new ListItem("Visitas no registradas", "0"));
            }
        }

        private void Cabecera(string vIdPaciente)
        {
            dtDatosPaciente = objCBPaciente.DatosPacientexId(vIdPaciente);

            if (dtDatosPaciente.Rows.Count > 0)
            {
                txtPaciente.Text = dtDatosPaciente.Rows[0]["NombreCompleto"].ToString();
            }
        }

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocal.Items.Count > -1)
            {
                Listar_Proyectos();
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
                Listar_Datos();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;

                Num_Rpta = objCBVisitas.InsertarVisitas(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), int.Parse(ddlGrupo.SelectedValue), int.Parse(ddlVisita.SelectedValue), Session["CodigoPaciente"].ToString(), txtFecha.Text, txtHora.Text, int.Parse(Session["CodigoUsuario"].ToString()));

                if (Num_Rpta == -1 || Num_Rpta == 0)
                {
                    lblMensaje.Text = "Ocurrió un error al registrar";
                }
                else
                {
                    Response.Redirect("~/Paciente/WFListadoVisitas.aspx?CodigoPaciente=" + lblIdP.Text, false);
                    lblMensaje.Text = "Se registró correctamente";
                }
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            dtAuto = objCBVisitas.InsertarVisitasAuto(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), Session["CodigoPaciente"].ToString(), int.Parse(Session["CodigoUsuario"].ToString()));

            if (dtAuto.Rows.Count > 0)
            {
                lblMensaje.Text = dtAuto.Rows[0]["Mensaje"].ToString();

                if (dtAuto.Rows[0]["Respuesta"].ToString() == "1")
                {
                    Response.Redirect("~/Paciente/WFListadoVisitas.aspx?CodigoPaciente=" + lblIdP.Text, false);
                    lblMensaje.Text = "Se registró correctamente";
                }
            }
        }


    }
}