<%@ Page Title="Lista de Proyectos" Language="C#" AutoEventWireup="true" CodeBehind="WFProyectos.aspx.cs" Inherits="WSProyectos.Administracion.WFProyectos" MasterPageFile="~/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
            </Scripts>
        </asp:ScriptManager>
        <table align="left" style="width: 700px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updUsuario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table>
                           <tr>
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Lista de Proyectos"></asp:Label></td>
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
                                    <asp:Label ID="lblRed" runat="server" CssClass="TitulitosSub" Text="Red:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRed" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlRed_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:UpdateProgress ID="prg1" runat="server" 
                                        AssociatedUpdatePanelID="updUsuario" DynamicLayout="False">
                                        <ProgressTemplate>
                                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/ajax-loader.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        <tr>
                           <td colspan="3">
                                    <asp:LinkButton ID="btnNuevo" runat="server" onclick="btnNuevo_Click">Nuevo</asp:LinkButton></td>
                        </tr>
                            <tr>

                                <td colspan="3">

                                            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoProyecto"
                                                CssClass="Grilla2" Width="700px" BorderStyle="None" BorderWidth="1px" AllowPaging="True" 
                                                GridLines="Vertical" onrowcommand="gvListado_RowCommand" 
                                                onpageindexchanging="gvListado_PageIndexChanging" PageSize="20">
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblVacio" runat="server" Text="No se encontró Proyectos para la Red seleccionada"
                                                        SkinID="label_vacio"></asp:Label>
                                                </EmptyDataTemplate>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                    <asp:BoundField DataField="CodigoProyecto" HeaderText="CodigoProyecto" ReadOnly="True" SortExpression="CodigoProyecto" Visible="False" />
                                                    <asp:BoundField DataField="CodigoRedes" HeaderText="CodigoRedes" ReadOnly="True" SortExpression="CodigoRedes" Visible="False" />

                                                    <asp:BoundField DataField="NomRed" HeaderText="Red" SortExpression="NomRed">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"> 
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="FechaInicio" HeaderText="FechaInicio" SortExpression="FechaInicio">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FechaFin" HeaderText="FechaFin" SortExpression="FechaFin">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="false">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EstadoName" HeaderText="Estado" SortExpression="Estado">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px"/>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbEditar" SkinID="link_grilla" runat="server" AlternateText="Editar" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoProyecto") %>' CommandName="Editar" ToolTip="Editar" Text="Editar"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Local" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbALocal" SkinID="link_grilla" runat="server" AlternateText="Local" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoProyecto") %>' CommandName="AsignarLocal" ToolTip="Asignar locales" Text="Local"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px"/>
                                                    </asp:TemplateField>

                                                </Columns>
                                         <PagerStyle CssClass="Pie2" ForeColor="White" HorizontalAlign="center" />
                                        <AlternatingRowStyle BackColor="#FFFFFF" />
                                            </asp:GridView>
                                            <br />
                                            <div style="text-align:center"><asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label></div>
                                       
                                </td>
                           </tr>
                        </table>
                    </asp:Panel>
                     </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRed" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>