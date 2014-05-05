<%@ Page Title="Búsqueda de visitas" Language="C#" AutoEventWireup="true" CodeBehind="WFBusquedaVisitasD.aspx.cs" Inherits="WSProyectos.Data.WFBusquedaVisitasD" MasterPageFile="~/Site.Master"%>
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
                            <td><asp:Label ID="Label1" runat="server" CssClass="Titulitos" 
                                    Text="Editar Datos - Búsqueda de Visitas"></asp:Label></td>
                        </tr>
                            <tr>
                                <td><asp:UpdateProgress ID="prg1" runat="server" 
                                                     AssociatedUpdatePanelID="updActualizar" DynamicLayout="False">
                                                     <ProgressTemplate>
                                                         <asp:Image ID="img1" runat="server" ImageUrl="~/images/ajax-loader.gif" />
                                                     </ProgressTemplate>
                                                 </asp:UpdateProgress></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pBusquedaS" runat="server">
                                     <table width="800px">
                                 <tr>
                                <td valign="top" style="width:130px;">
                                    <asp:Label ID="lblLocal" runat="server" CssClass="TitulitosSub" 
                                        Text="Local:"></asp:Label>
                                </td>
                                <td style="width:130px;">
                                    <asp:Label ID="lblProyecto" runat="server" CssClass="TitulitosSub" 
                                        Text="Proyecto:"></asp:Label>
                                </td>
                                <td style="width:50px;">
                                    <asp:Label ID="lblEstadoV" runat="server" CssClass="TitulitosSub" 
                                        Text="Estado:"></asp:Label>
                                </td>
                                    <td>
                                        <asp:Label ID="lblFecha" runat="server" CssClass="TitulitosSub" Text="Fecha:"></asp:Label>
                                     </td>
                                    <td></td>
                                    <td>&nbsp;</td>
                            </tr>
                                         <tr>
                                             <td style="width:130px;">
                                                 <asp:DropDownList ID="ddlLocal" runat="server" Width="180px" 
                                                     CssClass="textbox1" AutoPostBack="True" 
                                                     onselectedindexchanged="ddlLocal_SelectedIndexChanged">
                                                 </asp:DropDownList>
                                             </td>
                                             <td style="width:130px;">
                                                 <asp:DropDownList ID="ddlProyecto" runat="server" Width="180px" 
                                                     CssClass="textbox1" AutoPostBack="True" 
                                                     onselectedindexchanged="ddlProyecto_SelectedIndexChanged">
                                                 </asp:DropDownList>
                                             </td>
                                             <td style="width:50px;">
                                                 <asp:DropDownList ID="ddlEstado" runat="server" CssClass="textbox1" 
                                                     Width="90px">
                                                 </asp:DropDownList>
                                             </td>
                                             <td style="width:120px;">
                                                 <asp:TextBox ID="txtFechaA" runat="server" CssClass="textbox1" Width="75px"></asp:TextBox>
                                                 <cc1:CalendarExtender ID="txtFechaA_CalendarExtender" runat="server" 
                                                     Enabled="True" TargetControlID="txtFechaA">
                                                 </cc1:CalendarExtender>
                                             </td>
                                             <td>

                                                 <asp:LinkButton ID="btnBuscar" runat="server" 
                                                     Text="Buscar" onclick="btnBuscar_Click"></asp:LinkButton>

                                             </td>
                                             <td>
                                                   
                                                 <asp:LinkButton ID="btnBusquedaA" runat="server" onclick="btnBusquedaA_Click" 
                                                     Text="Búsqueda Avanzada"></asp:LinkButton>
                                                   
                                             </td>
                                         </tr>
                            </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pBusquedaA" runat="server" Visible="false">
                                     <table width="800px">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblFechaD" runat="server" CssClass="TitulitosSub" 
                                        Text="Fecha Desde:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaH" runat="server" CssClass="TitulitosSub" 
                                        Text="Fecha Hasta:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNom" runat="server" CssClass="TitulitosSub" Text="Id.TAM/Id.ENR" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td></td><td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFechaD" runat="server" CssClass="textbox1" Visible="False" 
                                        Width="80px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFechaD_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaD">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaH" runat="server" CssClass="textbox1" Visible="False" 
                                        Width="80px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFechaH_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaH">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="textbox1" Visible="False" 
                                        Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnBuscarAvanzada" runat="server" Text="Buscar" 
                                        Visible="False" onclick="btnBuscarAvanzada_Click"></asp:LinkButton>
                                </td><td>
                                    <asp:LinkButton ID="btnBusquedaS" runat="server" 
                                        Text="Búsqueda Simple" Visible="false" onclick="btnBusquedaS_Click"></asp:LinkButton>
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
                                        PageSize="30" Width="970px" onpageindexchanging="gvListado_PageIndexChanging" 
                                        onrowdatabound="gvListado_RowDataBound" 
                                        onrowcommand="gvListado_RowCommand">
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle CssClass="Header2" />
                                        <Columns>
                                                        <asp:TemplateField HeaderText="CodigoPaciente" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoPaciente" runat="server" Text='<%# Bind("CodigoPaciente") %>' ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="CodigoLocal" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoLocal" runat="server" Text='<%# Bind("CodigoLocal") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CodigoProyecto" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoProyecto" runat="server" Text='<%# Bind("CodigoProyecto") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CodigoGrupoVisita" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoGrupoVisita" runat="server" Text='<%# Bind("CodigoGrupoVisita") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CodigoVisita" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoVisita" runat="server" Text='<%# Bind("CodigoVisita") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CodigoVisitas" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoVisitas" runat="server" Text='<%# Bind("CodigoVisitas") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CodigoKardex" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoKardex" runat="server" Text='<%# Bind("CodigoKardex") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                            <asp:BoundField DataField="CodigoEstadoVisita" HeaderText="CodigoEstadoVisita" ReadOnly="True" SortExpression="CodigoEstadoVisita" Visible="False" />
                                            <asp:BoundField DataField="CodigoTAM" HeaderText="CodigoTAM" ReadOnly="True" SortExpression="CodigoTAM" Visible="False" />
                                            <asp:BoundField DataField="CodigoENR" HeaderText="CodigoENR" ReadOnly="True" SortExpression="CodigoENR" Visible="False" />
                                            <asp:BoundField DataField="TAM" HeaderText="TAM" ReadOnly="True" SortExpression="TAM" Visible="False" />
                                            <asp:BoundField DataField="ENR" HeaderText="ENR" ReadOnly="True" SortExpression="ENR" Visible="False" />
                                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="Local" HeaderText="Local" SortExpression="Local">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="100px" /> </asp:BoundField>
                                            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="Proyecto">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="100px" /> </asp:BoundField>
                                            <asp:BoundField DataField="Id_TAM" HeaderText="Id_TAM" SortExpression="Id_TAM">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/> </asp:BoundField>
                                            <asp:BoundField DataField="Id_ENR" HeaderText="Id_ENR" SortExpression="Id_ENR">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/> </asp:BoundField>
                                            <asp:BoundField DataField="NombreCompleto" HeaderText="Paciente" SortExpression="NombreCompleto">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2"/> </asp:BoundField>
                                            <asp:BoundField DataField="NombreSexo" HeaderText="Sexo" SortExpression="NombreSexo" Visible="false">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="40px" /></asp:BoundField>
                                            <asp:BoundField DataField="Visita" HeaderText="Visita" SortExpression="Visita">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="80px"/> </asp:BoundField>
                                            <asp:TemplateField HeaderText="FechaVisita">
                                                <ItemTemplate><asp:Label ID="lblFechaVisita" runat="server" Text='<%# Bind("FechaNVisita") %>'></asp:Label></ItemTemplate>
                                                <HeaderStyle CssClass="Header2" /><ItemStyle CssClass="Item2" Width="70" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="HoraInicio" HeaderText="HoraInicio" SortExpression="HoraInicio" Visible="false">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="50px"/> </asp:BoundField>
                                            <asp:BoundField DataField="EstadoVisita" HeaderText="Estado" SortExpression="EstadoVisita">
                                            <HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="50px"/></asp:BoundField>
                                            <asp:TemplateField HeaderText="Kardex" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkD1" runat="server" AlternateText="Salida" CausesValidation="False" 
                                                    CommandName="Salida" SkinID="link_grilla" Text="Salida" ToolTip="Salida"></asp:LinkButton>
                                                    <asp:LinkButton ID="linkD2" runat="server" AlternateText="Archivado" CausesValidation="False" 
                                                    SkinID="link_grilla" Text="Archivado" ToolTip="Archivado"></asp:LinkButton>
                                                    <asp:LinkButton ID="linkD3" runat="server" AlternateText="Entrada" CausesValidation="False" 
                                                    CommandName="Entrada" SkinID="link_grilla" Text="Entrada" ToolTip="Entrada"></asp:LinkButton>

                                                </ItemTemplate><HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Errores" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hypError"  runat="server" Text="Errores" ToolTip="Registrar errores" navigateurl='<%# String.Format("WFRegistrarErrores.aspx?CodigoPaciente={0}&CodigoLocal={1}&CodigoProyecto={2}&CodigoUsuario={3}", Eval("CodigoPaciente"), Eval("CodigoLocal"), Eval("CodigoProyecto"),numUsuario) %>'> 
                                                    </asp:HyperLink>
                                                </ItemTemplate><HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Visita" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="imbVisita" runat="server" AlternateText="Visita" 
                                                        CausesValidation="False" CommandArgument='<%# Eval("CodigoPaciente") %>' 
                                                        CommandName="Visita" SkinID="link_grilla" Text="Visita" ToolTip="Lista visitas"></asp:LinkButton>
                                                </ItemTemplate><HeaderStyle CssClass="header2" /><ItemStyle CssClass="Item2" Width="30px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=""  ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hypCRF"  runat="server" ToolTip="" navigateurl='<%# String.Format("WFInter.aspx?CodigoPaciente={0}", Eval("CodigoPaciente")) %>'> 
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="Header2" HorizontalAlign="Center" /><ItemStyle CssClass="Item2"/>
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
                                            <asp:AsyncPostBackTrigger ControlID="ddlLocal" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlProyecto" EventName="SelectedIndexChanged" />


                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

