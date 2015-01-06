<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformesRetiros.aspx.cs" Inherits="InformesRetiros" %>

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
            width: 1328px;
        }
        .auto-style6 {
            width: 332px;
        }
        .auto-style7 {
            width: 331px;
        }
    .auto-style8 {
        height: 25px;
    }
    .auto-style9 {
        width: 332px;
        height: 25px;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table >
        <tr>
            <td class="auto-style8" colspan="2">
                <asp:Label ID="Label7" runat="server" Text="SELECCIONE INFORME" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">
                <asp:DropDownList ID="ddlInforme" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInforme_SelectedIndexChanged">
                    <asp:ListItem Value="INFORME NOVEDADES">INFORME NOVEDADES</asp:ListItem>
                    <asp:ListItem>INFORME RETIROS DEFINITIVOS</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style9">
                </td>
            <td class="auto-style9">
                </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label3" runat="server" Text="LOCALIDAD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:Label ID="Label6" runat="server" Text="DIGITACION DESDE" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:Label ID="Label4" runat="server" Text="DIGITACION HASTA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:Label ID="Label5" runat="server" Text="FECHA DE VIGENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlLocalidad" runat="server">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtDesde" runat="server" Enabled="False" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesde" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpInf"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDesde" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpInf"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtHasta" runat="server" Enabled="False" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHasta" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpInf"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHasta" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpInf"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtFechaVigencia" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaVigencia" ErrorMessage="** Campo Requerido" Font-Size="Smaller" ForeColor="Red" ValidationGroup="grpInf"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFechaVigencia" ErrorMessage="Formato de Fecha: &quot;dd/mm/yyyy&quot;" Font-Size="Smaller" ForeColor="Red" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="grpInf"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="grpInf" />
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="celdaCentrada">
                <asp:Label ID="Label8" runat="server" Text="INFORME RETIROS" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                
                
                <asp:GridView ID="grvInformesRetiros" runat="server" Font-Names="Miriam" Font-Underline="True" ForeColor="#193C75" Font-Size="Small" AllowPaging="True" OnPageIndexChanging="grvInformesRetiros_PageIndexChanging" PageSize="50">
                    <HeaderStyle BackColor="#183E77" ForeColor="#CFCFD4" />
                    <PagerStyle HorizontalAlign="Left" Wrap="True" />
                </asp:GridView>
                 
                 
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style7">
                &nbsp;</td>
            <td class="auto-style7" colspan="1">
                &nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style6" colspan="1">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnExcel" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="Descargar Excel" ValidationGroup="grpEdicion" OnClick="btnExcel_Click" Enabled="False" Visible="False" />
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
    </table>
        
</asp:Content>

