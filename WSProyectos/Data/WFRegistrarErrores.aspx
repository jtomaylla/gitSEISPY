<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFRegistrarErrores.aspx.cs" Inherits="WSProyectos.Data.WFRegistrarErrores" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head id="Head1" runat="server">
		<title>Registro de Errores</title>
   <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

	</head>
	<body>
	
		<form id="Form1" method="post" runat="server">
			<table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" bgColor="#ffffff">
						<table id="Table4" cellspacing="0" cellpadding="0" align="center" border="0" width="600px">
							<tr>
								<td class="style3" colspan="3"><!--Cabeza-->
                                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="false">
                                    </asp:ScriptManager>
                                </td>
							</tr>
							<!--2-->
							<tr>
								<td Class="TitulitoLog" align="center" colspan="3">Registro de errores</td>
							</tr>
							<tr>
								<td class="style2" align="center" colspan="3">
                                                                            <asp:Label ID="lblIdP" 
                                        runat="server" CssClass="body_text" Visible="False"></asp:Label>
                                                                                                            <asp:Label ID="txtIdError" runat="server" 
                                                                                Visible="False"></asp:Label>
                                                                                                            </td>
							</tr>
							<br>
								<tr><td colspan="3"></td></tr>
								<tr><td colspan="3"></td></tr>
							<tr>
								<td colspan="3">
                                    <asp:Label ID="lblLocal" runat="server" CssClass="TitulitosSub" 
                                        Text="Paciente:"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="3">
                                    <asp:TextBox ID="txtPaciente" runat="server" CssClass="textbox1" 
                                        ReadOnly="True" Width="250px"></asp:TextBox>
                                </td>
							</tr>
							<tr>
								<td colspan="3">
                                    &nbsp;</td>
							</tr>
							<tr>
								<td>
                                    <asp:Label ID="lblLocal0" runat="server" CssClass="TitulitosSub" 
                                        Text="Tipo de Error:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLocal1" runat="server" CssClass="TitulitosSub" 
                                        Text="Tipo Documento:"></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="lblLocal2" runat="server" CssClass="TitulitosSub" 
                                        Text="Nombre Documento:"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td>
                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="textbox1">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDocumento" runat="server" CssClass="textbox1">
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                     <asp:TextBox ID="txtNomDoc" runat="server" CssClass="textbox1" Width="160px"></asp:TextBox>
                                </td>

							</tr>
							<tr>
								<td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                 <td>&nbsp;</td>

							</tr>
							<tr>
								<td>
                                    <asp:Label ID="lblLocal3" runat="server" CssClass="TitulitosSub" 
                                        Text="Fecha Error:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLocal4" runat="server" CssClass="TitulitosSub" 
                                        Text="Usuario Error:"></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="lblLocal5" runat="server" CssClass="TitulitosSub" 
                                        Text="Cantidad:"></asp:Label>
                                </td>

							</tr>
							<tr>
								<td>
                                    <asp:TextBox ID="txtFechaError" runat="server" CssClass="textbox1" 
                                        MaxLength="10" Width="80px"></asp:TextBox>

                                    <cc1:CalendarExtender ID="txtFechaError_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaError">
                                    </cc1:CalendarExtender>

                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUsuarios" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" 
                                        onselectedindexchanged="ddlUsuarios_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                     <asp:TextBox ID="txtCantidad" runat="server" CssClass="textbox1" Width="50px"></asp:TextBox>
                                     <asp:CheckBox ID="ckbA72" runat="server" Text="A72" />
                                </td>

							</tr>
							<tr>
								<td colspan="3"></td>
							</tr>
							<tr>
								<td colspan="3">&nbsp;</td>
							</tr>
							<tr>
								<td colspan="3">
                                    <asp:LinkButton ID="lkbAceptar" runat="server" onclick="lkbAceptar_Click">Aceptar</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lkbListar" runat="server" onclick="lkbListar_Click">Listar registros</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lkbOtro" runat="server" onclick="lkbOtro_Click" 
                                        Visible="False">Registrar otro</asp:LinkButton>
                                    
                                </td>
							</tr>
							<tr>
								<td colspan="3">
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="False" 
                SkinID="label_vacio"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="3">&nbsp;</td>
							</tr>
							<tr>
								<td colspan="3">
                                    <asp:GridView ID="gvListado" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" 
                                        CssClass="Grilla2" DataKeyNames="CodigoError" GridLines="Vertical" 
                                        Width="600px" onpageindexchanging="gvListado_PageIndexChanging" 
                                        onrowcommand="gvListado_RowCommand">
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle CssClass="Header2" />
                                        <Columns>
                                                        <asp:TemplateField HeaderText="codigoerrordmc" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcodigoerrordmc" runat="server" Text='<%# Bind("codigoerror") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Usuario" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcodigousuario" runat="server" Text='<%# Bind("codigousuario") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="CodigoDocumento" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoDocumento" runat="server" Text='<%# Bind("CodigoDocumento") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="CodigoTipoError" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCodigoTipoError" runat="server" Text='<%# Bind("CodigoTipoError") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="FechaError">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFechaError" runat="server" Text='<%# Bind("FechaError") %>'></asp:Label>
                                                            </ItemTemplate><ItemStyle CssClass="Item2" Width="30"/><HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Documento">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDocumento" runat="server" Text='<%# Bind("Documento") %>'></asp:Label>
                                                            </ItemTemplate><ItemStyle CssClass="Item2" Width="100"/><HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="TipoError">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTipoError" runat="server" Text='<%# Bind("TipoError") %>'></asp:Label>
                                                            </ItemTemplate><ItemStyle CssClass="Item2" Width="100"/><HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Nombre Doc.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNumDoc" runat="server" Text='<%# Bind("NumDoc") %>'></asp:Label>
                                                            </ItemTemplate><ItemStyle CssClass="Item2" Width="80"/><HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Cant.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                                            </ItemTemplate><ItemStyle CssClass="Item2" Width="20"/><HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="A72">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblA72" runat="server" Text='<%# Bind("A72") %>'></asp:Label>
                                                            </ItemTemplate><ItemStyle CssClass="Item2" Width="20"/><HeaderStyle CssClass="Header2" HorizontalAlign="Center" />
                                                        </asp:TemplateField>




                                            <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="imbEditar" runat="server" AlternateText="Editar" 
                                                        CausesValidation="False" CommandArgument='<%# Eval("CodigoError") %>' 
                                                        CommandName="Editar" SkinID="link_grilla" Text="Editar" ToolTip="Editar"></asp:LinkButton>
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
						</table>
					</td>
				</tr>


			</table>
		</form>
	</body>
</html>

