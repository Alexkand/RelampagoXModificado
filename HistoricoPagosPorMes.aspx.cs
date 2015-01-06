using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using interExcel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Configuration;


public partial class HistoricoPagosPorMes : System.Web.UI.Page
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
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "2";
            mes.Text = "Febrero";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "3";
            mes.Text = "Marzo";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "4";
            mes.Text = "Abril";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "5";
            mes.Text = "Mayo";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "6";
            mes.Text = "Junio";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "7";
            mes.Text = "Julio";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "8";
            mes.Text = "Agosto";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "9";
            mes.Text = "Septiembre";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "10";
            mes.Text = "Octubre";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "11";
            mes.Text = "Noviembre";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            mes = new ListItem();
            mes.Value = "12";
            mes.Text = "Diciembre";
            ddlMesInicio.Items.Add(mes);
            ddlMesFin.Items.Add(mes);

            for (int i = 2007; i <= DateTime.Today.Year + 1; i++)
            {
                anio = new ListItem();
                anio.Text = i.ToString();
                anio.Value = i.ToString();
                ddlAnioInicio.Items.Add(anio);
                ddlAnioFin.Items.Add(anio);
            }
        }
        
        
        
            
    }
    protected void btnGestionRetiro_Click(object sender, EventArgs e)
    {        
        DataTable dt = new DataTable();
        DataTable dtResultado = new DataTable();
        int mesInicio = int.Parse(ddlMesInicio.SelectedValue.ToString());
        int anioInicio = int.Parse(ddlAnioInicio.SelectedValue.ToString());
        int mesFin = int.Parse(ddlMesFin.SelectedValue.ToString());
        int anioFin = int.Parse(ddlAnioFin.SelectedValue.ToString());

        if (anioInicio > anioFin)
        {                  
            Response.Write("<script LANGUAGE='JavaScript' >alert('POR FAVOR REVISE LAS FECHAS INTRODUCIDAS')</script>");
            return;
        }            
        else
            if (anioInicio == anioFin && mesInicio > mesFin)
            {                   
                Response.Write("<script LANGUAGE='JavaScript' >alert('POR FAVOR REVISE LAS FECHAS INTRODUCIDAS')</script>");
                return;
            }

        if (ddlCompanias.Items.FindByText("GENERALI").Selected && ddlSeguros.Items.FindByText("SALUD").Selected)
        {
            dt = BD.ConsultarPagosPorMesAMesGenerali(mesInicio, anioInicio, mesFin, anioFin, dt);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);            
            GenerarReporte(dtResultado, "ReportePagosGenerali.xls");
        }
        if (ddlCompanias.Items.FindByText("LA PREVISORA").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            dt = new DataTable(); 
            dtResultado = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesPrevisora(mesInicio, anioInicio, mesFin, anioFin);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosPrevisora.xls");            
        }
        if (ddlCompanias.Items.FindByText("LIBERTY SEGUROS").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            dt = new DataTable();
            dtResultado = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesLiberty(mesInicio, anioInicio, mesFin, anioFin);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosEducadoresLiberty.xls");
        }
        if (ddlCompanias.Items.FindByText("LIBERTY SEGUROS").Selected && ddlSeguros.Items.FindByText("VIGILANTES").Selected)
        {
            dt = new DataTable();
            dtResultado = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesVigilantesLiberty(mesInicio, anioInicio, mesFin, anioFin);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosVigilantesLiberty.xls");
        }
        if (ddlCompanias.Items.FindByText("SURAMERICANA").Selected && ddlSeguros.Items.FindByText("EMPRESARIOS").Selected)
        {
            dt = new DataTable();
            dtResultado = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesEmpresariosSuramericana(mesInicio, anioInicio, mesFin, anioFin);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosEmpresariosSuramericana.xls");
        }
        if (ddlCompanias.Items.FindByText("SEGUROS BOLIVAR").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            //BOLIVAR
            dt = new DataTable();
            dtResultado = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesPlanMaestroBolivar(mesInicio, anioInicio, mesFin, anioFin);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosPlanMaestroBolivar.xls");
        }
        if (ddlCompanias.Items.FindByText("MAPFRE").Selected && ddlSeguros.Items.FindByText("CAMARAS DE COMERCIO").Selected)
        {            
            dt = new DataTable();
            dtResultado = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesCamaraComercioMapfre(mesInicio, anioInicio, mesFin, anioFin);            
            dtResultado = GenerarDataTable(dt, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosCamaraComercioMapfre.xls");
        }
        if (ddlCompanias.Items.FindByText("MAPFRE").Selected && ddlSeguros.Items.FindByText("EDUCADORES").Selected)
        {
            //LENTAAAA
            dt = new DataTable();
            dtResultado = new DataTable();
            DataTable dtFinal = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesEducadoresMapfre(mesInicio, anioInicio, mesFin, anioFin);            
            dtFinal = OrganizarGrandesConsultasMapfre(dt);
            dtResultado = GenerarDataTable(dtFinal, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosEducadoresMapfre.xls");
        }

        if (ddlCompanias.Items.FindByText("SEGUROS BOLIVAR").Selected && ddlSeguros.Items.FindByText("EDUCADORES PLUS").Selected)
        {
            //LENTAAAA
            dt = new DataTable();
            dtResultado = new DataTable();
            DataTable dtFinal = new DataTable();
            dt = BD.ConsultarPagosPorMesAMesPlus(mesInicio, anioInicio, mesFin, anioFin);
            dtFinal = OrganizarGrandesConsultasPlus(dt);
            dtResultado = GenerarDataTable(dtFinal, mesInicio, anioInicio, mesFin, anioFin);
            GenerarReporte(dtResultado, "ReportePagosEducadoresPlusBolivar.xls");
        }
        
    }

    //protected DataTable LlenarConCeros(DataTable dt)
    //{
    //    DataTable dtResultado = new DataTable();        
    //    dtResultado = dt.Clone();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        if (dr[""])
    //        dtResultado.ImportRow(dr);
    //    }
    //}

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
        //dtResultado.Columns.Remove("Producto");
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

    protected DataTable GenerarDataTable(DataTable dt, int mesInicio, int anioInicio, int mesFin, int anioFin)
    {
        int mesTemp = mesInicio;
        int anioTemp = anioInicio;
        DataTable dtResult = new DataTable();
        DataColumn column = new DataColumn();
        int[] mesAnio = new int[2];
        List<int[]> periodos = new List<int[]>();
        List<string> meses = new List<string>();
        DataColumn columnNew = new DataColumn();
        int contadorCamposTotales = 0;
        List<string> primas = new List<string>();
        foreach (DataColumn col in dt.Columns)
        {
            if (col.ColumnName != "Periodo" && col.ColumnName != "Valor" && col.ColumnName != "Prima")
            {
                columnNew = new DataColumn();
                columnNew.DataType = System.Type.GetType("System.String");
                columnNew.ColumnName = col.ColumnName;                
                dtResult.Columns.Add(columnNew);
                contadorCamposTotales++;
            }
        }

        do
        {            
            mesAnio[0] = mesTemp;
            mesAnio[1] = anioTemp;
            periodos.Add(mesAnio);
            if (mesTemp == 12)
            {
                mesTemp = 1;
                anioTemp++;
            }
            else
                mesTemp++;            
            mesAnio = new int[2];
            if (anioTemp > anioFin && mesTemp == 1)
                mesTemp = 13;
                
        } while (anioTemp < anioFin || mesTemp <= mesFin);

        meses = GenerarFecha(periodos);

        DataColumn idColumn = new DataColumn();
        foreach (string mes in meses)
        {
            idColumn = new DataColumn();
            //idColumn.DataType = System.Type.GetType("System.Int32");            
            idColumn.DataType = System.Type.GetType("System.String");
            idColumn.ColumnName = mes;            
            dtResult.Columns.Add(idColumn);
        }
        idColumn = new DataColumn();
        //idColumn.DataType = System.Type.GetType("System.Int32");        
        idColumn.DataType = System.Type.GetType("System.String");        
        idColumn.ColumnName = "Prima";        
        dtResult.Columns.Add(idColumn);

        DataRow rowTemp = dtResult.NewRow();

        float idTemp = 0;
        foreach (DataRow row in dt.Rows)
        {
            float temp = float.Parse(row["DocumentoIdentidad"].ToString());
            if (temp != idTemp)
            {
                if (idTemp != 0)
                {
                    foreach (string mes in meses)
                    {
                        if (rowTemp[mes].ToString() == "")
                            rowTemp[mes] = "0";
                    }
                    dtResult.Rows.Add(rowTemp);
                    rowTemp = dtResult.NewRow();
                }
                for (int i = 0; i < contadorCamposTotales; i++)
                {
                    rowTemp[i] = row[i].ToString();
                }                
                string nombreColumna = row["Periodo"].ToString();
                if (nombreColumna != "")
                {
                    rowTemp[nombreColumna] = row["Valor"];                    
                }
                if (rowTemp["Prima"].ToString() == "")
                {
                    //rowTemp["Prima"] = row["Prima"];
                    rowTemp["Prima"] = row["Prima"].ToString();
                }   
                idTemp = temp;
            }
            else
            {
                string nombreColumna = row["Periodo"].ToString();
                if (nombreColumna != "")
                {
                    rowTemp[nombreColumna] = row["Valor"];
                    if (rowTemp["Prima"].ToString() == "")
                    {
                        //rowTemp["Prima"] = row["Prima"];
                        rowTemp["Prima"] = row["Prima"].ToString();
                    }                    
                }
            }            
        }
        return dtResult;
    }
    
    protected List<string> GenerarFecha(List<int[]> periodos)
    {       
        List<string> meses = new List<string>();

        foreach (int[] mesAnio in periodos)
        {
            //int aniotemp = mesAnio[1] % 2000;
            int aniotemp = mesAnio[1];
            switch (mesAnio[0])
            {
                case 1:
                    meses.Add("Ene "+aniotemp.ToString());
                    break;
                case 2:
                    meses.Add("Feb " + aniotemp.ToString());
                    break;
                case 3:
                    meses.Add("Mar " + aniotemp.ToString());
                    break;
                case 4:
                    meses.Add("Abr " + aniotemp.ToString());
                    break;
                case 5:
                    meses.Add("May " + aniotemp.ToString());
                    break;
                case 6:
                    meses.Add("Jun " + aniotemp.ToString());
                    break;
                case 7:
                    meses.Add("Jul " + aniotemp.ToString());
                    break;
                case 8:
                    meses.Add("Ago " + aniotemp.ToString());
                    break;
                case 9:
                    meses.Add("Sep " + aniotemp.ToString());
                    break;
                case 10:
                    meses.Add("Oct " + aniotemp.ToString());
                    break;
                case 11:
                    meses.Add("Nov " + aniotemp.ToString());
                    break;
                case 12:
                    meses.Add("Dic " + aniotemp.ToString());
                    break;                
            }            
        }
        return meses;
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