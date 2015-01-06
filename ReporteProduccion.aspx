<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteProduccion.aspx.cs" Inherits="ReporteProduccion" %>

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
        .espacioFin {
            margin: 300px, 300px, 300px, 300px;
        }
        
        .auto-style1 {
            width: 323px;
        }
        
        .auto-style4 {
            width: 250px;
            height: 26px;
        }
        .auto-style11 {
            width: 280px;
            height: 26px;
        }
        .auto-style12 {
            width: 280px;
        }
        .auto-style16 {
            width: 250px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
    <td class="auto-style11">
                        <asp:Label ID="labMesInicio" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="MES REPORTE"></asp:Label>                                                
                    </td>
        <td class="auto-style4" align="center">
            <asp:DropDownList ID="ddlMesInicio" Height="20px" Width="120px" runat="server"></asp:DropDownList>
        </td>
    <td class="auto-style11">
                        <asp:Label ID="labAnioInicio" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="AÑO REPORTE"></asp:Label>                                                
                    </td>
        <td class="auto-style4" align="center">
            <asp:DropDownList ID="ddlAnioInicio" Height="20px" Width="120px" runat="server"></asp:DropDownList>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="auto-style12">
            <asp:Label ID="labCompania" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="SELECCIONE LA COMPAÑÍA <br/> SELECCIONE EL PRODUCTO"></asp:Label>                       
        </td>
        <td align="center" class="auto-style16">            

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlCompanias" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="ddlCompanias_SelectedIndexChanged" Width="200px">
                    </asp:DropDownList>                                   
                    <asp:DropDownList ID="ddlSeguros" runat="server" AutoPostBack="True" Height="20px" Width="200px">
                    </asp:DropDownList>
                </ContentTemplate>
                
            </asp:UpdatePanel>    

        </td>
        <td class="auto-style12" align="center">
                                   
            <asp:Button ID="btnGestionRetiro" runat="server" Font-Bold="True" Font-Names="Miriam" ForeColor="#193C75" Text="GENERAR REPORTE" OnClick="btnGestionRetiro_Click" />
                        lkjsdlfkjdfkljjdflkdjflkdjflkdfjldkfj           
        </td>

        <td>    
              
            
        </td>

        
        <td align="center" class="auto-style16">          
                &nbsp;</td>
        
    </tr>    
    </table>
                            

</asp:Content>

