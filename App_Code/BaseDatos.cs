using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

/// <summary>
/// Descripción breve de BaseDatos
/// </summary>
public class BaseDatos
{
    private SqlConnection cnx;
    private SqlCommand cmd;
    private SqlDataAdapter da;

	public BaseDatos()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public String sDefinirConexion(String sConexion)
    {
        return ConfigurationManager.ConnectionStrings[sConexion].ConnectionString;
    }

    public DataSet dsConsultarPagosCliente(String sCedula)
    {
        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        
        sql = "SELECT * FROM PAGO WHERE TER_ID=" + sCedula;

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Pagos");
        return ds;

    }

    public DataSet dsConsultarPagosClienteCompañia(String sCedula, String sCompañia)
    {
        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = @"SELECT DEP_NOMBRE LOCALIDAD, PRO_NOMBRE PRODUCTO, CONVERT(VARCHAR(10),FAC_FECHAEXPEDICION,103) EXPEDIDO, RECMOV_RECIBO RECIBO, FAC_VALOR VALOR," + 
            "CONVERT(VARCHAR(10),FAC_INICIOVIGENCIA,103) 'INICIO_VIGENCIA'" +
            " , CONVERT(VARCHAR(10),FAC_FINVIGENCIA,103) 'FIN_VIGENCIA', PAGO_ID ID, P.DEP_ID 'COD LOCALIDAD'" +
            " FROM PAGO P, PRODUCTO PR, DEPARTAMENTO D WHERE P.PRO_ID = PR.PRO_ID AND D.DEP_ID = P.DEP_ID AND TER_ID=" + sCedula+" AND P.COM_ID =" + sCompañia;

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Pagos");
        return ds;

    }

    public DataSet dsConsultarProductos()
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT * FROM PRODUCTO WHERE PRO_NOMBRE NOT LIKE '%DEVOLUCION DE PRIMA%'";

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Productos");
        return ds;
    }


    public DataSet dsConsultarProductosCompañia(String sCompañia)
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT * FROM PRODUCTO WHERE PRO_NOMBRE NOT LIKE '%DEVOLUCION DE PRIMA%' AND COM_ID =" + sCompañia;

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Productos");
        return ds;
    }

    public DataSet dsConsultarCompañia()
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT * FROM COMPAÑIA";

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Compañia");
        return ds;
        
    }

    public void actualizarPago(String sCedula, String sPagoId, String sValor, String sCompañia, String sEstado)
    {
        SqlCommand cmd;
        String sql;
        String sProducto = "0";
        if (sEstado == "TRAMITADA")
        {
            switch (sCompañia)
            {
                case "1":
                case "71":
                    {
                        sProducto = "81";
                        break;
                    }
                case "99":
                case "79":
                    {
                        sProducto = "89";
                        break;
                    }
                case "2":
                case "72":
                    {
                        sProducto = "82";
                        break;
                    }
                case "3":
                case "73":
                    {
                        sProducto = "83";
                        break;
                    }
                case "4":
                case "74":
                    {
                        sProducto = "84";
                        break;
                    }
                case "6":
                case "76":
                    {
                        sProducto = "86";
                        break;
                    }
            }
        }
        else
        {
            switch (sCompañia)
            {
                case "1":
                    {
                        sProducto = "71";
                        break;
                    }
                case "99":
                    {
                        sProducto = "79";
                        break;
                    }
                case "2":
                    {
                        sProducto = "72";
                        break;
                    }
                case "3":
                    {
                        sProducto = "73";
                        break;
                    }
                case "4":
                    {
                        sProducto = "74";
                        break;
                    }
                case "6":
                    {
                        sProducto = "76";
                        break;
                    }
            }
        }
            

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE PAGO SET PRO_ID = " + sProducto + " WHERE TER_ID = " + sCedula + " AND FAC_VALOR = " + sValor + " AND PAGO_ID = " + sPagoId;
        cmd = new SqlCommand(sql,cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }


    public DataSet dsConsultarUsuario(String sUsuario, String sContraseña)
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT * FROM CONTROL WHERE CON_USUARIO = '"+sUsuario +"' AND CON_PASSWORD = '"+sContraseña+"'";

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Usuario");
        return ds;
        
    }



    public void insertarDevolucion(String sCedula, String sRecibo, String sProducto, String sFechaSol, String sBanco, String sNumero, String sTipo, String sCausal, String sFechaTransf, String sUsuario, String sValor, String sFechaVigencia, String sLocalidad, String sEstado )
    {
        SqlCommand cmd;
        String sql;
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        //CEDULA, RECIBO, PRODUCTO, FECHASOLICTUD, BANCO, NUMEROCUENTA, TIPOCUENTA, CAUSAL, FECHATRANSFERENCIA, FECHASISTEMA, USUARIO
        sql = "INSERT INTO DEVOLUCIONES VALUES (" + sCedula + "," + sRecibo + "," + sProducto + ",'" + sFechaSol + "','" + sBanco + "','" + sNumero + "','" + sTipo + "','" + sCausal + "','" + sFechaTransf + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + sUsuario + "','" + sFechaVigencia + "'," + sValor + ","+sLocalidad+",'"+sEstado +"')";
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }


    public DataSet dsConsultarDevoluciones()
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT DEP_NOMBRE LOCALIDAD,DEV_CEDULA CEDULA, DEV_RECIBO RECIBO, COM_NOMBRE COMPAÑIA, PRO_NOMBRE PRODUCTO, CONVERT(VARCHAR(10),DEV_FECHASOLICITUD,103) 'FECHA SOLICITUD', DEV_BANCO BANCO, DEV_NUMEROCUENTA 'NUMERO DE CUENTA'" +
               " , DEV_TIPOCUENTA 'TIPO DE CUENTA', DEV_CAUSAL 'CAUSAL', CONVERT(VARCHAR(10),DEV_FECHATRANSFERENCIA,103) 'FECHA TRANSFERENCIA', CONVERT(VARCHAR(10),DEV_VIGENCIA,103)  VIGENCIA, DEV_VALOR VALOR" +
               " ,CONVERT(VARCHAR(10),DEV_FECHASISTEMA,103) 'FECHA APLICACION SISTEMA', DEV_USUARIO USUARIO, DEV_CONSECUTIVO CONSECUTIVO, DEV_ESTADO ESTADO" + 
               " FROM DEVOLUCIONES D, PRODUCTO P, COMPAÑIA C, DEPARTAMENTO DE "+
               " WHERE D.DEV_PRODUCTO = P.PRO_ID AND P.COM_ID = C.COM_ID AND D.DEV_LOCALIDAD = DE.DEP_ID"+
               " ORDER BY DEV_FECHASISTEMA DESC, DEV_CONSECUTIVO DESC";

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Devoluciones");
        return ds;

    }

    public DataSet dsConsultarDevoluciones(String sCedula, String sRecibo, String sFechaTransferencia, String sLocalidad)
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT DEP_NOMBRE LOCALIDAD, DEV_CEDULA CEDULA, DEV_RECIBO RECIBO, COM_NOMBRE COMPAÑIA, PRO_NOMBRE PRODUCTO, CONVERT(VARCHAR(10),DEV_FECHASOLICITUD,103) 'FECHA SOLICITUD', DEV_BANCO BANCO, DEV_NUMEROCUENTA 'NUMERO DE CUENTA'" +
               " , DEV_TIPOCUENTA 'TIPO DE CUENTA', DEV_CAUSAL 'CAUSAL', CONVERT(VARCHAR(10),DEV_FECHATRANSFERENCIA,103) 'FECHA TRANSFERENCIA', CONVERT(VARCHAR(10),DEV_VIGENCIA,103) VIGENCIA, DEV_VALOR VALOR" +
               " ,CONVERT(VARCHAR(10),DEV_FECHASISTEMA,103) 'FECHA APLICACION SISTEMA', DEV_USUARIO USUARIO, DEV_CONSECUTIVO CONSECUTIVO, DEV_ESTADO ESTADO" +
               " FROM DEVOLUCIONES D, PRODUCTO P, COMPAÑIA C, DEPARTAMENTO DE " +
               " WHERE D.DEV_PRODUCTO = P.PRO_ID AND P.COM_ID = C.COM_ID AND D.DEV_LOCALIDAD = DE.DEP_ID" +
               " AND DEV_CEDULA LIKE '%" + sCedula + "%' AND DEV_RECIBO LIKE '%" + sRecibo + "%' AND CONVERT(VARCHAR(10),DEV_FECHATRANSFERENCIA,103) LIKE '%" + sFechaTransferencia + "%'";
         if (sLocalidad != "0")      
               sql += " AND DEV_LOCALIDAD ="+sLocalidad;

         sql += " ORDER BY DEV_FECHASISTEMA DESC, DEV_CONSECUTIVO DESC";

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Devoluciones");
        return ds;

    }

    public DataSet dsConsultarDevoluciones(String sConsecutivo)
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT DEP_NOMBRE LOCALIDAD,DEV_CEDULA CEDULA, DEV_RECIBO RECIBO, COM_NOMBRE COMPAÑIA, PRO_NOMBRE PRODUCTO, CONVERT(VARCHAR(10),DEV_FECHASOLICITUD,103) 'FECHA SOLICITUD', DEV_BANCO BANCO, DEV_NUMEROCUENTA 'NUMERO DE CUENTA'" +
               " , DEV_TIPOCUENTA 'TIPO DE CUENTA', DEV_CAUSAL 'CAUSAL', CONVERT(VARCHAR(10),DEV_FECHATRANSFERENCIA,103) 'FECHA TRANSFERENCIA', CONVERT(VARCHAR(10),DEV_VIGENCIA,103)  VIGENCIA, DEV_VALOR VALOR" +
               " ,CONVERT(VARCHAR(10),DEV_FECHASISTEMA,103) 'FECHA APLICACION SISTEMA', DEV_USUARIO USUARIO, DEV_CONSECUTIVO CONSECUTIVO, DEV_ESTADO ESTADO" +
               " FROM DEVOLUCIONES D, PRODUCTO P, COMPAÑIA C, DEPARTAMENTO DE " +
               " WHERE D.DEV_PRODUCTO = P.PRO_ID AND P.COM_ID = C.COM_ID AND D.DEV_LOCALIDAD = DE.DEP_ID"+
               " AND DEV_CONSECUTIVO = "+sConsecutivo+
               " ORDER BY DEV_FECHASISTEMA DESC, DEV_CONSECUTIVO DESC";

        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Devoluciones");
        return ds;

    }


    public DataTable dtConsultarCliente(String sCedula)
    {

        DataSet ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT *, CONVERT(VARCHAR(10),TER_FECHANACIMIENTO,103) FECHA_NAC FROM TERCERO WHERE TER_ID = " + sCedula ;


        SqlCommand cmd = new SqlCommand(sql, cnx);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //sqlTercero.InsertParameters.Add("ter_id",Control,txtCedula.ToString());

        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;



        /*
        da = new SqlDataAdapter(sql, cnx);
        ds = new DataSet();
        da.Fill(ds, "Cliente");
        return ds;*/

    }



    public DataSet consultarDepartamentos()
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT * FROM DEPARTAMENTO";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Departamentos");
        return Ds;
    }

    public DataSet consultarDepartamento(String sDepartamento)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT * FROM DEPARTAMENTO WHERE DEP_ID =" + sDepartamento;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Departamento");
        return Ds;
    }


    public DataSet consultarCiudadesDepartamento(String sDep)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT * FROM CIUDAD WHERE DEP_ID ="+ sDep;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Departamentos");
        return Ds;
    }

    public DataSet consultarOcupaciones()
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT * FROM OCUPACION";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Ocupaciones");
        return Ds;
    }


    public DataSet consultarResumenCliente(String sCedula, String sProducto)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT RES_CERTIFICADO CERTIFICADO, CONVERT(VARCHAR(10),RES_FECHAEXPEDICION,103) 'FECHA EXPEDICION', CONVERT(VARCHAR(10),RES_VIGENCIADESDE,103) 'VIGENCIA' "+
            " , RES_VALORTOTAL 'PRIMA', RES_ESTADONEGOCIO 'ESTADO NEGOCIO',RES_ESTADODESCUENTO 'ESTADO DESCUENTO', RES_ESTADOCARTERA 'ESTADO CARTERA'" +
            " FROM RESUMEN WHERE TER_ID =" + sCedula+" AND PRO_ID = "+sProducto +
            " ORDER BY RES_VIGENCIADESDE DESC, RES_FECHAEXPEDICION DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Resumen");
        return Ds;
    }


    public DataSet consultarCertificadoResumen(String sCedula, String sProducto, String sCertificado)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT RES_CERTIFICADO CERTIFICADO, CONVERT(VARCHAR(10),RES_FECHAEXPEDICION,103) 'FECHA EXPEDICION', CONVERT(VARCHAR(10),RES_VIGENCIADESDE,103) 'VIGENCIA' " +
            " , RES_VALORTOTAL 'PRIMA', RES_ESTADONEGOCIO 'ESTADO NEGOCIO',RES_ESTADODESCUENTO 'ESTADO DESCUENTO', RES_ESTADOCARTERA 'ESTADO CARTERA'" +
            " FROM RESUMEN WHERE TER_ID =" + sCedula + " AND PRO_ID = " + sProducto + " AND RES_CERTIFICADO = "+ sCertificado+
            " ORDER BY RES_VIGENCIADESDE DESC, RES_FECHAEXPEDICION DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Resumen");
        return Ds;
    }


    public DataSet consultarGestionRetiroCliente(String sCedula, String sCertificado, String sProducto, String sLocalidad, String sCompañia)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CONVERT(VARCHAR(10),gesret_fechacarta,103) 'FECHA CARTA', GESRET_TIPO 'TIPO GESTION', CONVERT(VARCHAR(10),GESRET_FECHA,103) 'FECHA CONTACTO', GESRET_HORA 'HORA', GESRET_AMPM 'AM/PM',"+
            " ASE_APELLIDOS 'APELLIDOS ASESOR', ASE_NOMBRES 'NOMBRES ASESOR', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'"+
            " , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.' "+
            "FROM GESTIONRETIROS GR, ASESOR A WHERE GR.GESRET_FUNCIONARIO = ASE_ID" +
            " AND TER_ID =" + sCedula + " AND GESRET_CERTIFICADO = " + sCertificado + " AND PRO_ID = " + sProducto+" AND A.DEP_ID=" + sLocalidad+ " AND A.COM_ID="+sCompañia+
            " ORDER BY GESRET_FECHACARTA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Retiros");
        return Ds;
    }

    public DataSet consultarGestionRetiroCliente(String sCedula, String sCertificado, String sProducto, String sLocalidad, String sCompañia, String sFechaCarta)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CONVERT(VARCHAR(10),gesret_fechacarta,103) 'FECHA CARTA', GESRET_TIPO 'TIPO GESTION', CONVERT(VARCHAR(10),GESRET_FECHA,103) 'FECHA CONTACTO', GESRET_HORA 'HORA', GESRET_AMPM 'AM/PM'," +
            " ASE_APELLIDOS 'APELLIDOS ASESOR', ASE_NOMBRES 'NOMBRES ASESOR', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'" +
            " , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.' " +
            "FROM GESTIONRETIROS GR, ASESOR A WHERE GR.GESRET_FUNCIONARIO = ASE_ID" +
            " AND TER_ID =" + sCedula + " AND GESRET_CERTIFICADO = " + sCertificado + " AND PRO_ID = " + sProducto + " AND A.DEP_ID=" + sLocalidad + " AND A.COM_ID=" + sCompañia +
            " AND GESRET_FECHACARTA = '" +sFechaCarta + "'"+
            " ORDER BY GESRET_FECHACARTA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Retiros");
        return Ds;
    }

    public DataSet consultarGestionRetiroCliente(String sCedula, String sCertificado, String sProducto, String sFechaCarta)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CONVERT(VARCHAR(10),gesret_fechacarta,103) 'FECHA CARTA', GESRET_TIPO 'TIPO GESTION', CONVERT(VARCHAR(10),GESRET_FECHA,103) 'FECHA CONTACTO', GESRET_HORA 'HORA', GESRET_AMPM 'AM/PM'," +
            "  GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'" +
            " , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.', GESRET_FUNCIONARIO 'CODIGO ASESOR' " +
            "FROM GESTIONRETIROS GR WHERE" +
            " TER_ID =" + sCedula + " AND GESRET_CERTIFICADO = " + sCertificado + " AND PRO_ID = " + sProducto +
            " AND GESRET_FECHACARTA = '" + sFechaCarta + "'" +
            " ORDER BY GESRET_FECHACARTA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Retiros");
        return Ds;
    }

    public DataSet consultarObservacionGestionRetiroCliente(String sCedula, String sCertificado, String sProducto)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT GESRET_GESTION OBSERVACION" +
            " FROM GESTIONRETIROS GR WHERE" +
            " TER_ID =" + sCedula + " AND GESRET_CERTIFICADO = " + sCertificado + " AND PRO_ID = " + sProducto +
            " ORDER BY GESRET_FECHACARTA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Retiros");
        return Ds;
    }

    public void actualizarDevolucion(String sConsecutivo, String sFechaSol, String sBanco, String sNumero, String sTipo, String sCausal, String sFechaTransf,  String sEstado)
    {
        SqlCommand cmd;
        String sql;
        
        

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE DEVOLUCIONES SET DEV_FECHASOLICITUD = '" + sFechaSol + "', DEV_BANCO ='" + sBanco + "', DEV_NUMEROCUENTA ='" + sNumero + "',DEV_TIPOCUENTA='" + sTipo + "', DEV_CAUSAL='" +
            sCausal + "',DEV_FECHATRANSFERENCIA='" + sFechaTransf + "', DEV_ESTADO='" + sEstado + "'" +
            " WHERE DEV_CONSECUTIVO = " + sConsecutivo; 
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }

    public DataSet consultarCausalesRetiro()
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT * FROM CAUSALRETIRO";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Devoluciones");
        return Ds;
    }
    

    public void insertarGestionRetiro(String sCedula, String sCertificado, String sProducto, String sFechaGestion, String sHora, String sFuncionario, String sGestion, 
        String sFechaCarta, String sTipoGestion, String sVigenciaPrinc, String sCausalPrin, String sConyuge, String sUsuario)
    {
        SqlCommand cmd;
        String sql;
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        //CEDULA, RECIBO, PRODUCTO, FECHASOLICTUD, BANCO, NUMEROCUENTA, TIPOCUENTA, CAUSAL, FECHATRANSFERENCIA, FECHASISTEMA, USUARIO
        sql = "INSERT INTO GESTIONRETIROS VALUES (" + sCedula + "," + sCertificado + "," + "NULL" + ",'" + sProducto + "'," + sFechaGestion + "," + sHora + "," +
            "NULL" + "," + sFuncionario + ",'" + sGestion + "','" + sFechaCarta + "'," + sTipoGestion + ",'" + sVigenciaPrinc + "'," + sCausalPrin;
        if (sConyuge == "SI")
            sql += ",'" + sVigenciaPrinc + "'," + sCausalPrin;
        else
            sql += ",NULL, NULL";
        sql += ")"; //DateTime.Now.ToString("dd/MM/yyyy")
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        if (sTipoGestion == "RETIRO DEFINITIVO")
            sql = "INSERT INTO LOG VALUES (" + sCedula + ",'" + "GESTIONRETIROS" + "','" + "RELAMPAGOX" + "','" + "CREAR RETIRO CERTIFICADO:"+sCertificado+" PRODUCTO:"+sProducto +
            "','" + sUsuario + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "')"; //DateTime.Now.ToString("dd/MM/yyyy")
        else
            sql = "INSERT INTO LOG VALUES (" + sCedula + ",'" + "GESTIONRETIROS" + "','" + "RELAMPAGOX" + "','" + "CREAR RECUPERACION CERTIFICADO:" + sCertificado + " PRODUCTO:" + sProducto +
            "','" + sUsuario + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "')";
        cmd = new SqlCommand(sql, cnx);
        //cnx.Open();
        cmd.ExecuteNonQuery();


        //int i = cmd.ExecuteNonQuery();    
    }


    public DataSet consultarAsesores()
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT *, ase_Nombres + ' ' + ase_Apellidos ase_NombreCompleto FROM ASESOR ";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Asesores");
        return Ds;
    }

    public DataSet consultarAsesoresLocalidadCompañia(String sLocalidad, String sCompañia)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT *, ase_Nombres + ' ' + ase_Apellidos ase_NombreCompleto FROM ASESOR WHERE DEP_ID="+sLocalidad+ " AND COM_ID = "+sCompañia;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Asesores");
        return Ds;
    }


    public DataSet consultarCertificado (String sCedula, String sProducto, String sCertificado)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        
        
        sql = "SELECT * FROM "+Funciones.identificarTabla(sProducto)+" WHERE TER_ID ="+sCedula +" AND "+ Funciones.identificarPrefijo(sProducto)+"certificado =" + sCertificado;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Certificado");
        return Ds;
    }


    public String consultarLocalidadCertificado(String sCedula, String sProducto, String sCertificado)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        
        sql = "SELECT " + Funciones.identificarPrefijo(sProducto) + "localidad" + " Localidad FROM " + Funciones.identificarTabla(sProducto) + " WHERE TER_ID =" + sCedula + " AND " + Funciones.identificarPrefijo(sProducto) + "certificado=" + sCertificado;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Certificado");
        return Ds.Tables[0].Rows[0]["Localidad"].ToString();
    }



    public void actualizarEstado(String sTabla, String sPrefijo, String sCertificado, String sCedula, String sEstadoNegocio, String sProducto)
    {
        SqlCommand cmd;
        String sql;
        //String sNombreTabla = "";
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE " + sTabla + " SET " + sPrefijo + "ESTADONEGOCIO='" + sEstadoNegocio + "' WHERE TER_ID=" + sCedula + " AND " + sPrefijo + "CERTIFICADO=" + sCertificado;
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        sql = "UPDATE RESUMEN SET RES_ESTADONEGOCIO='" + sEstadoNegocio + "' WHERE TER_ID=" + sCedula + " AND RES_CERTIFICADO=" + sCertificado + " AND PRO_ID =" + sProducto;
        cmd = new SqlCommand(sql, cnx);
        //cnx.Open();
        cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }

    public void actualizarMovimiento(String sTabla, String sPrefijo, String sCertificado, String sCedula, String sTipoMovimiento, String sProducto)
    {
        SqlCommand cmd;
        String sql;
        String sMovimiento="";
        //String sNombreTabla = "";
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        switch (sTipoMovimiento)
        {
            case "1": sMovimiento = "INGRESA PRINCIPAL"; break;
            case "2": sMovimiento = "INGRESA PRINCIPAL Y CONYUGE"; break;
            case "3": sMovimiento = "INGRESA CONYUGE"; break;
            case "4": sMovimiento = "MODIFICA PRINCIPAL"; break;
            case "5": sMovimiento = "MODIFICA PRINCIPAL Y CONYUGE"; break;
            case "6": sMovimiento = "MODIFICA CONYUGE"; break;
            case "7": sMovimiento = "RETIRA PRINCIPAL"; break;
            case "8": sMovimiento = "RETIRA PRINCIPAL Y CONYUGE"; break;
            case "9": sMovimiento = "RETIRA CONYUGE"; break;
            case "10": sMovimiento = "MODIFICA PRINCIPAL Y RETIRA CONYUGE"; break;
            case "11": sMovimiento = "MODIFICA PRINCIPAL E INGRESA CONYUGE"; break;
            case "12": sMovimiento = "REEXPEDICION PRINCIPAL"; break;
            case "13": sMovimiento = "REEXPEDICION PRINCIPAL Y CONYUGE"; break;
            case "14": sMovimiento = "REEXPEDICION CONYUGE"; break;
            case "15": sMovimiento = "RECUPERACION PRINCIPAL"; break;
            case "16": sMovimiento = "RECUPERACION PRINCIPAL Y CONYUGE"; break;
            case "17": sMovimiento = "MIGRACION VERSION ANTERIOR"; break;
            case "18": sMovimiento = "RETIRO EN GESTION"; break;
            case "19": sMovimiento = "NO APLICO"; break;
            case "20": sMovimiento = "REVERSION"; break;
            case "21": sMovimiento = "DEVOLUCION"; break;
        }

        sql = "UPDATE " + sTabla + " SET " + sPrefijo + "MOVIMIENTO='" + sMovimiento + "',"+sPrefijo + "TIPOMOVIMIENTO= "+sTipoMovimiento+" WHERE TER_ID=" + sCedula + 
              " AND " + sPrefijo + "CERTIFICADO=" + sCertificado;
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        /*sql = "UPDATE RESUMEN SET RES_ESTADONEGOCIO='" + sEstadoNegocio + "' WHERE TER_ID=" + sCedula + " AND RES_CERTIFICADO=" + sCertificado + " AND PRO_ID =" + sProducto;
        cmd = new SqlCommand(sql, cnx);*/
        //cnx.Open();
        //cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }


    public void actualizarRetiroProducto(String sTabla, String sPrefijo, String sCertificado, String sCedula, String sFechaVigenciaRetiro, String sProducto, String sConyuge, 
            String sCausal, String sMesProduccion, String sAñoProduccion, String sMesProduccionLetras)
    {
        SqlCommand cmd;
        String sql;
        
        //String sNombreTabla = "";
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE " + sTabla + " SET " + sPrefijo + "VIGENCIARETIROPRINCIPAL='" + sFechaVigenciaRetiro + "'," + sPrefijo + "CAUSALPRINCIPAL='" + sCausal + "'" +
              "," + sPrefijo + "MesProduccion='" + sMesProduccion + "'," + sPrefijo + "AnoProduccion=" + sAñoProduccion + "," + sPrefijo + "MesProduccionLetras='" + sMesProduccionLetras;
        if (sConyuge == "SI")
            sql += "'," + sPrefijo + "VIGENCIARETIROCONYUGE='" + sFechaVigenciaRetiro + "',"  + sPrefijo + "CAUSALCONYUGE='" + sCausal ;

        
        sql += "' WHERE TER_ID=" + sCedula + " AND " + sPrefijo + "CERTIFICADO=" + sCertificado;
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        /*sql = "UPDATE RESUMEN SET RES_ESTADONEGOCIO='" + sEstadoNegocio + "' WHERE TER_ID=" + sCedula + " AND RES_CERTIFICADO=" + sCertificado + " AND PRO_ID =" + sProducto;
        cmd = new SqlCommand(sql, cnx);*/
        //cnx.Open();
        //cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }

    public void actualizarCausalRetiroProducto(String sTabla, String sPrefijo, String sCertificado, String sCedula,  String sProducto, String sConyuge,
            String sCausal)
    {
        SqlCommand cmd;
        String sql;

        //String sNombreTabla = "";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE " + sTabla + " SET " +sPrefijo+ "CAUSALPRINCIPAL='" + sCausal + "'";
                      
        if (sConyuge == "SI")
            sql += "," +  sPrefijo + "CAUSALCONYUGE='" + sCausal+"'";


        sql += " WHERE TER_ID=" + sCedula + " AND " + sPrefijo + "CERTIFICADO=" + sCertificado;
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        /*sql = "UPDATE RESUMEN SET RES_ESTADONEGOCIO='" + sEstadoNegocio + "' WHERE TER_ID=" + sCedula + " AND RES_CERTIFICADO=" + sCertificado + " AND PRO_ID =" + sProducto;
        cmd = new SqlCommand(sql, cnx);*/
        //cnx.Open();
        //cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }


    public DataSet consultarSumaAseguradaAmparo(String sCedula, String sProducto, String sCertificado, String sAmparo)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "SELECT * FROM " + Funciones.identificarTabla(sProducto) + "AMPARO WHERE TER_ID =" + sCedula + " AND " + Funciones.identificarPrefijo(sProducto) + "certificado=" + sCertificado + " AND "+Funciones.identificarPrefijoAmparos(sProducto)+"nombre = '"+sAmparo+"'";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Amparo");
        return Ds;
    }

    public void insertarCartaRetiro(String sCedula, String sCertificado, String sProducto, String sFechaAgencia, String sFechaCompañia, String sOficinaCompañia, String sAgenciaTorres
                , String sOficio, String sObservacion, String sFechaCasaMatriz, String sUsuario)
    {
        SqlCommand cmd;
        String sql;
        
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        //ter_id,gesret_certificado,pro_id,car_FechaAgencia,car_FechaCompañia,car_OficinaCompañia,car_AgenciaTorres,car_Oficio,car_FechaCasaMatriz

        sql = "INSERT INTO CARTARETIRO VALUES (" + sCedula + "," + sCertificado + "," + sProducto + ",'" + sFechaAgencia + "','" + sFechaCompañia + "','" + sOficinaCompañia + "','" +
            sAgenciaTorres + "','" + sOficio + "','" + sObservacion + "','" + sFechaCasaMatriz + "','" + sUsuario + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("hh:mm:ss tt");
        /*if (sConyuge == "SI")
            sql += "','" + sVigenciaPrinc + "','" + sCausalPrin;*/
        sql += "')"; //DateTime.Now.ToString("dd/MM/yyyy")
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

       

        //int i = cmd.ExecuteNonQuery();    
    }

    public String sNombreDepartamento (String sCodigoDepartamento)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));


        sql = "SELECT *  FROM DEPARTAMENTO WHERE DEP_ID =" + sCodigoDepartamento;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Departamento");
        return Ds.Tables[0].Rows[0]["dep_Nombre"].ToString();
    }


    public DataSet dsConsultarCartasRetirosCliente (String sCedula, String sCertificado, String sProducto)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CONVERT(VARCHAR(10),car_FechaAgencia,103) 'FECHA RADICACION AGENCIA', CAR_AGENCIATORRES 'LOCALIDAD', CONVERT(VARCHAR(10),CAR_FECHACOMPAÑIA,103) 'FECHA RADICACION COMPAÑIA',"+
            " CAR_OFICINACOMPAÑIA 'OFICINA COMPAÑIA', CAR_OFICIO 'ORIGEN OFICIO',CONVERT(VARCHAR(10),CAR_FECHACASAMATRIZ,103) 'FECHA CASA MATRIZ'" +
            //" ASE_APELLIDOS 'APELLIDOS ASESOR', ASE_NOMBRES 'NOMBRES ASESOR', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'" +
            //" , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.' " +
            " FROM CARTARETIRO "+ //GR, ASESOR A WHERE GR.GESRET_FUNCIONARIO = ASE_ID" +
            " WHERE TER_ID =" + sCedula + " AND GESRET_CERTIFICADO = " + sCertificado + " AND PRO_ID = " + sProducto + 
            " ORDER BY CAR_FECHAAGENCIA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "CartaRetiro");
        return Ds;
    }


    public DataSet dsConsultarCartasRetiros()
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CR.TER_ID CEDULA, CR.GESRET_CERTIFICADO CERTIFICADO, CR.PRO_ID PRODUCTO, CONVERT(VARCHAR(10),car_FechaAgencia,103) 'FECHA RADICACION AGENCIA',"+
            " CAR_AGENCIATORRES 'LOCALIDAD', CONVERT(VARCHAR(10),CAR_FECHACOMPAÑIA,103) 'FECHA RADICACION COMPAÑIA'," +
            " CAR_OFICINACOMPAÑIA 'OFICINA COMPAÑIA', CAR_OFICIO 'ORIGEN OFICIO', CAR_OBSERVACION OBSERVACION, CONVERT(VARCHAR(10),CAR_FECHACASAMATRIZ,103) 'FECHA CASA MATRIZ'," +
            " CAR_USUARIO USUARIO, CAR_FECHADIGITACION 'FECHA DIGITACION'"+
            " ,GESRET_FECHA 'FECHA CONTACTO', GESRET_TIPO 'TIPO GESTION'"+
            //" ASE_APELLIDOS 'APELLIDOS ASESOR', ASE_NOMBRES 'NOMBRES ASESOR', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'" +
            //" , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.' " +
            " FROM CARTARETIRO CR" +
            " ,GESTIONRETIROS GR"+//GR, ASESOR A WHERE GR.GESRET_FUNCIONARIO = ASE_ID" +
            " WHERE CAR_FECHADIGITACION ='" + DateTime.Now.ToString("dd/MM/yyyy") +"'"+
            " AND CR.TER_ID = GR.TER_ID AND CR.GESRET_CERTIFICADO = GR.GESRET_CERTIFICADO AND CR.PRO_ID = GR.PRO_ID "+
            " AND GESRET_FECHACARTA =(SELECT MAX(GESRET_FECHACARTA) FROM GESTIONRETIROS WHERE TER_ID = CR.TER_ID AND GESRET_CERTIFICADO = CR.GESRET_CERTIFICADO AND PRO_ID = CR.PRO_ID" +
            " AND (GESRET_FECHACARTA >= CAR_FECHACOMPAÑIA OR GESRET_FECHACARTA >= CAR_FECHAAGENCIA))" +
            " ORDER BY CAR_FECHAAGENCIA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "CartaRetiro");
        return Ds;
    }

    public DataSet dsConsultarCartasRetiros(String sFechaDigitacion, String sCedula, String sCertificado)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CR.TER_ID CEDULA, CR.GESRET_CERTIFICADO CERTIFICADO, CR.PRO_ID PRODUCTO, CONVERT(VARCHAR(10),car_FechaAgencia,103) 'FECHA RADICACION AGENCIA'," +
            " CAR_AGENCIATORRES 'LOCALIDAD', CONVERT(VARCHAR(10),CAR_FECHACOMPAÑIA,103) 'FECHA RADICACION COMPAÑIA'," +
            " CAR_OFICINACOMPAÑIA 'OFICINA COMPAÑIA', CAR_OFICIO 'ORIGEN OFICIO',CONVERT(VARCHAR(10),CAR_FECHACASAMATRIZ,103) 'FECHA CASA MATRIZ'," +
            " CAR_USUARIO USUARIO, CAR_FECHADIGITACION 'FECHA DIGITACION'" +
            " ,GESRET_FECHA 'FECHA CONTACTO', GESRET_TIPO 'TIPO GESTION'" +
            //" ASE_APELLIDOS 'APELLIDOS ASESOR', ASE_NOMBRES 'NOMBRES ASESOR', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'" +
            //" , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.' " +
            " FROM CARTARETIRO CR" +
            " ,GESTIONRETIROS GR" +//GR, ASESOR A WHERE GR.GESRET_FUNCIONARIO = ASE_ID" +
            " WHERE CAR_FECHADIGITACION LIKE '%" + sFechaDigitacion +"%'"+
            " AND CR.TER_ID LIKE '%"+sCedula+"%'"+
            " AND CR.GESRET_CERTIFICADO LIKE '%" + sCertificado + "%'" +
            " AND CR.TER_ID = GR.TER_ID AND CR.GESRET_CERTIFICADO = GR.GESRET_CERTIFICADO AND CR.PRO_ID = GR.PRO_ID " +
            " AND GESRET_FECHACARTA =(SELECT MAX(GESRET_FECHACARTA) FROM GESTIONRETIROS WHERE TER_ID = CR.TER_ID AND GESRET_CERTIFICADO = CR.GESRET_CERTIFICADO AND PRO_ID = CR.PRO_ID"+
            " AND (GESRET_FECHACARTA >= CAR_FECHACOMPAÑIA OR GESRET_FECHACARTA >= CAR_FECHAAGENCIA))" +
            " ORDER BY CAR_FECHAAGENCIA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "CartaRetiro");
        return Ds;
    }


    public DataSet dsConsultarProducto(String sCodigoProducto)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));


        sql = "SELECT *  FROM PRODUCTO WHERE PRO_ID =" + sCodigoProducto;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Productos");
        return Ds;
    }


    public void actualizarGestionRetiro(String sCedula, String sCertificado, String sProducto, String sFechaCarta, String sFechaContacto, String sHora, String sFuncionario, String sGestion, String sVigenciaRetiro, String sCausalRetiro, String sConyuge)
    {
        SqlCommand cmd;
        String sql;
        //String sNombreTabla = "";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE GESTIONRETIROS SET GESRET_FECHA ='" + sFechaContacto + "',GESRET_HORA ='" + sHora + "' ,GESRET_FUNCIONARIO =" + sFuncionario + ",GESRET_GESTION ='" + sGestion +
            "', GESRET_VIGENCIARETIROPRIN='" + sVigenciaRetiro + "' ,GESRET_CAUSALRETIROPRIN='" + sCausalRetiro + "'";
        if (sConyuge == "SI")
            sql += ",GESRET_VIGENCIARETIROCONY='"+sVigenciaRetiro+"' ,GESRET_CAUSALRETIROCONY= '"+sCausalRetiro+"'";
        sql += " WHERE TER_ID ="+ sCedula+" AND GESRET_CERTIFICADO="+sCertificado+" AND PRO_ID ="+sProducto+" AND GESRET_FECHACARTA = '"+sFechaCarta+"'";
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        
        //int i = cmd.ExecuteNonQuery();    
    }


    public void actualizarTercero(String sCedula, String sNombres, String sApellidos, String sSexo, String sEstadoCivil, String sFechanacimiento, String sOcupacion, String sDepartamento
        , String sCiudad, String sDireccion, String sTelefonoRes, String sTelefonoOf, String sCelular, String sCorreoElectronico, String sObservaciones, String sUsuario)
    {
        SqlCommand cmd;
        String sql;
        //String sNombreTabla = "";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE Tercero " +
            " SET " +//ter_Id = "ter_Id, numeric(12,0)
            " ter_Apellidos = '" + sApellidos + "'" +//, varchar(50)
            ",ter_Nombres = '" + sNombres + "'" +//, varchar(50)
            ",ter_Sexo = '" + sSexo + "'" +//, varchar(50)
            ",ter_EstadoCivil = '" + sEstadoCivil + "'" +//, varchar(50)
            ",ter_FechaNacimiento = '" + sFechanacimiento + "'" +//, datetime
            ",ocu_Id = '" + sOcupacion + "'" +//, numeric(12,0)
            ",dep_Id = '" + sDepartamento + "'" +// dep_Id, numeric(12,0)
            ",ciu_Id = '" + sCiudad + "'" +// ciu_Id, numeric(12,0)
            ",ter_Direccion = '" + sDireccion + "'" +// ter_Direccion, varchar(100)
            ",ter_TelefonoResidencia = '" + sTelefonoRes + "'" +//, varchar(50)
            ",ter_TelefonoOficina = '" + sTelefonoOf + "'" +// ter_TelefonoOficina, varchar(50)
            ",ter_Celular = '" + sCelular + "'" +// ter_Celular, varchar(50)
            ",ter_Correo = '" + sCorreoElectronico + "'" +// ter_Correo, varchar(50)
            ",ter_Usuario = '" + sObservaciones + "'";// ter_Usuario, varchar
      //,ter_Password = ter_Password, varchar(50)
      //,ter_HabeasData = ter_HabeasData, numeric(1,0)";
        
        sql += " WHERE TER_ID =" + sCedula ;
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();


        sql = "INSERT INTO LOG VALUES (" + sCedula + ",'" + "TERCERO" + "','" + "RELAMPAGOX" + "','" + "ACTUALIZAR CLIENTE"+
            "','" + sUsuario + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "')";
        cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }


    public DataSet dsConsultarAsesor (String sCodigoAsesor)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));


        sql = "SELECT *  FROM ASESOR WHERE ASE_ID = " + sCodigoAsesor;
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Asesor");
        return Ds;
    }


    public void actualizarAsesorProducto(String sTabla, String sPrefijo, String sCertificado, String sCedula, String sAsesor)
    {
        SqlCommand cmd;
        String sql;

        //String sNombreTabla = "";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));

        sql = "UPDATE " + sTabla + " SET ASE_ID = " + sAsesor +      
              " WHERE TER_ID=" + sCedula + " AND " + sPrefijo + "CERTIFICADO=" + sCertificado;
        cmd = new SqlCommand(sql, cnx);
        cnx.Open();
        cmd.ExecuteNonQuery();

        /*sql = "UPDATE RESUMEN SET RES_ESTADONEGOCIO='" + sEstadoNegocio + "' WHERE TER_ID=" + sCedula + " AND RES_CERTIFICADO=" + sCertificado + " AND PRO_ID =" + sProducto;
        cmd = new SqlCommand(sql, cnx);*/
        //cnx.Open();
        //cmd.ExecuteNonQuery();
        //int i = cmd.ExecuteNonQuery();    
    }


   
    public DataSet InformeRetirosNovedades(String sFechaVigencia)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CONVERT(VARCHAR(10),GESRET_FECHA,103) 'FECHA CONTACTO', CONVERT(VARCHAR(10),GESRET_FECHACARTA,103) 'FECHA CARTA', GR.TER_ID 'CEDULA', "+
            "GR.GESRET_CERTIFICADO 'CERTIFICADO', TER_APELLIDOS 'APELLIDOS', TER_NOMBRES 'NOMBRES', R.RES_VALORTOTAL 'PRIMA' "+
            " ,GESRET_TIPO 'TIPO GESTION', CAR_AGENCIATORRES 'AGENCIA TORRES', PRO_NOMBRE 'PRODUCTO', CONVERT(VARCHAR(10),CAR_FECHAAGENCIA,103) 'RECIBIDO AGENCIA', " +
            " CONVERT(VARCHAR(10),CAR_FECHACOMPAÑIA,103) 'RECIBIDO COMPAÑIA', CONVERT(VARCHAR(10),CAR_FECHACASAMATRIZ,103) 'RECIBIDO CASA MATRIZ', "+
            " CAR_OFICINACOMPAÑIA 'OFICINA COMPAÑIA', CAR_OFICIO 'ORIGEN OFICIO', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO' "+
            " FROM GESTIONRETIROS GR, TERCERO T, RESUMEN R, CARTARETIRO CR, PRODUCTO P "+
            " WHERE GR.TER_ID = T.TER_ID AND  R.TER_ID = GR.TER_ID AND R.RES_CERTIFICADO = GR.GESRET_CERTIFICADO "+  
            " AND P.PRO_ID = GR.PRO_ID AND CR.PRO_ID = P.PRO_ID AND P.PRO_ID = R.PRO_ID AND CR.PRO_ID = R.PRO_ID "+
            " AND CR.TER_ID = GR.TER_ID AND CR.GESRET_CERTIFICADO = GR.GESRET_CERTIFICADO AND CR.PRO_ID = GR.PRO_ID "+ 
            " AND GESRET_FECHACARTA = (SELECT MAX(GESRET_FECHACARTA) FROM GESTIONRETIROS WHERE TER_ID = GR.TER_ID  "+
            " AND GESRET_CERTIFICADO = GR.GESRET_CERTIFICADO) AND GESRET_TIPO = 'RETIRO DEFINITIVO' " +
            " AND GESRET_VIGENCIARETIROPRIN LIKE '%" + sFechaVigencia + "%'" +
            " ORDER BY GESRET_FECHACARTA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Informe Retiros");
        return Ds;
    }

    public DataSet InformeRetirosDefinitivos(String sFechaDesde, String sFechaHasta)
    {

        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT CONVERT(VARCHAR(10),GESRET_FECHA,103) 'FECHA CONTACTO', CONVERT(VARCHAR(10),GESRET_FECHACARTA,103) 'FECHA CARTA', GR.TER_ID 'CEDULA', " +
            "GR.GESRET_CERTIFICADO 'CERTIFICADO', TER_APELLIDOS 'APELLIDOS', TER_NOMBRES 'NOMBRES', R.RES_VALORTOTAL 'PRIMA' " +
            " ,GESRET_TIPO 'TIPO GESTION', CAR_AGENCIATORRES 'AGENCIA TORRES', PRO_NOMBRE 'PRODUCTO', CONVERT(VARCHAR(10),CAR_FECHAAGENCIA,103) 'RECIBIDO AGENCIA', " +
            " CONVERT(VARCHAR(10),CAR_FECHACOMPAÑIA,103) 'RECIBIDO COMPAÑIA', CONVERT(VARCHAR(10),CAR_FECHACASAMATRIZ,103) 'RECIBIDO CASA MATRIZ', " +
            " CAR_OFICINACOMPAÑIA 'OFICINA COMPAÑIA', CAR_OFICIO 'ORIGEN OFICIO', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO'  " +
            " FROM GESTIONRETIROS GR, TERCERO T, RESUMEN R, CARTARETIRO CR, PRODUCTO P " +
            " WHERE GR.TER_ID = T.TER_ID AND  R.TER_ID = GR.TER_ID AND R.RES_CERTIFICADO = GR.GESRET_CERTIFICADO " +
            " AND P.PRO_ID = GR.PRO_ID AND CR.PRO_ID = P.PRO_ID AND P.PRO_ID = R.PRO_ID AND CR.PRO_ID = R.PRO_ID " +
            " AND CR.TER_ID = GR.TER_ID AND CR.GESRET_CERTIFICADO = GR.GESRET_CERTIFICADO AND CR.PRO_ID = GR.PRO_ID " +
            " AND GESRET_FECHACARTA = (SELECT MAX(GESRET_FECHACARTA) FROM GESTIONRETIROS WHERE TER_ID = GR.TER_ID  " +
            " AND GESRET_CERTIFICADO = GR.GESRET_CERTIFICADO) AND GESRET_TIPO = 'RETIRO DEFINITIVO' " +
            " AND GESRET_FECHA BETWEEN '" + sFechaDesde + "' AND '" +sFechaHasta+ "'"+ 
            " ORDER BY GESRET_FECHACARTA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "Informe Retiros");
        return Ds;
    }

   /* public DataSet dsConsultarRetiro(String sCedula, String sCertificado, String sProducto, String sFechaCarta)
    {
        SqlDataAdapter Da;
        DataSet Ds;
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        sql = "SELECT TER_ID CEDULA, GESRET_CERTIFICADO CERTIFICADO, PRO_ID PRODUCTO, CONVERT(VARCHAR(10),car_FechaAgencia,103) 'FECHA RADICACION AGENCIA'," +
            " CAR_AGENCIATORRES 'LOCALIDAD', CONVERT(VARCHAR(10),CAR_FECHACOMPAÑIA,103) 'FECHA RADICACION COMPAÑIA'," +
            " CAR_OFICINACOMPAÑIA 'OFICINA COMPAÑIA', CAR_OFICIO 'ORIGEN OFICIO', CAR_OBSERVACION OBSERVACION, CONVERT(VARCHAR(10),CAR_FECHACASAMATRIZ,103) 'FECHA CASA MATRIZ'," +
            " CAR_USUARIO USUARIO, CAR_FECHADIGITACION 'FECHA DIGITACION'" +
            //" ASE_APELLIDOS 'APELLIDOS ASESOR', ASE_NOMBRES 'NOMBRES ASESOR', GESRET_VIGENCIARETIROPRIN 'VIGENCIA RETIRO PRINC.', GESRET_CAUSALRETIROPRIN 'CAUSAL RETIRO PRINC.'" +
            //" , GESRET_VIGENCIARETIROCONY 'VIGENCIA RETIRO CONY.', GESRET_CAUSALRETIROCONY 'CAUSAL RETIRO CONY.' " +
            " FROM CARTARETIRO " + //GR, ASESOR A WHERE GR.GESRET_FUNCIONARIO = ASE_ID" +
            " WHERE CAR_FECHADIGITACION ='" + DateTime.Now.ToString("dd/MM/yyyy") + "'" +
            " ORDER BY CAR_FECHAAGENCIA DESC";
        Da = new SqlDataAdapter(sql, cnx);
        Ds = new DataSet();
        Da.Fill(Ds, "CartaRetiro");
        return Ds;
    }*/

    public DataTable ConsultarPagosPorMes(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        String sql;
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        //sql = "Select * From Tercero Where ter_Id = 17857116";
        sql = "select  T.ter_Id,T.ter_Nombres,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion Direccion," +
            "ter_TelefonoResidencia Tel_Particular,T.ter_Celular Tel_Movil,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES BOLIVAR' Cuenta,'PLAN MAESTRO' Asignado_a ,PA.paga_Nombre Empresa_donde_labora, "+
            "D1.dep_Nombre,C1.ciu_Nombre,ES.edubol_IdConyuge,ES.edubol_NombresConyuge,ES.edubol_ApellidosConyuge, "+
            "'NO TIENE' Tel_Conyugue,O1.ocu_Nombre Ocupacion_Conyugue,ES.edubol_VigenciaDesde,ESB.Hijos, (P.fac_valor) AS Enero, (P1.fac_valor) AS Febrero, (P2.fac_valor) as Marzo,(P3.fac_valor) as Abril,(P4.fac_valor) as Mayo,(P5.fac_valor) as Junio,(P6.fac_valor) as Julio,(P7.fac_valor) as Agosto,(P8.fac_valor) as Septiembre,(P9.fac_valor) as Octubre,R.res_ValorTotal Prima " +
            "from  Tercero T JOIN Departamento D ON(T.dep_Id=D.dep_Id ) JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id )JOIN Ocupacion O " +
            "ON(T.ocu_Id=O.ocu_Id)JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=1) JOIN EducadoresBolivar ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.edubol_Certificado and ES.edubol_EstadoNegocio='VIGENTE')JOIN Pagaduria PA "+
            "ON(ES.paga_Id=PA.paga_Id)LEFT JOIN Departamento D1 ON(PA.dep_Id=D1.dep_Id)JOIN Ciudad C1 ON(PA.ciu_Id=C1.ciu_Id)left JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) "+
            "left join (SELECT COUNT(*)Hijos ,edubol_Certificado,ter_Id FROM EducadoresBolivarBeneficiario where edubolben_Parentesco='HIJO' OR edubolben_Parentesco='HIJA' group by edubol_Certificado,ter_Id )ESB on(ES.edubol_Certificado=ESB.edubol_Certificado and ES.ter_Id=ESB.ter_Id ) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P ON(ES.ter_Id=P.ter_Id and P.fac_InicioVigencia Between '2014-01-01 00:00:00.000' and '2014-31-01 00:00:00.000' and P.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P1 ON(ES.ter_Id=P1.ter_Id and P1.fac_InicioVigencia Between '2014-01-02 00:00:00.000' and '2014-28-02 00:00:00.000' and P1.pro_Id=1) "+ 
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P2 ON(ES.ter_Id=P2.ter_Id and P2.fac_InicioVigencia Between '2014-01-03 00:00:00.000' and '2014-30-03 00:00:00.000' and P2.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P3 ON(ES.ter_Id=P3.ter_Id and P3.fac_InicioVigencia Between '2014-01-04 00:00:00.000' and '2014-30-04 00:00:00.000' and P3.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P4 ON(ES.ter_Id=P4.ter_Id and P4.fac_InicioVigencia Between '2014-01-05 00:00:00.000' and '2014-31-05 00:00:00.000' and P4.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P5 ON(ES.ter_Id=P5.ter_Id and P5.fac_InicioVigencia Between '2014-01-06 00:00:00.000' and '2014-30-06 00:00:00.000' and P5.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P6 ON(ES.ter_Id=P6.ter_Id and P6.fac_InicioVigencia Between '2014-01-07 00:00:00.000' and '2014-31-07 00:00:00.000' and P6.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P7 ON(ES.ter_Id=P7.ter_Id and P7.fac_InicioVigencia Between '2014-01-08 00:00:00.000' and '2014-31-08 00:00:00.000' and P7.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P8 ON(ES.ter_Id=P8.ter_Id and P8.fac_InicioVigencia Between '2014-01-09 00:00:00.000' and '2014-30-09 00:00:00.000' and P8.pro_Id=1) "+
            "left JOIN (Select ter_id, SUM(fac_Valor) fac_valor, fac_InicioVigencia,pro_Id from Pago  group by ter_id,fac_InicioVigencia, pro_Id) P9 ON(ES.ter_Id=P9.ter_Id and P9.fac_InicioVigencia Between '2014-01-10 00:00:00.000' and '2014-31-10 00:00:00.000' and P9.pro_Id=1)";
        da = new SqlDataAdapter(sql, cnx);     
        
        
        da.Fill(dt);
        return dt;
    }


    public int LastDaysMonth(int year, int month)
    {
        int days = 0;
        switch (month)
        {
            case 1:
                days = 31;
                break;
            case 2:
                if (DateTime.IsLeapYear(year) == true)
                    days = 29;
                else
                    days = 28;                
                break;
            case 3:
                days = 31;
                break;        
            case 4:
                days = 30;
                break;
            case 5:
                days = 31;
                break;
            case 6:
                days = 30;
                break;
            case 7:
                days = 31;
                break;
            case 8:
                days = 31;
                break;
            case 9:
                days = 30;
                break;
            case 10:
                days = 31;
                break;
            case 11:
                days = 30;
                break;
            case 12:
                days = 31;
                break;
        }
        return days;   
    }

    public DataTable ConsultarPagosPorMesAMesGenerali(int mesInicio, int anioInicio, int mesFin, int anioFin, DataTable dt)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        //DataTable dt = new DataTable();
        DataSet ds = new DataSet();       
        dt = new DataTable();
        string consulta = "SELECT T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento, " +
                          "(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 AS INT)) Edad, D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion,ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'SALUD' Cuenta,'GENERALI' Aseguradora, " +
                          "PA.paga_Nombre EmpresaDondeLabora, ES.salgen_IdConyuge IdConyuge,'NO TIENE' Conyuge,'NO TIENE' ApellidosConyuge,'NO TIENE' FechaNacConyuge, " +
                          "'NO TIENE' TelConyugue,ES.salgen_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_Valor) AS Valor, R.res_ValorTotal Prima " +
                          "FROM Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=13 AND R.res_EstadoNegocio='VIGENTE') " +
                          "LEFT JOIN Pago P ON (T.ter_Id=P.ter_id AND P.pro_Id=13 AND P.fac_InicioVigencia Between ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id)" +
                          "JOIN SaludGenerali ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.salgen_Certificado and ES.salgen_EstadoNegocio='VIGENTE')" +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.salgen_IdConyuge,ES.salgen_VigenciaDesde,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120)";
         
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);        
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();        
        
        return dt;
    }

    public DataTable ConsultarPagosPorMesAMesPrevisora(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "SELECT T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES' Cuenta,'PREVISORA' Aseguradora, PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.edupre_IdConyuge IdConyuge, ES.edupre_NombresConyuge Conyuge,ES.edupre_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyugue, O1.ocu_Nombre OcupacionConyugue,ES.edupre_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor, R.res_ValorTotal Prima " +
                          "FROM  Tercero T JOIN Departamento D ON(T.dep_Id=D.dep_Id )  " +
                          "LEFT JOIN Pago P ON (T.ter_Id=P.ter_Id AND P.pro_Id=2 AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=2 AND R.res_EstadoNegocio='VIGENTE') " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id)" +
                          "JOIN EducadoresPrevisora ES ON(R.ter_Id=ES.ter_Id AND R.res_Certificado=ES.edupre_Certificado AND ES.edupre_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id)" +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.edupre_IdConyuge, ES.edupre_NombresConyuge, ES.edupre_ApellidosConyuge, O1.ocu_Nombre, ES.edupre_VigenciaDesde ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }



    public DataTable ConsultarPagosPorMesAMesLiberty(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "SELECT T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES' Cuenta,'LIBERTY' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.edulib_IdConyuge IdConyuge,ES.edulib_NombresConyuge Conyuge,ES.edulib_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.edulib_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor, R.res_ValorTotal Prima " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=3) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=3 AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN EducadoresLiberty ES ON(R.ter_Id=ES.ter_Id AND R.res_Certificado=ES.edulib_Certificado AND ES.edulib_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.edulib_IdConyuge,ES.edulib_VigenciaDesde,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.edulib_NombresConyuge,ES.edulib_ApellidosConyuge, O1.ocu_Nombre ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }

    public DataTable ConsultarPagosPorMesAMesVigilantesLiberty(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "select T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'VIGILANTES' Cuenta,'LIBERTY' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.viglib_IdConyuge IdConyuge,ES.viglib_NombresConyuge NombresConyuge,ES.viglib_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge, ES.viglib_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor,R.res_ValorTotal Prima " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=21) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=21 AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN VigilantesLiberty ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.viglib_Certificado and ES.viglib_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.viglib_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.viglib_NombresConyuge,ES.viglib_ApellidosConyuge, O1.ocu_Nombre, ES.viglib_VigenciaDesde ";                          

        //cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }

    public DataTable ConsultarPagosPorMesAMesCamaraComercioMapfre(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "select T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'CAMARA DE COMERCIO' Cuenta,'MAPFRE' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.camcommap_IdConyuge IdConyuge,ES.camcommap_NombresConyuge NombresConyuge,ES.camcommap_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.camcommap_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor,R.res_ValorTotal Prima " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=9) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=9 AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN CamaraComercioMapfre ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.camcommap_Certificado and ES.camcommap_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.camcommap_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.camcommap_NombresConyuge,ES.camcommap_ApellidosConyuge, O1.ocu_Nombre, ES.camcommap_VigenciaDesde ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }  


    public DataTable ConsultarPagosPorMesAMesEmpresariosSuramericana(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "select T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EMPRESARIOS' Cuenta,'SURAMERICANA' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.empsur_IdConyuge IdConyuge,ES.empsur_NombresConyuge NombresConyuge,ES.empsur_ApellidosConyuge ApellidosConyuge,ES.empsur_FechaNacimientoConyuge FechaNacConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.empsur_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor,R.res_ValorTotal Prima " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=4) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=4 AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN EmpresariosSuramericana ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.empsur_Certificado and ES.empsur_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.empsur_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.empsur_NombresConyuge,ES.empsur_ApellidosConyuge, O1.ocu_Nombre, ES.empsur_VigenciaDesde, ES.empsur_FechaNacimientoConyuge ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }


    public DataTable ConsultarPagosPorMesAMesPlanMaestroBolivar(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "select  T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento ,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES BOLIVAR' Cuenta,'PLAN MAESTRO' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.edubol_IdConyuge IdConyuge,ES.edubol_NombresConyuge NombresConyuge,ES.edubol_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.edubol_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor, R.res_ValorTotal Prima " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=1) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=1 AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN EducadoresBolivar ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.edubol_Certificado and ES.edubol_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.edubol_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.edubol_NombresConyuge,ES.edubol_ApellidosConyuge, O1.ocu_Nombre, ES.edubol_VigenciaDesde ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }


    // CONSULTAS LENTAS ACORTADAS
    public DataTable ConsultarPagosPorMesAMesEducadoresMapfre(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "select T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES' Cuenta,'MAPFRE' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.camcommap_IdConyuge IdConyuge,ES.camcommap_NombresConyuge NombresConyuge,ES.camcommap_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.camcommap_VigenciaDesde InicioVigencia,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor, R.res_ValorTotal Prima, R.pro_Id Producto " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN CamaraComercioMapfre ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.camcommap_Certificado and ES.camcommap_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.camcommap_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.camcommap_NombresConyuge,ES.camcommap_ApellidosConyuge, O1.ocu_Nombre, ES.camcommap_VigenciaDesde, R.pro_Id ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }


    public DataTable ConsultarPagosPorMesAMesPlus(int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int lastDay = LastDaysMonth(anioFin, mesFin);
        int anioInicioFijo = anioInicio;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        dt = new DataTable();
        string consulta = "select  T.ter_Id DocumentoIdentidad,T.ter_Nombres Nombres,T.ter_Apellidos Apellidos,T.ter_Sexo Sexo,T.ter_EstadoCivil EstadoCivil,T.ter_FechaNacimiento FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre Departamento,C.ciu_Nombre Ciudad,T.ter_Direccion Direccion, " +
                          "ter_TelefonoResidencia Telefono,T.ter_Celular Celular,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES BOLIVAR' Cuenta,'PLUS' Aseguradora ,PA.paga_Nombre EmpresaDondeLabora, " +
                          "ES.edubol_IdConyuge IdConyuge,ES.edubol_NombresConyuge NombresConyuge,ES.edubol_ApellidosConyuge ApellidosConyuge, " +
                          "'NO TIENE' TelConyuge,O1.ocu_Nombre OcupacionConyuge,ES.edubol_VigenciaDesde InicioVigencia, CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor, R.res_ValorTotal Prima, R.pro_Id Producto " +
                          "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id) " +
                          "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.fac_InicioVigencia BETWEEN ' " + anioInicio + " - 01 - " + mesInicio + " 00:00:00.000' AND '" + anioFin + " - " + lastDay + " - " + mesFin + " 00:00:00.000')" +
                          "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
                          "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
                          "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
                          "JOIN EducadoresBolivar ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.edubol_Certificado and ES.edubol_EstadoNegocio='VIGENTE') " +
                          "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +                          
                          "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
                          "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
                          "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
                          "PA.paga_Nombre,ES.edubol_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
                          "ES.edubol_NombresConyuge,ES.edubol_ApellidosConyuge, O1.ocu_Nombre, ES.edubol_VigenciaDesde, R.pro_Id ";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        ds.Tables.Add(dt);
        cnx.Close();

        return dt;
    }  

    public DataTable CargarDDLCompania()
    {
        DataTable dt = new DataTable();
        string consulta = "SELECT com_Id, com_Nombre FROM Compañia";

        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);        
        cnx.Close();
        return dt;
    }

    public DataTable CargarDDLProducto(string compania)
    {
        DataTable dt = new DataTable();
        string consulta = "SELECT pro_Id, com_Id, pro_Nombre, pro_Tabla, pro_Campo, pro_MesesGracia FROM Producto WHERE com_Id = @compania";
        int company = CodigoCompania(compania);
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cmd.Parameters.Add("@compania", SqlDbType.Int).Value = company;
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        cnx.Close();
        return dt;
    }

    public int CodigoCompania(string compania)
    {   
        string consulta = "SELECT com_Id FROM Compañia WHERE com_Nombre = @compania";
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cmd.Parameters.Add("@compania", SqlDbType.VarChar).Value = compania;
        cnx.Open();
        cmd.CommandTimeout = 50000;
        string codCompania = cmd.ExecuteScalar().ToString();
        int cod = int.Parse(codCompania);
        return cod;
    }

    ////MUY LENTAAA
    //public DataTable ConsultarPagosPorMesAMesEducadoresMapfre(int mesInicio, int anioInicio, int mesFin, int anioFin)
    //{
    //    int lastDay = LastDaysMonth(anioFin, mesFin);
    //    int anioInicioFijo = anioInicio;
    //    DataTable dt = new DataTable();
    //    DataSet ds = new DataSet();
    //    dt = new DataTable();
    //    string consulta = "select T.ter_Id,T.ter_Nombres,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,(cast(datediff(DD,T.ter_FechaNacimiento,getdate())/365.25 as int)) Edad,D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion Direccion, " +
    //                      "ter_TelefonoResidencia Tel_Particular,T.ter_Celular Tel_Movil,T.ter_Correo Email,O.ocu_Nombre Ocupacion,'EDUCADORES' Cuenta,'MAPFRE' Asignado_a ,PA.paga_Nombre Empresa_donde_labora, " +
    //                      "D1.dep_Nombre,C1.ciu_Nombre,ES.camcommap_IdConyuge,ES.camcommap_NombresConyuge,ES.camcommap_ApellidosConyuge, " +
    //                      "'NO TIENE' Tel_Conyugue,O1.ocu_Nombre Ocupacion_Conyugue,ES.camcommap_VigenciaDesde,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120) Periodo, SUM(P.fac_valor) AS Valor, R.res_ValorTotal Prima " +
    //                      "FROM  Tercero T JOIN Resumen R ON(T.ter_Id=R.ter_Id AND R.pro_Id=98) " +
    //                      "LEFT JOIN Pago P ON(T.ter_Id=P.ter_Id AND P.pro_Id=98 AND P.fac_InicioVigencia BETWEEN '2014-01-01 00:00:00.000' AND '2014-31-01 00:00:00.000') " +
    //                      "JOIN Departamento D ON(T.dep_Id=D.dep_Id ) " +
    //                      "JOIN Ciudad C ON(T.ciu_Id=C.ciu_Id ) " +
    //                      "JOIN Ocupacion O ON(T.ocu_Id=O.ocu_Id) " +
    //                      "JOIN CamaraComercioMapfre ES ON(R.ter_Id=ES.ter_Id and R.res_Certificado=ES.camcommap_Certificado and ES.camcommap_EstadoNegocio='VIGENTE') " +
    //                      "JOIN Pagaduria PA ON(ES.paga_Id=PA.paga_Id) " +
    //                      "LEFT JOIN Departamento D1 ON(PA.dep_Id=D1.dep_Id) " +
    //                      "JOIN Ciudad C1 ON(PA.ciu_Id=C1.ciu_Id) " +
    //                      "LEFT JOIN Ocupacion O1 ON(ES.ocu_Id=O1.ocu_Id) " +
    //                      "GROUP BY T.ter_Nombres, T.ter_Id,T.ter_Apellidos,T.ter_Sexo,T.ter_EstadoCivil,T.ter_FechaNacimiento,R.res_ValorTotal, " +
    //                      "D.dep_Nombre,C.ciu_Nombre,T.ter_Direccion,T.ter_TelefonoResidencia,T.ter_Celular,T.ter_Correo,O.ocu_Nombre, " +
    //                      "PA.paga_Nombre,D1.dep_Nombre,C1.ciu_Nombre,ES.camcommap_IdConyuge,CONVERT(CHAR(4), P.fac_InicioVigencia, 100) + CONVERT(CHAR(4), P.fac_InicioVigencia, 120), " +
    //                      "ES.camcommap_NombresConyuge,ES.camcommap_ApellidosConyuge, O1.ocu_Nombre, ES.camcommap_VigenciaDesde ";

    //    cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
    //    SqlCommand cmd = new SqlCommand(consulta, cnx);
    //    cnx.Open();
    //    cmd.CommandTimeout = 50000;
    //    SqlDataReader reader = cmd.ExecuteReader();
    //    dt.Load(reader);
    //    ds.Tables.Add(dt);
    //    cnx.Close();

    //    return dt;
    //}  
    


                                            /*REPORTE PARA CALIDAD DE PRODUCCION MES A MES */
           
    public DataTable ReporteProduccionPlanMaestroBolivar(int mesInicio, int anioInicio)
    {        
        DataTable dt = new DataTable();        
        string consulta = "SELECT DEP_NOMBRE,EB.TER_ID, T.TER_APELLIDOS, TER_NOMBRES, EDUBOL_CERTIFICADO, PAGA_NOMBRE, RES_VALORTOTAL, EDUBOL_MOVIMIENTO, EDUBOL_FECHAEXPEDICION, EDUBOL_VIGENCIADESDE, EDUBOL_CONVERSION, R.PRO_ID, " +
                          "CASE " + 
	                      "WHEN EDUBOL_TIPOMOVIMIENTO IN(1,2) THEN 'INGRESO' " +
	                      "WHEN EDUBOL_TIPOMOVIMIENTO IN (3,4,5,6,9,10,11) THEN 'MODIFICACION' " +
                          "END, LOG_FECHA " +
                          "FROM EDUCADORESBOLIVAR EB, RESUMEN R, PAGADURIA P, TERCERO T, DEPARTAMENTO D, LOG L " +
                          "WHERE EB.TER_ID = R.TER_ID AND EB.EDUBOL_CERTIFICADO = R.RES_CERTIFICADO  AND P.PAGA_ID = EB.PAGA_ID " +
                          "AND EDUBOL_MESPRODUCCION = 12 AND EDUBOL_ANOPRODUCCION = 2014 " +
                          "AND T.TER_ID = R.TER_ID AND D.DEP_ID = EDUBOL_LOCALIDAD " +
                          "AND EDUBOL_TIPOMOVIMIENTO NOT IN (7,8,12,13,15,16,18,19,21) AND R.PRO_ID = 1 " +
                          "AND LOG_MOVIMIENTO LIKE 'CREAR CERTIFICADO%' " +
                          "AND L.LOG_IDTABLA = R.TER_ID AND SUBSTRING(LOG_MOVIMIENTO,20,LEN(LOG_MOVIMIENTO)-19) = RES_CERTIFICADO " +
                          "ORDER BY CONVERT(DATETIME,LOG_FECHA) "; 
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);        
        cnx.Close();

        return dt;
    }


    public DataTable ReporteProduccionPlusBolivar(int mesInicio, int anioInicio)
    {
        DataTable dt = new DataTable();
        string consulta = "SELECT DEP_NOMBRE,EB.TER_ID, T.TER_APELLIDOS, TER_NOMBRES, EDUBOL_CERTIFICADO, PAGA_NOMBRE, RES_VALORTOTAL, EDUBOL_MOVIMIENTO, EDUBOL_FECHAEXPEDICION, EDUBOL_VIGENCIADESDE, EDUBOL_CONVERSION, R.PRO_ID, " +
                          "CASE WHEN EDUBOL_TIPOMOVIMIENTO IN(1,2) AND EDUBOL_CONVERSION = 0 THEN 'INGRESO PLUS' " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN (3,4,5,6,9,10,11) AND EDUBOL_CONVERSION = 1 THEN 'CONVERSION' " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN (3,4,5,6,9,10,11) AND EDUBOL_CONVERSION = 0 THEN 'MODIFICACION PLUS' " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN (15,16) AND EDUBOL_CONVERSION = 0 THEN 'INGRESO PLUS' " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN (15,16) AND EDUBOL_CONVERSION = 1 THEN 'CONVERSION' " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN (12,13) AND EDUBOL_CONVERSION = 1 THEN 'CONVERSION' " +
                          "END, LOG_FECHA " +
                          "FROM EDUCADORESBOLIVAR EB, RESUMEN R, PAGADURIA P, TERCERO T, DEPARTAMENTO D, LOG L " +
                          "WHERE EB.TER_ID = R.TER_ID AND EB.EDUBOL_CERTIFICADO = R.RES_CERTIFICADO  AND P.PAGA_ID = EB.PAGA_ID " +
                          "AND EDUBOL_MESPRODUCCION = " + mesInicio + " AND EDUBOL_ANOPRODUCCION = " + anioInicio +
                          "AND T.TER_ID = R.TER_ID AND D.DEP_ID = EDUBOL_LOCALIDAD " +
                          "AND EDUBOL_TIPOMOVIMIENTO NOT IN (7,8,18,19,21) AND R.PRO_ID = 99 " +
                          "AND LOG_MOVIMIENTO LIKE 'CREAR CERTIFICADO%' " +
                          "AND L.LOG_IDTABLA = R.TER_ID AND SUBSTRING(LOG_MOVIMIENTO,20,LEN(LOG_MOVIMIENTO)-19) = RES_CERTIFICADO " +
                          "ORDER BY CONVERT(DATETIME,LOG_FECHA) ";
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        cnx.Close();

        return dt;
    }

    public DataTable ReporteProduccionGeneraliSalud(int mesInicio, int anioInicio)
    {
        DataTable dt = new DataTable();
        string consulta = "SELECT DEP_NOMBRE,EB.TER_ID, T.TER_APELLIDOS, TER_NOMBRES, EDUBOL_CERTIFICADO, PAGA_NOMBRE, RES_VALORTOTAL, EDUBOL_MOVIMIENTO, EDUBOL_FECHAEXPEDICION, EDUBOL_VIGENCIADESDE, EDUBOL_CONVERSION, R.PRO_ID, " +
                          "CASE " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN(1,2) THEN 'INGRESO' " +
                          "WHEN EDUBOL_TIPOMOVIMIENTO IN (3,4,5,6,9,10,11) THEN 'MODIFICACION' " +
                          "END, LOG_FECHA " +
                          "FROM EDUCADORESBOLIVAR EB, RESUMEN R, PAGADURIA P, TERCERO T, DEPARTAMENTO D, LOG L " +
                          "WHERE EB.TER_ID = R.TER_ID AND EB.EDUBOL_CERTIFICADO = R.RES_CERTIFICADO  AND P.PAGA_ID = EB.PAGA_ID " +
                          "AND EDUBOL_MESPRODUCCION = 12 AND EDUBOL_ANOPRODUCCION = 2014 " +
                          "AND T.TER_ID = R.TER_ID AND D.DEP_ID = EDUBOL_LOCALIDAD " +
                          "AND EDUBOL_TIPOMOVIMIENTO NOT IN (7,8,12,13,15,16,18,19,21) AND R.PRO_ID = 1 " +
                          "AND LOG_MOVIMIENTO LIKE 'CREAR CERTIFICADO%' " +
                          "AND L.LOG_IDTABLA = R.TER_ID AND SUBSTRING(LOG_MOVIMIENTO,20,LEN(LOG_MOVIMIENTO)-19) = RES_CERTIFICADO " +
                          "ORDER BY CONVERT(DATETIME,LOG_FECHA) ";
        cnx = new SqlConnection(sDefinirConexion("Cn_RelampagoX"));
        SqlCommand cmd = new SqlCommand(consulta, cnx);
        cnx.Open();
        cmd.CommandTimeout = 50000;
        SqlDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        cnx.Close();

        return dt;
    }
}