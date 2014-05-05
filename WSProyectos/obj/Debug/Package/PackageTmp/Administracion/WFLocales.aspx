<%@ Page Title="Lista de Locales" Language="C#" AutoEventWireup="true" CodeBehind="WFLocales.aspx.cs" Inherits="WSProyectos.Administracion.WFLocales" MasterPageFile="~/Site.Master"%>

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
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" 
                                    Text="Lista de Locales"></asp:Label></td>
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
                                    <asp:LinkButton ID="btnNuevo" runat="server" 
                                        onclick="btnNuevo_Click">Nuevo</asp:LinkButton></td>
                        </tr>
                            <tr>

                                <td colspan="3">

                                            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoLocal"
                                                CssClass="Grilla2" Width="700px" BorderStyle="None" BorderWidth="1px" AllowPaging="True" 
                                                GridLines="Vertical" onrowcommand="gvListado_RowCommand" 
                                                onpageindexchanging="gvListado_PageIndexChanging" PageSize="20">
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblVacio" runat="server" Text="No se encontraron registros"
                                                        SkinID="label_vacio"></asp:Label>
                                                </EmptyDataTemplate>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                    <asp:BoundField DataField="CodigoLocal" HeaderText="CodigoLocal" ReadOnly="True" SortExpression="CodigoLocal"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="CodigoEmpresa" HeaderText="CodigoEmpresa" ReadOnly="True" SortExpression="CodigoEmpresa"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="NomEmpresa" HeaderText="Nom.Empresa" SortExpression="NomEmpresa">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion"> 
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DireccionLocal" HeaderText="Dirección" SortExpression="DireccionLocal">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DistritoLocal" HeaderText="Distrito" SortExpression="DistritoLocal">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="false">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EstadoName" HeaderText="Estado" SortExpression="Estado">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbEditar" SkinID="link_grilla" runat="server" AlternateText="Editar" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoLocal") %>' CommandName="Editar" ToolTip="Editar" Text="Editar"></asp:LinkButton>

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

                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>