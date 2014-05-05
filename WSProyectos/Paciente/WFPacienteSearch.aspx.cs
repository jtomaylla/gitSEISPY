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
    public partial class WFPacienteSearch : System.Web.UI.Page
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtLista = new DataTable();
        DataTable dtListaS = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BusquedaSimple()
        {
            Session["Opc"] = 1;
            dtListaS = objCBPaciente.BuscarPacxDocumento(txtDoc.Text);

            if (dtListaS.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtListaS;
                gvListado.DataBind();
                gvListado.SelectedIndex = -1;
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se encontró registros...";
                gvListado.Visible = false;
            }
        }

        protected void btnBusquedaA_Click(object sender, EventArgs e)
        {
            pBusquedaS.Visible = false;
            pBusquedaA.Visible = true;
            lblAM.Visible = true;
            lblAP.Visible = true;
            lblFN.Visible = true;
            lblNom.Visible = true;
            btnBuscarAvanzada.Visible = true;
            txtApeM.Visible = true;
            txtApeP.Visible = true;
            txtFN.Visible = true;
            txtNombres.Visible = true;
            txtApeM.Text = "";
            txtApeP.Text = "";
            txtFN.Text = "";
            txtNombres.Text = "";
            btnBusquedaS.Visible = true;

            lblDoc.Visible = false;
            txtDoc.Visible = false;
            txtDoc.Text = "";
            btnBuscar.Visible = false;
            btnBusquedaA.Visible = false;
        }

        protected void btnBusquedaS_Click(object sender, EventArgs e)
        {
            pBusquedaS.Visible = true;
            pBusquedaA.Visible = false;
            lblAM.Visible = false;
            lblAP.Visible = false;
            lblFN.Visible = false;
            lblNom.Visible = false;
            btnBuscarAvanzada.Visible = false;
            txtApeM.Visible = false;
            txtApeP.Visible = false;
            txtFN.Visible = false;
            txtNombres.Visible = false;
            txtApeM.Text = "";
            txtApeP.Text = "";
            txtFN.Text = "";
            txtNombres.Text = "";
            btnBusquedaS.Visible = false;

            lblDoc.Visible = true;
            txtDoc.Visible = true;
            txtDoc.Text = "";
            btnBuscar.Visible = true;
            btnBusquedaA.Visible = true;

        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Paciente/WFPacienteEdit.aspx?CodigoPaciente=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Visita")
            {
                Response.Redirect("~/Paciente/WFGenerarVisitas.aspx?CodigoPaciente=" + e.CommandArgument, false);
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaSimple();
        }

        private void BusquedaAvanzada()
        {
            Session["Opc"] = 2;
            dtLista = objCBPaciente.BuscarPacxDatos(txtApeP.Text,txtApeM.Text,txtNombres.Text,txtFN.Text);

            if (dtLista.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtLista;
                gvListado.DataBind();
                gvListado.SelectedIndex = -1;
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se encontró registros...";
                gvListado.Visible = false;
            }
        }

        protected void btnBuscarAvanzada_Click(object sender, EventArgs e)
        {
            BusquedaAvanzada();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();

            if (Session["Opc"].ToString() == "1")
            {
                BusquedaSimple();
            }
            else
            {
                BusquedaAvanzada();
            }
        }
    }
}