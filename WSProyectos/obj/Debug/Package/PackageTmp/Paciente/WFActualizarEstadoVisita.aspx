<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFActualizarEstadoVisita.aspx.cs" Inherits="WSProyectos.Paciente.WFActualizarEstadoVisita" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head id="Head1" runat="server">
		<title>Estado Visita</title>
   <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

	</head>
	<body>
	
		<form id="Form1" method="post" runat="server">
			<table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" bgColor="#ffffff">
						<table id="Table4" cellspacing="0" cellpadding="0" align="center" border="0" width="250px">
							<tr>
								<td class="style3"><!--Cabeza-->
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
							</tr>
							<!--2-->
							<tr>
								<td Class="TitulitoLog" align="center">Actualizar Estado Visita</td>
							</tr>
							<tr>
								<td class="style2" align="center">
                                                                            <asp:Label ID="lblIdP" 
                                        runat="server" CssClass="body_text" Visible="False"></asp:Label>
                                                                                                            </td>
							</tr>
							<br>
								<tr><td></td>
							</tr>
								<tr><td>&nbsp;</td>
							</tr>
							<tr>
								<td>
                                    <asp:Label ID="lblLocal" runat="server" CssClass="TitulitosSub" 
                                        Text="Estado Visita:"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td>
                                    <asp:DropDownList ID="ddlEstadoVisita" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" 
                                        onselectedindexchanged="ddlEstadoVisita_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
							</tr>
							<tr>
								<td>
                                    &nbsp;</td>
							</tr>
							<tr>
								<td>
                                    <asp:Label ID="lblLocal0" runat="server" CssClass="TitulitosSub" 
                                        Text="Estatus Paciente:"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td>
                                    <asp:DropDownList ID="ddlEstadoPaciente" runat="server" CssClass="textbox1">
                                    </asp:DropDownList>
                                </td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>
                                    <asp:LinkButton ID="lkbAceptar" runat="server" onclick="lkbAceptar_Click">Aceptar</asp:LinkButton>
                                </td>
							</tr>
							<tr>
								<td>
                                    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" 
                                        SkinID="label_vacio" Text=""></asp:Label>
                                </td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>


			</table>
		</form>
	</body>
</html>