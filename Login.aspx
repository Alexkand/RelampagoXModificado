<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-st    .auto-style1 {
            width: 1233px;
        }
        td { 
            background:#CFCFD4;
            align-content:center; 
            text-align:center;  

            

        }
        .auto-style1 {
            width: 100%;
            height: 120px;
        }
        .auto-style2 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="1" class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="USUARIO" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style2">
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="CONTRASEÑA" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style2">
                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="1" class="auto-style2">
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnConsultar_Click" Text="ACEPTAR" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" />
            </td>
        </tr>
    </table>
</asp:Content>

