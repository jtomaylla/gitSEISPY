<%@ Page Title="Registro de Proyectos" Language="C#" AutoEventWireup="true" CodeBehind="WFProyectosNew.aspx.cs" Inherits="WSProyectos.Administracion.WFProyectosNew" MasterPageFile="~/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false">
        </asp:ScriptManager>  
            <table style="width: 700px">
            <tr><td>
              <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
         
       <asp:Panel ID="Panel1" runat="server" Width="700px">
            <table style="width: 700px">
            <tr>
                <td colspan="2"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Registro de Proyectos"></asp:Label>
</td></tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblEmpresa" runat="server" CssClass="TitulitosSub" 
                            Text="Red:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRed" runat="server" AutoPostBack="False" 
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
                            Text="Fecha Inicio:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="textbox1" 
                            MaxLength="15" Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtFechaInicio">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label8" runat="server" CssClass="TitulitosSub" 
                            Text="Fecha Fin:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="textbox1" MaxLength="15" 
                            Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtFechaFin">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label11" runat="server" CssClass="TitulitosSub" 
                            Text="ID TAM:"></asp:Label>
                        </td>
                    <td>
                    
                        <asp:CheckBox ID="ckbptid" runat="server" AutoPostBack="True" 
                            oncheckedchanged="ckbptid_CheckedChanged" />
                    
                        <asp:DropDownList ID="ddlTipoId" runat="server" CssClass="textbox1" 
                            Visible="False">
                            <asp:ListItem Selected="True" Value="0">ID Libre</asp:ListItem>
                            <asp:ListItem Value="1">ID Validado</asp:ListItem>
                            <asp:ListItem Value="2">ID Automático</asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label7" runat="server" CssClass="TitulitosSub" Text="ID ENR:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbenr" runat="server" AutoPostBack="True" 
                            oncheckedchanged="ckbenr_CheckedChanged" />
                        <asp:DropDownList ID="ddlTipoENR" runat="server" CssClass="textbox1" 
                            Visible="False">
                            <asp:ListItem Selected="True" Value="0">ID Libre</asp:ListItem>
                            <asp:ListItem Value="1">ID Validado</asp:ListItem>
                            <asp:ListItem Value="2">ID Automático</asp:ListItem>
                        </asp:DropDownList>
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
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Aceptar" 
                            onclick="btnAceptar_Click">Aceptar</asp:LinkButton>&nbsp; &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
                SkinID="label_vacio"></asp:Label>
            <br />
        </asp:Panel>
         </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ckbptid" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="ckbenr" EventName="CheckedChanged" />

            </Triggers>
        </asp:UpdatePanel>
        </td></tr></table>    
    </div>

</asp:Content>