<%@ Page Title="Registro de Pacientes" Language="C#" AutoEventWireup="true" CodeBehind="WFPacienteNew.aspx.cs" Inherits="WSProyectos.Paciente.WFPacienteNew" MasterPageFile="~/Site.Master"%>
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
                <td colspan="2"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Registro de Pacientes"></asp:Label>
</td></tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblIdP" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblEmpresa" runat="server" CssClass="TitulitosSub" 
                            Text="Tipo de documento:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDoc" runat="server" AutoPostBack="True" 
                            CssClass="textbox1" onselectedindexchanged="ddlDoc_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="lblEmpresa0" runat="server" CssClass="TitulitosSub" 
                            Text="DNI / Documento:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="textbox1" 
                            MaxLength="11" Width="100px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label2" runat="server" CssClass="TitulitosSub" Text="Nombres:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombres" runat="server" CssClass="textbox1" MaxLength="50" 
                            Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombres" runat="server" 
                            ControlToValidate="txtNombres" ErrorMessage="Ingresar nombres" 
                            ForeColor="Red" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label3" runat="server" CssClass="TitulitosSub" 
                            Text="Apellido Paterno"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtApeP" runat="server" CssClass="textbox1" MaxLength="50" 
                            Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAP" runat="server" 
                            ErrorMessage="Ingresar apellido paterno" ControlToValidate="txtApeP" ForeColor="Red" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label6" runat="server" CssClass="TitulitosSub" 
                            Text="Apellido Materno:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtApeM" runat="server" CssClass="textbox1" MaxLength="50" 
                            Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAM" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ControlToValidate="txtApeM" ForeColor="Red" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label8" runat="server" CssClass="TitulitosSub" 
                            Text="Fecha de nacimiento:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFN" runat="server" CssClass="textbox1" MaxLength="15" 
                            Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFN_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="txtFN">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvFN" runat="server" 
                            ErrorMessage="Ingresar fecha de nacimiento" ForeColor="Red" 
                            ControlToValidate="txtFN" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        <asp:Label ID="Label7" runat="server" CssClass="TitulitosSub" 
                            Text="Sexo:"></asp:Label>
                        </td>
                    <td>
                    
                        <asp:RadioButtonList ID="rblSexo" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">Masculino</asp:ListItem>
                            <asp:ListItem Value="2">Femenino</asp:ListItem>
                        </asp:RadioButtonList>
                    
                        </td>
                </tr>
                <tr>
                    <td style="width: 145px;">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" ValidationGroup="Paciente">Aceptar</asp:LinkButton>
                        <asp:LinkButton ID="btnRegistrarOtro" runat="server" Text="Registrar otro paciente" 
                            onclick="btnRegistrarOtro_Click" Visible="False">Registrar otro paciente</asp:LinkButton>&nbsp; &nbsp;
                    <asp:LinkButton ID="btnCrear" runat="server" Text="Crear visita" Visible="False" 
                            onclick="btnCrear_Click">Crear visita</asp:LinkButton>&nbsp; &nbsp;
                    <asp:LinkButton ID="btnDatos" runat="server" Text="Datos de Contacto" onclick="btnDatos_Click" Visible="False" ></asp:LinkButton></td>
                </tr>
            </table>
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
                SkinID="label_vacio"></asp:Label>
            <br />
        </asp:Panel>
         </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlDoc" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        </td></tr></table>
    </div>

</asp:Content>