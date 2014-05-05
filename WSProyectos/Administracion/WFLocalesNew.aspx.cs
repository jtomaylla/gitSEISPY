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
    public partial class WFLocalesNew : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaLocal = new DataTable();
        DataTable dtLista = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Empresa();
            }
        }

        private void Listar_Empresa()
        {
            dtListaLocal = objCBLocal.ListarEmpresasAct();

            if (dtListaLocal.Rows.Count > 0)
            {
                ddlEmpresa.DataSource = dtListaLocal;
                ddlEmpresa.DataValueField = dtListaLocal.Columns[0].ToString();
                ddlEmpresa.DataTextField = dtListaLocal.Columns[1].ToString();
                ddlEmpresa.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;
                int vEstatus = 0;
                int vEstado = 0;

                if (ckbEstatus.Checked==true)
                { vEstatus = 1; }

                if (ckbEstado.Checked == true)
                { vEstado = 1; }

                Num_Rpta = objCBLocal.InsertarLocales(int.Parse(ddlEmpresa.SelectedValue), txtNombre.Text, txtDescripcion.Text, txtDireccion.Text, txtDistrito.Text, txtTelefono.Text, vEstatus,vEstado);

                if (Num_Rpta != 0)
                {
                    Response.Redirect("~/Administracion/WFLocales.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al agregar el local";
                }
            }
        }


    }
}