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
using System.Threading;

namespace WSProyectos.Paciente
{
    public partial class WFPacienteEdit : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtCargar = new DataTable();
        string vIdPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Parametros();

                vIdPaciente = Request.QueryString["CodigoPaciente"].ToString();
                lblIdP.Text = vIdPaciente;
                Cabecera(vIdPaciente);

            }
        }

        private void Cabecera(string vIdPaciente)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

            dtCargar = objCBPaciente.DatosPacientexId(vIdPaciente);

            if (dtCargar.Rows.Count > 0)
            {
                txtNombres.Text = dtCargar.Rows[0]["Nombres"].ToString();
                txtApeP.Text = dtCargar.Rows[0]["ApellidoPaterno"].ToString();
                txtApeM.Text = dtCargar.Rows[0]["ApellidoMaterno"].ToString();
                ddlDoc.SelectedValue = dtCargar.Rows[0]["CodigoTipoDocumento"].ToString();
                txtFN.Text = dtCargar.Rows[0]["FechaNacimiento"].ToString();
                rblSexo.SelectedValue = dtCargar.Rows[0]["Sexo"].ToString();

                if (ddlDoc.SelectedValue == "1")
                {
                    txtDocumento.Text = "";
                    txtDocumento.Enabled = false;
                }
                else
                {
                    txtDocumento.Enabled = true;
                    txtDocumento.Text = dtCargar.Rows[0]["DocumentoIdentidad"].ToString();
                }

            }
        }

        private void Listar_Parametros()
        {
            dtListaPar = objCBPaciente.MostrarParametrosxId(2);

            if (dtListaPar.Rows.Count > 0)
            {
                ddlDoc.DataSource = dtListaPar;
                ddlDoc.DataValueField = dtListaPar.Columns[0].ToString();
                ddlDoc.DataTextField = dtListaPar.Columns[1].ToString();
                ddlDoc.DataBind();
            }
        }

        protected void ddlDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDoc.SelectedValue == "1")
            {
                txtDocumento.Text = "";
                txtDocumento.Enabled = false;
            }
            else
            {
                txtDocumento.Enabled = true;
            }
        }

        protected void btnDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paciente/WFPacienteContact.aspx?CodigoPaciente=" + lblIdP.Text, false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string documento;
            string Resultado;

            if (ddlDoc.SelectedValue == "1")
            {
                documento = "";
            }
            else
            {
                documento = txtDocumento.Text;
            }

            if (ddlDoc.SelectedValue != "1" && txtDocumento.Text == "")
            {
                lblMensaje.Text = "Ingresar el documento";
            }
            else
            {

                dtDatos = objCBPaciente.EditarPacientes(lblIdP.Text,txtNombres.Text, txtApeP.Text, txtApeM.Text, int.Parse(ddlDoc.SelectedValue), documento, txtFN.Text, int.Parse(rblSexo.SelectedValue));

                if (dtDatos.Rows.Count > 0)
                {
                    Resultado = dtDatos.Rows[0]["Mensaje"].ToString();

                    if (Resultado == "1")
                    {
                        lblIdP.Text = dtDatos.Rows[0]["CodigoPaciente"].ToString();
                        lblMensaje.Text = "Los datos se modificaron correctamente";
                        btnDatos.Visible = true;
                        btnAceptar.Visible = false;
                        Cabecera(lblIdP.Text);

                    }
                }
                else
                {
                    lblMensaje.Text = "Error al modificar los datos..";

                }
            }
        }
    }
}