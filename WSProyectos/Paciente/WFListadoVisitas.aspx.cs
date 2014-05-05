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
    public partial class WFListadoVisitas : System.Web.UI.Page
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paciente/WFBusquedaVisitas.aspx", false);
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            ListadoVisitas();
        }

        protected void gvListado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                HyperLink hypEstadoVisita = (HyperLink)e.Row.FindControl("hypEstadoVisita");
                string CodigoEstadoVisita = ((DataRowView)(e.Row.DataItem))["CodigoEstadoVisita"].ToString();

                if (CodigoEstadoVisita == "1")
                {
                    hypEstadoVisita.ToolTip = "Modificar estado de visita";
                    hypEstadoVisita.Attributes.Add("onClick", "window.open('WFActualizarEstadoVisita.aspx?CodigoPaciente=" + DataBinder.Eval(e.Row.DataItem, "CodigoPaciente") + "&CodigoLocal=" + DataBinder.Eval(e.Row.DataItem, "CodigoLocal") + "&CodigoProyecto=" + DataBinder.Eval(e.Row.DataItem, "CodigoProyecto") + "&CodigoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisita") + "&CodigoVisitas=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisitas") + "','PageW','width=270,height=200,scrollbars=no,center=yes,status=no,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");
                }
                else
                {
                    hypEstadoVisita.NavigateUrl = "";
                    hypEstadoVisita.ToolTip = "";
                }
            }
        }
    }
}