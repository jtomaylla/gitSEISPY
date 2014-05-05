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
    public partial class WFVisitasEdit : System.Web.UI.Page
    {
        CBPaciente objCBPaciente = new CBPaciente();
        CBVisitas objCBVisitas = new CBVisitas();
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaPY = new DataTable();
        DataTable dtCargar = new DataTable();
        DataTable dtListaGrupo = new DataTable();
        DataTable dtListaVisitasAncla = new DataTable();
        protected string vCodigoGrupoVisita;
        protected string vCodigoVisita;
        protected string vCodigoProyecto;
        string strCod;
        string strDes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Parametros();

                vCodigoGrupoVisita = Request.QueryString["CodigoGrupoVisita"].ToString();
                Session["vCodigoGrupoVisita"] = Request.QueryString["CodigoGrupoVisita"].ToString();
                vCodigoVisita = Request.QueryString["CodigoVisita"].ToString();
                Session["vCodigoVisita"] = Request.QueryString["CodigoVisita"].ToString();
                lblIdPY.Text = Request.QueryString["CodigoProyecto"].ToString();
                Listar_Proyecto(int.Parse(lblIdPY.Text));
                Listar_GrupoAncla();
                Cargar(int.Parse(lblIdPY.Text), int.Parse(vCodigoGrupoVisita), int.Parse(vCodigoVisita));
            }
        }

        private void Cargar(int CodigoProyecto, int CodigoGrupoVisita, int CodigoVisita)
        {
            dtCargar = objCBVisitas.ListarVisitaxIdxProy(CodigoProyecto, CodigoGrupoVisita, CodigoVisita);

            if (dtCargar.Rows.Count > 0)
            {
                ddlGrupo.SelectedValue = dtCargar.Rows[0]["CodigoGrupoVisita"].ToString();
                ddlGrupoAncla.SelectedValue = dtCargar.Rows[0]["CodigoGrupoVisitaProx"].ToString();
                ddlVisitaAncla.SelectedValue = dtCargar.Rows[0]["CodigoVisitaProx"].ToString();
                txtNombre.Text = dtCargar.Rows[0]["Nombre"].ToString();
                txtDescripcion.Text = dtCargar.Rows[0]["Descripcion"].ToString();
                txtDiasProxV.Text = dtCargar.Rows[0]["DiasVisitaProx"].ToString();
                txtVentI.Text = dtCargar.Rows[0]["DiasAntes"].ToString();
                txtVentS.Text = dtCargar.Rows[0]["DiasDespues"].ToString();
                txtOrden.Text = dtCargar.Rows[0]["OrdenVisita"].ToString();
                string vEstado = dtCargar.Rows[0]["Estado"].ToString();
                string vAuto = dtCargar.Rows[0]["Auto"].ToString();

                if (vEstado == "1")
                {
                    ckbEstado.Checked = true;
                }
                else
                {
                    ckbEstado.Checked = false;
                }

                if (vAuto == "1")
                {
                    ckbAuto.Checked = true;
                }
                else
                {
                    ckbAuto.Checked = false;
                }

            }
        }

        private void Listar_GrupoAncla()
        {
            dtListaGrupo = objCBVisitas.CargarGrupoVisitaxProy(int.Parse(lblIdPY.Text));

            if (dtListaGrupo.Rows.Count > 0)
            {
                ddlGrupoAncla.DataSource = dtListaGrupo;
                ddlGrupoAncla.DataValueField = dtListaGrupo.Columns[0].ToString();
                ddlGrupoAncla.DataTextField = dtListaGrupo.Columns[1].ToString();
                ddlGrupoAncla.DataBind();

                Listar_VisitasAncla();
            }
        }

        private void Listar_VisitasAncla()
        {
            dtListaVisitasAncla = objCBVisitas.CargarVisitaxProy(int.Parse(lblIdPY.Text), int.Parse(ddlGrupoAncla.SelectedValue));
            ddlVisitaAncla.Items.Clear();

            if (dtListaVisitasAncla.Rows.Count > 0)
            {
                for (int i = 0; i < dtListaVisitasAncla.Rows.Count; i++)
                {
                    strCod = dtListaVisitasAncla.Rows[i][0].ToString();
                    strDes = dtListaVisitasAncla.Rows[i][1].ToString();
                    ddlVisitaAncla.Items.Add(new ListItem(strDes, strCod));
                }

            }
            else
            {
                ddlVisitaAncla.Items.Clear();
                ddlVisitaAncla.Items.Add(new ListItem("Visita Inicial", "0"));
            }
        }

        private void Listar_Parametros()
        {
            dtListaGrupo = objCBPaciente.MostrarParametrosxId(3);

            if (dtListaGrupo.Rows.Count > 0)
            {
                ddlGrupo.DataSource = dtListaGrupo;
                ddlGrupo.DataValueField = dtListaGrupo.Columns[0].ToString();
                ddlGrupo.DataTextField = dtListaGrupo.Columns[1].ToString();
                ddlGrupo.DataBind();
            }
        }

        private void Listar_Proyecto(int IdProyecto)
        {
            dtListaPY = objCBProyecto.ListarProyectosxID(IdProyecto);

            if (dtListaPY.Rows.Count > 0)
            {
                txtNomProyecto.Text = dtListaPY.Rows[0]["Nombre"].ToString();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;
                int vAuto = 0;
                int vEstado = 0;

                if (ckbEstado.Checked == true)
                { vEstado = 1; }

                if (ckbAuto.Checked == true)
                { vAuto = 1; }

                Num_Rpta = objCBVisitas.EditarVisita(int.Parse(lblIdPY.Text), int.Parse(ddlGrupo.SelectedValue), int.Parse(Session["vCodigoVisita"].ToString()), txtNombre.Text, txtDescripcion.Text, vAuto, int.Parse(txtDiasProxV.Text), int.Parse(ddlGrupoAncla.SelectedValue), int.Parse(ddlVisitaAncla.SelectedValue), int.Parse(txtVentI.Text), int.Parse(txtVentS.Text), int.Parse(txtOrden.Text), vEstado);

                if (Num_Rpta == -1 || Num_Rpta == 0)
                {
                    lblMensaje.Text = "Ocurrió un error al registrar";
                }
                else
                {
                    //lblMensaje.Text = "Se registró correctamente";
                    Response.Redirect("~/Administracion/WFVisitas.aspx", false);

                }
            }
        }

        protected void ddlGrupoAncla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGrupoAncla.Items.Count > -1)
            {
                Listar_VisitasAncla();
            }
        }


    }
}