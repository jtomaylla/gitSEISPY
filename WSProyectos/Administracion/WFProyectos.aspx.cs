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
    public partial class WFProyectos : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaRed = new DataTable();
        DataTable dtLista = new DataTable();
        string strCod;
        string strDes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Redes();
            }
        }

        private void Listar_Redes()
        {
            dtListaRed = objCBProyecto.ListarRedes();
            ddlRed.Items.Clear();
            ddlRed.Items.Add(new ListItem("-----Todos-----", "0"));

            if (dtListaRed.Rows.Count > 0)
            {
                for (int i = 0; i < dtListaRed.Rows.Count; i++)
                {
                    strCod = dtListaRed.Rows[i][0].ToString();
                    strDes = dtListaRed.Rows[i][1].ToString();
                    ddlRed.Items.Add(new ListItem(strDes, strCod));
                }
                Cargardatos();
            }
        }

        private void Cargardatos()
        {
            dtLista = objCBProyecto.ListarProyectosxRed(int.Parse(ddlRed.SelectedValue));

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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/WFProyectosNew.aspx", false);
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Administracion/WFProyectosEdit.aspx?CodigoProyecto=" + e.CommandArgument, false);
            }
            if (e.CommandName == "AsignarLocal")
            {
                Response.Redirect("~/Administracion/WFProyectosLocales.aspx?CodigoProyecto=" + e.CommandArgument, false);
            }

        }

        protected void ddlRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargardatos();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            Cargardatos();
        }
    }
}