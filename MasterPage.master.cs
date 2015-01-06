using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"].ToString() == "" || Session["Usuario"] == null)
            Response.Redirect("Login.aspx");
        else
        {
            if (Session["Usuario"].ToString() != "cats" && Session["Rol"].ToString() != "AUXILIAR SERVICIO AL CLIENTE")
            {
                mnuPrincipal.FindItem("Retiros").Enabled = false;
                mnuPrincipal.FindItem("Informes/Informe Retiros").Enabled = false;
                mnuPrincipal.FindItem("Retiros").Selectable = false;
                mnuPrincipal.FindItem("Informes/Informe Retiros").Selectable = false;
                
            }
            if (Session["Usuario"].ToString() != "cats" && Session["Rol"].ToString() != "AUXILIAR TECNICO")
            {
                mnuPrincipal.FindItem("Devoluciones de Prima").Enabled = false;
                mnuPrincipal.FindItem("Informes/Informe Devoluciones de Prima").Enabled = false;
                mnuPrincipal.FindItem("Devoluciones de Prima").Selectable = false;
                mnuPrincipal.FindItem("Informes/Informe Devoluciones de Prima").Selectable = false;

            }
            lblFechaActual.Text = "FECHA:" + DateTime.Now.ToString("dd/MM/yyyy");
            lblUsuario.Text = "USUARIO:" + Session["Usuario"].ToString();
        }
    }
    

    protected void configMenu()
    {
        
    }
    protected void mnuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
    {
        
        switch (e.Item.Value)
        {
            case "Cartas Retiro":
                Response.Redirect("Clientes.aspx");
                break;
            case "Gestion Retiros":
                Response.Redirect("GestionRetiros.aspx");
                break;
            case "Devoluciones de Prima":
                Response.Redirect("DevolucionesPrima.aspx");
                break;
            case "Informe Devoluciones de Prima":
                Response.Redirect("InformesDevoluciones.aspx");
                break;
            case "Informe Retiros":
                Response.Redirect("InformesRetiros.aspx");
                break;
            case "Historico Pagos Por Mes":
                Response.Redirect("HistoricoPagosPorMes.aspx");
                break;
            case "Reporte Produccion":
                Response.Redirect("ReporteProduccion.aspx");
                break;
            case "Salir":
                {
                    Response.Redirect("Login.aspx");
                    Session["Usuario"] = "";
                    break;
                }
        }
    }
}
