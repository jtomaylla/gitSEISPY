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
    public partial class WFPacienteNew : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                txtFN.Text = "01/01/1980";

                Listar_Parametros();

                if (ddlDoc.SelectedValue == "1")
                {
                    txtDocumento.Text = "";
                    txtDocumento.Enabled = false;
                }
                else
                {
                    txtDocumento.Text = "";
                    txtDocumento.Enabled = true;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string documento;
            string Resultado;

            if (ddlDoc.SelectedValue == "1")
            {
                documento="";
            }
            else
            {
                documento=txtDocumento.Text;
            }

            if (ddlDoc.SelectedValue != "1" && txtDocumento.Text=="")
            {
                lblMensaje.Text = "Ingresar el documento";
            }
            else
            {

                dtDatos = objCBPaciente.RegistrarPacientes(txtNombres.Text, txtApeP.Text, txtApeM.Text, int.Parse(ddlDoc.SelectedValue), documento, txtFN.Text, int.Parse(rblSexo.SelectedValue));

                if (dtDatos.Rows.Count > 0)
                {
                    Resultado = dtDatos.Rows[0]["Mensaje"].ToString();

                    if (Resultado == "1")
                    {
                        lblIdP.Text = dtDatos.Rows[0]["CodigoPaciente"].ToString();
                        lblMensaje.Text = "Los datos se grabaron correctamente";
                        btnDatos.Visible = true;
                        btnRegistrarOtro.Visible = true;
                        btnAceptar.Visible = false;
                        btnCrear.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "El paciente ya existe..por favor verifique bien los datos ingresados";
                        btnDatos.Visible = false;
                        btnRegistrarOtro.Visible = false;
                        btnAceptar.Visible = true;
                        btnCrear.Visible = false;

                    }
                }
            }
        }


        protected void btnDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paciente/WFPacienteContact.aspx?CodigoPaciente=" + lblIdP.Text, false);
        }

        protected void btnRegistrarOtro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paciente/WFPacienteNew.aspx", false);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paciente/WFGenerarVisitas.aspx?CodigoPaciente=" + lblIdP.Text, false);

        }
    }
}