<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformesDevoluciones.aspx.cs" Inherits="InformesDevoluciones" %>

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
        
        
    .auto-style1 {
        width: 1341px;
    }
    .auto-style6 {
        width: 334px;
    }
    .auto-style7 {
        width: 335px;
    }
    .auto-style8 {
        width: 334px;
        height: 20px;
    }
    .auto-style9 {
        width: 335px;
        height: 20px;
    }
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table >
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label3" runat="server" Text="LOCALIDAD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:Label ID="Label6" runat="server" Text="CEDULA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:Label ID="Label4" runat="server" Text="RECIBO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:Label ID="Label5" runat="server" Text="FECHA DE TRANSFERENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlLocalidad" runat="server" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtRecibo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtFechaTransferencia" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaTransferencia" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpDev"></asp:RegularExpressionValidator>
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
            <td colspan="4">
                <asp:GridView ID="grvDevoluciones" runat="server" Font-Names="Miriam" Font-Underline="True" ForeColor="#193C75" Font-Size="Small" OnSelectedIndexChanged="grvDevoluciones_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Modificar" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style23">
                <asp:Label ID="Label8" runat="server" Text="FECHA SOLICITUD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style23" colspan="1">
                <asp:Label ID="Label9" runat="server" Text="BANCO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style24" colspan="1">
                <asp:Label ID="Label10" runat="server" Text="NUMERO DE CUENTA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style24" colspan="1">
                <asp:Label ID="Label11" runat="server" Text="TIPO DE CUENTA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style23">
                <asp:TextBox ID="txtFechaSolicitud" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaSolicitud" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaSolicitud" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpEdicion"></asp:RegularExpressionValidator>
                
            </td>
            <td class="auto-style23" colspan="1">
                <asp:DropDownList ID="ddlBanco" runat="server" Enabled="False">
                    <asp:ListItem>DAVIVIENDA</asp:ListItem>
                    <asp:ListItem>BANCOLOMBIA</asp:ListItem>
                    <asp:ListItem>CAJA SOCIAL</asp:ListItem>
                    <asp:ListItem>BANCO AGRARIO</asp:ListItem>
                    <asp:ListItem>BANCO POPULAR</asp:ListItem>
                    <asp:ListItem>AV VILLAS</asp:ListItem>
                    <asp:ListItem>BBVA</asp:ListItem>
                    <asp:ListItem>COOMEVA</asp:ListItem>
                    <asp:ListItem>CITIBANK</asp:ListItem>
                    <asp:ListItem>BANCO DE BOGOTA</asp:ListItem>
                    <asp:ListItem>BANCO DE OCCIDENTE</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBanco" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style24" colspan="1">
                <asp:TextBox ID="txtNumeroCuenta" runat="server" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNumeroCuenta" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style24" colspan="1">
                <asp:DropDownList ID="ddlTipoCuenta" runat="server" Enabled="False">
                    <asp:ListItem>AHORROS</asp:ListItem>
                    <asp:ListItem>CORRIENTE</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlTipoCuenta" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style23">
                <asp:Label ID="Label12" runat="server" Text="CAUSAL DE DEVOLUCION" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style23" colspan="1">
                <asp:Label ID="Label13" runat="server" Text="FECHA DE TRANSFERENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style24">
                <asp:Label ID="Label15" runat="server" Text="ESTADO DEVOLUCION" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style24" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style23">
                <asp:TextBox ID="txtCausalDevolucion" runat="server" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCausalDevolucion" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style23" colspan="1">
                <asp:TextBox ID="txtFechaTransferenciaEditar" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaTransferenciaEditar" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFechaTransferenciaEditar" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpEdicion"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style24">
                <asp:DropDownList ID="ddlEstadoDevolucion" runat="server" Enabled="False">
                    <asp:ListItem>TRAMITADA</asp:ListItem>
                    <asp:ListItem>RECHAZADA</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlEstadoDevolucion" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpEdicion"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style24" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnActualizar" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="False" ValidationGroup="grpEdicion" />
                <asp:Button ID="btnCancelar" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Cancelar" OnClick="btnCancelar_Click" Enabled="False" />
                </td>
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
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

