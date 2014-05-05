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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        CBUsuario objCBUsuario = new CBUsuario();
        CBLocal objCBLocal = new CBLocal();
        DataTable dtListaLocal = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUser.Text = Session["LoginUsuario"].ToString();

                DataTable menuData = null;
                try
                {
                    menuData = new DataTable();
                    menuData = objCBUsuario.GetMenuData(int.Parse(Session["CodigoUsuario"].ToString()));
                    AddTopMenuItems(menuData);

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);

                }
                finally
                {
                    menuData = null;

                }
            }
        }

        private void AddTopMenuItems(DataTable menuData)
        {
            DataView view = null;
            try
            {
                view = new DataView(menuData);
                view.RowFilter = "ParentID IS NULL";
                foreach (DataRowView row in view)
                {
                    //Adding the menu item
                    MenuItem newMenuItem = new MenuItem(row["Text"].ToString(), row["MenuID"].ToString());
                    menuBar.Items.Add(newMenuItem);
                    AddChildMenuItems(menuData, newMenuItem);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                view = null;
            }
        }

        private void AddChildMenuItems(DataTable menuData, MenuItem parentMenuItem)
        {
            DataView view = null;
            try
            {
                view = new DataView(menuData);
                view.RowFilter = "ParentID=" + parentMenuItem.Value;
                foreach (DataRowView row in view)
                {
                    MenuItem newMenuItem = new MenuItem(row["Text"].ToString(), row["MenuID"].ToString());
                    newMenuItem.NavigateUrl = row["NavigateUrl"].ToString();
                    parentMenuItem.ChildItems.Add(newMenuItem);

                    AddChildMenuItems(menuData, newMenuItem);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                view = null;
            }
        }

        protected void lkSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WFLogin.aspx", false);
        }

        protected void lkbNomP_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WFPrincipal.aspx", false);
        }

    }
}
