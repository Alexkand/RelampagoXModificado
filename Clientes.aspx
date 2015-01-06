<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    
        td { 
            background:#CFCFD4;
        }
        table {
            width: 99%;
            margin: 10px;
            /*margin-right: -50px;*/
            align-content: center;
        }   
        .celdaCentrada {
            background:#CFCFD4;
            align-content: center;
            text-align: center;
        }   
        
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 23px;
        }
        
        .auto-style3 {
            height: 33px;
        }
        
    .auto-style4 {
        width: 1311px;
    }
    .auto-style10 {
        height: 23px;
        width: 511px;
    }
        .auto-style13 {
    }
        .auto-style14 {
            width: 511px;
        }
        .auto-style16 {
            width: 328px;
        }
        .auto-style17 {
            height: 23px;
            }
        
        .auto-style19 {
            width: 503px;
            height: 30px;
        }
        
        .auto-style23 {
            height: 23px;
            width: 599px;
        }
        .auto-style24 {
            height: 23px;
            width: 503px;
        }
        .auto-style25 {
            width: 503px;
        }
        .auto-style26 {
            width: 324px;
            height: 30px;
        }
        .auto-style27 {
            width: 324px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table>
    <tr>
    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CEDULA"></asp:Label>
                        <asp:TextBox ID="txtCedula" runat="server" Height="20px" Width="161px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCedula" ErrorMessage="Se requiere la cedula del cliente." ForeColor="Red" ValidationGroup="grpCed"></asp:RequiredFieldValidator>
                    </td>
    </tr> 
    <tr>
    <td class="auto-style3">
                        <asp:Button ID="btnConsultar" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnConsultar_Click" Text="CONSULTAR" ValidationGroup="grpCed" />
                    </td>
    </tr> 
    </table>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Menu ID="mnuCliente" runat="server" BorderColor="#003E87" Font-Bold="True" Font-Names="Miriam" ForeColor="#011D5E" Orientation="Horizontal" OnMenuItemClick="mnuCliente_MenuItemClick">
                            <Items>
                                <asp:MenuItem Text="Nuevo" Value="Nuevo"></asp:MenuItem>
                                <asp:MenuItem Text="Editar" Value="Editar"></asp:MenuItem>
                                <asp:MenuItem Text="Guardar" Value="Guardar"></asp:MenuItem>
                                <asp:MenuItem Text="Cancelar" Value="Cancelar"></asp:MenuItem>
                            </Items>
                            <StaticHoverStyle BorderColor="#014691" BorderStyle="Solid" />
                        </asp:Menu>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="celdaCentrada" colspan="3">
                        <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="INFORMACION PERSONAL"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="APELLIDOS"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="NOMBRES"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SEXO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtApellidos" runat="server" Enabled="False" Height="20px" Width="314px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombres" runat="server" Enabled="False" Height="20px" Width="314px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSexo" runat="server" Enabled="False" Height="20px">
                            <asp:ListItem>MASCULINO</asp:ListItem>
                            <asp:ListItem>FEMENINO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="ESTADO CIVIL"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA DE NACIMIENTO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="EDAD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlEstadoCivil" runat="server" Enabled="False" Height="20px">
                            <asp:ListItem>CASADO (A)</asp:ListItem>
                            <asp:ListItem>SOLTERO (A)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" Enabled="False" Height="20px" TextMode="Date"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEdad" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="OCUPACION"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="DEPARTAMENTO"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CIUDAD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlOcupacion" runat="server" Enabled="False" Height="20px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" Enabled="False" Height="20px" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server" Enabled="False" Height="20px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="DIRECCION DE CORRESPONDENCIA"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="TELEFONO RESIDENCIA"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtDireccionCorrespondencia" runat="server" Enabled="False" Height="20px" Width="737px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefonoResidencia" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="TELEFONO OFICINA"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CELULAR"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CORREO ELECTRONICO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtTelefonoOficina" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelular" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server" Enabled="False" Height="20px" Width="194px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="OBSERVACIONES"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtObservaciones" runat="server" Enabled="False" Height="75px" TextMode="MultiLine" Width="735px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="celdaCentrada" colspan="3">
                        <asp:Button ID="btnResumen" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnResumen_Click" Text="RESUMEN DE PRODUCTOS" ValidationGroup="grpCed" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table >
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="COMPAÑIA"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="PRODUCTO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlCompañia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlProducto" runat="server" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="celdaCentrada" colspan="2">
                        <asp:Button ID="btnConsultarResumen" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnConsultarResumen_Click" Text="CONSULTAR" ValidationGroup="grpCed" />
                    </td>
                </tr>
                <tr>
                    <td class="celdaCentrada" colspan="2">
                        <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CERTIFICADOS CLIENTE"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grvResumen" runat="server" Font-Names="Miriam" Font-Underline="True" ForeColor="#193C75" OnSelectedIndexChanged="grvResumen_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="celdaCentrada">
                        <asp:Button ID="btnVerCliente" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnVerCliente_Click" Text="VER INFORMACION CLIENTE" ValidationGroup="grpCed" />
                        
                    </td>
                </tr>
                <tr>
                    <td class="celdaCentrada" colspan="2">
                        <asp:Button ID="btnPagosCliente" runat="server" Enabled="False" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnPagosCliente_Click" Text="PAGOS POR CLIENTE" ValidationGroup="grpCed" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="celdaCentrada" colspan="2">
                        <asp:GridView ID="grvPagosCliente" runat="server" Font-Names="Miriam" Font-Underline="True" ForeColor="#193C75" OnSelectedIndexChanged="grvResumen_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
                        <table class="auto-style4">
                            <tr>
                                <td class="auto-style13">
                                    <asp:Menu ID="mnuGestionRetiro" runat="server" BorderColor="#003E87" Font-Bold="True" Font-Names="Miriam" ForeColor="#011D5E" OnMenuItemClick="mnuGestionRetiro_MenuItemClick" Orientation="Horizontal">
                                        <Items>
                                            <asp:MenuItem Text="Nuevo" Value="Nuevo"></asp:MenuItem>
                                            <asp:MenuItem Text="Editar" Value="Editar"></asp:MenuItem>
                                            <asp:MenuItem Text="Guardar" Value="Guardar"></asp:MenuItem>
                                            <asp:MenuItem Text="Cancelar" Value="Cancelar"></asp:MenuItem>
                                        </Items>
                                        <StaticHoverStyle BorderColor="#014691" BorderStyle="Solid" />
                                    </asp:Menu>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CERTIFICADO"></asp:Label>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtCertificado" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="VALOR PRIMA"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CONYUGE"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SUMA ASEGURADA PRINCIPAL"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SUMA ASEGURADA CONYUGE"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtPrimaTotal" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtConyuge" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtSumaAseguradaPpal" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtSumaAseguradaCony" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA CARTA RETIRO"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="TIPO DE GESTION"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA DE CONTACTO"></asp:Label>
                                </td>
                                <td class="auto-style16">
                                    <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="HORA DE CONTACTO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaCarta" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaCarta" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaCarta" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpRet"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style13">
                                    <asp:DropDownList ID="ddlTipoGestion" runat="server" Enabled="False">
                                        <asp:ListItem>RETIRO DEFINITIVO</asp:ListItem>
                                        <asp:ListItem>RECUPERACION</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaContacto" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaContacto" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaContacto" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpRet"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style16">
                                    <asp:TextBox ID="txtHora" runat="server" Height="16px" TextMode="Time" Width="103px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="NOMBRE DEL FUNCIONARIO"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="VIGENCIA QUE APLICA"></asp:Label>
                                </td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:DropDownList ID="ddlAsesor" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAsesor" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaAplicacion" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaAplicacion" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFechaAplicacion" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpRet"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style14" colspan="2">
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CAUSAL RETIRO"></asp:Label>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:DropDownList ID="ddlCausalRetiro" runat="server" Enabled="False">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCausalRetiro" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="GESTION"></asp:Label>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtGestion" runat="server" Enabled="False" Height="77px" TextMode="MultiLine" Width="711px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtGestion" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17"></td>
                                <td class="auto-style17"></td>
                                <td class="auto-style10" colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="auto-style2" colspan="4">
                                    <asp:GridView ID="grvRetiros" runat="server" Font-Names="Miriam" Font-Size="Small" Font-Underline="True" ForeColor="#193C75" OnSelectedIndexChanged="grvRetiros_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="celdaCentrada" colspan="4">
                                    <asp:Button ID="btnVerResumen" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnVerResumen_Click" Text="VER RESUMEN CLIENTE" />
                                </td>
                            </tr>
                        </table>
                        </asp:View>

        <asp:View ID="View4" runat="server">
                        <table>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Menu ID="mnuCartaRetiro" runat="server" BorderColor="#003E87" Font-Bold="True" Font-Names="Miriam" ForeColor="#011D5E" OnMenuItemClick="mnuCartaRetiro_MenuItemClick" Orientation="Horizontal">
                                        <Items>
                                            <asp:MenuItem Text="Nuevo" Value="Nuevo"></asp:MenuItem>
                                            <asp:MenuItem Text="Editar" Value="Editar"></asp:MenuItem>
                                            <asp:MenuItem Text="Guardar" Value="Guardar"></asp:MenuItem>
                                            <asp:MenuItem Text="Cancelar" Value="Cancelar"></asp:MenuItem>
                                        </Items>
                                        <StaticHoverStyle BorderColor="#014691" BorderStyle="Solid" />
                                    </asp:Menu>
                                </td>
                                <td class="auto-style2"></td>
                                <td class="auto-style24" colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="celdaCentrada" colspan="4">
                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CARTA DE RETIRO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CERTIFICADO"></asp:Label>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style25" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    <asp:TextBox ID="txtCertificadoCarta" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style26"></td>
                                <td class="auto-style19" colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="VALOR PRIMA"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CONYUGE"></asp:Label>
                                </td>
                                <td class="auto-style27">
                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SUMA ASEGURADA PRINCIPAL"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SUMA ASEGURADA CONYUGE"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtPrimaTotalCarta" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtConyugeCarta" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style27">
                                    <asp:TextBox ID="txtSumaAseguradaPpalCarta" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtSumaAseguradaConyCarta" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA RADICACION TORRES GUARIN"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label39" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="LOCALIDAD"></asp:Label>
                                </td>
                                <td class="auto-style27">
                                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA RADICACION COMPAÑIA"></asp:Label>
                                </td>
                                <td class="auto-style27">
                                    <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="OFICINA COMPAÑIA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaRadicacionTorres" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaRadicacionTorres" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpCarta"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFechaRadicacionTorres" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpCarta"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtLocalidad" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="auto-style27">
                                    <asp:TextBox ID="txtFechaRadicacionCompañia" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaRadicacionCompañia" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpCarta"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFechaRadicacionCompañia" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpCarta"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style27">
                                    <asp:DropDownList ID="ddlOficinaCompañia" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>N/A</asp:ListItem>
                                        <asp:ListItem>SEGUROS BOLIVAR</asp:ListItem>
                                        <asp:ListItem>LA PREVISORA</asp:ListItem>
                                        <asp:ListItem>LIBERTY SEGUROS</asp:ListItem>
                                        <asp:ListItem>MAPFRE</asp:ListItem>
                                        <asp:ListItem>SURAMERICANA</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlOficinaCompañia" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpCarta"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="ORIGEN DEL OFICIO"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA RECIBIDO CASA MATRIZ"></asp:Label>
                                </td>
                                <td class="auto-style25" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:DropDownList ID="ddlOrigenOficio" runat="server" Enabled="False">
                                        <asp:ListItem>DERECHO DE PETICION</asp:ListItem>
                                        <asp:ListItem>QUEJAS SUPERINTENDENCIA</asp:ListItem>
                                        <asp:ListItem>SOLICITUD DEL ASEGURADO</asp:ListItem>
                                        <asp:ListItem>SOLICITUD DE LA PAGADURIA</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlOrigenOficio" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpCarta"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaRecibidoCasaMatriz" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFechaRecibidoCasaMatriz" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpCarta"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtFechaRecibidoCasaMatriz" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpCarta"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style25" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="OBSERVACION"></asp:Label>
                                </td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style25" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13" colspan="2">
                                    <asp:TextBox ID="txtObservacion" runat="server" Enabled="False" Height="77px" TextMode="MultiLine" Width="711px"></asp:TextBox>
                                </td>
                                <td class="auto-style25" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    &nbsp;</td>
                                <td class="auto-style13">&nbsp;</td>
                                <td class="auto-style25" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style17"></td>
                                <td class="auto-style17"></td>
                                <td class="auto-style24" colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="celdaCentrada" colspan="4">
                                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CARTAS DE RETIRO POR CLIENTE"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2" colspan="4">
                                    <asp:GridView ID="grvCartasRetiro" runat="server" Font-Names="Miriam" Font-Size="Small" Font-Underline="True" ForeColor="#193C75">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="celdaCentrada" colspan="4">
                                    <asp:Button ID="btnVerResumenCarta" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnVerResumenCarta_Click" Text="VER RESUMEN CLIENTE" />
                                </td>
                            </tr>
                        </table>
                        
                        </asp:View>
        <asp:View ID="View5" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </asp:View>

    </asp:MultiView>

    
</asp:Content>