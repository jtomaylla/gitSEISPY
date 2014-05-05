<%@ Page Title="Historial de visitas" Language="C#" AutoEventWireup="true" CodeBehind="WFListadoVisitas.aspx.cs" Inherits="WSProyectos.Paciente.WFListadoVisitas" MasterPageFile="~/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false">
        </asp:ScriptManager>
        <table align="left" style="width: 600px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table>
                           <tr>
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Historial de visitas"></asp:Label></td>
                        </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblIdP" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY7" runat="server" CssClass="TitulitosSub" Text="Paciente:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaciente" runat="server" CssClass="textbox1" 
                                        ReadOnly="True" Width="300px"></asp:TextBox>
                                </td>
                                <td><asp:UpdateProgress ID="prg1" runat="server" 
                                        AssociatedUpdatePanelID="updActualizar" DynamicLayout="False">
                                        <ProgressTemplate>
                                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/ajax-loader.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnRegresar" runat="server" Text="Regresar" 
                                        onclick="btnRegresar_Click"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" 
                                        SkinID="label_vacio" Text=""></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                                           <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
                            BorderStyle="None" BorderWidth="1px" CssClass="Grilla2" 
                            DataKeyNames="CodigoPaciente" GridLines="Vertical" Width="700px" 
                            onpageindexchanging="gvListado_PageIndexChanging" PageSize="30" 
                            onrowdatabound="gvListado_RowDataBound">
                            <EmptyDataTemplate>
                                <asp:Label ID="lblVacio" runat="server" SkinID="label_vacio" 
                                    Text="No se encontró registros..."></asp:Label>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle CssClass="Header2" />
                            <Columns>
                                <asp:BoundField DataField="CodigoPaciente" HeaderText="CodigoPaciente" Visible="False" />
                                <asp:BoundField DataField="FechaVisitas" HeaderText="FechaVisitas" Visible="False" />
                                <asp:BoundField DataField="Id_TAM" HeaderText="Id_TAM" Visible="False" />
                                <asp:BoundField DataField="Id_ENR" HeaderText="Id_ENR" Visible="False" />
                                <asp:BoundField DataField="NombreParticipante" HeaderText="NombreParticipante" Visible="False" />
                                <asp:BoundField DataField="NombreSexo" HeaderText="NombreSexo" Visible="False" />
                                <asp:BoundField DataField="sexo" HeaderText="sexo" Visible="False" />
                                <asp:BoundField DataField="CodigoLocal" HeaderText="CodigoLocal" Visible="False" />
                                <asp:BoundField DataField="codigoredes" HeaderText="codigoredes" Visible="False" />
                                <asp:BoundField DataField="CodigoProyecto" HeaderText="CodigoProyecto" Visible="False" />
                                <asp:BoundField DataField="CodigoVisita" HeaderText="CodigoVisita" Visible="False" />
                                <asp:BoundField DataField="CodigoVisitas" HeaderText="CodigoVisitas" Visible="False" />
                                <asp:BoundField DataField="CodigoEstadoVisita" HeaderText="CodigoEstadoVisita" Visible="False" />
                                <asp:BoundField DataField="CodigoEstatusPaciente" HeaderText="CodigoEstatusPaciente" Visible="False" />
                                <asp:BoundField DataField="CodigoTAM" HeaderText="CodigoTAM" Visible="False" />
                                <asp:BoundField DataField="CodigoENR" HeaderText="CodigoENR" Visible="False" />
                                <asp:BoundField DataField="Auto" HeaderText="Auto" Visible="False" />

                                <asp:BoundField DataField="Local" HeaderText="Local" SortExpression="Local">
                                <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="150px"/></asp:BoundField>
                                 <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="Proyecto">
                                <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="150px"/></asp:BoundField>
                                <asp:BoundField DataField="Visita" HeaderText="Visita" SortExpression="Visita">
                                <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="100px"/></asp:BoundField>
                                <asp:TemplateField HeaderText="FechaVisita" ItemStyle-Width="120px" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hypFechaVisita"  runat="server" ToolTip='<%# String.Concat(DataBinder.Eval(Container, "DataItem.FechaVisitaAntes")," : ", DataBinder.Eval(Container, "DataItem.FechaVisitaDespues")) %>' Text='<%# Eval("FechaVisita") %>' > 
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="Item2"/>
                                    <HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hypEstadoVisita"  runat="server" ToolTip="" Text='<%# Eval("EstadoVisita") %>' navigateurl='<%# String.Format("WFActualizarEstadoVisita.aspx?CodigoPaciente={0}&CodigoLocal={1}&CodigoProyecto={2}&CodigoVisita={3}&CodigoVisitas={4}", Eval("CodigoPaciente"), Eval("CodigoLocal"), Eval("CodigoProyecto"), Eval("CodigoVisita"), Eval("CodigoVisitas")) %>'> 
                                        </asp:HyperLink>
                                    </ItemTemplate><HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="80px"/>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EstatusPaciente" HeaderText="Estatus" SortExpression="EstatusPaciente">
                                <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="80px"/></asp:BoundField>


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
                     </ContentTemplate>
                                        <Triggers>

                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
