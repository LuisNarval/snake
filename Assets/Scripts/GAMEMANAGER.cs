using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{

    public static GAMEMANAGER instancia;

    public static string DIFICULTAD;
    public static Color COLORSERPIENTE;

    public static string[] MEJORESNOMBRES;
    public static int[] MEJORESPUNTOS;

    [HideInInspector]
    public static string[] listaNombres;
    [HideInInspector]
    public static string[] listaPuntos;



    private void Awake()
    {
        hacerUnico();
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



    private void Start()
    {
        listaNombres = new string[] {"NOMBREUNO", "NOMBREDOS", "NOMBRETRES", "NOMBRECUATRO", "NOMBRECINCO", "NOMBRESEIS", "NOMBRESIETE", "NOMBREOCHO", "NOMBRENUEVE", "NOMBREDIEZ", };
        listaPuntos = new string[] { "PUNTOSUNO", "PUNTOSDOS", "PUNTOSTRES", "PUNTOSCUATRO", "PUNTOSCINCO", "PUNTOSSEIS", "PUNTOSSIETE", "PUNTOSOCHO", "PUNTOSNUEVE", "PUNTOSDIEZ", };

        inicializarValores();
        verificarSiEsPrimerJuego();
    }




    void inicializarValores() {

        DIFICULTAD = "NORMAL";
        COLORSERPIENTE = Color.green;

        MEJORESNOMBRES = new string[10];
        MEJORESPUNTOS = new int[10];

        
        for (int i=0; i<10; i++) {

            MEJORESNOMBRES[i] = PlayerPrefs.GetString(listaNombres[i]);
            MEJORESPUNTOS[i] = PlayerPrefs.GetInt(listaPuntos[i]); 

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


}