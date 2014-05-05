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

namespace WSProyectos.Administracion
{
    public partial class WFVisitas : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaPY = new DataTable();
        DataTable dtLista = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Proyecto();
            }
        }

        private void Listar_Proyecto()
        {
            dtListaPY = objCBProyecto.ListarProyectos();

            if (dtListaPY.Rows.Count > 0)
            {
                ddlProyecto.DataSource = dtListaPY;
                ddlProyecto.DataValueField = dtListaPY.Columns[0].ToString();
                ddlProyecto.DataTextField = dtListaPY.Columns[1].ToString();
                ddlProyecto.DataBind();

                Cargardatos();
            }
        }

        private void Cargardatos()
        {
            dtLista = objCBProyecto.ListarVisitasxProyecto(int.Parse(ddlProyecto.SelectedValue));

            if (dtLista.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtLista;
                gvListado.DataBind();
                gvListado.SelectedIndex = -1;
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
            }
            else
            {
                gvListado.Visible = false;
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
                Cargardatos();
            }
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                GridViewRow dgi = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCodigoGrupoVisita = (Label)dgi.FindControl("lblCodigoGrupoVisita");
                Response.Redirect("~/Administracion/WFVisitasEdit.aspx?CodigoProyecto=" + ddlProyecto.SelectedValue + "&CodigoGrupoVisita=" + lblCodigoGrupoVisita.Text + "&CodigoVisita=" + e.CommandArgument, false);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/WFVisitasNew.aspx", false);
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            Cargardatos();
        }

    }
}