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

namespace WSProyectos.Data
{
    public partial class WFRegistrarErrores : System.Web.UI.Page
    {
        CBVisitas objCBVisitas = new CBVisitas();
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtTipoDoc = new DataTable();
        DataTable dtTipoError = new DataTable();
        DataTable dtCargar = new DataTable();
        DataTable dtUserError = new DataTable();
        DataTable dtLista = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                txtFechaError.Text = DateTime.Today.ToShortDateString();

                lblIdP.Text = Request["CodigoPaciente"].ToString();
                Session["CodigoPaciente"] = Request["CodigoPaciente"].ToString();
                Session["CodigoProyecto"] = Request["CodigoProyecto"].ToString();
                Session["CodigoLocal"] = Request["CodigoLocal"].ToString();
                Session["vCodigoUsuario"] = Request["CodigoUsuario"].ToString();
                Cabecera(lblIdP.Text);
                ListaTipoError();
                ListaTipoDocError();
                ListaUserError();
                Listar();
            }

        }

        private void Listar()
        {
            dtLista = objCBVisitas.ListarErroresxPaciente(int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), ddlUsuarios.SelectedValue, lblIdP.Text, txtFechaError.Text);

            if (dtLista.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtLista;
                gvListado.DataBind();
                gvListado.SelectedIndex = -1;
            }
            else
            {
                gvListado.Visible = false;
            }
        }

        private void ListaUserError()
        {
            dtUserError = objCBUsuario.ListarUsuariosxLocalRol(int.Parse(Session["CodigoLocal"].ToString()));

            if (dtUserError.Rows.Count > 0)
            {
                ddlUsuarios.DataSource = dtUserError;
                ddlUsuarios.DataValueField = dtUserError.Columns[0].ToString();
                ddlUsuarios.DataTextField = dtUserError.Columns[1].ToString();
                ddlUsuarios.DataBind();
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

        private void ListaTipoDocError()
        {
            dtTipoDoc = objCBPaciente.MostrarParametrosxId(7);

            if (dtTipoDoc.Rows.Count > 0)
            {
                ddlDocumento.DataSource = dtTipoDoc;
                ddlDocumento.DataValueField = dtTipoDoc.Columns[0].ToString();
                ddlDocumento.DataTextField = dtTipoDoc.Columns[1].ToString();
                ddlDocumento.DataBind();
            }
        }

        private void ListaTipoError()
        {
            dtTipoError = objCBPaciente.MostrarParametrosxId(8);

            if (dtTipoError.Rows.Count > 0)
            {
                ddlTipo.DataSource = dtTipoError;
                ddlTipo.DataValueField = dtTipoError.Columns[0].ToString();
                ddlTipo.DataTextField = dtTipoError.Columns[1].ToString();
                ddlTipo.DataBind();
            }
        }

        private void Limpiar()
        {
            txtIdError.Text = "";
            txtCantidad.Text = "1";
            txtNomDoc.Text = "";
            ckbA72.Checked = false;
            lkbAceptar.Visible = true;
            lkbOtro.Visible = false;
        }

        protected void lkbOtro_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void lkbAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int intA72;
                int Num_Rpta = 0;

                if (txtIdError.Text == "")
                {
                    if (ckbA72.Checked == true)
                    { intA72 = 1; }
                    else { intA72 = 0; }

                    Num_Rpta = objCBVisitas.RegistraErrores(Session["CodigoPaciente"].ToString(), int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), int.Parse(ddlDocumento.SelectedValue), int.Parse(ddlTipo.SelectedValue), int.Parse(ddlUsuarios.SelectedValue), txtFechaError.Text, txtNomDoc.Text, int.Parse(txtCantidad.Text), intA72, int.Parse(Session["CodigoUsuario"].ToString()));

                    if (Num_Rpta == -1 || Num_Rpta == 0)
                    {
                        lblMensaje.Text = "Ocurrió un error al registrar";
                    }
                    else
                    {
                        lblMensaje.Text = "Se registró correctamente";
                        lkbOtro.Visible = true;
                        lkbAceptar.Visible = false;
                        Listar();
                    }
                }
                else
                {
                    if (ckbA72.Checked == true)
                    { intA72 = 1; }
                    else { intA72 = 0; }

                    Num_Rpta = objCBVisitas.EditarErrores(int.Parse(txtIdError.Text), Session["CodigoPaciente"].ToString(), int.Parse(Session["CodigoLocal"].ToString()), int.Parse(Session["CodigoProyecto"].ToString()), int.Parse(ddlDocumento.SelectedValue), int.Parse(ddlTipo.SelectedValue), int.Parse(ddlUsuarios.SelectedValue), txtFechaError.Text, txtNomDoc.Text, int.Parse(txtCantidad.Text), intA72, int.Parse(Session["CodigoUsuario"].ToString()));

                    if (Num_Rpta == -1 || Num_Rpta == 0)
                    {
                        lblMensaje.Text = "Ocurrió un error al registrar";
                    }
                    else
                    {
                        lblMensaje.Text = "Se modificó correctamente";
                        lkbOtro.Visible = true;
                        lkbAceptar.Visible = false;
                        Listar();

                    }
                }

            }

        }

        protected void lkbListar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            Listar();
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow dgi = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblFechaError = (Label)dgi.FindControl("lblFechaError");
            Label lblCodigoDocumento = (Label)dgi.FindControl("lblCodigoDocumento");
            Label lblCodigoTipoError = (Label)dgi.FindControl("lblCodigoTipoError");
            Label lblcodigousuario = (Label)dgi.FindControl("lblcodigousuario");
            Label lblNumDoc = (Label)dgi.FindControl("lblNumDoc");
            Label lblCantidad = (Label)dgi.FindControl("lblCantidad");
            Label lblA72 = (Label)dgi.FindControl("lblA72");

            if (e.CommandName == "Editar")
            {
                txtIdError.Text = e.CommandArgument.ToString();
                txtFechaError.Text = lblFechaError.Text;
                txtNomDoc.Text = lblNumDoc.Text;
                txtCantidad.Text = lblCantidad.Text;
                ddlDocumento.SelectedValue = lblCodigoDocumento.Text;
                ddlUsuarios.SelectedValue = lblcodigousuario.Text;
                ddlTipo.SelectedValue = lblCodigoTipoError.Text;

                if (lblA72.Text == "Si")
                {
                    ckbA72.Checked = true;
                }
                else
                {
                    ckbA72.Checked = false;
                }
                lkbAceptar.Visible = true;
                lkbOtro.Visible = false;
            }

        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar();
        }

    }
}