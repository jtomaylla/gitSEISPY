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
    public partial class WFLocalesEdit : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaLocal = new DataTable();
        DataTable dtLista = new DataTable();
        DataTable dtCargar = new DataTable();
        int CodigoLocal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Empresa();
                CodigoLocal = int.Parse(Request.QueryString["CodigoLocal"]);
                Cargar(CodigoLocal);
            }
        }

        private void Cargar(int CodigoLocal)
        {
            dtCargar = objCBLocal.ListarLocalesxID(CodigoLocal);

            if (dtCargar.Rows.Count > 0)
            {
                lblCodLocal.Text = dtCargar.Rows[0]["CodigoLocal"].ToString();
                ddlEmpresa.SelectedValue = dtCargar.Rows[0]["CodigoEmpresa"].ToString();
                txtNombre.Text = dtCargar.Rows[0]["Nombre"].ToString();
                txtDescripcion.Text = dtCargar.Rows[0]["Descripcion"].ToString();
                txtDireccion.Text = dtCargar.Rows[0]["DireccionLocal"].ToString();
                txtDistrito.Text = dtCargar.Rows[0]["DistritoLocal"].ToString();
                txtTelefono.Text = dtCargar.Rows[0]["Telefono"].ToString();
                string Estado = dtCargar.Rows[0]["Estado"].ToString();
                string Estatus = dtCargar.Rows[0]["Estatus"].ToString();

                if (Estado == "1")
                {
                    ckbEstado.Checked = true;
                }
                else
                {
                    ckbEstado.Checked = false;
                }

                if (Estatus == "1")
                {
                    ckbEstatus.Checked = true;
                }
                else
                {
                    ckbEstatus.Checked = false;
                }

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

        protected void btnEditar_Click(object sender, EventArgs e)
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

                Num_Rpta = objCBLocal.ModificarLocales(int.Parse(lblCodLocal.Text), int.Parse(ddlEmpresa.SelectedValue), txtNombre.Text, txtDescripcion.Text, txtDireccion.Text, txtDistrito.Text, txtTelefono.Text, vEstatus,vEstado);

                if (Num_Rpta != 0)
                {
                    Response.Redirect("~/Administracion/WFLocales.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al actualizar el usuario";
                }
            }
        }
    }
}