<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFGenerarVisitas.aspx.cs" Inherits="WSProyectos.Paciente.WFGenerarVisitas" MasterPageFile="~/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false">
        </asp:ScriptManager>
        <table align="left" style="width: 700px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table>

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="Titulitos" 
                                        Text="Generar visita"></asp:Label>
                                </td>
                                <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblIdP" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPY7" runat="server" CssClass="TitulitosSub" Text="Paciente:"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtPaciente" runat="server" CssClass="textbox1" 
                                        ReadOnly="True" Width="300px"></asp:TextBox>
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblLocal" runat="server" CssClass="TitulitosSub" Text="Local:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLocal0" runat="server" CssClass="TitulitosSub" 
                                        Text="Proyecto:"></asp:Label>
                                </td> <td>
                                    <asp:Label ID="lblGrupo" runat="server" CssClass="TitulitosSub" 
                                        Text="Grupo Visita:" Visible="False"></asp:Label>
                                </td> <td>
                                    <asp:Label ID="lblVisita" runat="server" CssClass="TitulitosSub" 
                                        Text="Visita:"></asp:Label>
                                </td> <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlLocal" runat="server" CssClass="textbox1" 
                                        Width="200px" AutoPostBack="True" 
                                        onselectedindexchanged="ddlLocal_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="textbox1" 
                                        Width="200px" AutoPostBack="True" 
                                        onselectedindexchanged="ddlProyecto_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="textbox1" 
                                        Width="120px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlVisita" runat="server" CssClass="textbox1" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblLocal3" runat="server" CssClass="TitulitosSub" Text="Fecha:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLocal4" runat="server" CssClass="TitulitosSub" Text="Hora:"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="textbox1" Width="80px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtFecha">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHora" runat="server" CssClass="textbox1" Width="60px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="txtHora_MaskedEditExtender" runat="server"  MaskType="Time"
                                        Mask="99:99" Enabled="True" CultureName="es-ES"  
                                        TargetControlID="txtHora"  MessageValidatorTip="true" AcceptAMPM="false">
                                    </cc1:MaskedEditExtender>
                                    <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                       ErrorMessage="*" ControlExtender="txtHora_MaskedEditExtender" ControlToValidate="txtHora"
                                       IsValidEmpty="false" EmptyValueMessage="Ingresar hora" InvalidValueMessage="Hora no valido"></cc1:MaskedEditValidator>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnCrear" runat="server" Visible="False" 
                                        onclick="btnCrear_Click">Crear visita</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="btnGenerar" runat="server" Visible="False" 
                                        onclick="btnGenerar_Click">Generar automáticamente</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    </td>
                                <td class="style1">
                                    </td>
                                <td class="style1">
                                    </td>
                                <td class="style1">
                                    </td>
                                <td class="style1">
                                    </td>
                                <td class="style1">
                                    </td>
                            </tr>
                            <tr>

                                <td>

                                            &nbsp;</td>
                                <td colspan="5">
                                    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" 
                                        SkinID="label_vacio" Text=""></asp:Label>
                                </td>
                           </tr>
                            <tr>

                                <td colspan="6">

                                            &nbsp;</td>
                           </tr>
                                           <tr>
                    <td colspan="6">
                        &nbsp; &nbsp;
                    </td>
                </tr>
                        </table>
                    </asp:Panel>
                     </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlLocal" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlProyecto" EventName="SelectedIndexChanged" />

                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
