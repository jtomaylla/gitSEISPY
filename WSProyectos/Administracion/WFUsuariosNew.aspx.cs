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
    public partial class WFUsuariosNew : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaLocal = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar_Local();

                string CodigoLocal = Request.QueryString["IdLocal"];

                if (!string.IsNullOrEmpty(CodigoLocal))
                {
                    ddlLocal.SelectedValue = CodigoLocal;
                }
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
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;

                Num_Rpta = objCBUsuario.AgregarUsuario(int.Parse(ddlLocal.SelectedValue), txtLogin.Text, txtNombre.Text, txtIniciales.Text, txtEmail.Text);

                if (Num_Rpta != 0)
                {
                    Response.Redirect("~/Administracion/WFUsuarios.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al agregar el usuario";
                }
            }
        }
    }
}