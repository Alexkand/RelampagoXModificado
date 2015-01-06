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
        
        /*if (Session["Usuario"].ToString() == "")
            Response.Redirect("Login.aspx");*/
        if (Session["Navegador"].ToString() == "Chrome")
        {
            //RegularExpressionValidator1.Enabled = false;
            RegularExpressionValidator1.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
            RegularExpressionValidator3.Enabled = false;
            RegularExpressionValidator4.Enabled = false;
            RegularExpressionValidator5.Enabled = false;
            RegularExpressionValidator6.Enabled = false;

        }
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

            mnuCliente.FindItem("Editar").Selectable = false;
            mnuCliente.FindItem("Nuevo").Selectable = false;
            mnuCliente.FindItem("Guardar").Selectable = false;
            mnuCliente.FindItem("Cancelar").Selectable = false;
        }
        
    }
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = BD.dtConsultarCliente(txtCedula.Text);
        MultiView1.ActiveViewIndex = 0;
        grvResumen.DataSource = null;
        grvResumen.DataBind();
        grvPagosCliente.DataSource = null;
        grvPagosCliente.DataBind();

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
            //txtOcupacion.Text = dt.Rows[0]["ocu_id"].ToString();
            //txtCiudad.Text = dt.Rows[0]["ciu_id"].ToString();
            //txtDepartamento.Text = dt.Rows[0]["dep_id"].ToString();
            txtFechaNacimiento.Text = Convert.ToDateTime(dt.Rows[0]["FECHA_NAC"].ToString()).ToString("yyyy-MM-dd");
            txtEdad.Text = Funciones.Edad(Convert.ToDateTime(txtFechaNacimiento.Text.ToString())).ToString();
            btnResumen.Enabled = true;
            mnuCliente.FindItem("Editar").Selectable = true;
            /*mnuCliente.FindItem("Nuevo").Selectable = false;
            mnuCliente.FindItem("Guardar").Selectable = false;
            mnuCliente.FindItem("Cancelar").Selectable = false;*/
        }
        else
        {
            limpiarCamposTercero();
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CEDULA NO EXISTE PARA NINGUN CLIENTE EN EL SISTEMA" + "');", true);
            mnuCliente.FindItem("Editar").Selectable = false;
            btnResumen.Enabled = false;
        }
        //mnuCliente.FindItem("Editar").Selectable = true;
        mnuCliente.FindItem("Nuevo").Selectable = false;
        mnuCliente.FindItem("Guardar").Selectable = false;
        mnuCliente.FindItem("Cancelar").Selectable = false;

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

    protected void btnResumen_Click(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        {
            txtCedula.Enabled = false;
            btnConsultar.Enabled = false;
            ddlCompañia.DataSource = BD.dsConsultarCompañia();
            ddlCompañia.DataTextField = "com_nombre";
            ddlCompañia.DataValueField = "com_id";
            ddlCompañia.DataBind();

            ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
            ddlProducto.DataTextField = "pro_nombre";
            ddlProducto.DataValueField = "pro_id";
            ddlProducto.DataBind();
        }

        MultiView1.ActiveViewIndex = 1;
    }

   protected void limpiarCamposTercero()
    {
        txtApellidos.Text = "";
        txtNombres.Text = "";
        txtDireccionCorrespondencia.Text = "";
        txtCelular.Text = "";
        txtCorreo.Text = "";
        ddlDepartamento.DataSource = null;
        ddlDepartamento.Items.Insert(0, new ListItem("", ""));
        //ddlDepartamento.SelectedValue = "0";
        //llenarCiudadDepartamento();
        ddlCiudad.DataSource = null;
        ddlCiudad.Items.Insert(0, new ListItem("", ""));
        //ddlCiudad.SelectedValue = "0";
        ddlSexo.Items.Insert(0, new ListItem("", ""));
        txtTelefonoResidencia.Text = "";
        txtTelefonoOficina.Text = "";
        txtObservaciones.Text = "";
        ddlOcupacion.DataSource = null;
        ddlOcupacion.Items.Insert(0, new ListItem("", ""));
        //ddlOcupacion.SelectedValue = "";
        //txtOcupacion.Text = dt.Rows[0]["ocu_id"].ToString();
        //txtCiudad.Text = dt.Rows[0]["ciu_id"].ToString();
        //txtDepartamento.Text = dt.Rows[0]["dep_id"].ToString();
        txtFechaNacimiento.Text = "";
        txtEdad.Text = "";
        deshabilitarCampos();
    }

    /*protected void ddlCompañia_TextChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ddlCompañia.SelectedValue.ToString() + "');", true);
        ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_id";
        ddlProducto.DataBind();
    }*/


   /* protected void ddlProducto_TextChanged(object sender, EventArgs e)
    {
        grvResumen.DataSource = BD.consultarResumenCliente(txtCedula.Text, ddlProducto.SelectedValue.ToString());
        grvResumen.DataBind();
        grvResumen.Visible = true;
    }*/
    
    protected void ddlCompañia_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_id";
        ddlProducto.DataBind();
        
    }

    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*ddlProducto.DataSource = BD.dsConsultarProductosCompañia(ddlCompañia.SelectedValue.ToString());
        ddlProducto.DataTextField = "pro_nombre";
        ddlProducto.DataValueField = "pro_id";
        ddlProducto.DataBind();*/
    }
    protected void btnConsultarResumen_Click(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        {
            grvResumen.DataSource = BD.consultarResumenCliente(txtCedula.Text, ddlProducto.SelectedValue.ToString());
            grvResumen.DataBind();
            grvResumen.Visible = true;
            grvPagosCliente.DataSource = null;
            grvPagosCliente.Visible = false;

            if (BD.consultarResumenCliente(txtCedula.Text, ddlProducto.SelectedValue.ToString()).Tables[0].Rows.Count > 0)
            {
                btnPagosCliente.Visible = true;
                btnPagosCliente.Enabled = true;
            }
            else
            {
                btnPagosCliente.Visible = false;
                btnPagosCliente.Enabled = false;
            }
        }
    }
    protected void btnVerCliente_Click(object sender, EventArgs e)
    {
        txtCedula.Enabled = true;
        btnConsultar.Enabled = true;
        MultiView1.ActiveViewIndex = 0;
    }
    protected void grvResumen_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
        txtCertificado.Text = grvResumen.SelectedRow.Cells[1].Text;
        //String sPrefijo = Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim()+"conyuge";
        DataSet dsCertificado =  BD.consultarCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificado.Text);
        String sCedulaConyuge = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "idconyuge"].ToString();
        txtConyuge.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "conyuge"].ToString();
        
        txtPrimaTotal.Text = BD.consultarResumenCliente(txtCedula.Text, ddlProducto.SelectedValue.ToString()).Tables[0].Rows[0]["PRIMA"].ToString();
        txtSumaAseguradaPpal.Text = BD.consultarSumaAseguradaAmparo(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificado.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(ddlProducto.SelectedValue.ToString()).Trim()+"valorasegurado"].ToString();
        if (txtConyuge.Text == "SI")
            txtSumaAseguradaCony.Text = BD.consultarSumaAseguradaAmparo(sCedulaConyuge,ddlProducto.SelectedValue.ToString(),txtCertificado.Text,"VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(ddlProducto.SelectedValue.ToString()).Trim()+"valorasegurado"].ToString();
        String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificado.Text);
        grvRetiros.DataSource = BD.consultarGestionRetiroCliente(txtCedula.Text, grvResumen.SelectedRow.Cells[1].Text, ddlProducto.SelectedValue.ToString(),sLoc);
        grvRetiros.DataBind();
        mnuGestionRetiro.FindItem("Editar").Selectable = false;
        mnuGestionRetiro.FindItem("Guardar").Selectable = false;
        mnuGestionRetiro.FindItem("Cancelar").Selectable = false;
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text + ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);
        MultiView1.ActiveViewIndex = 2;*/



        txtCertificadoCarta.Text = grvResumen.SelectedRow.Cells[1].Text;
        //String sPrefijo = Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim()+"conyuge";
        DataSet dsCertificado = BD.consultarCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificadoCarta.Text);
        String sCedulaConyuge = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "idconyuge"].ToString();
        txtConyugeCarta.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "conyuge"].ToString();

        txtPrimaTotalCarta.Text = BD.consultarCertificadoResumen(txtCedula.Text, ddlProducto.SelectedValue.ToString(),txtCertificadoCarta.Text).Tables[0].Rows[0]["PRIMA"].ToString();
        txtSumaAseguradaPpalCarta.Text = BD.consultarSumaAseguradaAmparo(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificadoCarta.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(ddlProducto.SelectedValue.ToString()).Trim() + "valorasegurado"].ToString();
        if (txtConyugeCarta.Text == "SI")
            txtSumaAseguradaConyCarta.Text = BD.consultarSumaAseguradaAmparo(sCedulaConyuge, ddlProducto.SelectedValue.ToString(), txtCertificadoCarta.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(ddlProducto.SelectedValue.ToString()).Trim() + "valorasegurado"].ToString();
        String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificadoCarta.Text);
        txtLocalidad.Text = BD.consultarDepartamento(sLoc).Tables[0].Rows[0]["dep_nombre"].ToString();
        grvCartasRetiro.DataSource = BD.dsConsultarCartasRetirosCliente(txtCedula.Text, grvResumen.SelectedRow.Cells[1].Text, ddlProducto.SelectedValue.ToString());
        grvCartasRetiro.DataBind();
        mnuCartaRetiro.FindItem("Editar").Selectable = false;
        mnuCartaRetiro.FindItem("Guardar").Selectable = false;
        mnuCartaRetiro.FindItem("Cancelar").Selectable = false;
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text + ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);
        MultiView1.ActiveViewIndex = 3;
    }
    protected void btnVerResumen_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1; 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = txtHora.Text;
    }
    
    protected void nuevoRetiro()
    {
        if (grvResumen.SelectedRow.Cells[5].Text == "VIGENTE" || grvResumen.SelectedRow.Cells[5].Text == "PRODUCCION NUEVA")
        {
            DataTable dtCertificado = BD.consultarCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificado.Text).Tables[0];
            if ((dtCertificado.Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim()+"tipomovimiento"].ToString() != "7") 
                && (dtCertificado.Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim()+"tipomovimiento"].ToString() != "8"))
            {
                ddlCausalRetiro.DataSource = BD.consultarCausalesRetiro();
                ddlCausalRetiro.DataTextField = "cau_Nombre";
                ddlCausalRetiro.DataValueField = "cau_id";
                ddlCausalRetiro.DataBind();
                ddlCausalRetiro.Items.Insert(0, new ListItem("", ""));

                String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificado.Text);
            
                ddlAsesor.DataSource = BD.consultarAsesoresLocalidadCompañia(sLoc, ddlCompañia.SelectedValue.ToString());
                ddlAsesor.DataTextField = "ase_NombreCompleto";// +" " + "ase_Apellido";
                ddlAsesor.DataValueField = "ase_id";
                ddlAsesor.DataBind();
                ddlAsesor.Items.Insert(0, new ListItem("", ""));
            
                txtFechaCarta.Enabled = true;
                txtFechaContacto.Enabled = true;
                txtHora.Enabled = true;
                ddlTipoGestion.Enabled = true;
                ddlCausalRetiro.Enabled = true;
                txtFechaAplicacion.Enabled = true;
                txtGestion.Enabled = true;

                mnuGestionRetiro.FindItem("Editar").Selectable = false;
                mnuGestionRetiro.FindItem("Nuevo").Selectable = false;
                mnuGestionRetiro.FindItem("Guardar").Selectable = true;
                mnuGestionRetiro.FindItem("Cancelar").Selectable = true;
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE UN RETIRO DIGITADO PENDIENTE POR APLICAR.')", true);
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text+
                ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);

                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CEDULA NO EXISTE PARA NINGUN CLIENTE EN EL SISTEMA" + "');", true);

    }

    protected void guardarRetiro()
    {
        //Convert.ToDateTime(txtFechaAplicacion.Text).Day; 
        BD.insertarGestionRetiro(txtCedula.Text, txtCertificado.Text, ddlProducto.SelectedValue.ToString(), Funciones.sFechaConvertida(txtFechaContacto.Text), txtHora.Text, 
            ddlAsesor.SelectedValue.ToString(), txtGestion.Text,Funciones.sFechaConvertida(txtFechaCarta.Text), ddlTipoGestion.SelectedValue.ToString(),
            Funciones.sFechaConvertida(txtFechaAplicacion.Text), ddlCausalRetiro.SelectedItem.ToString(),txtConyuge.Text, Session["Usuario"].ToString());
        /*if (txtConyuge.Text == "SI")
        {
            BD.actualizarMovimiento(Funciones.identificarTabla(ddlProducto.SelectedValue.ToString()), Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()),
                    txtCertificado.Text, txtCedula.Text, "8", ddlProducto.SelectedValue.ToString());
        }
        else
        {
            BD.actualizarMovimiento(Funciones.identificarTabla(ddlProducto.SelectedValue.ToString()), Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()),
                    txtCertificado.Text, txtCedula.Text, "7", ddlProducto.SelectedValue.ToString());
        }
        BD.actualizarRetiroProducto(Funciones.identificarTabla(ddlProducto.SelectedValue.ToString()), Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()),
            txtCertificado.Text, txtCedula.Text, Funciones.sFechaConvertida(txtFechaAplicacion.Text), ddlProducto.SelectedValue.ToString(), txtConyuge.Text,
            ddlCausalRetiro.SelectedItem.ToString(), Funciones.sMesProduccion(Funciones.sFechaConvertida(txtFechaCarta.Text))[0].ToString(),
            Funciones.sMesProduccion(Funciones.sFechaConvertida(txtFechaCarta.Text))[1].ToString(), Funciones.sMesProduccion(Funciones.sFechaConvertida(txtFechaCarta.Text))[2].ToString());*/
        //actualizarEstado(String sTabla, String sPrefijo, String sCertificado, String sCedula, String sEstadoNegocio, String sProducto)
        txtFechaCarta.Enabled = false;
        txtFechaContacto.Enabled = false;
        txtHora.Enabled = false;
        ddlTipoGestion.Enabled = false;
        ddlCausalRetiro.Enabled = false;
        txtFechaAplicacion.Enabled = false;
        txtGestion.Enabled = false;
        mnuGestionRetiro.FindItem("Editar").Selectable = true;
        mnuGestionRetiro.FindItem("Nuevo").Selectable = true;
        mnuGestionRetiro.FindItem("Guardar").Selectable = false;
        mnuGestionRetiro.FindItem("Cancelar").Selectable = false;
    }
    protected void mnuGestionRetiro_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "Nuevo":
                nuevoRetiro();                  
                break;
            case "Editar":

                break;
            case "Guardar":
                
                Page.Validate("grpRet");
                if ((Page.IsValid) && (Convert.ToDateTime(txtFechaAplicacion.Text).Day == 1) && (Convert.ToDateTime(txtFechaAplicacion.Text)>DateTime.Today)
                    && (Convert.ToDateTime(txtFechaContacto.Text) <= DateTime.Today))
                {
                    guardarRetiro();
                }
                else if (Convert.ToDateTime(txtFechaAplicacion.Text).Day != 1)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER EL PRIMER DIA DEL MES')", true);
                else if (Convert.ToDateTime(txtFechaAplicacion.Text)<DateTime.Today)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER MAYOR A LA FECHA ACTUAL')", true);
                else if (Convert.ToDateTime(txtFechaContacto.Text) > DateTime.Today)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE CONTACTO NO DEBE SER MAYOR A LA FECHA ACTUAL')", true);
                break;
            case "Cancelar":

                break;
        }
    }
    protected void mnuCartaRetiro_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "Nuevo":
                nuevaCarta();
                break;
            case "Editar":

                break;
            case "Guardar":

                Page.Validate("grpCarta");
                if ((Page.IsValid))
                {
                    guardarCarta();
                }
                /*else if (Convert.ToDateTime(txtFechaAplicacion.Text).Day != 1)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER EL PRIMER DIA DEL MES')", true);
                else if (Convert.ToDateTime(txtFechaAplicacion.Text) < DateTime.Today)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER MAYOR A LA FECHA ACTUAL')", true);
                else if (Convert.ToDateTime(txtFechaContacto.Text) > DateTime.Today)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE CONTACTO NO DEBE SER MAYOR A LA FECHA ACTUAL')", true);*/
                break;
            case "Cancelar":
                deshabilitarCarta();

                break;
        }
    }

    protected void guardarCarta()
    {
        BD.insertarCartaRetiro(txtCedula.Text, txtCertificadoCarta.Text, ddlProducto.SelectedValue.ToString(), Funciones.sFechaConvertida(txtFechaRadicacionTorres.Text),
            Funciones.sFechaConvertida(txtFechaRadicacionCompañia.Text), ddlOficinaCompañia.SelectedItem.ToString(), txtLocalidad.Text, ddlOrigenOficio.SelectedItem.ToString(), txtObservacion.Text, 
            Funciones.sFechaConvertida(txtFechaRecibidoCasaMatriz.Text),Session["Usuario"].ToString());
        grvCartasRetiro.DataSource = BD.dsConsultarCartasRetirosCliente(txtCedula.Text, grvResumen.SelectedRow.Cells[1].Text, ddlProducto.SelectedValue.ToString());
        grvCartasRetiro.DataBind();

        /*BD.insertarGestionRetiro(txtCedula.Text, txtCertificado.Text, ddlProducto.SelectedValue.ToString(), Funciones.sFechaConvertida(txtFechaContacto.Text), txtHora.Text,
            ddlAsesor.SelectedValue.ToString(), txtGestion.Text, Funciones.sFechaConvertida(txtFechaCarta.Text), ddlTipoGestion.SelectedValue.ToString(),
            Funciones.sFechaConvertida(txtFechaAplicacion.Text), ddlCausalRetiro.SelectedItem.ToString(), txtConyuge.Text, Session["Usuario"].ToString());*/
        String sFechaRadicacion;
        String[] sMesProd = new String[3];
        
        if (Convert.ToDateTime(txtFechaRadicacionTorres.Text) < Convert.ToDateTime(txtFechaRadicacionCompañia.Text))
            sFechaRadicacion = Funciones.sFechaConvertida(txtFechaRadicacionTorres.Text);
        else
            sFechaRadicacion = Funciones.sFechaConvertida(txtFechaRadicacionCompañia.Text);
        sMesProd = Funciones.sMesProduccion(sFechaRadicacion);
        BD.insertarGestionRetiro(txtCedula.Text, txtCertificadoCarta.Text, ddlProducto.SelectedValue.ToString(), "NULL", "NULL",
            "NULL", txtObservacion.Text, sFechaRadicacion, "'RETIRO DEFINITIVO'",
            Funciones.sFechaVigenciaRetiro(sFechaRadicacion), "NULL", txtConyuge.Text, Session["Usuario"].ToString());
        if (txtConyuge.Text == "SI")
        {
            BD.actualizarMovimiento(Funciones.identificarTabla(ddlProducto.SelectedValue.ToString()), Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()),
                    txtCertificadoCarta.Text, txtCedula.Text, "8", ddlProducto.SelectedValue.ToString());
        }
        else
        {
            BD.actualizarMovimiento(Funciones.identificarTabla(ddlProducto.SelectedValue.ToString()), Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()),
                    txtCertificadoCarta.Text, txtCedula.Text, "7", ddlProducto.SelectedValue.ToString());
        }
        BD.actualizarRetiroProducto(Funciones.identificarTabla(ddlProducto.SelectedValue.ToString()), Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()),
            txtCertificadoCarta.Text, txtCedula.Text, Funciones.sFechaVigenciaRetiro(sFechaRadicacion), ddlProducto.SelectedValue.ToString(), txtConyuge.Text,
            ddlCausalRetiro.SelectedValue.ToString(), sMesProd[0].ToString(),
            sMesProd[1].ToString(), sMesProd[2].ToString());
        deshabilitarCarta();
    }

    protected void nuevaCarta()
    {
        if (grvResumen.SelectedRow.Cells[5].Text == "VIGENTE" || grvResumen.SelectedRow.Cells[5].Text == "PRODUCCION NUEVA")
        {
            DataTable dtCertificado = BD.consultarCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificadoCarta.Text).Tables[0];
            if ((dtCertificado.Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "tipomovimiento"].ToString() != "7")
                && (dtCertificado.Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "tipomovimiento"].ToString() != "8"))
            {
                /*ddlCausalRetiro.DataSource = BD.consultarCausalesRetiro();
                ddlCausalRetiro.DataTextField = "cau_Nombre";
                ddlCausalRetiro.DataValueField = "cau_id";
                ddlCausalRetiro.DataBind();
                ddlCausalRetiro.Items.Insert(0, new ListItem("", ""));*/

                String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificadoCarta.Text);

                /*ddlAsesor.DataSource = BD.consultarAsesoresLocalidadCompañia(sLoc, ddlCompañia.SelectedValue.ToString());
                ddlAsesor.DataTextField = "ase_NombreCompleto";// +" " + "ase_Apellido";
                ddlAsesor.DataValueField = "ase_id";
                ddlAsesor.DataBind();
                ddlAsesor.Items.Insert(0, new ListItem("", ""));*/

                txtFechaRadicacionTorres.Enabled = true;
                txtFechaRadicacionCompañia.Enabled = true;
                txtFechaRecibidoCasaMatriz.Enabled = true;
                ddlOficinaCompañia.Enabled = true;
                ddlOrigenOficio.Enabled = true;
                txtLocalidad.Text = BD.sNombreDepartamento(sLoc);
                txtObservacion.Enabled = true;
                btnVerResumenCarta.Enabled = false;
                txtCedula.Enabled = false;

                mnuCartaRetiro.FindItem("Editar").Selectable = false;
                mnuCartaRetiro.FindItem("Nuevo").Selectable = false;
                mnuCartaRetiro.FindItem("Guardar").Selectable = true;
                mnuCartaRetiro.FindItem("Cancelar").Selectable = true;
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE UN RETIRO DIGITADO PENDIENTE POR APLICAR.')", true);
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text +
                ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);

        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CEDULA NO EXISTE PARA NINGUN CLIENTE EN EL SISTEMA" + "');", true);
    }
    protected void grvRetiros_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void btnVerResumenCarta_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void deshabilitarCarta()
    {
        txtFechaRadicacionTorres.Enabled = false;        
        txtFechaRadicacionCompañia.Enabled = false;
        txtFechaRecibidoCasaMatriz.Enabled = false;
        ddlOficinaCompañia.Enabled = false;
        ddlOrigenOficio.Enabled = false;
        txtLocalidad.Enabled = false;
        txtObservacion.Enabled = false;
        btnVerResumenCarta.Enabled = true;

        txtFechaRadicacionTorres.Text = "";
        txtFechaRadicacionCompañia.Text = "";
        txtFechaRecibidoCasaMatriz.Text = "";
        //txtOficinaCompañia.Text = "";
        //ddlOrigenOficio.SelectedValue = "0";
        txtLocalidad.Text = "";
        txtObservacion.Text = "";
        //txtCedula.Enabled = true;

        mnuCartaRetiro.FindItem("Editar").Selectable = false;
        mnuCartaRetiro.FindItem("Nuevo").Selectable = true;
        mnuCartaRetiro.FindItem("Guardar").Selectable = false;
        mnuCartaRetiro.FindItem("Cancelar").Selectable = false;
    }
    protected void mnuCliente_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "Nuevo":
                //nuevoRetiro();
                break;
            case "Editar":
                Page.Validate("grpCed");
                if ((Page.IsValid))
                {
                    habilitarCampos();
                }

                break;
            case "Guardar":

                guardarTercero();
                deshabilitarCampos();
                txtEdad.Text = Funciones.Edad(Convert.ToDateTime(txtFechaNacimiento.Text.ToString())).ToString();
                
                /*Page.Validate("grpRet");
                if ((Page.IsValid) && (Convert.ToDateTime(txtFechaAplicacion.Text).Day == 1) && (Convert.ToDateTime(txtFechaAplicacion.Text) > DateTime.Today)
                    && (Convert.ToDateTime(txtFechaContacto.Text) <= DateTime.Today))
                {
                    guardarRetiro();
                }
                else if (Convert.ToDateTime(txtFechaAplicacion.Text).Day != 1)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER EL PRIMER DIA DEL MES')", true);
                else if (Convert.ToDateTime(txtFechaAplicacion.Text) < DateTime.Today)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER MAYOR A LA FECHA ACTUAL')", true);
                else if (Convert.ToDateTime(txtFechaContacto.Text) > DateTime.Today)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE CONTACTO NO DEBE SER MAYOR A LA FECHA ACTUAL')", true);*/
                break;
            case "Cancelar":
                deshabilitarCampos();
                

                break;
        }
    }

    protected void habilitarCampos()
    {
        txtApellidos.Enabled = true;
        txtNombres.Enabled = true;
        txtCorreo.Enabled = true;
        txtDireccionCorrespondencia.Enabled = true;
        txtObservaciones.Enabled = true;
        ddlDepartamento.Enabled = true;
        ddlCiudad.Enabled = true;
        txtFechaNacimiento.Enabled = true;
        txtTelefonoOficina.Enabled = true;
        txtTelefonoResidencia.Enabled = true;
        ddlOcupacion.Enabled = true;
        txtCelular.Enabled = true;
        ddlSexo.Enabled = true;
        btnResumen.Enabled = false;
        txtCedula.Enabled = false;
        mnuCliente.FindItem("Editar").Selectable = false;
        mnuCliente.FindItem("Nuevo").Selectable = false;
        mnuCliente.FindItem("Guardar").Selectable = true;
        mnuCliente.FindItem("Cancelar").Selectable = true;
    }

    protected void deshabilitarCampos()
    {
        txtApellidos.Enabled = false;
        txtNombres.Enabled = false;
        txtCorreo.Enabled = false;
        txtDireccionCorrespondencia.Enabled = false;
        txtObservaciones.Enabled = false;
        ddlDepartamento.Enabled = false;
        ddlCiudad.Enabled = false;
        txtFechaNacimiento.Enabled = false;
        txtTelefonoOficina.Enabled = false;
        txtTelefonoResidencia.Enabled = false;
        ddlOcupacion.Enabled = false;
        txtCelular.Enabled = false;
        ddlSexo.Enabled = false;
        btnResumen.Enabled = true;
        txtCedula.Enabled = true;
        
    }

    protected void guardarTercero()
    {
        BD.actualizarTercero(txtCedula.Text, txtNombres.Text, txtApellidos.Text, ddlSexo.SelectedValue.ToString(), ddlEstadoCivil.SelectedValue.ToString()
                , Funciones.sFechaConvertida(txtFechaNacimiento.Text), ddlOcupacion.SelectedValue.ToString(), ddlDepartamento.SelectedValue.ToString()
                , ddlCiudad.SelectedValue.ToString(), txtDireccionCorrespondencia.Text, txtTelefonoResidencia.Text, txtTelefonoOficina.Text, txtCelular.Text
                , txtCorreo.Text, txtObservaciones.Text, Session["Usuario"].ToString());
    }

    protected void btnPagosCliente_Click(object sender, EventArgs e)
    {
        grvPagosCliente.DataSource = BD.dsConsultarPagosClienteCompañia(txtCedula.Text, ddlCompañia.SelectedValue.ToString());
        grvPagosCliente.DataBind();
        grvPagosCliente.Visible = true;
    }
}