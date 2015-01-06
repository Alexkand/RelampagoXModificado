<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clientes1.aspx.cs" Inherits="Clientes" %>

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
            height: 20px;
        }
        .auto-style2 {
            height: 23px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table style="width:100%;">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" Text="CEDULA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                <asp:TextBox ID="txtCedula" runat="server" Height="20px" Width="161px"></asp:TextBox>
                <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" Text="CONSULTAR" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" ValidationGroup="grpCed" />
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="APELLIDOS" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="NOMBRES" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="SEXO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtApellidos" runat="server" Height="20px" Width="314px" Enabled="False"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="txtNombres" runat="server" Height="20px" Width="314px" Enabled="False"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="txtCedula2" runat="server" Height="20px"></asp:TextBox>
                <asp:DropDownList ID="ddlSexo" runat="server" Enabled="False" Height="20px">
                    <asp:ListItem>MASCULINO</asp:ListItem>
                    <asp:ListItem>FEMENINO</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="ESTADO CIVIL" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="FECHA DE NACIMIENTO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="EDAD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtEstadoCivil" runat="server" Height="20px"></asp:TextBox>
                <asp:DropDownList ID="ddlEstadoCivil" runat="server" Enabled="False" Height="20px">
                    <asp:ListItem>CASADO (A)</asp:ListItem>
                    <asp:ListItem>SOLTERO (A)</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" Enabled="False" Height="20px" TextMode="Date"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="txtCedula5" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label8" runat="server" Text="OCUPACION" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td class="auto-style1">
                <asp:Label ID="Label9" runat="server" Text="DEPARTAMENTO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td class="auto-style1">
                <asp:Label ID="Label10" runat="server" Text="CIUDAD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtOcupacion" runat="server" Height="20px"></asp:TextBox>
                <asp:DropDownList ID="ddlOcupacion" runat="server" Enabled="False" Height="20px">
                </asp:DropDownList>
                </td>
            <td>
                <asp:TextBox ID="txtDepartamento" runat="server" Height="20px"></asp:TextBox>
                <asp:DropDownList ID="ddlDepartamento" runat="server" Enabled="False" Height="20px" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            <td>
                <asp:TextBox ID="txtCiudad" runat="server" Height="20px"></asp:TextBox>
                <asp:DropDownList ID="ddlCiudad" runat="server" Enabled="False" Height="20px">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="Label11" runat="server" Text="DIRECCION DE CORRESPONDENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td class="auto-style1">
                <asp:Label ID="Label13" runat="server" Text="TELEFONO RESIDENCIA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtDireccionCorrespondencia" runat="server" Height="20px" Width="737px" Enabled="False"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="txtTelefonoResidencia" runat="server" Enabled="False" Height="20px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="TELEFONO OFICINA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label15" runat="server" Text="CELULAR" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label16" runat="server" Text="CORREO ELECTRONICO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
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
                <asp:Label ID="Label17" runat="server" Text="OBSERVACIONES" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text="EDAD" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Height="75px" Width="735px" Enabled="False"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="txtCedula17" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
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
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
   
</asp:Content>

