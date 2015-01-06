using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
jkdhfkjdhfkjdhfkdjfhksdjfhdkjfhdkjf

public partial class ReporteProduccion : System.Web.UI.Page
{

    BaseDatos BD = new BaseDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtCompania = new DataTable();
        if (Session["Usuario"].ToString() == "")
            Response.Redirect("Login.aspx");
        if (Session["Navegador"].ToString() == "Chrome")
        {            

        }
        ListItem mes = new ListItem();
        ListItem anio = new ListItem();
        ListItem items = new ListItem();
        bool flag = false;
        if (IsPostBack == false)
        {
            dtCompania = BD.CargarDDLCompania();            
            foreach (DataRow dr in dtCompania.Rows)
            {   
                if (int.Parse(dr["com_Id"].ToString()) != 5)
                {                    
                    ddlCompanias.Items.Add(dr["com_Nombre"].ToString());
                }                    
            }
    
            LlenaDDLProducto();

            mes.Value = "1";
            mes.Text = "Enero";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "2";
            mes.Text = "Febrero";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "3";
            mes.Text = "Marzo";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "4";
            mes.Text = "Abril";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "5";
            mes.Text = "Mayo";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "6";
            mes.Text = "Junio";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "7";
            mes.Text = "Julio";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "8";
            mes.Text = "Agosto";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "9";
            mes.Text = "Septiembre";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "10";
            mes.Text = "Octubre";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "11";
            mes.Text = "Noviembre";
            ddlMesInicio.Items.Add(mes);
            
            mes = new ListItem();
            mes.Value = "12";
            mes.Text = "Diciembre";
            ddlMesInicio.Items.Add(mes);
            
            for (int i = 2007; i <= DateTime.Today.Year + 1; i++)
            {
                anio = new ListItem();
                anio.Text = i.ToString();
                anio.Value = i.ToString();
                ddlAnioInicio.Items.Add(anio);                
            }
        }
        
        
        
            
    }
    protected void btnGestionRetiro_Click(object sender, EventArgs e)
    {        
        DataTable dt = new DataTable();
        DataTable dtResultado = new DataTable();
        int mesInicio = int.Parse(ddlMesInicio.SelectedValue.ToString());
        int anioInicio = int.Parse(ddlAnioInicio.SelectedValue.ToString());        
      
        if (ddlCompanias.Items.FindByText("GENERALI").Selected && ddlSeguros.Items.FindByText("SALUD").Selected)
        {
            //dt = BD.ConsultarPagosPorMesAMesGenerali(mesInicio, anioInicio, mesFin, anioFin, dt);            
            //dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);            
            //GenerarReporte(dtResultado, "ReportePagosGenerali.xls");
        }
        if (ddlCompanias.Items.FindByText("LA PREVISORA").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            //dt = new DataTable(); 
            //dtResultado = new DataTable();
            //dt = BD.ConsultarPagosPorMesAMesPrevisora(mesInicio, anioInicio, mesFin, anioFin);            
            //dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            //GenerarReporte(dtResultado, "ReportePagosPrevisora.xls");            
        }
        if (ddlCompanias.Items.FindByText("LIBERTY SEGUROS").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            //dt = new DataTable();
            //dtResultado = new DataTable();
            //dt = BD.ConsultarPagosPorMesAMesLiberty(mesInicio, anioInicio, mesFin, anioFin);            
            //dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            //GenerarReporte(dtResultado, "ReportePagosEducadoresLiberty.xls");
        }
        if (ddlCompanias.Items.FindByText("LIBERTY SEGUROS").Selected && ddlSeguros.Items.FindByText("VIGILANTES").Selected)
        {
            //dt = new DataTable();
            //dtResultado = new DataTable();
            //dt = BD.ConsultarPagosPorMesAMesVigilantesLiberty(mesInicio, anioInicio, mesFin, anioFin);            
            //dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            //GenerarReporte(dtResultado, "ReportePagosVigilantesLiberty.xls");
        }
        if (ddlCompanias.Items.FindByText("SURAMERICANA").Selected && ddlSeguros.Items.FindByText("EMPRESARIOS").Selected)
        {
            //dt = new DataTable();
            //dtResultado = new DataTable();
            //dt = BD.ConsultarPagosPorMesAMesEmpresariosSuramericana(mesInicio, anioInicio, mesFin, anioFin);            
            //dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            //GenerarReporte(dtResultado, "ReportePagosEmpresariosSuramericana.xls");
        }
        if (ddlCompanias.Items.FindByText("SEGUROS BOLIVAR").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            //BOLIVAR
            dt = new DataTable();            
            dt = BD.ReporteProduccionPlanMaestroBolivar(mesInicio, anioInicio);                        
            GenerarReporte(dt, "ReporteProduccionPlanMaestroBolivar" + mesInicio + anioInicio + ".xls");
        }
        if (ddlCompanias.Items.FindByText("MAPFRE").Selected && ddlSeguros.Items.FindByText("CAMARAS DE COMERCIO").Selected)
        {            
            //dt = new DataTable();
            //dtResultado = new DataTable();
            //dt = BD.ConsultarPagosPorMesAMesCamaraComercioMapfre(mesInicio, anioInicio, mesFin, anioFin);            
            //dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            //GenerarReporte(dtResultado, "ReportePagosCamaraComercioMapfre.xls");
        }
        if (ddlCompanias.Items.FindByText("MAPFRE").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {            
            //dt = new DataTable();
            //dtResultado = new DataTable();
            //DataTable dtFinal = new DataTable();
            //dt = BD.ConsultarPagosPorMesAMesEducadoresMapfre(mesInicio, anioInicio, mesFin, anioFin);            
            //dtFinal = OrganizarGrandesConsultasMapfre(dt);
            //dtResultado = GenerarDataTable(dtFinal, mesInicio, anioInicio, mesFin, anioFin);
            //GenerarReporte(dtResultado, "ReportePagosEducadoresMapfre.xls");
        }

        if (ddlCompanias.Items.FindByText("SEGUROS BOLIVAR").Selected && ddlSeguros.Items.FindByText("EDUCADORES PLUS").Selected)
        {
            //PLUS
            dt = new DataTable();
            dt = BD.ReporteProduccionPlanMaestroBolivar(mesInicio, anioInicio);
            GenerarReporte(dt, "ReporteProduccionPlusBolivar" + mesInicio + anioInicio + ".xls");
        }
        
    }

    protected DataTable OrganizarGrandesConsultasMapfre(DataTable dt)
    {
        DataTable dtResultado = new DataTable();        
        dtResultado = dt.Clone();
        //dtResultado.Columns.Remove("Producto");
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["Producto"].ToString() == "98")
            {
                dtResultado.ImportRow(dr);
            }
        }
        dtResultado.Columns.Remove("Producto");
        return dtResultado;
    }

    protected DataTable OrganizarGrandesConsultasPlus(DataTable dt)
    {
        DataTable dtResultado = new DataTable();
        dtResultado = dt.Clone();        
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["Producto"].ToString() == "99")
            {
                dtResultado.ImportRow(dr);
            }
        }
        dtResultado.Columns.Remove("Producto");
        return dtResultado;
    }        

    protected void GenerarReporte(DataTable dt, string fileName)
    {           
        string attachment = "attachment; filename=" + fileName;
        Response.HeaderEncoding = System.Text.Encoding.Default;
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.ClearContent();
        Response.ClearHeaders();        
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";
            }
            Response.Write("\n");
        }
        //Response.Flush();       
        Response.End();
    }
    protected void ddlCompanias_SelectedIndexChanged(object sender, EventArgs e)
    {
        LlenaDDLProducto();
    }

    protected void LlenaDDLProducto()
    {
        ddlSeguros.Items.Clear();
        DataTable dtProducto = new DataTable();
        ListItem items = new ListItem();
        string value = ddlCompanias.SelectedValue.ToString();
        dtProducto = BD.CargarDDLProducto(value);
        ddlSeguros.SelectedIndex = -1;
        foreach (DataRow dr in dtProducto.Rows)
        {
            items.Text = dr["pro_Nombre"].ToString();
            items.Value = dr["pro_Id"].ToString();
            int producto = int.Parse(dr["pro_Id"].ToString());
            if (producto == 1 || producto == 2 || producto == 3 || producto == 4 || producto == 9 || producto == 13 || producto == 21 || producto == 98 || producto == 99)
                ddlSeguros.Items.Add(dr["pro_Nombre"].ToString());
        }        
    }
}