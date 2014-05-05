<%@ Page Title="Registro de Locales" Language="C#" AutoEventWireup="true" CodeBehind="WFLocalesNew.aspx.cs" Inherits="WSProyectos.Administracion.WFLocalesNew" MasterPageFile="~/Site.Master"%>

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
                <td colspan="2"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Registro de Locales"></asp:Label>
</td></tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblEmpresa" runat="server" CssClass="TitulitosSub" 
                            Text="Empresa:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="False" 
                            CssClass="textbox1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label2" runat="server" CssClass="TitulitosSub" Text="Nombre:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="textbox1" MaxLength="50" 
                            Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label3" runat="server" CssClass="TitulitosSub" 
                            Text="Descripción:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="500" Width="400px" 
                            CssClass="textbox1" Height="30px" TextMode="MultiLine"></asp:TextBox>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label6" runat="server" CssClass="TitulitosSub" 
                            Text="Dirección:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" MaxLength="5" Width="400px" 
                            CssClass="textbox1" Height="30px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label8" runat="server" CssClass="TitulitosSub" 
                            Text="Distrito:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDistrito" runat="server" CssClass="textbox1" MaxLength="50" 
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label7" runat="server" CssClass="TitulitosSub" 
                            Text="Teléfono:"></asp:Label>
                        </td>
                    <td>
                    
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="textbox1" MaxLength="20" 
                            Width="100px"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label9" runat="server" CssClass="TitulitosSub" Text="Estatus:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbEstatus" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label10" runat="server" CssClass="TitulitosSub" Text="Estado:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbEstado" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" >Aceptar</asp:LinkButton>&nbsp; &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
                SkinID="label_vacio"></asp:Label>
            <br />
        </asp:Panel>
    </div>

</asp:Content>
