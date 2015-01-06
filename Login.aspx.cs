using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Session["Navegador"] = Request.Browser.Browser;                     

    }
    
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + BD.dsConsultarUsuario(txtUsuario.Text, txtContraseña.Text).Tables[0].Rows[0].ToString() + "');", true);
        DataTable dt = BD.dsConsultarUsuario(txtUsuario.Text, txtContraseña.Text).Tables[0];
    
        if (dt.Rows.Count == 0) 
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "EL USUARIO O LA CONTRASEÑA NO SON VALIDOS" + "');", true);
        }
        else
        {
        
            if (dt.Rows[0]["con_estado"].ToString() == "SUSPENDIDO")
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "EL USUARIO SE ENCUENTRA SUSPENDIDO, COMUNIQUESE CON EL ADMINISTRADOR DEL SISTEMA" + "');", true);
            }
            else
            {
                Session["Rol"] = dt.Rows[0]["con_cargo"];
                Session["Usuario"] = dt.Rows[0]["con_usuario"];
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + dt.Rows[0]["con_usuario"] + "');", true);
                switch (dt.Rows[0]["con_cargo"].ToString())
                {
                    case "AUXILIAR TECNICO":
                        Response.Redirect("DevolucionesPrima.aspx");
                        break;                
                    case "AUXILIAR SERVICIO AL CLIENTE":
                        if (Session["Usuario"].ToString() == "cats")
                            Response.Redirect("GestionRetiros.aspx");
                        else
                            Response.Redirect("Clientes.aspx");
                        break;
                    default:
                        Response.Redirect("Clientes.aspx");
                        break;

                }
            }
        }
    }
}