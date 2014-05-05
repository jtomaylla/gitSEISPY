<%@ Page Title="Lista de Códigos de Enrolamiento" Language="C#" AutoEventWireup="true" CodeBehind="WFListaCodENR.aspx.cs" Inherits="WSProyectos.Administracion.WFListaCodENR" MasterPageFile="~/Site.Master"%>

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
                            <td colspan="4"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Lista de Códigos de Enrolamiento"></asp:Label></td>
                        </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td><td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRed" runat="server" CssClass="TitulitosSub" Text="Local:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRed0" runat="server" CssClass="TitulitosSub" Text="Proyecto:"></asp:Label>
                                </td><td>
                                    <asp:Label ID="lblRed1" runat="server" CssClass="TitulitosSub" Text="Cod.ENR"></asp:Label>
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
                                <td>
                                    <asp:DropDownList ID="ddlLocal" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlLocal_SelectedIndexChanged" 
                                        Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlProyecto_SelectedIndexChanged" 
                                        Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCod" runat="server" CssClass="textbox1"></asp:TextBox>
                                </td><td>
                                    <asp:LinkButton ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                                        Text="Buscar"></asp:LinkButton>
                                </td>
                            </tr>
                        <tr>
                           <td colspan="4">
                                    <asp:LinkButton ID="btnNuevo" runat="server" onclick="btnNuevo_Click">Generar ID.ENR</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="btnAgregar" runat="server" onclick="btnAgregar_Click">Crear ID.ENR</asp:LinkButton>
                            </td>
                        </tr>
                            <tr>

                                <td colspan="4">

                                            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" DataKeyNames="CodigoProyecto"
                                                CssClass="Grilla2" Width="550px" BorderStyle="None" BorderWidth="1px" AllowPaging="True" 
                                                GridLines="Vertical" 
                                                onpageindexchanging="gvListado_PageIndexChanging" PageSize="20" 
                                                onrowcommand="gvListado_RowCommand" onrowdatabound="gvListado_RowDataBound">
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="Header2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Codigo" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCodigoProyecto" runat="server" Text='<%# Bind("CodigoProyecto") %>' ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Codigo" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCodigoLocal" runat="server" Text='<%# Bind("CodigoLocal") %>' ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Codigo" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCodigoENR" runat="server" Text='<%# Bind("CodigoENR") %>' ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CodigoENR" HeaderText="Item" SortExpression="CodigoENR">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Local" HeaderText="Local" SortExpression="Local"> 
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="120px"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="Proyecto">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="130px"/>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Cod.ENR"  ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hypENR"  runat="server" ToolTip="" Text='<%# Eval("Numero") %>' navigateurl='<%# String.Format("WFCodEnrEdit.aspx?vCodigoENR={0}&vCodigoLocal={1}&vCodigoProyecto={2}&vCodigoUsuario={3}", Eval("CodigoENR"), Eval("CodigoLocal"), Eval("CodigoProyecto"),numUsuario) %>'> 
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="Header2" HorizontalAlign="Center" /><ItemStyle CssClass="Item2"/>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="false">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EstadoName" HeaderText="Estado" SortExpression="Estado">
                                                    <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="50px"/>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="" ShowHeader="False">
                                                        <ItemTemplate>
                                                        <asp:LinkButton ID="imbLimpiar" SkinID="link_grilla" runat="server" AlternateText="Limpiar" CausesValidation="False"
                                                                CommandArgument='<%# Eval("CodigoENR") %>' CommandName="Limpiar" ToolTip="Limpiar" Text="Limpiar"></asp:LinkButton>
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
                                            <asp:AsyncPostBackTrigger ControlID="ddlLocal" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlProyecto" EventName="SelectedIndexChanged" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>