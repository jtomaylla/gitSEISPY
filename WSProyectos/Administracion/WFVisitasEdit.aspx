<%@ Page Title="Editar Visitas" Language="C#" AutoEventWireup="true" CodeBehind="WFVisitasEdit.aspx.cs" Inherits="WSProyectos.Administracion.WFVisitasEdit" MasterPageFile="~/Site.Master"%>
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
                <td colspan="2"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Editar Visitas"></asp:Label>
</td></tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblIdPY" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblEmpresa" runat="server" CssClass="TitulitosSub" 
                            Text="Proyecto:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNomProyecto" runat="server" CssClass="textbox1" 
                            MaxLength="50" ReadOnly="True" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblEmpresa0" runat="server" CssClass="TitulitosSub" 
                            Text="Grupo Visita:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="False" 
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
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label11" runat="server" CssClass="TitulitosSub" 
                            Text="Descripción:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="textbox1" 
                            MaxLength="50" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label12" runat="server" CssClass="TitulitosSub" 
                            Text="# Días Próxima Visita:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiasProxV" runat="server" CssClass="textbox1" MaxLength="3" 
                            Width="70px">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label18" runat="server" CssClass="TitulitosSub" 
                            Text="Grupo Ancla:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGrupoAncla" runat="server" AutoPostBack="True" 
                            CssClass="textbox1" onselectedindexchanged="ddlGrupoAncla_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label13" runat="server" CssClass="TitulitosSub" 
                            Text="Visita Ancla:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVisitaAncla" runat="server" AutoPostBack="False" 
                            CssClass="textbox1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label14" runat="server" CssClass="TitulitosSub" 
                            Text="Ventana Inferior:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVentI" runat="server" CssClass="textbox1" MaxLength="2" 
                            Width="70px">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label15" runat="server" CssClass="TitulitosSub" 
                            Text="Ventana Superior:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVentS" runat="server" CssClass="textbox1" MaxLength="2" 
                             Width="70px">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label7" runat="server" CssClass="TitulitosSub" 
                            Text="Nro. Orden:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrden" runat="server" CssClass="textbox1" MaxLength="5" 
                            Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label17" runat="server" CssClass="TitulitosSub" 
                            Text="Automático:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbAuto" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label10" runat="server" CssClass="TitulitosSub" Text="Estado:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbEstado" runat="server" Checked="True" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Aceptar" 
                            onclick="btnAceptar_Click">Aceptar</asp:LinkButton>&nbsp; &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
                SkinID="label_vacio"></asp:Label>
            <br />
        </asp:Panel>
    </div>

</asp:Content>
