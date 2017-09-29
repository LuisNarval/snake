using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{

    public static GAMEMANAGER instancia;
    
    public static string DIFICULTAD;
    public static string COLORSERPIENTE;

    public static string[] MEJORESNOMBRES;
    public static int[] MEJORESPUNTOS;


    public static string NOMBREUNO { get { return PlayerPrefs.GetString("NOMBREUNO"); } set { PlayerPrefs.SetString("NOMBREUNO", value); } }
    public static string NOMBREDOS { get { return PlayerPrefs.GetString("NOMBREDOS"); } set { PlayerPrefs.SetString("NOMBREDOS", value); } }
    public static string NOMBRETRES { get { return PlayerPrefs.GetString("NOMBRETRES"); } set { PlayerPrefs.SetString("NOMBRETRES", value); } }
    public static string NOMBRECUATRO { get { return PlayerPrefs.GetString("NOMBRECUATRO"); } set { PlayerPrefs.SetString("NOMBRECUATRO", value); } }
    public static string NOMBRECINCO { get { return PlayerPrefs.GetString("NOMBRECINCO"); } set { PlayerPrefs.SetString("NOMBRECINCO", value); } }
    public static string NOMBRESEIS { get { return PlayerPrefs.GetString("NOMBRESEIS"); } set { PlayerPrefs.SetString("NOMBRESEIS", value); } }
    public static string NOMBRESIETE { get { return PlayerPrefs.GetString("NOMBRESIETE"); } set { PlayerPrefs.SetString("NOMBRESIETE", value); } }
    public static string NOMBREOCHO { get { return PlayerPrefs.GetString("NOMBREOCHO"); } set { PlayerPrefs.SetString("NOMBREOCHO", value); } }
    public static string NOMBRENUEVE { get { return PlayerPrefs.GetString("NOMBRENUEVE"); } set { PlayerPrefs.SetString("NOMBRENUEVE", value); } }
    public static string NOMBREDIEZ { get { return PlayerPrefs.GetString("NOMBREDIEZ"); } set { PlayerPrefs.SetString("NOMBREDIEZ", value); } }

    public static int PUNTOSUNO { get { return PlayerPrefs.GetInt("PUNTOSUNO"); } set { PlayerPrefs.SetInt("PUNTOSUNO", value); } }
    public static int PUNTOSDOS { get { return PlayerPrefs.GetInt("PUNTOSDOS"); } set { PlayerPrefs.SetInt("PUNTOSDOS", value); } }
    public static int PUNTOSTRES { get { return PlayerPrefs.GetInt("PUNTOSTRES"); } set { PlayerPrefs.SetInt("PUNTOSTRES", value); } }
    public static int PUNTOSCUATRO { get { return PlayerPrefs.GetInt("PUNTOSCUATRO"); } set { PlayerPrefs.SetInt("PUNTOSCUATRO", value); } }
    public static int PUNTOSCINCO { get { return PlayerPrefs.GetInt("PUNTOSCINCO"); } set { PlayerPrefs.SetInt("PUNTOSCINCO", value); } }
    public static int PUNTOSSEIS { get { return PlayerPrefs.GetInt("PUNTOSSEIS"); } set { PlayerPrefs.SetInt("PUNTOSSEIS", value); } }
    public static int PUNTOSSIETE { get { return PlayerPrefs.GetInt("PUNTOSSIETE"); } set { PlayerPrefs.SetInt("PUNTOSSIETE", value); } }
    public static int PUNTOSOCHO { get { return PlayerPrefs.GetInt("PUNTOSOCHO"); } set { PlayerPrefs.SetInt("PUNTOSOCHO", value); } }
    public static int PUNTOSNUEVE { get { return PlayerPrefs.GetInt("PUNTOSNUEVE"); } set { PlayerPrefs.SetInt("PUNTOSNUEVE", value); } }
    public static int PUNTOSDIEZ { get { return PlayerPrefs.GetInt("PUNTOSDIEZ"); } set { PlayerPrefs.SetInt("PUNTOSDIEZ", value); } }




    private void Awake()
    {
        hacerUnico();

        DIFICULTAD = "NORMAL";
        COLORSERPIENTE = "GREEN";

        MEJORESNOMBRES = new string[] {NOMBREUNO, NOMBREDOS, NOMBRETRES, NOMBRECUATRO, NOMBRECINCO, NOMBRESEIS, NOMBRESIETE, NOMBREOCHO, NOMBRENUEVE, NOMBREDIEZ };
        MEJORESPUNTOS = new int[] {PUNTOSUNO, PUNTOSDOS, PUNTOSTRES, PUNTOSCUATRO, PUNTOSCINCO, PUNTOSSEIS, PUNTOSSIETE, PUNTOSOCHO, PUNTOSNUEVE, PUNTOSDIEZ };

        verificarSiEsPrimerJuego();
    }


    void hacerUnico()
    {
        if (instancia != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    void verificarSiEsPrimerJuego() {

        if (!PlayerPrefs.HasKey("SEHAJUGADOANTES"))
        {

            PlayerPrefs.SetInt("SEHAJUGADOANTES", 1);

            for (int i = 0; i < 10; i++) {
                MEJORESNOMBRES[i] = "--------------------------------------------";
            }

            for (int i = 0; i < 10; i++)
            {
                MEJORESPUNTOS[i] = 0;
            }

        }

    }










    void conseguirPlayerPrefs() {
        
        print(PlayerPrefs.GetString("NOMBREUNO"));

        print(PlayerPrefs.GetInt("PUNTOSUNO"));
    }








    


}
