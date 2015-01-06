using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDepartamento.DataSource = BD.consultarDepartamentos();
            ddlDepartamento.DataTextField = "dep_nombre";
            ddlDepartamento.DataValueField = "dep_id";
            ddlDepartamento.DataBind();

            ddlCiudad.DataSource = BD.consultarCiudadesDepartamento(ddlDepartamento.SelectedValue.ToString());
            ddlCiudad.DataTextField = "ciu_nombre";
            ddlCiudad.DataValueField = "ciu_id";
            ddlCiudad.DataBind();

            ddlOcupacion.DataSource = BD.consultarOcupaciones();
            ddlOcupacion.DataTextField = "ocu_nombre";
            ddlOcupacion.DataValueField = "ocu_id";
            ddlOcupacion.DataBind();
        }
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = BD.dtConsultarCliente(txtCedula.Text);
        if (dt.Rows.Count > 0)
        {

            txtApellidos.Text = dt.Rows[0]["ter_Apellidos"].ToString();
            txtNombres.Text = dt.Rows[0]["ter_Nombres"].ToString();
            txtDireccionCorrespondencia.Text = dt.Rows[0]["ter_Direccion"].ToString();
            txtCelular.Text = dt.Rows[0]["ter_Celular"].ToString();
            txtCorreo.Text = dt.Rows[0]["ter_Correo"].ToString();
            ddlDepartamento.SelectedValue = dt.Rows[0]["dep_id"].ToString();
            llenarCiudadDepartamento();
            ddlCiudad.SelectedValue = dt.Rows[0]["ciu_id"].ToString();
            ddlSexo.Text = dt.Rows[0]["ter_sexo"].ToString();
            txtTelefonoResidencia.Text = dt.Rows[0]["ter_TelefonoResidencia"].ToString();
            txtTelefonoOficina.Text = dt.Rows[0]["ter_TelefonoOficina"].ToString();
            txtObservaciones.Text = dt.Rows[0]["ter_Usuario"].ToString();
            ddlOcupacion.SelectedValue = dt.Rows[0]["ocu_id"].ToString();
            txtOcupacion.Text = dt.Rows[0]["ocu_id"].ToString();
            txtCiudad.Text = dt.Rows[0]["ciu_id"].ToString();
            txtDepartamento.Text = dt.Rows[0]["dep_id"].ToString();
            txtFechaNacimiento.Text = Convert.ToDateTime(dt.Rows[0]["FECHA_NAC"].ToString()).ToString("yyyy-MM-dd");
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CEDULA NO EXISTE PARA NINGUN CLIENTE EN EL SISTEMA" + "');", true);

    }
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenarCiudadDepartamento();
    }

    private void llenarCiudadDepartamento()
    {
        ddlCiudad.DataSource = BD.consultarCiudadesDepartamento(ddlDepartamento.SelectedValue.ToString());
        ddlCiudad.DataTextField = "ciu_nombre";
        ddlCiudad.DataValueField = "ciu_id";
        ddlCiudad.DataBind();
    }
   
}