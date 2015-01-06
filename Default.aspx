<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-st    .auto-style1 {
           /* width: 100%;*/
           align-content: center;
            width: 3500px;
            
        }
        .auto-style8 {
        }
        .auto-style9 {
            width: 313px;
        }
        .auto-style11 {
            width: 224px;
        }
        .auto-style12 {
            width: 187px;
        }
        .auto-style13 {
            height: 26px;
        }
        .auto-style14 {
            width: 313px;
            height: 26px;
        }
        .auto-style15 {
            width: 224px;
            height: 26px;
        }
        td { 
            background:#CFCFD4;

        }
        table {
            width: 99%;
            margin: 10px;
            /*margin-right: -50px;*/
            align-content: center;
        }
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <table >
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Text="CEDULA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCedula" ErrorMessage="Se requiere la cedula del cliente." ForeColor="Red" ValidationGroup="grpCed"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label7" runat="server" Text="COMPAÑIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:Label ID="Label2" runat="server" Text="PRODUCTO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style8" colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlCompañia" runat="server" OnSelectedIndexChanged="ddlCompañia_SelectedIndexChanged" OnTextChanged="ddlCompañia_TextChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlProducto" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style8" colspan="2">
                <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" Text="CONSULTAR" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" ValidationGroup="grpCed" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Miriam" Font-Underline="True" ForeColor="#193C75">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:Label ID="Label3" runat="server" Text="RECIBO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style9" colspan="1">
                <asp:Label ID="Label4" runat="server" Text="PRODUCTO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style8" colspan="1">
                <asp:Label ID="Label5" runat="server" Text="VIGENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style11" colspan="1">
                <asp:Label ID="Label6" runat="server" Text="VALOR" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                <asp:TextBox ID="txtRecibo" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style14" colspan="1">
                <asp:TextBox ID="txtProducto" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style13" colspan="1">
                <asp:TextBox ID="txtVigencia" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style15" colspan="1">
                <asp:TextBox ID="txtValor" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                <asp:Label ID="Label8" runat="server" Text="FECHA SOLICITUD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style14" colspan="1">
                <asp:Label ID="Label9" runat="server" Text="BANCO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style13" colspan="1">
                <asp:Label ID="Label10" runat="server" Text="NUMERO DE CUENTA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style15" colspan="1">
                <asp:Label ID="Label11" runat="server" Text="TIPO DE CUENTA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                <asp:TextBox ID="txtFechaSolicitud" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaSolicitud" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpDev"></asp:RequiredFieldValidator>
                
            </td>
            <td class="auto-style14" colspan="1">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBanco" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpDev"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style13" colspan="1">
                <asp:TextBox ID="txtNumeroCuenta" runat="server" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNumeroCuenta" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpDev"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style15" colspan="1">
                <asp:DropDownList ID="ddlTipoCuenta" runat="server" Enabled="False">
                    <asp:ListItem>AHORROS</asp:ListItem>
                    <asp:ListItem>CORRIENTE</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlTipoCuenta" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpDev"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                <asp:Label ID="Label12" runat="server" Text="CAUSAL DE DEVOLUCION" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style14" colspan="1">
                <asp:Label ID="Label13" runat="server" Text="FECHA DE TRANSFERENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style13" colspan="1">
                &nbsp;</td>
            <td class="auto-style15" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                <asp:TextBox ID="txtCausalDevolucion" runat="server" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCausalDevolucion" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpDev"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style14" colspan="1">
                <asp:TextBox ID="txtFechaTransferencia" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaTransferencia" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpDev"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style13" colspan="1">
                &nbsp;</td>
            <td class="auto-style15" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                &nbsp;</td>
            <td class="auto-style14" colspan="1">
                &nbsp;</td>
            <td class="auto-style13" colspan="1">
                &nbsp;</td>
            <td class="auto-style15" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                &nbsp;</td>
            <td class="auto-style14" colspan="1">
                &nbsp;</td>
            <td class="auto-style13" colspan="1">
                &nbsp;</td>
            <td class="auto-style15" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
            </td>
            <td class="auto-style14" colspan="1">
                <asp:Button ID="btnDevolucion" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Aplicar Devolucion" OnClick="btnDevolucion_Click" ValidationGroup="grpDev" />
                <asp:ConfirmButtonExtender ID="btnDevolucion_ConfirmButtonExtender" runat="server" ConfirmText="Esta seguro de Aplicar Devolucion" Enabled="True" TargetControlID="btnDevolucion" ConfirmOnFormSubmit="True">
                </asp:ConfirmButtonExtender>
            </td>
            <td class="auto-style13" colspan="1">
            </td>
            <td class="auto-style15" colspan="1">
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style13">
                <asp:Label ID="lblFechaActual" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Label"></asp:Label>
            </td>
            <td class="auto-style14" colspan="1">
                <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Label"></asp:Label>
            </td>
            <td class="auto-style13" colspan="1">
                &nbsp;</td>
            <td class="auto-style15" colspan="1">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

