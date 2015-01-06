using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public CascadingDropDownNameValue[] ObtenerCompañia(string knownCategoryValues)
    {
        string query = "SELECT com_nombre, com_id FROM Compañia";
        List<CascadingDropDownNameValue> countries = GetData(query);
        return countries.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] ObtenerProductoCompañia(string knownCategoryValues)
    {
        string country = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["com_id"];
        string query = string.Format("SELECT pro_nombre, pro_id FROM Producto WHERE pro_id = {0}", country);
        List<CascadingDropDownNameValue> states = GetData(query);
        return states.ToArray();
    }


    private List<CascadingDropDownNameValue> GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["Cn_RelampagoX"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            cmd.Connection = con;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    values.Add(new CascadingDropDownNameValue
                    {
                        name = reader[0].ToString(),
                        value = reader[1].ToString()
                    });
                }
                reader.Close();
                con.Close();
                return values;
            }
        }
    }

    
}
