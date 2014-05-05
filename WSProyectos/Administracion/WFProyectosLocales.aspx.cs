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
    public partial class WFProyectosLocales : System.Web.UI.Page
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

                string CodigoProyecto = Request.QueryString["CodigoProyecto"];

                if (!string.IsNullOrEmpty(CodigoProyecto))
                {
                    ddlProyecto.SelectedValue = CodigoProyecto;
                }
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
            dtLista = objCBProyecto.ListarLocalesxProyecto(int.Parse(ddlProyecto.SelectedValue));

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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/WFProyectos.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            for (int I = 0; I < gvListado.Rows.Count; I++)
            {
                int vEstado;
                int Num_Rpta = 0;

                Label strCodigoLocal = ((Label)gvListado.Rows[I].FindControl("lblCodigoLocal"));

                if (((CheckBox)gvListado.Rows[I].FindControl("ckbAsignar")).Checked == true)
                {
                    vEstado = 1;
                }
                else
                {
                    vEstado = 0;
                }
                Num_Rpta = objCBProyecto.InsertarLocalesxProyecto(int.Parse(strCodigoLocal.Text), int.Parse(ddlProyecto.SelectedValue), vEstado);

                if (Num_Rpta != 0)
                {
                    lblMensaje.Text = "Se registró correctamente...";
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error...";
                }
            }
        }

        protected void gvListado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                CheckBox ckbA = (CheckBox)e.Row.FindControl("ckbAsignar");
                object cellValue = DataBinder.Eval(e.Row.DataItem, "Estado");

                if (Convert.ToString(cellValue) == "1")
                {
                    ckbA.Checked = true;
                }
                else
                {
                    ckbA.Checked = false;
                }
            } 
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
                Cargardatos();
            }
        }

    }
}