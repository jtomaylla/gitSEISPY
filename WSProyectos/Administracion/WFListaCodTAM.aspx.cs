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
    public partial class WFListaCodTAM : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtCargarLocal = new DataTable();
        DataTable dtCargarProyecto = new DataTable();
        DataTable dtListado = new DataTable();
        protected string numUsuario;
        string strCod;
        string strDes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                numUsuario = Session["CodigoUsuario"].ToString();
                btnAgregar.Attributes.Add("onClick", "window.open('WFCodTamNew.aspx?','PageW','width=340,height=200,scrollbars=no,center=yes,status=no,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");

                Listar_Locales();
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
            }
            else
            {
                ddlProyecto.Items.Clear();
                ddlProyecto.Items.Add(new ListItem("No hay Proyectos asignados a este local", "0"));
            }
        }

        private void BusquedaSimple()
        {
            dtListado = objCBProyecto.ListarCodTamizaje(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue),txtCod.Text);

            if (dtListado.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtListado;
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaSimple();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/WFGenerarCodTAM.aspx", false);
        }

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocal.Items.Count > -1)
            {
                Listar_Proyectos();
                BusquedaSimple();
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
                BusquedaSimple();
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            BusquedaSimple();
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                GridViewRow dgi = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCodigoProyecto = (Label)dgi.FindControl("lblCodigoProyecto");
                Label lblCodigoLocal = (Label)dgi.FindControl("lblCodigoLocal");
                Label lblCodigoTAM = (Label)dgi.FindControl("lblCodigoTAM");

                Response.Redirect("~/Administracion/WFCodTamEdit.aspx?vCodigoTAM=" + lblCodigoTAM.Text + "&vCodigoLocal=" + lblCodigoLocal.Text + "&vCodigoProyecto=" + lblCodigoProyecto.Text, false);
            }
            if (e.CommandName == "Limpiar")
            {
                int Resultado;
                GridViewRow dgi = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCodigoProyecto = (Label)dgi.FindControl("lblCodigoProyecto");
                Label lblCodigoLocal = (Label)dgi.FindControl("lblCodigoLocal");
                Label lblCodigoTAM = (Label)dgi.FindControl("lblCodigoTAM");

                Resultado = objCBProyecto.LimiarCodTAM(int.Parse(lblCodigoLocal.Text), int.Parse(lblCodigoProyecto.Text), int.Parse(lblCodigoTAM.Text));

                if (Resultado == 0 || Resultado == -1)
                {
                    lblMensaje.Text = "Error al liberar código";
                }
                else
                {
                    BusquedaSimple();
                    lblMensaje.Text = "El código fue liberó satisfactoriamente";
                }
            }

        }

        protected void gvListado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton imbLimpiar = (LinkButton)e.Row.FindControl("imbLimpiar");
                HyperLink hypTAM = (HyperLink)e.Row.FindControl("hypTAM");
                string Estado = ((DataRowView)(e.Row.DataItem))["Estado"].ToString();

                if (Estado == "1")
                {
                    hypTAM.NavigateUrl = "";
                    hypTAM.ToolTip = "";
                }
                else
                {
                    hypTAM.Attributes.Add("onClick", "window.open('WFCodTamEdit.aspx?vCodigoTAM=" + DataBinder.Eval(e.Row.DataItem, "CodigoTAM") + "&vCodigoLocal=" + DataBinder.Eval(e.Row.DataItem, "CodigoLocal") + "&vCodigoProyecto=" + DataBinder.Eval(e.Row.DataItem, "CodigoProyecto") + "&vLocal=" + DataBinder.Eval(e.Row.DataItem, "Local") + "&vProyecto=" + DataBinder.Eval(e.Row.DataItem, "Proyecto") + "&vNumero=" + DataBinder.Eval(e.Row.DataItem, "Numero") + "&vCodigoUsuario=" + numUsuario + "','PageW','width=340,height=200,scrollbars=no,center=yes,status=no,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");
                    imbLimpiar.Text = "";
                    imbLimpiar.ToolTip = "";
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

    }
}