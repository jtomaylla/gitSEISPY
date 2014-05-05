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
    public partial class WFVisitasNew : System.Web.UI.Page
    {
        CBPaciente objCBPaciente = new CBPaciente();
        CBVisitas objCBVisitas = new CBVisitas();
        CBProyecto objCBProyecto = new CBProyecto();
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaPY = new DataTable();
        DataTable dtLista = new DataTable();
        DataTable dtListaGrupo = new DataTable();
        DataTable dtListaVisitasAncla = new DataTable();
        string strCod;
        string strDes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Parametros();
                Listar_Proyecto();
                //Listar_GrupoAncla();
                //Listar_VisitasAncla();
            }
        }

        private void Listar_GrupoAncla()
        {
            dtListaGrupo = objCBVisitas.CargarGrupoVisitaxProy(int.Parse(ddlProyecto.SelectedValue));

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
            dtListaVisitasAncla = objCBVisitas.CargarVisitaxProy(int.Parse(ddlProyecto.SelectedValue), int.Parse(ddlGrupoAncla.SelectedValue));
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

        private void Listar_Proyecto()
        {
            dtListaPY = objCBProyecto.ListarProyectos();

            if (dtListaPY.Rows.Count > 0)
            {
                ddlProyecto.DataSource = dtListaPY;
                ddlProyecto.DataValueField = dtListaPY.Columns[0].ToString();
                ddlProyecto.DataTextField = dtListaPY.Columns[1].ToString();
                ddlProyecto.DataBind();

                Listar_GrupoAncla();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;
                int vAuto = 0;

                if (ckbAuto.Checked == true)
                { vAuto = 1; }

                Num_Rpta = objCBVisitas.RegistraVisita(int.Parse(ddlProyecto.SelectedValue), int.Parse(ddlGrupo.SelectedValue), txtNombre.Text, txtDescripcion.Text, vAuto, int.Parse(txtDiasProxV.Text), int.Parse(ddlGrupoAncla.SelectedValue), int.Parse(ddlVisitaAncla.SelectedValue), int.Parse(txtVentI.Text), int.Parse(txtVentS.Text));

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

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
                Listar_GrupoAncla();
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