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
    public partial class WFBusquedaVisitasD : System.Web.UI.Page
    {
        CBLocal objCBLocal = new CBLocal();
        CBVisitas objCBVisitas = new CBVisitas();
        CBUsuario objCBUsuario = new CBUsuario();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtDatos = new DataTable();
        DataTable dtLista = new DataTable();
        DataTable dtListaS = new DataTable();
        DataTable dtListaA = new DataTable();
        DataTable dtCargarLocal = new DataTable();
        DataTable dtCargarProyecto = new DataTable();
        DataTable dtKardex = new DataTable();
        protected string numUsuario;
        string strCod;
        string strDes;
        string LinkPag;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                numUsuario = Session["CodigoUsuario"].ToString();
                txtFechaA.Text = DateTime.Today.ToShortDateString();
                txtFechaD.Text = DateTime.Today.ToShortDateString();
                txtFechaH.Text = DateTime.Today.ToShortDateString();
                Session["Opc"] = 1;
                Listar_Parametros();
                Listar_Locales();
            }
        }

        private void Listar_Parametros()
        {
            dtListaPar = objCBPaciente.MostrarParametrosxId(5);
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("-----Todos-----", "0"));

            if (dtListaPar.Rows.Count > 0)
            {
                for (int i = 0; i < dtListaPar.Rows.Count; i++)
                {
                    strCod = dtListaPar.Rows[i][0].ToString();
                    strDes = dtListaPar.Rows[i][1].ToString();
                    ddlEstado.Items.Add(new ListItem(strDes, strCod));
                }
            }
        }

        private void Listar_Locales()
        {
            dtCargarLocal = objCBLocal.ListarLocalesxUser(int.Parse(Session["CodigoUsuario"].ToString()));

            if (dtCargarLocal.Rows.Count > 0)
            {
                ddlLocal.DataSource = dtCargarLocal;
                ddlLocal.DataValueField = dtCargarLocal.Columns[0].ToString();
                ddlLocal.DataTextField = dtCargarLocal.Columns[1].ToString();
                ddlLocal.DataBind();

                Listar_Proyectos();
            }
            else
            {
                ddlLocal.Items.Clear();
                ddlLocal.Items.Add(new ListItem("Locales no registrados", "0"));
            }
        }

        private void Listar_Proyectos()
        {
            dtCargarProyecto = objCBLocal.ListarProyectoxLocalxUser(int.Parse(ddlLocal.SelectedValue), int.Parse(Session["CodigoUsuario"].ToString()));
            ddlProyecto.Items.Clear();
            ddlProyecto.Items.Add(new ListItem("-----Todos-----", "0"));

            if (dtCargarProyecto.Rows.Count > 0)
            {
                for (int i = 0; i < dtCargarProyecto.Rows.Count; i++)
                {
                    strCod = dtCargarProyecto.Rows[i][0].ToString();
                    strDes = dtCargarProyecto.Rows[i][1].ToString();
                    ddlProyecto.Items.Add(new ListItem(strDes, strCod));
                }
                if (ddlProyecto.Items.Count > -1)
                {
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
            else
            {
                ddlProyecto.Items.Clear();
                ddlProyecto.Items.Add(new ListItem("No hay Proyectos asignados a este local", "0"));
                gvListado.Visible = false;
                gvListado.DataSource = null;

            }
        }

        private void BusquedaSimple()
        {
            Session["Opc"] = 1;
            dtListaS = objCBVisitas.GetBusquedaVisitasS(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), int.Parse(ddlEstado.SelectedValue), txtFechaA.Text);

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

        private void BusquedaAvanzada()
        {
            Session["Opc"] = 2;
            dtListaA = objCBVisitas.GetBusquedaVisitasA(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), int.Parse(ddlEstado.SelectedValue), txtFechaD.Text, txtFechaH.Text, txtNombres.Text);

            if (dtListaA.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtListaA;
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

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocal.Items.Count > -1)
            {
                Listar_Proyectos();
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
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

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visita")
            {
                Response.Redirect("~/Data/WFListadoVisitasD.aspx?CodigoPaciente=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Salida")
            {
                int respuesta;
                GridViewRow dgi = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCodigoPaciente = (Label)dgi.FindControl("lblCodigoPaciente");
                Label lblCodigoLocal = (Label)dgi.FindControl("lblCodigoLocal");
                Label lblCodigoProyecto = (Label)dgi.FindControl("lblCodigoProyecto");
                Label lblCodigoVisita = (Label)dgi.FindControl("lblCodigoVisita");
                Label lblCodigoVisitas = (Label)dgi.FindControl("lblCodigoVisitas");
                Label lblFechaVisita = (Label)dgi.FindControl("lblFechaVisita");

                respuesta = objCBVisitas.RegistraKardex(int.Parse(lblCodigoLocal.Text), int.Parse(lblCodigoProyecto.Text), int.Parse(lblCodigoVisita.Text), int.Parse(lblCodigoVisitas.Text), lblCodigoPaciente.Text, lblFechaVisita.Text, int.Parse(Session["CodigoUsuario"].ToString()));

                if (Session["Opc"].ToString() == "1")
                {
                    BusquedaSimple();
                }
                else
                {
                    BusquedaAvanzada();
                }
            }
            if (e.CommandName == "Entrada")
            {
                int respuesta;
                GridViewRow dgi = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCodigoPaciente = (Label)dgi.FindControl("lblCodigoPaciente");
                Label lblCodigoKardex = (Label)dgi.FindControl("lblCodigoKardex");

                respuesta = objCBVisitas.EditarKardex(int.Parse(lblCodigoKardex.Text), lblCodigoPaciente.Text, int.Parse(Session["CodigoUsuario"].ToString()));

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

        protected void gvListado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                HyperLink hypCRF = (HyperLink)e.Row.FindControl("hypCRF");
                HyperLink hypError = (HyperLink)e.Row.FindControl("hypError");
                LinkButton linkD1 = (LinkButton)e.Row.FindControl("linkD1");
                LinkButton linkD2 = (LinkButton)e.Row.FindControl("linkD2");
                LinkButton linkD3 = (LinkButton)e.Row.FindControl("linkD3");
                string EstadoK = ((DataRowView)(e.Row.DataItem))["Estado"].ToString();
                string CodigoKardex = ((DataRowView)(e.Row.DataItem))["CodigoKardex"].ToString();
                string CodigoEstadoVisita = ((DataRowView)(e.Row.DataItem))["CodigoEstadoVisita"].ToString();
                string FlagTAM = ((DataRowView)(e.Row.DataItem))["TAM"].ToString();
                string strTAM = ((DataRowView)(e.Row.DataItem))["Id_TAM"].ToString();
                string FlagENR = ((DataRowView)(e.Row.DataItem))["ENR"].ToString();
                string strENR = ((DataRowView)(e.Row.DataItem))["Id_ENR"].ToString();
                numUsuario = Session["CodigoUsuario"].ToString();
                LinkPag = System.Configuration.ConfigurationManager.AppSettings["LinkPag"];

                linkD1.Visible = false;
                linkD2.Visible = false;
                linkD3.Visible = false;

                hypError.Attributes.Add("onClick", "window.open('WFRegistrarErrores.aspx?CodigoPaciente=" + DataBinder.Eval(e.Row.DataItem, "CodigoPaciente") + "&CodigoLocal=" + DataBinder.Eval(e.Row.DataItem, "CodigoLocal") + "&CodigoProyecto=" + DataBinder.Eval(e.Row.DataItem, "CodigoProyecto") + "&CodigoUsuario=" + numUsuario + "','PageW','width=650,height=480,scrollbars=no,center=yes,status=no,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");
                hypError.Text = "Errores";
                hypError.ToolTip = "Registrar errores";

                if (CodigoKardex == "")//&& CodigoEstadoVisita == "1"
                {
                    linkD1.Visible = true;
                }
                if (CodigoKardex != "" && EstadoK == "1")
                {
                    linkD2.Visible = true;
                }
                if (CodigoKardex != "" && EstadoK == "0")
                {
                    linkD3.Visible = true;
                }

                if (strTAM == "" && FlagTAM == "1")
                {
                    hypCRF.NavigateUrl = "";
                    hypCRF.ToolTip = "";
                }
                else
                {
                    hypCRF.Attributes.Add("onClick", "window.open('" + LinkPag + "/WSData/WFInter.aspx?vIDTAM=" + DataBinder.Eval(e.Row.DataItem, "Id_TAM") + "&vCodigoLocal=" + DataBinder.Eval(e.Row.DataItem, "CodigoLocal") + "&vCodigoProyecto=" + DataBinder.Eval(e.Row.DataItem, "CodigoProyecto") + "&vCodigoGrupoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoGrupoVisita") + "&vCodigoVisita=" + DataBinder.Eval(e.Row.DataItem, "CodigoVisita") + "&vFechaVisita=" + DataBinder.Eval(e.Row.DataItem, "FechaNVisita") + "&vSexo=" + DataBinder.Eval(e.Row.DataItem, "sexo") + "&vCodigoUsuario=" + numUsuario + "&vOrganizacion=1&vIdioma=01&vRol=2" + "','PageW','width=800,height=600,scrollbars=yes,center=yes,status=yes,menubar=no,top=0,left=0,toolbar=no,resizable=no'); return false;");
                    hypCRF.Text = "CRF";
                    hypCRF.ToolTip = "Registro de CRF";
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaSimple();
        }

        protected void btnBusquedaA_Click(object sender, EventArgs e)
        {
            txtFechaA.Visible = false;
            lblFecha.Visible = false;
            btnBusquedaA.Visible = false;
            btnBuscar.Visible = false;

            pBusquedaA.Visible = true;
            txtFechaD.Visible = true;
            lblFechaD.Visible = true;
            txtFechaH.Visible = true;
            lblFechaH.Visible = true;
            txtNombres.Visible = true;
            lblNom.Visible = true;
            btnBuscarAvanzada.Visible = true;
            btnBusquedaS.Visible = true;
        }

        protected void btnBuscarAvanzada_Click(object sender, EventArgs e)
        {
            BusquedaAvanzada();
        }

        protected void btnBusquedaS_Click(object sender, EventArgs e)
        {
            txtFechaA.Visible = true;
            lblFecha.Visible = true;
            btnBusquedaA.Visible = true;
            btnBuscar.Visible = true;

            pBusquedaA.Visible = false;
            txtFechaD.Visible = false;
            lblFechaD.Visible = false;
            txtFechaH.Visible = false;
            lblFechaH.Visible = false;
            txtNombres.Visible = false;
            lblNom.Visible = false;
            btnBuscarAvanzada.Visible = false;
            btnBusquedaS.Visible = false;
        }

    }
}