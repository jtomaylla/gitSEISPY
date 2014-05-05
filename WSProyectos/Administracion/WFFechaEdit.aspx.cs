using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassData;
using ClassBusiness;
using System.Threading;

namespace WSProyectos.Administracion
{
    public partial class WFFechaEdit : System.Web.UI.Page
    {
        CBVisitas objCBVisitas = new CBVisitas();
        CBPaciente objCBPaciente = new CBPaciente();
        DataTable dtListaPar = new DataTable();
        DataTable dtMostrar = new DataTable();
        protected string numUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

                Session["vCodigoProyecto"] = Request["vCodigoProyecto"].ToString();
                Session["vCodigoLocal"] = Request["vCodigoLocal"].ToString();
                Session["vCodigoPaciente"] = Request["vCodigoPaciente"].ToString();
                Session["vCodigoUsuario"] = Request["vCodigoUsuario"].ToString();
                Session["vCodigoVisita"] = Request["vCodigoVisita"].ToString();
                Session["vCodigoVisitas"] = Request["vCodigoVisitas"].ToString();
                Session["vCodigoEstadoVisita"] = Request["vCodigoEstadoVisita"].ToString();
                Session["vFechaVisita"] = Request["vFechaVisita"].ToString();

                Mostrar_Cabecera();
                txtFecha.Text = Session["vFechaVisita"].ToString();
            }
        }

        private void Mostrar_Cabecera()
        {
            dtMostrar = objCBVisitas.ListarDatosxPaciente(int.Parse(Session["vCodigoLocal"].ToString()), int.Parse(Session["vCodigoProyecto"].ToString()), Session["vCodigoPaciente"].ToString());

            if (dtMostrar.Rows.Count > 0)
            {
                txtPaciente.Text = dtMostrar.Rows[0]["NombreCompleto"].ToString();
            }
        }

        protected void lkbAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Num_Rpta = 0;

                Num_Rpta = objCBVisitas.ActualizarFechaVAdmin(int.Parse(Session["vCodigoLocal"].ToString()), int.Parse(Session["vCodigoProyecto"].ToString()), int.Parse(Session["vCodigoVisita"].ToString()), int.Parse(Session["vCodigoVisitas"].ToString()), Session["vCodigoPaciente"].ToString(), txtFecha.Text);

                if (Num_Rpta == -1 || Num_Rpta == 0)
                {
                    lblMensaje.Text = "Ocurrió un error al registrar";
                }
                else
                {
                    lblMensaje.Text = "Se actualizó correctamente";
                }
            }
        }

    }
}