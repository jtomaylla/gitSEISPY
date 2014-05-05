<%@ Page Title="Generar Código de Enrolamiento" Language="C#" AutoEventWireup="true" CodeBehind="WFGenerarCodENR.aspx.cs" Inherits="WSProyectos.Administracion.WFGenerarCodENR" MasterPageFile="~/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
            </Scripts>
        </asp:ScriptManager>
        <table align="left" style="width: 600px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updUsuario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table>
                           <tr>
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Generar Código de Enrolamiento"></asp:Label></td>
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
                                    <asp:Label ID="Local" runat="server" CssClass="TitulitosSub" Text="Local:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLocal" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlLocal_SelectedIndexChanged" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY0" runat="server" CssClass="TitulitosSub" Text="Proyecto:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" Width="200px" 
                                        onselectedindexchanged="ddlProyecto_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY1" runat="server" CssClass="TitulitosSub" 
                                        Text="Cantidad de números:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumeros" runat="server" CssClass="textbox1" Width="100px">1</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY2" runat="server" CssClass="TitulitosSub" 
                                        Text="Número inicial:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInicio" runat="server" CssClass="textbox1" Width="100px">1</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>

                                <td colspan="3">

                                            &nbsp;</td>
                           </tr>
                                           <tr>
                    <td colspan="3">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Generar" 
                            onclick="btnAceptar_Click" Visible="False" ></asp:LinkButton>&nbsp; &nbsp;
                    <asp:LinkButton ID="btnExportar" runat="server" Text="Exportar a Excel" 
                            onclick="btnExportar_Click" Visible="False"></asp:LinkButton></td>
                </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="gvListado" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" 
                                        CssClass="Grilla2" DataKeyNames="CodigoProyecto" GridLines="Vertical" Width="400px" 
                                        PageSize="30" onpageindexchanging="gvListado_PageIndexChanging">
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle CssClass="Header2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Codigo" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodigoProyecto" runat="server" 
                                                        Text='<%# Bind("CodigoProyecto") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Codigo" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodigoLocal" runat="server" Text='<%# Bind("CodigoLocal") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Codigo" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodigoENR" runat="server" Text='<%# Bind("CodigoENR") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CodigoENR" HeaderText="Item" SortExpression="CodigoENR">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px" /></asp:BoundField>
                                            <asp:BoundField DataField="Local" HeaderText="Local" SortExpression="Local">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" 
                                                SortExpression="Proyecto">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" Width="130px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="numero" HeaderText="Código ENR" SortExpression="CodigoENR">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="100px" /></asp:BoundField>
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" 
                                                Visible="false">
                                            <HeaderStyle CssClass="header2" />
                                            <ItemStyle CssClass="Item2" />
                                            </asp:BoundField>

                                        </Columns>
                                        <PagerStyle CssClass="Pie2" ForeColor="White" HorizontalAlign="center" />
                                        <AlternatingRowStyle BackColor="#FFFFFF" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                                                                <div style="text-align:center"><asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label></div>

                     </ContentTemplate>
                                        <Triggers><asp:PostBackTrigger ControlID="btnExportar"/>
                                            <asp:AsyncPostBackTrigger ControlID="ddlLocal" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlProyecto" EventName="SelectedIndexChanged" />
                                        </Triggers>

                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
