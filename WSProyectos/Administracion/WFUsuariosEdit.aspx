<%@ Page Title="Editar Usuario" Language="C#" AutoEventWireup="true" CodeBehind="WFUsuariosEdit.aspx.cs" Inherits="WSProyectos.Administracion.WFUsuariosEdit" MasterPageFile="~/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
            </Scripts>
        </asp:ScriptManager>

       <asp:Panel ID="Panel1" runat="server" Width="700px">
            <table style="width: 700px">
            <tr>
                <td colspan="2"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Editar Usuario"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblSede" runat="server" CssClass="TitulitosSub" Text="Local:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLocal" runat="server" AutoPostBack="False" CssClass="textbox1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label2" runat="server" CssClass="TitulitosSub" Text="Login:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server" CssClass="textbox1" MaxLength="20" 
                            Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldLogin" runat="server" 
                            ControlToValidate="txtLogin" ErrorMessage="Debe ingresar el login del usuario" 
                            ForeColor="Red" ValidationGroup="usuario">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label3" runat="server" CssClass="TitulitosSub" 
                            Text="Apellidos y Nombres:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="150" Width="400px" 
                            CssClass="textbox1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldNombre" runat="server" ControlToValidate="txtNombre"
                            ErrorMessage="Debe ingresar el nombre completo de la persona" ForeColor="Red" ValidationGroup="usuario">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label6" runat="server" CssClass="TitulitosSub" 
                            Text="Iniciales:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtIniciales" runat="server" MaxLength="5" Width="70px" 
                            CssClass="textbox1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label7" runat="server" CssClass="TitulitosSub" 
                            Text="Correo electrónico:"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="150" Width="280px" 
                            CssClass="textbox1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmail" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Debe ingresar un correo válido" 
                            ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="usuario">*</asp:RegularExpressionValidator>
                        </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label8" runat="server" CssClass="TitulitosSub" Text="Estado:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="textbox1">
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblCodigoUsuario" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Editar" 
                            ValidationGroup="usuario" onclick="btnAceptar_Click" >Editar</asp:LinkButton>&nbsp; &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
                SkinID="label_vacio"></asp:Label>
            <br />
        </asp:Panel>
    </div>

</asp:Content>
