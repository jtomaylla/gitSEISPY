<%@ Page Title="Búsqueda de Pacientes" Language="C#" AutoEventWireup="true" CodeBehind="WFPacienteSearch.aspx.cs" Inherits="WSProyectos.Paciente.WFPacienteSearch" MasterPageFile="~/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false">
        </asp:ScriptManager>
        <table align="left" style="width: 800px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table width="800px">
                           <tr>
                            <td><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Generar Visita - Búsqueda de Pacientes"></asp:Label></td>
                        </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pBusquedaS" runat="server">
                                     <table width="800px">
                                 <tr>
                                <td style="width:130px;">
                                    <asp:Label ID="lblDoc" runat="server" CssClass="TitulitosSub" 
                                        Text="DNI / Documento:"></asp:Label>
                                </td>
                                <td style="width:130px;">
                                    <asp:TextBox ID="txtDoc" runat="server" CssClass="textbox1" Width="120px"></asp:TextBox>
                                </td>
                                <td style="width:50px;">
                                    <asp:LinkButton ID="btnBuscar" runat="server" Text="Buscar" 
                                        onclick="btnBuscar_Click"></asp:LinkButton>
                                </td>
                                    <td>
                                        <asp:LinkButton ID="btnBusquedaA" runat="server" onclick="btnBusquedaA_Click" 
                                            Text="Búsqueda Avanzada"></asp:LinkButton>
                                </td>
                                    <td><asp:UpdateProgress ID="prg1" runat="server" 
                                        AssociatedUpdatePanelID="updActualizar" DynamicLayout="False">
                                        <ProgressTemplate>
                                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/ajax-loader.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress></td>
                                    <td></td>
                            </tr>
                            </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pBusquedaA" runat="server" Visible="false">
                                     <table width="800px">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblAP" runat="server" CssClass="TitulitosSub" 
                                        Text="Apellido Paterno:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAM" runat="server" CssClass="TitulitosSub" 
                                        Text="Apellido Materno:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNom" runat="server" CssClass="TitulitosSub" Text="Nombre:" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFN" runat="server" CssClass="TitulitosSub" 
                                        Text="Fecha Nacimiento:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td><td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtApeP" runat="server" CssClass="textbox1" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApeM" runat="server" CssClass="textbox1" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="textbox1" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFN" runat="server" CssClass="textbox1" Visible="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFN_CalendarExtender" runat="server" Enabled="True" 
                                        TargetControlID="txtFN">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnBuscarAvanzada" runat="server" Text="Buscar" 
                                        Visible="False" onclick="btnBuscarAvanzada_Click"></asp:LinkButton>
                                </td><td>
                                    <asp:LinkButton ID="btnBusquedaS" runat="server" onclick="btnBusquedaS_Click" 
                                        Text="Búsqueda Simple" Visible="false"></asp:LinkButton>
                                </td>
                            </tr>
                            </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" 
                                        SkinID="label_vacio" Text=""></asp:Label>
                                </td>
                           </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvListado" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" 
                                        CssClass="Grilla2" DataKeyNames="CodigoPaciente" GridLines="Vertical" 
                                        onpageindexchanging="gvListado_PageIndexChanging" 
                                        onrowcommand="gvListado_RowCommand" PageSize="30" Width="700px">
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle CssClass="Header2" />
                                        <Columns>
                                            <asp:BoundField DataField="CodigoPaciente" HeaderText="CodigoPaciente" 
                                                ReadOnly="True" SortExpression="CodigoPaciente" Visible="False" />
                                            <asp:BoundField DataField="NombreCompleto" HeaderText="Apellidos y Nombres" 
                                                SortExpression="NombreCompleto">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DocIdentidad" HeaderText="Doc.Identidad" 
                                                SortExpression="DocIdentidad">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" 
                                                SortExpression="FechaNacimiento">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo" 
                                                Visible="false">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SexoName" HeaderText="Sexo" SortExpression="Estado">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" Width="40px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="imbEditar" runat="server" AlternateText="Editar" 
                                                        CausesValidation="False" CommandArgument='<%# Eval("CodigoPaciente") %>' 
                                                        CommandName="Editar" SkinID="link_grilla" Text="Editar" ToolTip="Editar"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header2" />
                                                <ItemStyle CssClass="Item2" Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Visita" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="imbVisita" runat="server" AlternateText="Visita" 
                                                        CausesValidation="False" CommandArgument='<%# Eval("CodigoPaciente") %>' 
                                                        CommandName="Visita" SkinID="link_grilla" Text="Visita" ToolTip="Crear visita"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="header2" />
                                                <ItemStyle CssClass="Item2" Width="30px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="Pie2" ForeColor="White" HorizontalAlign="center" />
                                        <AlternatingRowStyle BackColor="#FFFFFF" />
                                    </asp:GridView>
                                </td>
                            </tr>

<tr>
                                               <td>
                                               </td>
                            </tr>
                        </table>
                    </asp:Panel>
                                                                <div style="text-align:center"></div>

                     </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnBuscarAvanzada" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnBusquedaA" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnBusquedaS" EventName="Click" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>