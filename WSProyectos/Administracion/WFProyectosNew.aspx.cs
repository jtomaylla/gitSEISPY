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
    public partial class WFProyectosNew : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaRed = new DataTable();
        DataTable dtLista = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaInicio.Text = DateTime.Today.ToShortDateString();
                txtFechaFin.Text = DateTime.Today.ToShortDateString();

                Listar_Red();
            }
        }

        private void Listar_Red()
        {
            dtListaRed = objCBProyecto.ListarRedes();

            if (dtListaRed.Rows.Count > 0)
            {
                ddlRed.DataSource = dtListaRed;
                ddlRed.DataValueField = dtListaRed.Columns[0].ToString();
                ddlRed.DataTextField = dtListaRed.Columns[1].ToString();
                ddlRed.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;
                int vEstatus = 0;
                int vEstado = 0;
                int vTAM = 0;
                int vENR = 0;
                int vTipoTAM = 0;
                int vTipoENR = 0;

                if (ckbptid.Checked == true)
                { 
                    vTAM = 1;
                    vTipoTAM = int.Parse(ddlTipoId.SelectedValue);
                }

                if (ckbenr.Checked == true)
                { 
                    vENR = 1;
                    vTipoENR = int.Parse(ddlTipoENR.SelectedValue);
                }

                if (ckbEstatus.Checked == true)
                { vEstatus = 1; }

                if (ckbEstado.Checked == true)
                { vEstado = 1; }

                Num_Rpta = objCBProyecto.InsertarProyecto(int.Parse(ddlRed.SelectedValue), txtNombre.Text, txtDescripcion.Text, txtFechaInicio.Text, txtFechaFin.Text, vTAM, vENR, vTipoTAM, vTipoENR, vEstatus, vEstado);

                if (Num_Rpta != 0)
                {
                    Response.Redirect("~/Administracion/WFProyectos.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al agregar el Proyecto";
                }
            }
        }

        protected void ckbptid_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbptid.Checked == true)
            {
                ddlTipoId.Visible = true;
            }
            else
            {
                ddlTipoId.Visible = false;
            }
        }

        protected void ckbenr_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbenr.Checked == true)
            {
                ddlTipoENR.Visible = true;
            }
            else
            {
                ddlTipoENR.Visible = false;
            }
        }
    }
}