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

namespace WSProyectos.Paciente
{
    public partial class WFPacienteContact : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtDatosContacto = new DataTable();
        DataTable dtCargar = new DataTable();
        DataTable dtDep = new DataTable();
        DataTable dtProv = new DataTable();
        DataTable dtDist = new DataTable();
        string vIdPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vIdPaciente = Request.QueryString["CodigoPaciente"].ToString();
                lblIdP.Text = vIdPaciente;
                Cabecera(vIdPaciente);
                Departamentos();
                DatosContacto(vIdPaciente);
            }
        }

        private void Cabecera(string vIdPaciente)
        {
            dtCargar = objCBPaciente.DatosPacientexId(vIdPaciente);

            if (dtCargar.Rows.Count > 0)
            {
                txtPaciente.Text = dtCargar.Rows[0]["NombreCompleto"].ToString();
            }
        }

        private void DatosContacto(string vIdPaciente)
        {
            dtDatosContacto = objCBPaciente.DatosPacienteContactoxId(vIdPaciente);

            if (dtDatosContacto.Rows.Count > 0)
            {
                string vCodigoUbigeo = dtDatosContacto.Rows[0]["CodigoUbigeo"].ToString();
                txtDireccion.Text = dtDatosContacto.Rows[0]["Direccion"].ToString();
                txtRef.Text = dtDatosContacto.Rows[0]["Referencia"].ToString();
                txtTel1.Text = dtDatosContacto.Rows[0]["Telefono1"].ToString();
                txtTel2.Text = dtDatosContacto.Rows[0]["Telefono2"].ToString();
                txtCel.Text = dtDatosContacto.Rows[0]["Celular"].ToString();
                Departamentos();
                string strIdDepa = vCodigoUbigeo.Substring(0, 5) + "0000";
                ddlDepartamento.SelectedValue = strIdDepa;
                Provincia();
                string strIdProv = vCodigoUbigeo.Substring(0, 7) + "00";
                ddlProvincia.SelectedValue = strIdProv;
                Distrito();
                ddlDistrito.SelectedValue = vCodigoUbigeo;

            }
        }

        private void Departamentos()
        {
            dtDep = objCBPaciente.GetUbigeoPais(1);

            if (dtDep.Rows.Count > 0)
            {
                ddlDepartamento.DataSource = dtDep;
                ddlDepartamento.DataValueField = dtDep.Columns[0].ToString();
                ddlDepartamento.DataTextField = dtDep.Columns[1].ToString();
                ddlDepartamento.DataBind();

                if (ddlDepartamento.Items.Count > -1)
                {
                    Provincia();
                }
            }
        }

        private void Provincia()
        {
            string IdDep = ddlDepartamento.SelectedValue.Substring(0, 5);
            dtProv = objCBPaciente.GetUbigeoDep(int.Parse(IdDep));

            if (dtProv.Rows.Count > 0)
            {
                ddlProvincia.DataSource = dtProv;
                ddlProvincia.DataValueField = dtProv.Columns[0].ToString();
                ddlProvincia.DataTextField = dtProv.Columns[1].ToString();
                ddlProvincia.DataBind();

                if (ddlProvincia.Items.Count > -1)
                {
                    Distrito();
                }
            }
        }

        private void Distrito()
        {
            string IdProv = ddlProvincia.SelectedValue.Substring(0, 7);
            dtDist = objCBPaciente.GetUbigeoProv(int.Parse(IdProv));

            if (dtDist.Rows.Count > 0)
            {
                ddlDistrito.DataSource = dtDist;
                ddlDistrito.DataValueField = dtDist.Columns[0].ToString();
                ddlDistrito.DataTextField = dtDist.Columns[1].ToString();
                ddlDistrito.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;

                Num_Rpta = objCBPaciente.InsertarContacto(lblIdP.Text, ddlDistrito.SelectedValue, txtDireccion.Text, txtRef.Text, txtTel1.Text, txtTel2.Text, txtCel.Text);

                if (Num_Rpta == -1 || Num_Rpta == 0)
                {
                    lblMensaje.Text = "Ocurrió un error al registrar";
                }
                else
                {
                    lblMensaje.Text = "Se registró correctamente";
                    DatosContacto(lblIdP.Text);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WFPrincipal.aspx", false);
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartamento.Items.Count > -1)
            {
                Provincia();
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvincia.Items.Count > -1)
            {
                Distrito();
            }
        }

    }
}