<%@ Page Title="Lista de Usuarios" Language="C#" AutoEventWireup="true" CodeBehind="WFUsuarios.aspx.cs" Inherits="WSProyectos.Administracion.WFUsuarios" MasterPageFile="~/Site.Master"%>

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
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Lista de Usuarios"></asp:Label></td>
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
                                    <asp:Label ID="lblSede" runat="server" CssClass="TitulitosSub" Text="Local:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLocal" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlLocal_SelectedIndexChanged">
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
                                    <asp:LinkButton ID="btnNuevoUsuario" runat="server" 
                                        onclick="btnNuevoUsuario_Click">Nuevo</asp:LinkButton></td>
                        </tr>
                            <tr>

                                <td colspan="3">

                                            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoUsuario"
                                                CssClass="Grilla2" Width="600px" BorderStyle="None" BorderWidth="1px" AllowPaging="True" 
                                                GridLines="Vertical" onrowcommand="gvUsuarios_RowCommand" 
                                                onpageindexchanging="gvUsuarios_PageIndexChanging" PageSize="20">
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblVacio" runat="server" Text="No se encontró Usuarios para el local seleccionado"
                                                        SkinID="label_vacio"></asp:Label>
                                                </EmptyDataTemplate>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                    <asp:BoundField DataField="CodigoUsuario" HeaderText="CodigoUsuario" ReadOnly="True" SortExpression="CodigoUsuario"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="LoginUsuario" HeaderText="Login" SortExpression="LoginUsuario">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombres" SortExpression="NombreUsuario"> 
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo">
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
                                                                CommandArgument='<%# Eval("CodigoUsuario") %>' CommandName="Editar" ToolTip="Editar" Text="Editar"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Resetear" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbResetear" SkinID="link_grilla" runat="server" AlternateText="Resetear" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoUsuario") %>' CommandName="Resetear" 
                                                                ToolTip="Resetear Clave" OnClientClick="return confirm('¿Esta seguro que desea resetear la clave?')">Resetear</asp:LinkButton>
                                                        </ItemTemplate>
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rol" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbRol" SkinID="link_grilla" runat="server" AlternateText="Rol" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoUsuario") %>' CommandName="Rol" ToolTip="Asignar Roles" Text="Rol"></asp:LinkButton>
                                                        </ItemTemplate><HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="20px"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proyectos" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbProy" SkinID="link_grilla" runat="server" AlternateText="Proyectos" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoUsuario") %>' CommandName="Proyectos" ToolTip="Asignar Proyectos" Text="Proyectos"></asp:LinkButton>
                                                        </ItemTemplate><HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="50px"/>
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
                                            <asp:AsyncPostBackTrigger ControlID="ddlLocal" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>