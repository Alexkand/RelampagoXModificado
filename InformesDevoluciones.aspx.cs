using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformesDevoluciones : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        
            /*if (Session["Usuario"].ToString() == "")
                Response.Redirect("Login.aspx");*/
            
            grvDevoluciones.DataSource = BD.dsConsultarDevoluciones();
            grvDevoluciones.DataBind();
            grvDevoluciones.Visible = true;

            if (!IsPostBack)
            {
                ddlLocalidad.DataSource = BD.consultarDepartamentos();
                ddlLocalidad.DataTextField = "dep_nombre";
                ddlLocalidad.DataValueField = "dep_id";
                ddlLocalidad.DataBind();
                ddlLocalidad.Items.Insert(0, new ListItem("TODOS", "0"));
            }
            if (Session["Navegador"].ToString() == "Chrome")
            {
                //RegularExpressionValidator1.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
            }
        
        
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlLocalidad.SelectedValue.ToString() + "');", true);

            if (txtFechaTransferencia.Text != "")
            {
                grvDevoluciones.DataSource = BD.dsConsultarDevoluciones(txtCedula.Text, txtRecibo.Text, Funciones.sFechaConvertida(txtFechaTransferencia.Text), ddlLocalidad.SelectedValue.ToString());
            }
            else
                grvDevoluciones.DataSource = BD.dsConsultarDevoluciones(txtCedula.Text, txtRecibo.Text, "", ddlLocalidad.SelectedValue.ToString());
            grvDevoluciones.DataBind();
            grvDevoluciones.Visible = true;
        
    }
    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlLocalidad.SelectedValue.ToString() + "');", true);
    }


    
    protected void grvDevoluciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlLocalidad.SelectedValue.ToString() + "');", true);
        txtFechaSolicitud.Text = Convert.ToDateTime(grvDevoluciones.SelectedRow.Cells[6].Text).ToString("yyyy-MM-dd");
        ddlBanco.SelectedValue = grvDevoluciones.SelectedRow.Cells[7].Text;
        txtNumeroCuenta.Text = grvDevoluciones.SelectedRow.Cells[8].Text;
        ddlTipoCuenta.Text = grvDevoluciones.SelectedRow.Cells[9].Text;
        txtCausalDevolucion.Text = grvDevoluciones.SelectedRow.Cells[10].Text;
        txtFechaTransferenciaEditar.Text = Convert.ToDateTime(grvDevoluciones.SelectedRow.Cells[11].Text).ToString("yyyy-MM-dd");
        ddlEstadoDevolucion.SelectedValue = grvDevoluciones.SelectedRow.Cells[17].Text;
        grvDevoluciones.DataSource = BD.dsConsultarDevoluciones(grvDevoluciones.SelectedRow.Cells[16].Text);
        grvDevoluciones.DataBind();

        txtFechaSolicitud.Enabled = true;
        ddlBanco.Enabled = true;
        txtNumeroCuenta.Enabled = true;
        ddlTipoCuenta.Enabled = true;
        txtCausalDevolucion.Enabled = true;
        txtFechaTransferenciaEditar.Enabled = true;
        //ddlEstadoDevolucion.Enabled = true;
        btnActualizar.Enabled = true;
        btnCancelar.Enabled = true;
        if (Session["Navegador"].ToString() == "Chrome")
        {
            RegularExpressionValidator1.Enabled = false;
            RegularExpressionValidator3.Enabled = false;
        }



    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        BD.actualizarDevolucion(grvDevoluciones.SelectedRow.Cells[16].Text, Convert.ToDateTime(txtFechaSolicitud.Text).ToString("dd/MM/yyyy"), ddlBanco.SelectedValue.ToString(), txtNumeroCuenta.Text, ddlTipoCuenta.SelectedValue.ToString(), txtCausalDevolucion.Text, Convert.ToDateTime(txtFechaTransferenciaEditar.Text).ToString("dd/MM/yyyy"),ddlEstadoDevolucion.SelectedValue.ToString());
        grvDevoluciones.DataSource = BD.dsConsultarDevoluciones(grvDevoluciones.SelectedRow.Cells[16].Text);
        grvDevoluciones.DataBind();
        txtFechaSolicitud.Enabled = false;
        ddlBanco.Enabled = false;
        txtNumeroCuenta.Enabled = false;
        ddlTipoCuenta.Enabled = false;
        txtCausalDevolucion.Enabled = false;
        txtFechaTransferenciaEditar.Enabled = false;
        ddlEstadoDevolucion.Enabled = false;
        btnActualizar.Enabled = false;
        btnCancelar.Enabled = false;
        txtFechaSolicitud.Text = "";
        txtFechaTransferenciaEditar.Text = "";
        txtCausalDevolucion.Text = "";
        txtNumeroCuenta.Text = "";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //grvDevoluciones.DataSource = BD.dsConsultarDevoluciones(grvDevoluciones.SelectedRow.Cells[16].Text);
        //grvDevoluciones.DataBind();
        txtFechaSolicitud.Enabled = false;
        ddlBanco.Enabled = false;
        txtNumeroCuenta.Enabled = false;
        ddlTipoCuenta.Enabled = false;
        txtCausalDevolucion.Enabled = false;
        txtFechaTransferenciaEditar.Enabled = false;
        ddlEstadoDevolucion.Enabled = false;
        btnActualizar.Enabled = false;
        btnCancelar.Enabled = false;
        txtFechaSolicitud.Text = "";
        txtFechaTransferenciaEditar.Text = "";
        txtCausalDevolucion.Text = "";
        txtNumeroCuenta.Text = "";
    }
}