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
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.Reflection;

namespace WSProyectos.Administracion
{
    public partial class WFGenerarCodTAM : System.Web.UI.Page
    {
        CBProyecto objCBProyecto = new CBProyecto();
        CBVisitas objCBVisitas = new CBVisitas();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtCargarLocal = new DataTable();
        DataTable dtCargarProyecto = new DataTable();
        public int[,] a = new int[9, 11];
        public int[,] Op = new int[11, 11];
        public int[] Inv = new int[11];
        public int i;
        public int j;
        public int Numero;
        public string NumString;
        public string cadenita;
        public string Reverso;
        private object opc = Type.Missing;
        DataTable dtListado = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            a[0, 0] = 0;
            a[0, 1] = 1;
            a[0, 2] = 2;
            a[0, 3] = 3;
            a[0, 4] = 4;
            a[0, 5] = 5;
            a[0, 6] = 6;
            a[0, 7] = 7;
            a[0, 8] = 8;
            a[0, 9] = 9;

            a[1, 0] = 1;
            a[1, 1] = 5;
            a[1, 2] = 7;
            a[1, 3] = 6;
            a[1, 4] = 2;
            a[1, 5] = 8;
            a[1, 6] = 3;
            a[1, 7] = 0;
            a[1, 8] = 9;
            a[1, 9] = 4;

            for (i = 2; i <= 7; i++)
            {
                for (j = 0; j <= 9; j++)
                {
                    a[i, j] = a[i - 1, a[1, j]];
                }
            }

            Op[0, 0] = 0;
            Op[0, 1] = 1;
            Op[0, 2] = 2;
            Op[0, 3] = 3;
            Op[0, 4] = 4;
            Op[0, 5] = 5;
            Op[0, 6] = 6;
            Op[0, 7] = 7;
            Op[0, 8] = 8;
            Op[0, 9] = 9;

            Op[1, 0] = 1;
            Op[1, 1] = 2;
            Op[1, 2] = 3;
            Op[1, 3] = 4;
            Op[1, 4] = 0;
            Op[1, 5] = 6;
            Op[1, 6] = 7;
            Op[1, 7] = 8;
            Op[1, 8] = 9;
            Op[1, 9] = 5;

            Op[2, 0] = 2;
            Op[2, 1] = 3;
            Op[2, 2] = 4;
            Op[2, 3] = 0;
            Op[2, 4] = 1;
            Op[2, 5] = 7;
            Op[2, 6] = 8;
            Op[2, 7] = 9;
            Op[2, 8] = 5;
            Op[2, 9] = 6;

            Op[3, 0] = 3;
            Op[3, 1] = 4;
            Op[3, 2] = 0;
            Op[3, 3] = 1;
            Op[3, 4] = 2;
            Op[3, 5] = 8;
            Op[3, 6] = 9;
            Op[3, 7] = 5;
            Op[3, 8] = 6;
            Op[3, 9] = 7;

            Op[4, 0] = 4;
            Op[4, 1] = 0;
            Op[4, 2] = 1;
            Op[4, 3] = 2;
            Op[4, 4] = 3;
            Op[4, 5] = 9;
            Op[4, 6] = 5;
            Op[4, 7] = 6;
            Op[4, 8] = 7;
            Op[4, 9] = 8;

            Op[5, 0] = 5;
            Op[5, 1] = 9;
            Op[5, 2] = 8;
            Op[5, 3] = 7;
            Op[5, 4] = 6;
            Op[5, 5] = 0;
            Op[5, 6] = 4;
            Op[5, 7] = 3;
            Op[5, 8] = 2;
            Op[5, 9] = 1;

            Op[6, 0] = 6;
            Op[6, 1] = 5;
            Op[6, 2] = 9;
            Op[6, 3] = 8;
            Op[6, 4] = 7;
            Op[6, 5] = 1;
            Op[6, 6] = 0;
            Op[6, 7] = 4;
            Op[6, 8] = 3;
            Op[6, 9] = 2;

            Op[7, 0] = 7;
            Op[7, 1] = 6;
            Op[7, 2] = 5;
            Op[7, 3] = 9;
            Op[7, 4] = 8;
            Op[7, 5] = 2;
            Op[7, 6] = 1;
            Op[7, 7] = 0;
            Op[7, 8] = 4;
            Op[7, 9] = 3;

            Op[8, 0] = 8;
            Op[8, 1] = 7;
            Op[8, 2] = 6;
            Op[8, 3] = 5;
            Op[8, 4] = 9;
            Op[8, 5] = 3;
            Op[8, 6] = 2;
            Op[8, 7] = 1;
            Op[8, 8] = 0;
            Op[8, 9] = 4;

            Op[9, 0] = 9;
            Op[9, 1] = 8;
            Op[9, 2] = 7;
            Op[9, 3] = 6;
            Op[9, 4] = 5;
            Op[9, 5] = 4;
            Op[9, 6] = 3;
            Op[9, 7] = 2;
            Op[9, 8] = 1;
            Op[9, 9] = 0;

            Inv[0] = 0;
            Inv[1] = 4;
            Inv[2] = 3;
            Inv[3] = 2;
            Inv[4] = 1;
            Inv[5] = 5;
            Inv[6] = 6;
            Inv[7] = 7;
            Inv[8] = 8;
            Inv[9] = 9;


            if (!IsPostBack)
            {
                Listar_Locales();
                BusquedaSimple();
            }
        }

        private void BusquedaSimple()
        {
            dtListado = objCBProyecto.ListarCodTamizaje(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), "");

            if (dtListado.Rows.Count > 0)
            {
                gvListado.Visible = true;
                gvListado.DataSource = dtListado;
                gvListado.DataBind();
                gvListado.SelectedIndex = -1;
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
                btnExportar.Visible = true;
            }
            else
            {
                btnExportar.Visible = false;
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se encontró registros...";
                gvListado.Visible = false;
            }
        }

        public void Reversa()
        {
            int n = 0;

            Reverso = "";
            for (n = 0; n <= (NumString.Length) - 1; n++)
            {
                int vIndex = NumString.Length - n;
                Reverso = Reverso + NumString.Substring(vIndex - 1, 1);
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

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLocal.Items.Count > -1)
            {
                Listar_Proyectos();
                BusquedaSimple();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int m;
            int k;
            int x;
            int Chequeo;
            string Cadena;
            string Sede;
            string Proy;

            k = 1;
            Sede = ("00" + ddlLocal.SelectedValue);
            Sede = Sede.Substring((Sede.Length - 3));
            Proy = ("00" + ddlProyecto.SelectedValue);
            Proy = Proy.Substring((Proy.Length - 3));

            int NumTotal = int.Parse(txtInicio.Text) + int.Parse(txtNumeros.Text) - 1;

            for (m = int.Parse(txtInicio.Text); m <= NumTotal; m++)
            {
                Numero = m;
                NumString = (Sede + (Proy + (("0000" + Numero.ToString())).Substring((("0000" + Numero.ToString()).Length - 4))));
                Reversa();
                Cadena = Reverso;
                Chequeo = 0;
                for (x = 1; (x <= Cadena.Length); x++)
                {
                    int vCant = int.Parse(Cadena.Substring((x - 1), 1));
                    Chequeo = Op[Chequeo, a[(x % 8), vCant]];
                }
                cadenita = ("" + (Sede + (Proy + ("-" + ((("0000" + Numero.ToString())).Substring((("0000" + Numero.ToString()).Length - 4)) + ("-" + Inv[Chequeo]))))));
                objCBVisitas.RegID_TAM(int.Parse(ddlLocal.SelectedValue),int.Parse(ddlProyecto.SelectedValue),cadenita);
                k = (k + 1);
            }
            BusquedaSimple();

        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyecto.Items.Count > -1)
            {
                BusquedaSimple();
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            gvListado.DataBind();
            BusquedaSimple();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gvListado.EnableViewState = false;
            gvListado.AllowPaging = false;
            dtListado = objCBProyecto.ListarCodTamizaje(int.Parse(ddlLocal.SelectedValue), int.Parse(ddlProyecto.SelectedValue), "");
            gvListado.DataSource = dtListado;
            gvListado.DataBind();

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gvListado);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";//xls
            Response.AddHeader("Content-Disposition", "attachment;filename=Lista de codigos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

        }


    }
}