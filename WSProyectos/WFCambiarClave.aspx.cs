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

namespace WSProyectos
{
    public partial class WFCambiarClave : System.Web.UI.Page
    {
        CDUsuario objCDUsuario = new CDUsuario();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblIdUser.Text = Session["CodigoUsuario"].ToString();
                txtClaveA.Text = Session["LoginUsuario"].ToString();

            }

        }

        protected void lkbGrabar_Click(object sender, EventArgs e)
        {
            string mensaje;

            dt = objCDUsuario.GetCambiarClave(int.Parse(lblIdUser.Text), txtClaveA.Text, txtClaveN.Text);
            mensaje = dt.Rows[0]["Respuesta"].ToString();

            if (mensaje == "1")
            {
                lblMensaje.Text = "Contraseña anterior errada. Por favor, trate de nuevo.";
            }
            if (mensaje == "2")
            {
                lblMensaje.Text = "Contraseña no debe ser igual al login. Por favor, trate de nuevo.";
            }
            if (mensaje == "3")
            {
                lblMensaje.Text = "Contraseña debe tener una longitud mayor o igual a 10 caracteres";
            }

            if (mensaje == "4")
            {
                lblMensaje.Text = "";

                Session["CodigoUsuario"] = dt.Rows[0]["CodigoUsuario"].ToString();
                Session["CodigoEmpresa"] = dt.Rows[0]["CodigoEmpresa"].ToString();
                Response.Redirect("~/WFPrincipal.aspx");
            }		

        }
    }
}