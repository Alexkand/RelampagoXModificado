using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestionRetiros : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();
    String sFechaVigenciaAnterior;
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
            

        }
        if (!IsPostBack)
        {
            grvCartasRetiro.DataSource = BD.dsConsultarCartasRetiros();
            grvCartasRetiro.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnVerResumen_Click(object sender, EventArgs e)
    {

    }
    protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtFechaDigitacion.Text == "" && txtCedulaBusqueda.Text == "" && txtCertificadoBusqueda.Text == "")
        {
            grvCartasRetiro.DataSource = BD.dsConsultarCartasRetiros();
        }
        else
        {
            if (txtFechaDigitacion.Text != "")
                grvCartasRetiro.DataSource = BD.dsConsultarCartasRetiros(Funciones.sFechaConvertida(txtFechaDigitacion.Text), txtCedulaBusqueda.Text, txtCertificadoBusqueda.Text);
            else
                grvCartasRetiro.DataSource = BD.dsConsultarCartasRetiros("", txtCedulaBusqueda.Text, txtCertificadoBusqueda.Text);
        }
        grvCartasRetiro.DataBind();
    }
    protected void grvCartasRetiro_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + grvCartasRetiro.SelectedRow.Cells[1].Text + " ')", true);
        txtCedula.Text = grvCartasRetiro.SelectedRow.Cells[1].Text;
        txtCertificado.Text = grvCartasRetiro.SelectedRow.Cells[2].Text;
        //if (!IsPostBack)
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
        //String sPrefijo = Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim()+"conyuge";
        /*DataSet dsCertificado =  BD.consultarCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text);
        String sCedulaConyuge = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "idconyuge"].ToString();
        txtConyuge.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "conyuge"].ToString();
        
        txtPrimaTotal.Text = BD.consultarResumenCliente(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["PRIMA"].ToString();
        txtSumaAseguradaPpal.Text = BD.consultarSumaAseguradaAmparo(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "valorasegurado"].ToString();
        if (txtConyuge.Text == "SI")
            txtSumaAseguradaCony.Text = BD.consultarSumaAseguradaAmparo(sCedulaConyuge, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "valorasegurado"].ToString();
        String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text);
        grvRetiros.DataSource = BD.consultarGestionRetiroCliente(txtCedula.Text, txtCertificado.Text, grvCartasRetiro.SelectedRow.Cells[3].Text,sLoc);
        grvRetiros.DataBind();
        mnuGestionRetiro.FindItem("Editar").Selectable = false;
        mnuGestionRetiro.FindItem("Guardar").Selectable = false;
        mnuGestionRetiro.FindItem("Cancelar").Selectable = false;
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text + ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);
        
        MultiView1.ActiveViewIndex = 0;*/

        DataTable dt;
        dt = BD.dtConsultarCliente(txtCedula.Text);
        MultiView1.ActiveViewIndex = 2;
        //grvResumen.DataSource = null;
        //grvResumen.DataBind();
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
        }
        mnuCliente.FindItem("Editar").Selectable = true;
        mnuCliente.FindItem("Nuevo").Selectable = false;
        mnuCliente.FindItem("Guardar").Selectable = false;
        mnuCliente.FindItem("Cancelar").Selectable = false;
    }
    protected void mnuGestionRetiro_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "Nuevo":
                /*-------------------------------- */
                /*PARA RECUPERACIONES SOBRE RETIRO */
                /*-------------------------------- */
                
                nuevoRetiro();
                txtFechaContacto.Text = "";
                txtHora.Text = "";
                txtFechaAplicacion.Text = "";
                txtGestion.Text = "";
                ddlCausalRetiro.Items.Insert(0, new ListItem("RECUPERACION", "RECUPERACION"));
                ddlCausalRetiro.SelectedValue = "RECUPERACION";
                ddlTipoGestion.Items.Insert(0, new ListItem("RECUPERACION", "RECUPERACION"));
                ddlTipoGestion.SelectedValue = "RECUPERACION";
                ddlTipoGestion.Enabled = false;
                ddlCausalRetiro.Enabled = false;
                /*-------------------------------- */
                

                break;
            case "Editar":

                break;
            case "Guardar":

                Page.Validate("grpRet");
                if ((Page.IsValid) /*&& (Convert.ToDateTime(txtFechaAplicacion.Text).Day == 1) && (Convert.ToDateTime(txtFechaAplicacion.Text) > DateTime.Today)
                    && (Convert.ToDateTime(txtFechaContacto.Text) <= DateTime.Today)*/)
                {
                    if ((Convert.ToDateTime(txtFechaAplicacion.Text).Day == 1) && (Convert.ToDateTime(txtFechaAplicacion.Text) > DateTime.Today)
                    && (Convert.ToDateTime(txtFechaContacto.Text) <= DateTime.Today))
                        guardarRetiro();

                    else if (Convert.ToDateTime(txtFechaAplicacion.Text).Day != 1)
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER EL PRIMER DIA DEL MES')", true);
                    else if (Convert.ToDateTime(txtFechaAplicacion.Text) < DateTime.Today)
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE APLICACION DE LA VIGENCIA DEBE SER MAYOR A LA FECHA ACTUAL')", true);
                    else if (Convert.ToDateTime(txtFechaContacto.Text) > DateTime.Today)
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA FECHA DE CONTACTO NO DEBE SER MAYOR A LA FECHA ACTUAL')", true);
                }
                break;
            case "Cancelar":
                mnuGestionRetiro.FindItem("Editar").Selectable = false;
                mnuGestionRetiro.FindItem("Nuevo").Selectable = true;
                mnuGestionRetiro.FindItem("Guardar").Selectable = false;
                mnuGestionRetiro.FindItem("Cancelar").Selectable = true;
                deshabiltarRetiro();
                btnGestionRetiro_Click(new object() , new EventArgs());

                break;
        }
    }


    protected void guardarRetiro()
    {
        String[] sMesProd = new String[3];
        String sProd = grvCartasRetiro.SelectedRow.Cells[3].Text;
        String sTabla = Funciones.identificarTabla(sProd);
        String sPrefijo = Funciones.identificarPrefijo(sProd);
        sMesProd = Funciones.sMesProduccion(Funciones.sFechaConvertida(txtFechaCarta.Text));
        if (ddlTipoGestion.SelectedValue.ToString() == "RETIRO DEFINITIVO")
        {
            
            
            if (Convert.ToDateTime(sFechaVigenciaAnterior).Month + 1 == Convert.ToDateTime(Funciones.sFechaConvertida(txtFechaAplicacion.Text)).Month
                || Convert.ToDateTime(sFechaVigenciaAnterior).Month  == Convert.ToDateTime(Funciones.sFechaConvertida(txtFechaAplicacion.Text)).Month)
            {
                BD.actualizarGestionRetiro(txtCedula.Text, txtCertificado.Text, sProd, Funciones.sFechaConvertida(txtFechaCarta.Text),
                        Funciones.sFechaConvertida(txtFechaContacto.Text), txtHora.Text, ddlAsesor.SelectedValue.ToString(), txtGestion.Text, Funciones.sFechaConvertida(txtFechaAplicacion.Text),
                        ddlCausalRetiro.SelectedItem.ToString(), txtConyuge.Text);

                BD.actualizarCausalRetiroProducto(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, sProd, txtConyuge.Text, 
                    ddlCausalRetiro.SelectedItem.ToString());

                if (Convert.ToDateTime(sFechaVigenciaAnterior).Month == Convert.ToDateTime(Funciones.sFechaConvertida(txtFechaAplicacion.Text)).Month)
                    BD.actualizarRetiroProducto(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, Funciones.sFechaConvertida(txtFechaAplicacion.Text),
                    sProd, txtConyuge.Text, ddlCausalRetiro.SelectedItem.ToString(), sMesProd[0].ToString(),
                    sMesProd[1].ToString(), sMesProd[2].ToString());
                else
                {
                    sMesProd = Funciones.sMesProduccion(Funciones.sFechaConvertida((Convert.ToDateTime(txtFechaCarta.Text).AddMonths(-1)).ToString("yyyy-MM-dd")));
                    BD.actualizarRetiroProducto(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, Funciones.sFechaConvertida(txtFechaAplicacion.Text),
                    sProd, txtConyuge.Text, ddlCausalRetiro.SelectedItem.ToString(), sMesProd[0].ToString().ToString(),
                    sMesProd[1].ToString(), sMesProd[2].ToString());
                }
                DataSet dsCertificado = BD.consultarCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text);
                txtMesProduccion.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "mesproduccionLetras"].ToString();
                txtAñoProduccion.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "anoproduccion"].ToString();
                deshabiltarRetiro();
            }
            else //(Convert.ToDateTime(sFechaVigenciaAnterior).Month + 1 > Convert.ToDateTime(Funciones.sFechaConvertida(txtFechaAplicacion.Text)).Month)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('LA VIGENCIA ESTA MAL APLICADA SOLO PUEDE SER UN MES ATRAS DE LA POR DEFECTO .')", true);
            }
        }
        else
        {
            sMesProd = Funciones.sMesProduccionRecuperacion(Funciones.sFechaConvertida(txtFechaCarta.Text));
            BD.insertarGestionRetiro(txtCedula.Text, txtCertificado.Text, sProd, "'"+Funciones.sFechaConvertida(txtFechaContacto.Text)+"'", "'"+txtHora.Text+"'"
                , ddlAsesor.SelectedValue.ToString(), txtGestion.Text, Funciones.sFechaConvertida(txtFechaContacto.Text), "'" + ddlTipoGestion.SelectedValue.ToString() + "'"
                , Funciones.sFechaConvertida(txtFechaAplicacion.Text), "'RECUPERACION'", txtConyuge.Text, Session["Usuario"].ToString());
            if (txtConyuge.Text == "SI")
            {
                BD.actualizarMovimiento(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, "16", grvCartasRetiro.SelectedRow.Cells[3].Text);
            }
            else
            {
                BD.actualizarMovimiento(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, "15", grvCartasRetiro.SelectedRow.Cells[3].Text);
            }
            BD.actualizarCausalRetiroProducto(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, sProd, txtConyuge.Text, "RECUPERACION");
            if (ddlTipoGestion.SelectedValue.ToString() == "DESISTIMIENTO")
            BD.actualizarGestionRetiro(txtCedula.Text, txtCertificado.Text, sProd, Funciones.sFechaConvertida(txtFechaCarta.Text),
                    Funciones.sFechaConvertida(txtFechaContacto.Text), txtHora.Text, ddlAsesor.SelectedValue.ToString(), txtGestion.Text, Funciones.sFechaConvertida(txtFechaAplicacion.Text),
                    ddlCausalRetiro.SelectedItem.ToString(), txtConyuge.Text);
            BD.actualizarRetiroProducto(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, "", sProd, txtConyuge.Text,
            "", sMesProd[0].ToString(), sMesProd[1].ToString(), sMesProd[2].ToString());
            BD.actualizarAsesorProducto(sTabla, sPrefijo, txtCertificado.Text, txtCedula.Text, ddlAsesor.SelectedValue.ToString());
            deshabiltarRetiro();
        }
        String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, sProd, txtCertificado.Text);
        grvRetiros.DataSource = BD.consultarGestionRetiroCliente(txtCedula.Text, txtCertificado.Text, sProd, sLoc, BD.dsConsultarProducto(sProd).Tables[0].Rows[0]["com_id"].ToString());
        grvRetiros.DataBind();
       // deshabiltarRetiro();
        



    }

    protected void nuevoRetiro()
    {
       /* if (grvResumen.SelectedRow.Cells[5].Text == "VIGENTE" || grvResumen.SelectedRow.Cells[5].Text == "PRODUCCION NUEVA")
        {
            DataTable dtCertificado = BD.consultarCertificado(txtCedula.Text, ddlProducto.SelectedValue.ToString(), txtCertificado.Text).Tables[0];
            if ((dtCertificado.Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "tipomovimiento"].ToString() != "7")
                && (dtCertificado.Rows[0][Funciones.identificarPrefijo(ddlProducto.SelectedValue.ToString()).Trim() + "tipomovimiento"].ToString() != "8"))
            {*/
                ddlCausalRetiro.DataSource = BD.consultarCausalesRetiro();
                ddlCausalRetiro.DataTextField = "cau_Nombre";
                ddlCausalRetiro.DataValueField = "cau_id";
                ddlCausalRetiro.DataBind();
                ddlCausalRetiro.Items.Insert(0, new ListItem("", ""));

                String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text);

                ddlAsesor.DataSource = BD.consultarAsesoresLocalidadCompañia(sLoc, BD.dsConsultarProducto(grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["com_id"].ToString());
                ddlAsesor.DataTextField = "ase_NombreCompleto";// +" " + "ase_Apellido";
                ddlAsesor.DataValueField = "ase_id";
                ddlAsesor.DataBind();
                ddlAsesor.Items.Insert(0, new ListItem("", ""));

                //txtFechaCarta.Enabled = true;
                txtFechaContacto.Enabled = true;
                txtHora.Enabled = true;
                ddlTipoGestion.Enabled = true;
                ddlCausalRetiro.Enabled = true;
                txtFechaAplicacion.Enabled = true;
                txtGestion.Enabled = true;
                ddlAsesor.Enabled = true;
                

                mnuGestionRetiro.FindItem("Editar").Selectable = false;
                mnuGestionRetiro.FindItem("Nuevo").Selectable = false;
                mnuGestionRetiro.FindItem("Guardar").Selectable = true;
                mnuGestionRetiro.FindItem("Cancelar").Selectable = true;
            /*}
            else
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE UN RETIRO DIGITADO PENDIENTE POR APLICAR.')", true);
        }
        else
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text +
                ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);*/

        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LA CEDULA NO EXISTE PARA NINGUN CLIENTE EN EL SISTEMA" + "');", true);

    }

    protected void deshabiltarRetiro()
    {
        txtFechaContacto.Enabled = false;
        txtHora.Enabled = false;
        ddlTipoGestion.Enabled = false;
        ddlCausalRetiro.Enabled = false;
        txtFechaAplicacion.Enabled = false;
        txtGestion.Enabled = false;
        ddlAsesor.Enabled = false;

        mnuGestionRetiro.FindItem("Editar").Selectable = false;
        mnuGestionRetiro.FindItem("Nuevo").Selectable = false;
        mnuGestionRetiro.FindItem("Guardar").Selectable = false;
        mnuGestionRetiro.FindItem("Cancelar").Selectable = false;
    }


    private void llenarCiudadDepartamento()
    {
        //if (IsPostBack)
        {
            ddlCiudad.DataSource = BD.consultarCiudadesDepartamento(ddlDepartamento.SelectedValue.ToString());
            ddlCiudad.DataTextField = "ciu_nombre";
            ddlCiudad.DataValueField = "ciu_id";
            ddlCiudad.DataBind();
        }
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenarCiudadDepartamento();
        
    }
    protected void btnGestionRetiro_Click(object sender, EventArgs e)
    {
        DataSet dsCertificado = BD.consultarCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text);
        String sCedulaConyuge = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "idconyuge"].ToString();
        txtConyuge.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "conyuge"].ToString();
        txtMesProduccion.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "mesproduccionLetras"].ToString();
        txtAñoProduccion.Text = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "anoproduccion"].ToString();
        txtPrimaTotal.Text = BD.consultarResumenCliente(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["PRIMA"].ToString();
        txtSumaAseguradaPpal.Text = BD.consultarSumaAseguradaAmparo(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "valorasegurado"].ToString();
        if (txtConyuge.Text == "SI")
            txtSumaAseguradaCony.Text = BD.consultarSumaAseguradaAmparo(sCedulaConyuge, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text, "VIDA").Tables[0].Rows[0][Funciones.identificarPrefijoAmparos(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "valorasegurado"].ToString();
        String sLoc = BD.consultarLocalidadCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text);
        String sFecha = Funciones.sFechaConvertida(Convert.ToDateTime(grvCartasRetiro.SelectedRow.Cells[4].Text).ToString());

        if (Convert.ToDateTime(grvCartasRetiro.SelectedRow.Cells[6].Text) < Convert.ToDateTime(grvCartasRetiro.SelectedRow.Cells[4].Text))
            sFecha = Funciones.sFechaConvertida(Convert.ToDateTime(grvCartasRetiro.SelectedRow.Cells[6].Text).ToString());
        
        DataSet dsGestionRetiro = BD.consultarGestionRetiroCliente(txtCedula.Text, txtCertificado.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, sFecha);

        txtFechaCarta.Text = Convert.ToDateTime(dsGestionRetiro.Tables[0].Rows[0]["FECHA CARTA"]).ToString("yyyy-MM-dd");
        txtFechaAplicacion.Text = Convert.ToDateTime(dsGestionRetiro.Tables[0].Rows[0]["VIGENCIA RETIRO PRINC."]).ToString("yyyy-MM-dd");
        sFechaVigenciaAnterior = Convert.ToDateTime(dsGestionRetiro.Tables[0].Rows[0]["VIGENCIA RETIRO PRINC."]).ToString("yyyy-MM-dd");
        txtGestion.Text = BD.consultarObservacionGestionRetiroCliente(txtCedula.Text, txtCertificado.Text, grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["OBSERVACION"].ToString();
        String sTipoMovimiento = dsCertificado.Tables[0].Rows[0][Funciones.identificarPrefijo(grvCartasRetiro.SelectedRow.Cells[3].Text).Trim() + "tipomovimiento"].ToString();
        if (dsGestionRetiro.Tables[0].Rows[0]["CAUSAL RETIRO PRINC."].ToString() == "" && (sTipoMovimiento == "7" || sTipoMovimiento == "8"))
            nuevoRetiro();
        else
        {
            if (sTipoMovimiento == "7" || sTipoMovimiento == "8")
            {
                String sAsesor = BD.dsConsultarAsesor(dsGestionRetiro.Tables[0].Rows[0]["CODIGO ASESOR"].ToString()).Tables[0].Rows[0]["ase_nombres"].ToString()
                    + " " + BD.dsConsultarAsesor(dsGestionRetiro.Tables[0].Rows[0]["CODIGO ASESOR"].ToString()).Tables[0].Rows[0]["ase_apellidos"].ToString();
                /*dsGestionRetiro = BD.consultarGestionRetiroCliente(txtCedula.Text, txtCertificado.Text, grvCartasRetiro.SelectedRow.Cells[3].Text
                , BD.consultarLocalidadCertificado(txtCedula.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, txtCertificado.Text)
                , BD.dsConsultarProducto(grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["com_id"].ToString(), sFecha);*/
                txtFechaContacto.Text = Convert.ToDateTime(dsGestionRetiro.Tables[0].Rows[0]["FECHA CONTACTO"]).ToString("yyyy-MM-dd");
                txtHora.Text = dsGestionRetiro.Tables[0].Rows[0]["HORA"].ToString();
                /*ddlCausalRetiro.DataSource = BD.consultarCausalesRetiro();
                ddlCausalRetiro.DataTextField = "cau_Nombre";
                ddlCausalRetiro.DataValueField = "cau_id";
                ddlCausalRetiro.DataBind();*/
                ddlCausalRetiro.Items.Insert(0, new ListItem(dsGestionRetiro.Tables[0].Rows[0]["CAUSAL RETIRO PRINC."].ToString(), dsGestionRetiro.Tables[0].Rows[0]["CAUSAL RETIRO PRINC."].ToString()));
                ddlCausalRetiro.SelectedValue = dsGestionRetiro.Tables[0].Rows[0]["CAUSAL RETIRO PRINC."].ToString();
                ddlTipoGestion.SelectedValue = dsGestionRetiro.Tables[0].Rows[0]["TIPO GESTION"].ToString();
                ddlAsesor.Items.Insert(0, new ListItem(sAsesor, sAsesor));
                ddlAsesor.SelectedValue = sAsesor;
                mnuGestionRetiro.FindItem("Editar").Selectable = false;
                mnuGestionRetiro.FindItem("Guardar").Selectable = false;
                mnuGestionRetiro.FindItem("Cancelar").Selectable = false;
                
                /*-----------------------------------*/
                /* PARA RECUPERACIONES SOBRE RETIROS */
                /*-----------------------------------*/
                mnuGestionRetiro.FindItem("Nuevo").Selectable = true;
                //nuevoRetiro();
                //ddlCausalRetiro.Items.Insert(0, new ListItem("RECUPERACION", "RECUPERACION"));
                //ddlCausalRetiro.SelectedValue = "RECUPERACION";
                //ddlTipoGestion.Items.Insert(0, new ListItem("RECUPERACION", "RECUPERACION"));
                //ddlTipoGestion.SelectedValue = "RECUPERACION";

                /*-----------------------------------*/
                /*-----------------------------------*/
            }
            else
            {
                ddlCausalRetiro.Items.Insert(0, new ListItem("RECUPERACION","RECUPERACION"));
                ddlCausalRetiro.SelectedValue = "RECUPERACION";
                ddlTipoGestion.Items.Insert(0, new ListItem("RECUPERACION", "RECUPERACION"));
                ddlTipoGestion.SelectedValue = "RECUPERACION";                
                
                mnuGestionRetiro.FindItem("Nuevo").Selectable = false;
                mnuGestionRetiro.FindItem("Editar").Selectable = false;
                mnuGestionRetiro.FindItem("Guardar").Selectable = false;
                mnuGestionRetiro.FindItem("Cancelar").Selectable = false;
            }
        }
        /*
        ddlCausalRetiro.DataSource = BD.consultarCausalesRetiro();
        ddlCausalRetiro.DataTextField = "cau_Nombre";
        ddlCausalRetiro.DataValueField = "cau_id";
        ddlCausalRetiro.DataBind();
        ddlCausalRetiro.Items.Insert(0, new ListItem("", ""));

        ddlTipoGestion.SelectedValue = dsGestionRetiro.Tables[0].Rows[0]["TIPO GESTION"].ToString();

        
        ddlAsesor.DataSource = BD.consultarAsesoresLocalidadCompañia(sLoc, BD.dsConsultarProducto(grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["com_id"].ToString());
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
        txtGestion.Enabled = true;*/

        grvRetiros.DataSource = BD.consultarGestionRetiroCliente(txtCedula.Text, txtCertificado.Text, grvCartasRetiro.SelectedRow.Cells[3].Text, sLoc, BD.dsConsultarProducto(grvCartasRetiro.SelectedRow.Cells[3].Text).Tables[0].Rows[0]["com_id"].ToString());
        grvRetiros.DataBind();
        
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('EL CERTIFICADO TIENE EL ESTADO DE NEGOCIO:" + grvResumen.SelectedRow.Cells[5].Text + ". ESTE ESTADO NO ES VALIDO PARA DIGITAR RETIROS.')", true);
        
        MultiView1.ActiveViewIndex = 0;
    }
    protected void mnuCliente_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "Nuevo":
                //nuevoRetiro();
                break;
            case "Editar":
                habilitarCampos();
                btnGestionRetiro.Enabled = false;
                mnuCliente.FindItem("Editar").Selectable = false;
                mnuCliente.FindItem("Nuevo").Selectable = false;
                mnuCliente.FindItem("Guardar").Selectable = true;
                mnuCliente.FindItem("Cancelar").Selectable = true;

                break;
            case "Guardar":

                guardarTercero();
                deshabilitarCampos();
                btnGestionRetiro.Enabled = true;
                txtEdad.Text = Funciones.Edad(Convert.ToDateTime(txtFechaNacimiento.Text.ToString())).ToString();
                mnuCliente.FindItem("Editar").Selectable = true;
                mnuCliente.FindItem("Nuevo").Selectable = false;
                mnuCliente.FindItem("Guardar").Selectable = false;
                mnuCliente.FindItem("Cancelar").Selectable = false;
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
                btnGestionRetiro.Enabled = true;
                mnuCliente.FindItem("Editar").Selectable = true;
                mnuCliente.FindItem("Nuevo").Selectable = false;
                mnuCliente.FindItem("Guardar").Selectable = false;
                mnuCliente.FindItem("Cancelar").Selectable = false;

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
    }
    protected void ddlTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*if (ddlTipoGestion.SelectedValue.ToString() != "RETIRO DEFINITIVO")
        {
            //txtFechaCarta.Enabled = true;
            ddlCausalRetiro.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            //ddlCausalRetiro.SelectedValue = "0";
            //txtFechaCarta.Text = "";
        }
        else
        {
            //txtFechaCarta.Enabled = false;
            ddlCausalRetiro.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
        }
        */

    }

    protected void guardarTercero()
    {
        BD.actualizarTercero(txtCedula.Text, txtNombres.Text, txtApellidos.Text, ddlSexo.SelectedValue.ToString(), ddlEstadoCivil.SelectedValue.ToString()
                , Funciones.sFechaConvertida(txtFechaNacimiento.Text), ddlOcupacion.SelectedValue.ToString(), ddlDepartamento.SelectedValue.ToString()
                , ddlCiudad.SelectedValue.ToString(), txtDireccionCorrespondencia.Text, txtTelefonoResidencia.Text, txtTelefonoOficina.Text, txtCelular.Text
                , txtCorreo.Text, txtObservaciones.Text, Session["Usuario"].ToString());
    }
    
}