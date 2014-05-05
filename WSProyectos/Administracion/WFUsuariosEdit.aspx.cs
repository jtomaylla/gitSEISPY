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
    public partial class WFUsuariosEdit : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaLocal = new DataTable();
        DataTable dtCargar= new DataTable();
        int CodigoUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar_Local();

                CodigoUsuario = int.Parse(Request.QueryString["CodigoUsuario"]);

                Cargar(CodigoUsuario);
            }

        }

        private void Cargar(int CodigoUsuario)
        {
            dtCargar = objCBUsuario.ObtenerUsuario(CodigoUsuario);

            if (dtCargar.Rows.Count > 0)
            {
                ddlLocal.SelectedValue = dtCargar.Rows[0]["CodigoLocal"].ToString();
                lblCodigoUsuario.Text = dtCargar.Rows[0]["CodigoUsuario"].ToString();
                txtLogin.Text = dtCargar.Rows[0]["LoginUsuario"].ToString();
                txtNombre.Text = dtCargar.Rows[0]["NombreUsuario"].ToString();
                txtIniciales.Text = dtCargar.Rows[0]["Iniciales"].ToString();
                txtEmail.Text = dtCargar.Rows[0]["Correo"].ToString();
                ddlEstado.SelectedValue = dtCargar.Rows[0]["Estado"].ToString();
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

                Num_Rpta = objCBUsuario.ActualizarUsuario(int.Parse(lblCodigoUsuario.Text), int.Parse(ddlLocal.SelectedValue), txtLogin.Text, txtNombre.Text, txtIniciales.Text, txtEmail.Text, int.Parse(ddlEstado.SelectedValue));

                if (Num_Rpta != 0)
                {
                    Response.Redirect("~/Administracion/WFUsuarios.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al actualizar el usuario";
                }
            }

        }
    }
}