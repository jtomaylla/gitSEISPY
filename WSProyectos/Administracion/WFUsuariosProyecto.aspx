<%@ Page Title="Asignar Proyectos por Usuario" Language="C#" AutoEventWireup="true" CodeBehind="WFUsuariosProyecto.aspx.cs" Inherits="WSProyectos.Administracion.WFUsuariosProyecto" MasterPageFile="~/Site.Master"%>

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
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Asignar Proyectos por Usuario"></asp:Label></td>
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
                                    <asp:Label ID="lblPY" runat="server" CssClass="TitulitosSub" Text="Usuario:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox1" Width="300px"></asp:TextBox>
                                </td>
                                <td>

                                </td>
                            </tr>
                            <tr>

                                <td colspan="3">

                                            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoProyecto"
                                                CssClass="Grilla2" Width="400px" BorderStyle="None" BorderWidth="1px" 
                                                onrowdatabound="gvListado_RowDataBound">
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblVacio" runat="server" Text="No se encontró Proyectos"
                                                        SkinID="label_vacio"></asp:Label>
                                                </EmptyDataTemplate>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                        <asp:TemplateField HeaderText="Código">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcodigoProy" runat="server" Text='<%# Bind("CodigoProyecto") %>'></asp:Label>
                                                            </ItemTemplate> <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px"/>
                                                        </asp:TemplateField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Descripción" SortExpression="Descripcion"> 
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="false">
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ckbAsignar" runat="server" />
                                                        </ItemTemplate>
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px"/>
                                                    </asp:TemplateField>
                                                </Columns>
                                         <PagerStyle CssClass="Pie2" ForeColor="White" HorizontalAlign="center" />
                                        <AlternatingRowStyle BackColor="#FFFFFF" />
                                            </asp:GridView>
                                       
                                </td>
                           </tr>
                                           <tr>
                    <td colspan="3">
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Agregar" 
                            onclick="btnAceptar_Click"></asp:LinkButton>&nbsp; &nbsp;
                    <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" 
                            onclick="btnCancelar_Click">Cancelar</asp:LinkButton></td>
                </tr>
                        </table>
                    </asp:Panel>
                                                                <div style="text-align:center"><asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label></div>

                     </ContentTemplate>

                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
