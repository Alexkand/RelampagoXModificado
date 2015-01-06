using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Descripción breve de Funciones
/// </summary>
public class Funciones
{
    public string sTabla;
    public string sPrefijo;
	public Funciones()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//        
	}

    public static String sFechaConvertida (String sFecha)
    {
        return Convert.ToDateTime(sFecha).ToString("dd/MM/yyyy");
    }

    public static String identificarTabla(String sProducto)
    {
        String sTabla="";
        String sPrefijo;
        switch (sProducto)
        {
            case "1":
            case "99":
                {
                    sTabla = " EDUCADORESBOLIVAR";
                    sPrefijo = " edubol_";
                    //sSelect = " edubol_localidad"; 
                    break;
                }
            case "2":
                {
                    sTabla = " EDUCADORESPREVISORA";
                    sPrefijo = " edupre_";
                    //sSelect = " edupre_localidad";
                    break;
                }
            case "3":
                {
                    sTabla = " EDUCADORESLIBERTY";
                    sPrefijo = " edulib_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "4":
                {
                    sTabla = " EMPRESARIOSSURAMERICANA";
                    sPrefijo = " empsur_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "9":
            case "98":
                {
                    sTabla = " CAMARACOMERCIOMAPFRE";
                    sPrefijo = " camcommap_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "21":
                {
                    sTabla = " VIGILANTESLIBERTY";
                    sPrefijo = " viglib_";
                    //sSelect = " edulib_localidad";
                    break;
                }

        }
        return sTabla;
    }

    public static String identificarPrefijo(String sProducto)
    {
        String sTabla;
        String sPrefijo="";
        switch (sProducto)
        {
            case "1":
            case "99":
                {
                    sTabla = " EDUCADORESBOLIVAR";
                    sPrefijo = " edubol_";
                    //sSelect = " edubol_localidad"; 
                    break;
                }
            case "2":
                {
                    sTabla = " EDUCADORESPREVISORA";
                    sPrefijo = " edupre_";
                    //sSelect = " edupre_localidad";
                    break;
                }
            case "3":
                {
                    sTabla = " EDUCADORESLIBERTY";
                    sPrefijo = " edulib_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "4":
                {
                    sTabla = " EMPRESARIOSSURAMERICANA";
                    sPrefijo = " empsur_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "9":
            case "98":
                {
                    sTabla = " CAMARACOMERCIOMAPFRE";
                    sPrefijo = " camcommap_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "21":
                {
                    sTabla = " VIGILANTESLIBERTY";
                    sPrefijo = " viglib_";
                    //sSelect = " edulib_localidad";
                    break;
                }
        }
        return sPrefijo;
    }


    public static String identificarPrefijoAmparos(String sProducto)
    {
        String sTabla;
        String sPrefijo = "";
        switch (sProducto)
        {
            case "1":
            case "99":
                {
                    sTabla = " EDUCADORESBOLIVAR";
                    sPrefijo = " edubolamp_";
                    //sSelect = " edubol_localidad"; 
                    break;
                }
            case "2":
                {
                    sTabla = " EDUCADORESPREVISORA";
                    sPrefijo = " edupreamp_";
                    //sSelect = " edupre_localidad";
                    break;
                }
            case "3":
                {
                    sTabla = " EDUCADORESLIBERTY";
                    sPrefijo = " edulibamp_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "4":
                {
                    sTabla = " EMPRESARIOSSURAMERICANA";
                    sPrefijo = " empsuramp_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "9":
            case "98":
                {
                    sTabla = " CAMARACOMERCIOMAPFRE";
                    sPrefijo = " camcommapamp_";
                    //sSelect = " edulib_localidad";
                    break;
                }
            case "21":
                {
                    sTabla = " VIGILANTESLIBERTY";
                    sPrefijo = " viglibamp_";
                    //sSelect = " edulib_localidad";
                    break;
                }
        }
        return sPrefijo;
    }


    public static String[] sMesProduccion(String sFecha)
    {
        String[] sMesProduccion = new String[3];
        int iDia = Convert.ToDateTime(sFecha).Day;
        int iMes = Convert.ToDateTime(sFecha).Month;
        int iAño = Convert.ToDateTime(sFecha).Year;


        if(iDia<20)
        {
            sMesProduccion[0] = iMes.ToString();
            sMesProduccion[1] = iAño.ToString();
            //sMesProduccion[2] = DateTimeFormatInfo Convert.ToDateTime(sFecha);
            //DateTimeFormatInfo myDTFI = new CultureInfo("es-ES", false).DateTimeFormat;
            sMesProduccion[2] = new CultureInfo("es-ES", false).DateTimeFormat.MonthNames[iMes - 1].ToUpper();
        }
        else
        {
            if (iMes+1>12)
            {
                sMesProduccion[0] = "1";
                sMesProduccion[1] = (iAño + 1).ToString();
                sMesProduccion[2] = "ENERO";
            }
            else
            {
                sMesProduccion[0] = (iMes+1).ToString();
                sMesProduccion[1] = iAño.ToString();
                sMesProduccion[2] = new CultureInfo("es-ES", false).DateTimeFormat.MonthNames[iMes].ToUpper();
            }

            
        }

        return sMesProduccion;
    }

    public static String sFechaVigenciaRetiro(String sFecha)
    {
        int iDia = Convert.ToDateTime(sFecha).Day;
        int iMes = Convert.ToDateTime(sFecha).Month;
        int iAño = Convert.ToDateTime(sFecha).Year;
        String sFechaRetiro = "";

        if (iDia < 21)
        {
            if (iMes + 2 == 14)
                sFechaRetiro = "01/02" + "/" + (iAño + 1).ToString();
            if (iMes + 2 == 13)
                sFechaRetiro = "01/01" + "/" + (iAño + 1).ToString();
            if (iMes + 2 < 13)
                sFechaRetiro = "01/" + (iMes + 2).ToString() + "/" + iAño.ToString();
        }
        else
        {
            if (iMes + 3 == 15)
                sFechaRetiro = "01/03" + "/" + (iAño + 1).ToString();
            if (iMes + 3 == 14)
                sFechaRetiro = "01/02" + "/" + (iAño + 1).ToString();
            if (iMes + 3 == 13)
                sFechaRetiro = "01/01" + "/" + (iAño + 1).ToString();
            if (iMes + 3 < 13)
                sFechaRetiro = "01/" + (iMes + 3).ToString() + "/" + iAño.ToString();
        }
        return sFechaRetiro;
    }

    public static String sFechaVigenciaRecuperacion(String sFecha)
    {
        int iDia = Convert.ToDateTime(sFecha).Day;
        int iMes = Convert.ToDateTime(sFecha).Month;
        int iAño = Convert.ToDateTime(sFecha).Year;
        String sFechaRetiro = "";

        if (iDia < 16)
        {
            if (iMes + 2 == 14)
                sFechaRetiro = "01/02" + "/" + (iAño + 1).ToString();
            if (iMes + 2 == 13)
                sFechaRetiro = "01/01" + "/" + (iAño + 1).ToString();
            if (iMes + 2 < 13)
                sFechaRetiro = "01/" + (iMes + 2).ToString() + "/" + iAño.ToString();
        }
        else
        {
            if (iMes + 3 == 15)
                sFechaRetiro = "01/03" + "/" + (iAño + 1).ToString();
            if (iMes + 3 == 14)
                sFechaRetiro = "01/02" + "/" + (iAño + 1).ToString();
            if (iMes + 3 == 13)
                sFechaRetiro = "01/01" + "/" + (iAño + 1).ToString();
            if (iMes + 3 < 13)
                sFechaRetiro = "01/" + (iMes + 3).ToString() + "/" + iAño.ToString();
        }
        return sFechaRetiro;
    }

    public static String[] sMesProduccionRecuperacion(String sFecha)
    {
        String[] sMesProduccion = new String[3];
        int iDia = Convert.ToDateTime(sFecha).Day;
        int iMes = Convert.ToDateTime(sFecha).Month;
        int iAño = Convert.ToDateTime(sFecha).Year;


        if (iDia < 16)
        {
            sMesProduccion[0] = iMes.ToString();
            sMesProduccion[1] = iAño.ToString();
            //sMesProduccion[2] = DateTimeFormatInfo Convert.ToDateTime(sFecha);
            //DateTimeFormatInfo myDTFI = new CultureInfo("es-ES", false).DateTimeFormat;
            sMesProduccion[2] = new CultureInfo("es-ES", false).DateTimeFormat.MonthNames[iMes - 1].ToUpper();
        }
        else
        {
            if (iMes + 1 > 12)
            {
                sMesProduccion[0] = "1";
                sMesProduccion[1] = (iAño + 1).ToString();
                sMesProduccion[2] = "ENERO";
            }
            else
            {
                sMesProduccion[0] = (iMes + 1).ToString();
                sMesProduccion[1] = iAño.ToString();
                sMesProduccion[2] = new CultureInfo("es-ES", false).DateTimeFormat.MonthNames[iMes].ToUpper();
            }


        }

        return sMesProduccion;
    }
    

    public static int Edad(DateTime fechaNacimiento)
    {
        
         TimeSpan z = DateTime.Now.Subtract(fechaNacimiento);
         return (z.Days / 365);
    }

    
}