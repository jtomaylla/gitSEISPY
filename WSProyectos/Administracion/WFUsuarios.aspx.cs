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
    public partial class WFUsuarios : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaLocal = new DataTable();
        DataTable dtLista = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Local();
            }
        }

        private void Listar_Local()
        {
            dtListaLocal = objCBLocal.ListarLocales();

            if (dtListaLocal.Rows.Count > 0)
            {
                ddlLocal.DataSource = dtListaLocal;
                ddlLocal.DataValueField = dtListaLocal.Columns[0].ToString();
                ddlLocal.DataTextField = dtListaLocal.Columns[1].ToString();
                ddlLocal.DataBind();

                Cargardatos();
            }
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/WFUsuariosNew.aspx?IdLocal=" + ddlLocal.SelectedValue,false);
        }

        private void Cargardatos()
        {
            dtLista = objCBUsuario.ListarUsuariosxLocal(int.Parse(ddlLocal.SelectedValue));

            if (dtLista.Rows.Count > 0)
            {
                gvUsuarios.Visible = true;
                gvUsuarios.DataSource = dtLista;
                gvUsuarios.DataBind();
                gvUsuarios.SelectedIndex = -1;
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
            }
            else
            {
                gvUsuarios.Visible = false;
            }
        }

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocal.Items.Count > -1)
            {
                Cargardatos();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Administracion/WFUsuariosEdit.aspx?CodigoUsuario=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Rol")
            {
                Response.Redirect("~/Administracion/WFUsuariosRol.aspx?CodigoUsuario=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Proyectos")
            {
                Response.Redirect("~/Administracion/WFUsuariosProyecto.aspx?CodigoUsuario=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Resetear")
            {
                if (objCBUsuario.ResetearPassword(int.Parse(e.CommandArgument.ToString())) != 0)
                {
                    lblMensaje.Text = "La clave fue reseteada satisfactoriamente";
                }
            }

        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            gvUsuarios.DataBind();
            Cargardatos();

        }
    }
}