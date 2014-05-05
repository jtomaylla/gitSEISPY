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

namespace WSProyectos.Administracion
{
    public partial class WFBusquedaVisitas : System.Web.UI.Page
    {
        CBLocal objCBLocal = new CBLocal();
        CBVisitas objCBVisitas = new CBVisitas();
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtLista = new DataTable();
        DataTable dtListaS = new DataTable();
        DataTable dtListaA = new DataTable();
        DataTable dtCargarLocal = new DataTable();
        DataTable dtCargarProyecto = new DataTable();
        protected string numUsuario;
        string strCod;
        string strDes;
        string LinkPag;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                numUsuario = Session["CodigoUsuario"].ToString();
                txtFechaD.Text = DateTime.Today.ToShortDateString();
                txtFechaH.Text = DateTime.Today.ToShortDateString();
                Session["Opc"] = 1;
                Listar_Parametros();
                Listar_Locales();
            }
        }

        private void Listar_Parametros()
        {
            dtListaPar = objCBPaciente.MostrarParametrosxId(5);
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("-----Todos-----", "0"));

            if (dtListaPar.Rows.Count > 0)
            {
                for (int i = 0; i < dtListaPar.Rows.Count; i++)
                {
                    strCod = dtListaPar.Rows[i][0].ToString();
                    strDes = dtListaPar.Rows[i][1].ToString();
                    ddlEstado.Items.Add(new ListItem(strDes, strCod));
                }
            }
        }

        private void Listar_Locales()
        {
            dtCargarLocal = objCBLocal.ListarLocalesxUser(int.Parse(Session["CodigoUsuario"].ToString()));

            if (dtCargarLocal.Rows.Count > 0)
            {
                ddlLocal.DataSource = dtCargarLocal;
                ddlLocal.DataValueField = dtCargarLocal.Columns[0].ToString();
                ddlLocal.DataTextField = dtCargarLocal.Columns[1].ToString();
                ddlLocal.DataBind();

                Listar_Proyectos();
            }
            else
            {
                ddlLocal.Items.Clear();
                ddlLocal.Items.Add(new ListItem("Locales no registrados", "0"));
            }
        }

        private void Listar_Proyectos()
        {
            dtCargarProyecto = objCBLocal.ListarProyectoxLocalxUser(int.Parse(ddlLocal.SelectedValue), int.Parse(Session["CodigoUsuario"].ToString()));
            ddlProyecto.Items.Clear();
            ddlProyecto.Items.Add(new ListItem("-----Todos-----", "0"));

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
                    BusquedaAvanzada();
                }
            }
            else
            {
                ddlProyecto.Items.Clear();
                ddlProyecto.Items.Add(new ListItem("No hay Proyectos asignados a este local", "0"));
                gvListado.Visible = false;
                gvListado.DataSource = null;
            }
        }

        private void BusquedaAvanzada()
        {
            Session["Opc"] = 2;
            dtListaA = objCBVisitas.GetBusquedaVisitasA(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), int.Parse(ddlEstado.SelectedValue), txtFechaD.Text, txtFechaH.Text, txtNombres.Text);

            if (dtListaA.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtListaA;
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
                BusquedaAvanzada();
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();

            BusquedaAvanzada();
        }

        protected void gvListado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                HyperLink hypFecha = (HyperLink)e.Row.FindControl("hypFecha");
                HyperLink hypEstadoVisita = (HyperLink)e.Row.FindControl("hypEstadoVisita");

                numUsuario = Session["CodigoUsuario"].ToString();
                hypFecha.Attributes.Add("onClick", "window.open('WFFechaEdit.aspx?vCodigoPaciente=" + DataBinder.Eval(e.Row.DataItem, "CodigoPaciente") + "&vCodigoLocal=" + DataBinder.Eval(e.Row.DataItem, "CodigoLocal") + "&vCodigoProyecto=" + DataBinder.Eval(e.Row.DataItem, "CodigoProyecto") + "&vCodigoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisita") + "&vCodigoVisitas=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisitas") + "&vCodigoEstadoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoEstadoVisita") + "&vFechaVisita=" + DataBinder.Eval(e.Row.DataItem, "FechaNVisita") + "&vCodigoUsuario=" + numUsuario + "','PageW','width=340,height=300,scrollbars=no,center=yes,status=no,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");
                hypEstadoVisita.Attributes.Add("onClick", "window.open('WFEstadoVisitaEdit.aspx?vCodigoPaciente=" + DataBinder.Eval(e.Row.DataItem, "CodigoPaciente") + "&vCodigoLocal=" + DataBinder.Eval(e.Row.DataItem, "CodigoLocal") + "&vCodigoProyecto=" + DataBinder.Eval(e.Row.DataItem, "CodigoProyecto") + "&vCodigoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisita") + "&vCodigoVisitas=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisitas") + "&vCodigoEstadoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoEstadoVisita") + "&vFechaVisita=" + DataBinder.Eval(e.Row.DataItem, "FechaNVisita") + "&vCodigoUsuario=" + numUsuario + "','PageW','width=340,height=200,scrollbars=no,center=yes,status=no,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");
            }
        }

        protected void btnBuscarAvanzada_Click(object sender, EventArgs e)
        {
            BusquedaAvanzada();
        }


    }
}