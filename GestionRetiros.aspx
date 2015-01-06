<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GestionRetiros.aspx.cs" Inherits="GestionRetiros" %>

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
        
        .auto-style2 {
            height: 23px;
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
        
    .auto-style18 {
        width: 327px;
        height: 20px;
    }
    .auto-style19 {
        width: 328px;
        height: 20px;
    }
        
    .auto-style20 {
        width: 166px;
    }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
    <td class="auto-style3">
                        <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CEDULA"></asp:Label>
                        <asp:TextBox ID="txtCedula" runat="server" Height="20px" Width="161px" Enabled="False"></asp:TextBox>
                    </td>
    <td class="auto-style3">
                        <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CERTIFICADO"></asp:Label>
                        <asp:TextBox ID="txtCertificado" runat="server" Height="20px" Width="161px" Enabled="False"></asp:TextBox>
                    </td>
    </tr> 
    </table>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
        <asp:View ID="View1" runat="server">
    
                        <table>
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
                                <td class="celdaCentrada" colspan="4">
                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="GESTION TELEFONICA"></asp:Label>
                                </td>
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
                                <td class="auto-style18">
                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA CARTA RETIRO"></asp:Label>
                                </td>
                                <td class="auto-style18">
                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="TIPO DE GESTION"></asp:Label>
                                </td>
                                <td class="auto-style18">
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA DE CONTACTO"></asp:Label>
                                </td>
                                <td class="auto-style19">
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
                                    <asp:DropDownList ID="ddlTipoGestion" runat="server" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoGestion_SelectedIndexChanged">
                                        <asp:ListItem>RETIRO DEFINITIVO</asp:ListItem>
                                        <asp:ListItem>RECUPERACION</asp:ListItem>
                                        <asp:ListItem>DESISTIMIENTO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaContacto" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaContacto" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaContacto" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpRet"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style16">
                                    <asp:TextBox ID="txtHora" runat="server" Height="16px" TextMode="Time" Width="103px" Enabled="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtHora" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="NOMBRE DEL FUNCIONARIO"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="VIGENCIA QUE APLICA"></asp:Label>
                                </td>
                                <td class="auto-style14" colspan="2">
                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CAUSAL RETIRO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:DropDownList ID="ddlAsesor" runat="server" Enabled="False">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAsesor" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtFechaAplicacion" runat="server" Enabled="False" Height="20px" Width="128px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaAplicacion" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFechaAplicacion" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpRet"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style14" colspan="2">
                                    <asp:DropDownList ID="ddlCausalRetiro" runat="server" Enabled="False">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCausalRetiro" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpRet"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="MES DE PRODUCCION"></asp:Label>
                                </td>
                                <td class="auto-style13">
                                    <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="AÑO DE PRODUCCION"></asp:Label>
                                </td>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtMesProduccion" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="txtAñoProduccion" runat="server" Enabled="False" Height="20px" Width="128px"></asp:TextBox>
                                </td>
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
                                <td class="celdaCentrada" colspan="4">
                                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="GESTIONES CERTIFICADO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2" colspan="4">
                                    <asp:GridView ID="grvRetiros" runat="server" Font-Names="Miriam" Font-Size="Small" Font-Underline="True" ForeColor="#193C75">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="celdaCentrada" colspan="4">
                                    &nbsp;</td>
                            </tr>
                        </table>
            </asp:View>
        <asp:View ID="View2" runat="server">
                <table >
        <tr>
            <td class="auto-style20">
                <asp:Label ID="Label3" runat="server" Text="LOCALIDAD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:Label ID="Label6" runat="server" Text="CEDULA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:Label ID="Label4" runat="server" Text="CERTIFICADO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:Label ID="Label5" runat="server" Text="FECHA DE DIGITACION" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:DropDownList ID="ddlLocalidad" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtCedulaBusqueda" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtCertificadoBusqueda" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtFechaDigitacion" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFechaDigitacion" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpDev"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="grpDev" />
                </td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
                    <tr>
                        <td class="celdaCentrada" colspan="4">
                            <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CARTAS DE RETIRO"></asp:Label>
                        </td>
                    </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="grvCartasRetiro" runat="server" Font-Names="Miriam" Font-Size="Small" Font-Underline="True" ForeColor="#193C75" OnSelectedIndexChanged="grvCartasRetiro_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style20">
                &nbsp;</td>
            <td class="auto-style23" colspan="1">
                &nbsp;</td>
            <td class="auto-style24" colspan="1">
                &nbsp;</td>
            <td class="auto-style24" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style20">
                &nbsp;</td>
            <td class="auto-style23" colspan="1">
                &nbsp;</td>
            <td class="auto-style24" colspan="1">
                &nbsp;</td>
            <td class="auto-style24" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
    </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
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
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="NOMBRES"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SEXO"></asp:Label>
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
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="ESTADO CIVIL"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="FECHA DE NACIMIENTO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="EDAD"></asp:Label>
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
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpDev"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEdad" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="OCUPACION"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="DEPARTAMENTO"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CIUDAD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlOcupacion" runat="server" Enabled="False" Height="20px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" Enabled="False" Height="20px" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server" Enabled="False" Height="20px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="DIRECCION DE CORRESPONDENCIA"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="TELEFONO RESIDENCIA"></asp:Label>
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
                        <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="TELEFONO OFICINA"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CELULAR"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label39" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="CORREO ELECTRONICO"></asp:Label>
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
                        <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="OBSERVACIONES"></asp:Label>
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
                        <asp:Button ID="btnGestionRetiro" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" OnClick="btnGestionRetiro_Click" Text="GESTION DE RETIRO" />
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

    </asp:MultiView>
                        

</asp:Content>

