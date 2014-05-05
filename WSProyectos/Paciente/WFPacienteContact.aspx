<%@ Page Title="Datos de Contacto" Language="C#" AutoEventWireup="true" CodeBehind="WFPacienteContact.aspx.cs" Inherits="WSProyectos.Paciente.WFPacienteContact" MasterPageFile="~/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table align="left" style="width: 600px">
            <tr>
                <td valign="top" align="left">
                  <asp:UpdatePanel ID="updActualizar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                        <table>
                           <tr>
                            <td colspan="3"><asp:Label ID="Label1" runat="server" CssClass="Titulitos" Text="Datos de Contacto del Paciente"></asp:Label></td>
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
                                    </asp:UpdateProgress>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY" runat="server" CssClass="TitulitosSub" 
                                        Text="Departamento:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" 
                                        CssClass="textbox1" onselectedindexchanged="ddlDepartamento_SelectedIndexChanged" 
                                        Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY0" runat="server" CssClass="TitulitosSub" Text="Provincia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="textbox1" 
                                        Width="250px" AutoPostBack="True" 
                                        onselectedindexchanged="ddlProvincia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY1" runat="server" CssClass="TitulitosSub" Text="Distrito:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="textbox1" 
                                        Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY2" runat="server" CssClass="TitulitosSub" Text="Dirección"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox1" Height="35px" 
                                        TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" 
                                        ControlToValidate="txtDireccion" ErrorMessage="Ingresar dirección" 
                                        ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY3" runat="server" CssClass="TitulitosSub" 
                                        Text="Referencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRef" runat="server" CssClass="textbox1" Height="35px" 
                                        TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY4" runat="server" CssClass="TitulitosSub" 
                                        Text="Teléfono #1:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTel1" runat="server" CssClass="textbox1"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY5" runat="server" CssClass="TitulitosSub" 
                                        Text="Teléfono #2:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTel2" runat="server" CssClass="textbox1"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPY6" runat="server" CssClass="TitulitosSub" Text="Celular:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCel" runat="server" CssClass="textbox1"></asp:TextBox>
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
                    <asp:LinkButton ID="btnAceptar" runat="server" Text="Aceptar" 
                            onclick="btnAceptar_Click" ></asp:LinkButton>&nbsp; &nbsp;
                    <asp:LinkButton ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click">Cancelar</asp:LinkButton></td>
                </tr>
                        </table>
                    </asp:Panel>
                                                                <div style="text-align:center"><asp:Label ID="lblMensaje" runat="server" Text="" EnableViewState="false" SkinID="label_vacio"></asp:Label></div>

                     </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlProvincia" EventName="SelectedIndexChanged" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>