<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFCambiarClave.aspx.cs" Inherits="WSProyectos.WFCambiarClave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
		<title>Cambiar contraseña
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
   <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
 <table cellspacing="0" cellpadding="0" width="100%" border="0">
	<tr>
		<td></td>
	</tr>
	<tr>
		<td>
			<table cellspacing="0" cellpadding="0" width="300" align="center" border="0">
				<tr>
					<td align="center" class="TitulitoLog">Cambiar contraseña</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center" class="Titulito2">
                        <asp:Label ID="lblIdUser" runat="server" Text="Label" Visible="False"></asp:Label>
                        <br>
						<br>
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
								<td class="body_textLog" align="right">Login Usuario:</td>
								<td><asp:textbox id="txtClaveA" Width="140px" runat="server" CssClass="textboxLog" 
                                        ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td class="body_textLog" align="right">Nueva contraseña:</td>
								<td><asp:textbox id="txtClaveN" runat="server" CssClass="textboxLog" 
                                        TextMode="Password" Width="140px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="Titulito3">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2"><asp:Label id="lblMensaje" runat="server" ForeColor="Highlight" 
                                        Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
							</tr>
							<tr>
								<td colspan="2">
                                    <asp:LinkButton ID="lkbGrabar" runat="server" SkinID="label_link" Font-Bold="True" onclick="lkbGrabar_Click">Grabar</asp:LinkButton>
                                </td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
   
    </div>
    </form>
</body>
</html>

