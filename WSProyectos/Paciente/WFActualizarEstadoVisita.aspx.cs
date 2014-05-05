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
    public partial class WFActualizarEstadoVisita : System.Web.UI.Page
    {
        CBVisitas objCBVisitas = new CBVisitas();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtEstatus = new DataTable();
        string vIdPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                lblIdP.Text = Request["CodigoPaciente"].ToString();
                Session["CodigoProyecto"] = Request["CodigoProyecto"].ToString();
                Session["CodigoLocal"] = Request["CodigoLocal"].ToString();
                Session["CodigoVisitas"] = Request["CodigoVisitas"].ToString();
                Session["CodigoVisita"] = Request["CodigoVisita"].ToString();

                //numUsuario = Session["CodigoUsuario"].ToString();
                Listar_Parametros();
            }
        }

        private void Listar_Parametros()
        {
            dtListaPar = objCBPaciente.MostrarParametrosxId(5);

            if (dtListaPar.Rows.Count > 0)
            {
                ddlEstadoVisita.DataSource = dtListaPar;
                ddlEstadoVisita.DataValueField = dtListaPar.Columns[0].ToString();
                ddlEstadoVisita.DataTextField = dtListaPar.Columns[1].ToString();
                ddlEstadoVisita.DataBind();

                Listar_Estatus();
            }
        }

        private void Listar_Estatus()
        {
            dtEstatus = objCBPaciente.EstatusPacientexId(int.Parse(ddlEstadoVisita.SelectedValue));

            if (dtEstatus.Rows.Count > 0)
            {
                ddlEstadoPaciente.DataSource = dtEstatus;
                ddlEstadoPaciente.DataValueField = dtEstatus.Columns[0].ToString();
                ddlEstadoPaciente.DataTextField = dtEstatus.Columns[1].ToString();
                ddlEstadoPaciente.DataBind();
            }
        }
        protected void ddlEstadoVisita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstadoVisita.Items.Count > -1)
            {
                Listar_Estatus();
            }
       }

        protected void lkbAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;

                Num_Rpta = objCBVisitas.ActualizarEstadoV(int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), int.Parse(Session["CodigoVisita"].ToString()), int.Parse(Session["CodigoVisitas"].ToString()), lblIdP.Text, int.Parse(ddlEstadoVisita.SelectedValue), int.Parse(ddlEstadoPaciente.SelectedValue), int.Parse(Session["CodigoUsuario"].ToString()));

                if (Num_Rpta == -1 || Num_Rpta == 0)
                {
                    lblMensaje.Text = "Ocurrió un error al registrar";
                }
                else
                {
                    //lblMensaje.Text = "Se registró correctamente";
                    String str = "<script>opener.location.href=opener.location.href; window.close();</script>";
                    ClientScript.RegisterClientScriptBlock(GetType(), "test", str);

                }
            }
        }

    }
}