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
    public partial class WFProyectosEdit : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaRed = new DataTable();
        DataTable dtCargar = new DataTable();
        int CodigoProyecto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Red();
                CodigoProyecto = int.Parse(Request.QueryString["CodigoProyecto"]);
                Cargar(CodigoProyecto);

            }
        }

        private void Cargar(int CodigoProyecto)
        {
            dtCargar = objCBProyecto.ListarProyectosxID(CodigoProyecto);

            if (dtCargar.Rows.Count > 0)
            {
                lblIdPy.Text = dtCargar.Rows[0]["CodigoProyecto"].ToString();
                ddlRed.SelectedValue = dtCargar.Rows[0]["CodigoRedes"].ToString();
                txtNombre.Text = dtCargar.Rows[0]["Nombre"].ToString();
                txtDescripcion.Text = dtCargar.Rows[0]["Descripcion"].ToString();
                txtFechaInicio.Text = dtCargar.Rows[0]["FechaInicio"].ToString();
                txtFechaFin.Text = dtCargar.Rows[0]["FechaFin"].ToString();
                string TAM = dtCargar.Rows[0]["TAM"].ToString();
                string ENR = dtCargar.Rows[0]["ENR"].ToString();
                string Estado = dtCargar.Rows[0]["Estado"].ToString();
                string Estatus = dtCargar.Rows[0]["Estatus"].ToString();
                string TipoTAM = dtCargar.Rows[0]["TipoTAM"].ToString();
                string TipoENR = dtCargar.Rows[0]["TipoENR"].ToString();

                if (TAM == "1")
                {
                    ckbptid.Checked = true;
                    ddlTipoId.Visible = true;
                    ddlTipoId.SelectedValue = TipoTAM;
                }
                else
                {
                    ddlTipoId.Visible = false;
                    ckbptid.Checked = false;
                }

                if (ENR == "1")
                {
                    ckbenr.Checked = true;
                    ddlTipoENR.Visible = true;
                    ddlTipoENR.SelectedValue = TipoENR;
                }
                else
                {
                    ckbenr.Checked = false;
                    ddlTipoENR.Visible = false;
                }

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

                Num_Rpta = objCBProyecto.ModificarProyecto(int.Parse(lblIdPy.Text), int.Parse(ddlRed.SelectedValue), txtNombre.Text, txtDescripcion.Text, txtFechaInicio.Text, txtFechaFin.Text, vTAM, vENR, vTipoTAM, vTipoENR, vEstatus, vEstado);

                if (Num_Rpta != 0)
                {
                    Response.Redirect("~/Administracion/WFProyectos.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al actualizar el Proyecto";
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