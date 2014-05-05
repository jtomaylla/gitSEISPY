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

namespace WSProyectos.Data
{
    public partial class WFListadoVisitasD : System.Web.UI.Page
    {
        CBVisitas objCBVisitas = new CBVisitas();
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtListaS = new DataTable();
        DataTable dtCargar = new DataTable();
        protected string vIdPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                vIdPaciente = Request.QueryString["CodigoPaciente"].ToString();
                lblIdP.Text = vIdPaciente;

                Cabecera(vIdPaciente);
                ListadoVisitas();
            }
        }

        private void ListadoVisitas()
        {
            dtListaS = objCBVisitas.ListarVisitasxPaciente(vIdPaciente);

            if (dtListaS.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtListaS;
                gvListado.DataBind();
                gvListado.SelectedIndex = -1;
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se encontró registros...";
                gvListado.Visible = false;
            }
        }

        private void Cabecera(string vIdPaciente)
        {
            dtCargar = objCBPaciente.DatosPacientexId(vIdPaciente);

            if (dtCargar.Rows.Count > 0)
            {
                txtPaciente.Text = dtCargar.Rows[0]["NombreCompleto"].ToString();
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            ListadoVisitas();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Data/WFBusquedaVisitasD.aspx", false);
        }

    }
}