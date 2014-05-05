<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFLogin.aspx.cs" Inherits="WSProyectos.WFLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
   <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
 <table cellspacing="20" cellpadding="20" style="width: 800px; border:0px; padding:0px; border-collapse:collapse" align="center">
            <tr>
                <td style="width: 150px">
                </td>
              
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                </td>
                <td style="width: 500px" align="center">

                            <table style="width: 400px; border:0px; padding:4px; border-collapse: collapse">
                                <tr>
                                    <td align="center">
                                        <table style="border:0px; padding:0px; width: 380px; border-collapse:separate">
                                            <tr align="center">
                                          <td colspan="2">
                                            <asp:Label ID="lblTitulo" runat="server" Text="SEIS PROYECTOS" CssClass="TitulitoLog"></asp:Label><br />
                                                <br />
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="height:26px">
                                                    <asp:Label CssClass="body_textLog" ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="textboxLog"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="height:26px">
                                                    <asp:Label CssClass="body_textLog" ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Password" runat="server" CssClass="textboxLog" 
                                                        TextMode="Password" AutoPostBack="True" 
                                                        ontextchanged="Password_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="height:26px">
                                                    <asp:Label ID="PasswordLabel0" runat="server" AssociatedControlID="Password" 
                                                        CssClass="body_textLog">Local:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlLocal" runat="server" CssClass="textboxLog">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red">
                                                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" 
                                                        ForeColor="Highlight"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                   <asp:LinkButton ID="LoginButton" runat="server" Font-Bold="True" 
                                                        SkinID="label_link" CommandName="Login" ValidationGroup="logeo" 
                                                        onclick="LoginButton_Click">Inicio</asp:LinkButton>

                                                                        </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
         
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                </td>
                <td style="width: 500px">
                </td>
                <td style="width: 150px">
                </td>
            </tr>
        </table>   
    </div>
    </form>
</body>
</html>