using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Data;
using ClassData;
using ClassBusiness;

namespace WSProyectos.Administracion
{
    public partial class WFCodTamNew : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBVisitas objCBVisitas = new CBVisitas();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtCargarLocal = new DataTable();
        DataTable dtCargarProyecto = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar_Locales();
            }
        }

        private void Listar_Locales()
        {
            dtCargarLocal = objCBLocal.ListarLocales();

            if (dtCargarLocal.Rows.Count > 0)
            {
                ddlLocal.DataSource = dtCargarLocal;
                ddlLocal.DataValueField = dtCargarLocal.Columns[0].ToString();
                ddlLocal.DataTextField = dtCargarLocal.Columns[1].ToString();
                ddlLocal.DataBind();

                Listar_Proyectos();
            }
        }

        private void Listar_Proyectos()
        {
            dtCargarProyecto = objCBLocal.ListarProyectoxLocal(int.Parse(ddlLocal.SelectedValue));

            if (dtCargarProyecto.Rows.Count > 0)
            {
                btnAceptar.Visible = true;
                ddlProyecto.DataSource = dtCargarProyecto;
                ddlProyecto.DataValueField = dtCargarProyecto.Columns[0].ToString();
                ddlProyecto.DataTextField = dtCargarProyecto.Columns[1].ToString();
                ddlProyecto.DataBind();
            }
            else
            {
                btnAceptar.Visible = false;
                ddlProyecto.Items.Clear();
                ddlProyecto.Items.Add(new ListItem("No hay Proyectos asignados a este local", "0"));
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int Resultado;

            if (txtNumeros.Text != "")
            {
                Resultado = objCBVisitas.RegID_TAM(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), txtNumeros.Text);

                if (Resultado == 0 || Resultado == -1)
                {
                    lblMensaje.Text = "Error al registrar.";
                }
                else
                {
                    lblMensaje.Text = "Se registró con éxito.";
                }
            }
            else
            {
                lblMensaje.Text = "Ingresar el código";
            }
        }

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocal.Items.Count > -1)
            {
                Listar_Proyectos();
            }
        }
    }
}