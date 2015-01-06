using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformesRetiros : System.Web.UI.Page
{
    BaseDatos BD = new BaseDatos();    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Navegador"].ToString() == "Chrome")
        {
            RegularExpressionValidator1.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
            RegularExpressionValidator3.Enabled = false;            
        }
        else
        {
            RegularExpressionValidator1.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
            RegularExpressionValidator3.Enabled = true;
        }
        if (!IsPostBack)
        {
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = true;
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (ddlInforme.SelectedValue.ToString() == "INFORME NOVEDADES")
        {
            grvInformesRetiros.DataSource = BD.InformeRetirosNovedades(Funciones.sFechaConvertida(txtFechaVigencia.Text));            
            //Session["TablaInformes"] = BD.InformeRetirosNovedades(Funciones.sFechaConvertida(txtFechaVigencia.Text)).Tables[0];
            Session["DataSetInformes"] = BD.InformeRetirosNovedades(Funciones.sFechaConvertida(txtFechaVigencia.Text));
            
        }
        else
        {
            grvInformesRetiros.DataSource = BD.InformeRetirosDefinitivos(Funciones.sFechaConvertida(txtDesde.Text), Funciones.sFechaConvertida(txtHasta.Text));            
            //Session["TablaInformes"] = BD.InformeRetirosDefinitivos(Funciones.sFechaConvertida(txtDesde.Text), Funciones.sFechaConvertida(txtHasta.Text)).Tables[0];
            Session["DataSetInformes"] = BD.InformeRetirosDefinitivos(Funciones.sFechaConvertida(txtDesde.Text), Funciones.sFechaConvertida(txtHasta.Text));
        }

        grvInformesRetiros.DataBind();
        if (grvInformesRetiros.Rows.Count > 0)
        {
            btnExcel.Enabled = true;
            btnExcel.Visible = true;
        }
        else
        {
            btnExcel.Enabled = false;
            btnExcel.Visible = false;
        }
        
    }
    protected void ddlInforme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInforme.SelectedValue.ToString() == "INFORME NOVEDADES")
        {
            txtDesde.Text = "";
            txtHasta.Text = "";
            txtFechaVigencia.Text = "";
            txtDesde.Enabled = false;
            txtHasta.Enabled = false;
            txtFechaVigencia.Enabled = true;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = true;

            if (Session["Navegador"].ToString() != "Chrome")
            {
                RegularExpressionValidator1.Enabled = false;
                RegularExpressionValidator2.Enabled = false;
                RegularExpressionValidator3.Enabled = true;

            }
        }
        else
        {
            txtDesde.Text = "";
            txtHasta.Text = "";
            txtFechaVigencia.Text = "";
            txtDesde.Enabled = true;
            txtHasta.Enabled = true;
            txtFechaVigencia.Enabled = false;

            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = false;

            if (Session["Navegador"].ToString() != "Chrome")
            {
                RegularExpressionValidator1.Enabled = true;
                RegularExpressionValidator2.Enabled = true;
                RegularExpressionValidator3.Enabled = false;

            }
        }
        grvInformesRetiros.DataSource = null;
        grvInformesRetiros.DataBind();
        btnExcel.Enabled = false;
        btnExcel.Visible = false;

    }


    /*protected void DescargarExcel(GridView grv, String sNombreHoja)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename="+sNombreHoja+".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            //grv.AllowPaging = false;
            //this.BindGrid();

            grv.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in grv.HeaderRow.Cells)
            {
                cell.BackColor = grv.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in grv.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = grv.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = grv.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            grv.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            
        }
    }*/
    


    protected void btnExcel_Click(object sender, EventArgs e)
    {
        /*DataTable dt = new DataTable();
        for (int j = 0; j < grvInformesRetiros.Rows.Count; j++)
        {
            DataRow dr;
            GridViewRow row = grvInformesRetiros.Rows[j];
            dr = dt.NewRow();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dr[i] = row.Cells[j].Text;
            }

            dt.Rows.Add(dr);
        }
        //DescargarExcel(grvInformesRetiros, "Informe Retiros");*/
       
        descargarExcel(((DataSet)(Session["DataSetInformes"])).Tables[0], "Informe Retiros");
    }

    public override void VerifyRenderingInServerForm(Control control)
   {
 

   }

    
    protected void descargarExcel(DataTable dt, string filename)
    {
        string attachment = "attachment; filename=" + filename+".xls";
        Response.ClearContent();
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
        Response.End();
    }


    /*private DataTable GetDataTable(GridView dtg)
    {
        DataTable dt = new DataTable();

        // add the columns to the datatable            
        if (dtg.HeaderRow != null)
        {

            for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
            {
                dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
            }
        }

        //  add each of the data rows to the table
        foreach (GridViewRow row in dtg.Rows)
        {
            DataRow dr;
            dr = dt.NewRow();

            for (int i = 0; i < row.Cells.Count; i++)
            {
                dr[i] = row.Cells[i].Text.Replace(" ", "");
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }*/
    protected void grvInformesRetiros_PageIndexChanged(object sender, EventArgs e)
    {
        //grvInformesRetiros.PageIndex = e.NewPageIndex;
        //grvInformesRetiros.DataBind();
    }
    protected void grvInformesRetiros_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvInformesRetiros.PageIndex = e.NewPageIndex;
        grvInformesRetiros.DataSource = (DataSet)Session["DataSetInformes"];
        grvInformesRetiros.DataBind();
    }
}