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
    public partial class WFUsuariosProyecto : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtCargar = new DataTable();
        DataTable dtLista = new DataTable();
        int CodigoUsuarioR;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CodigoUsuarioR = int.Parse(Request.QueryString["CodigoUsuario"]);
                Session["CodigoUsuarioR"] = CodigoUsuarioR;
                Cargar(CodigoUsuarioR);
                Cargardatos();
            }
        }

        private void Cargar(int CodigoUsuario)
        {
            dtCargar = objCBUsuario.ObtenerUsuario(CodigoUsuario);

            if (dtCargar.Rows.Count > 0)
            {
                txtUsuario.Text = dtCargar.Rows[0]["NombreUsuario"].ToString();
            }
        }

        private void Cargardatos()
        {
            dtLista = objCBUsuario.GetListarProyectosxUser(int.Parse(Session["CodigoUsuarioR"].ToString()));

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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            for (int I = 0; I < gvListado.Rows.Count; I++)
            {
                int vEstado;
                int Num_Rpta = 0;

                Label strCodigoProy = ((Label)gvListado.Rows[I].FindControl("lblcodigoProy"));

                if (((CheckBox)gvListado.Rows[I].FindControl("ckbAsignar")).Checked == true)
                {
                    vEstado = 1;
                }
                else
                {
                    vEstado = 0;
                }
                Num_Rpta = objCBUsuario.InsertarProyectosxUser(int.Parse(Session["CodigoUsuarioR"].ToString()), int.Parse(strCodigoProy.Text), vEstado);

                if (Num_Rpta == -1 || Num_Rpta == 0)
                {
                    lblMensaje.Text = "Ocurrió un error...";
                }
                else
                {
                    lblMensaje.Text = "Se registró correctamente...";
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/WFUsuarios.aspx", false);
        }

    }
}