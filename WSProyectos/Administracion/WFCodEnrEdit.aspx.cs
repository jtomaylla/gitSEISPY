using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassData;
using ClassBusiness;

namespace WSProyectos.Administracion
{
    public partial class WFCodEnrEdit : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["vCodigoProyecto"] = Request["vCodigoProyecto"].ToString();
                Session["vCodigoLocal"] = Request["vCodigoLocal"].ToString();
                Session["vCodigoUsuario"] = Request["vCodigoUsuario"].ToString();
                Session["vCodigoENR"] = Request["vCodigoENR"].ToString();
                Session["vLocal"] = Request["vLocal"].ToString();
                Session["vProyecto"] = Request["vProyecto"].ToString();
                Session["vNumero"] = Request["vNumero"].ToString();
                txtLocal.Text = Session["vLocal"].ToString();
                txtProyecto.Text = Session["vProyecto"].ToString();
                txtNumeros.Text = Session["vNumero"].ToString();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int Resultado;
            Resultado = objCBProyecto.EditCodENR(int.Parse(Session["vCodigoLocal"].ToString()), int.Parse(Session["vCodigoProyecto"].ToString()), int.Parse(Session["vCodigoENR"].ToString()), txtNumeros.Text);

            if (Resultado == 0 || Resultado == -1)
            {
                lblMensaje.Text = "Error al modificar";
            }
            else
            {
                lblMensaje.Text = "Se modificadó satisfactoriamente";
            }
        }
    }
}