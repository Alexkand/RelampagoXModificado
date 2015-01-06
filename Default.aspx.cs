using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Session.Timeout = 10;
        if (!IsPostBack) 
        {
            lblFechaActual.Text = "FECHA:"+DateTime.Now.ToString("dd/MM/yyyy");
            lblUsuario.Text = "USUARIO:"+Session["Usuario"].ToString();
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
        txtRecibo.Text= GridView1.SelectedRow.Cells[3].Text;
        txtProducto.Text = GridView1.SelectedRow.Cells[1].Text;
        txtVigencia.Text = GridView1.SelectedRow.Cells[5].Text;
        txtValor.Text = GridView1.SelectedRow.Cells[4].Text;

        GridView1.Visible = false;
        if (txtProducto.Text == "DEVOLUCION DE PRIMA")
        {
            btnDevolucion.Enabled = true;
            txtFechaTransferencia.Enabled = true;
            txtNumeroCuenta.Enabled = true;
            txtCausalDevolucion.Enabled = true;
            txtFechaSolicitud.Enabled = true;
            ddlTipoCuenta.Enabled = true;
            ddlBanco.Enabled = true;
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
    protected void ddlCompañia_TextChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlCompañia.SelectedValue.ToString() + "');", true);
        ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_id";
        ddlProducto.DataBind();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = BD.dsConsultarPagosClienteCompañia(txtCedula.Text, ddlCompañia.SelectedValue.ToString());
        GridView1.DataBind();
        GridView1.Visible = true;
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "hola" + "');", true);
    }
    protected void btnDevolucion_Click(object sender, EventArgs e)
    {
        //BD.actualizarDevolucion(txtCedula.Text, GridView1.SelectedRow.Cells[7].Text, txtValor.Text, ddlProducto.SelectedValue.ToString());
        //BD.insertarDevolucion(txtCedula.Text, txtRecibo.Text, ddlProducto.SelectedValue.ToString(), Convert.ToDateTime(txtFechaSolicitud.Text).ToString("dd/MM/yyyy"), ddlBanco.SelectedValue.ToString(), txtNumeroCuenta.Text, ddlTipoCuenta.SelectedValue.ToString(), txtCausalDevolucion.Text, Convert.ToDateTime(txtFechaTransferencia.Text).ToString("dd/MM/yyyy"), Session["Usuario"].ToString(), txtValor.Text, txtVigencia.Text,GridView1.SelectedRow.Cells[1].Text);
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
    
}