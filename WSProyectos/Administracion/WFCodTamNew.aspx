<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFCodTamNew.aspx.cs" Inherits="WSProyectos.Administracion.WFCodTamNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>ID TAMIZAJE</title>
   <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

	</head>
<body>
    <form id="form1" runat="server">
    <div>
          <table align="left" style="width: 350px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updUsuario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table>
                           <tr>
                            <td colspan="3">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                               </td>
                        </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label1" runat="server" CssClass="Titulitos" 
                                        Text="Registrar Código de Tamizaje"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Local" runat="server" CssClass="TitulitosSub" Text="Local:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLocal" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlLocal_SelectedIndexChanged" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY0" runat="server" CssClass="TitulitosSub" Text="Proyecto:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="textbox1" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY1" runat="server" CssClass="TitulitosSub" 
                                        Text="Código TAM:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumeros" runat="server" CssClass="textbox1" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                                           <tr>
                    <td colspan="3">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Aceptar" 
                            onclick="btnAceptar_Click" ></asp:LinkButton>&nbsp; &nbsp;
                    </td>
                </tr>
                        </table>
                    </asp:Panel>
                                                                <div style="text-align:center"><asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label></div>

                     </ContentTemplate>

                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
  
    </div>
    </form>
</body>
</html>
