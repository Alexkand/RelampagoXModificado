using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web.Services;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["Usuario"].ToString() == "")
            Response.Redirect("Login.aspx");*/
        
        Session.Timeout = 20;
        if (!IsPostBack) 
        {
            
            ddlCompañia.DataSource = BD.dsConsultarCompañia();
            ddlCompañia.DataTextField = "com_nombre";
            ddlCompañia.DataValueField = "com_id";
            ddlCompañia.DataBind();

            ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
            ddlProducto.DataTextField = "pro_nombre";
            ddlProducto.DataValueField = "pro_id";
            ddlProducto.DataBind();
            }
            btnDevolucion.Enabled = false;
            
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtRecibo.Text= GridView1.SelectedRow.Cells[4].Text;        
        txtProducto.Text = GridView1.SelectedRow.Cells[2].Text;
        txtVigencia.Text = GridView1.SelectedRow.Cells[6].Text;
        txtValor.Text = GridView1.SelectedRow.Cells[5].Text;
        txtLocalidad.Text = GridView1.SelectedRow.Cells[1].Text;

        

        GridView1.Visible = false;
        if (txtProducto.Text == "DEVOLUCION DE PRIMA" || txtProducto.Text == "DEVOLUCION DE PRIMA RECHAZADA")
        {
            btnDevolucion.Enabled = true;
            txtFechaTransferencia.Enabled = true;
            txtNumeroCuenta.Enabled = true;
            txtCausalDevolucion.Enabled = true;
            txtFechaSolicitud.Enabled = true;
            ddlTipoCuenta.Items.Insert(0, new ListItem("", ""));
            ddlTipoCuenta.SelectedIndex = 0;
            ddlBanco.Items.Insert(0, new ListItem("", ""));
            ddlBanco.SelectedIndex = 0;
            ddlEstadoDevolucion.Items.Insert(0, new ListItem("", ""));
            ddlEstadoDevolucion.SelectedIndex = 0;
            ddlTipoCuenta.Enabled = true;
            ddlBanco.Enabled = true;
            ddlEstadoDevolucion.Enabled = true;
        }
    }
    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlCompañia.SelectedValue.ToString() + "');", true);
        ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_id";
        ddlProducto.DataBind();
    }
    /*protected void ddlCompañia_TextChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlCompañia.SelectedValue.ToString() + "');", true);
        ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_id";
        ddlProducto.DataBind();
    }*/

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = BD.dtConsultarCliente(txtCedula.Text);
        if (dt.Rows.Count > 0)
        {

            txtNombreCompleto.Text = dt.Rows[0]["ter_Nombres"].ToString()+" "+ dt.Rows[0]["ter_Apellidos"].ToString();
            GridView1.DataSource = BD.dsConsultarPagosClienteCompañia(txtCedula.Text, ddlCompañia.SelectedValue.ToString());
            GridView1.DataBind();
            GridView1.Visible = true;
            if (Session["Navegador"].ToString() == "Chrome")
            {
                RegularExpressionValidator1.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
            }
            
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CEDULA NO EXISTE PARA NINGUN CLIENTE EN EL SISTEMA" + "');", true);
        
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "hola" + "');", true);
    }

    protected void btnDevolucion_Click(object sender, EventArgs e)
    {
        BD.actualizarPago(txtCedula.Text, GridView1.SelectedRow.Cells[8].Text, txtValor.Text, ddlProducto.SelectedValue.ToString(),ddlEstadoDevolucion.SelectedValue.ToString());
        BD.insertarDevolucion(txtCedula.Text, txtRecibo.Text, ddlProducto.SelectedValue.ToString(), Convert.ToDateTime(txtFechaSolicitud.Text).ToString("dd/MM/yyyy"), ddlBanco.SelectedValue.ToString(), txtNumeroCuenta.Text, ddlTipoCuenta.SelectedValue.ToString(), txtCausalDevolucion.Text, Convert.ToDateTime(txtFechaTransferencia.Text).ToString("dd/MM/yyyy"), Session["Usuario"].ToString(), txtValor.Text, txtVigencia.Text, GridView1.SelectedRow.Cells[9].Text, ddlEstadoDevolucion.SelectedValue.ToString());
        btnDevolucion.Enabled = false;
        txtFechaTransferencia.Enabled = false;
        txtNumeroCuenta.Enabled = false;
        txtCausalDevolucion.Enabled = false;
        txtFechaSolicitud.Enabled = false;
        ddlTipoCuenta.Enabled = false;
        ddlBanco.Enabled = false;
        txtRecibo.Text = "";
        txtValor.Text = "";
        txtVigencia.Text = "";
        txtProducto.Text = "";
        txtFechaSolicitud.Text ="";
        txtFechaTransferencia.Text = "";
        txtCausalDevolucion.Text ="";
        txtNumeroCuenta.Text = "";
        ddlBanco.SelectedIndex = 0;
        ddlTipoCuenta.SelectedIndex = 0;
        
        

    }

    protected void txtCedula_TextChanged(object sender, EventArgs e)
    {
        
           
    }
}