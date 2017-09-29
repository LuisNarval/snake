using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*Este script es el Administrador de todo el juego, se encuentra presente en todas las escenas. Su función primordial es almacenar los arreglos que contienen la lista de los 10 mayores puntajes junto
a sus respectivos nombres, y los vincula con un PlayerPref.*/

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



    //Esta funcion se encarga de que el Game Object que almacena a este script este presente en todas las escenas y no se repita.
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



    /*Guarda los nombres de los PlayerPrefs que estaremos llamando en dos arreglos. Manda a llamar a la funcion que inicializa el resto de variables y a la funcion que verifica si es la primera vez
    que se esta jugando.*/
    private void Start()
    {
        listaNombres = new string[] {"NOMBREUNO", "NOMBREDOS", "NOMBRETRES", "NOMBRECUATRO", "NOMBRECINCO", "NOMBRESEIS", "NOMBRESIETE", "NOMBREOCHO", "NOMBRENUEVE", "NOMBREDIEZ", };
        listaPuntos = new string[] { "PUNTOSUNO", "PUNTOSDOS", "PUNTOSTRES", "PUNTOSCUATRO", "PUNTOSCINCO", "PUNTOSSEIS", "PUNTOSSIETE", "PUNTOSOCHO", "PUNTOSNUEVE", "PUNTOSDIEZ", };

        inicializarValores();
        verificarSiEsPrimerJuego();
    }



    //Asigna un valor por default a la dificultad del juego y al color del personaje. Guarda todos los valores almacenas en los PlayerPref en dos arreglos para su posterior consulta.
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



    //Si es la primera vez que se juega los PlayerPref estaran vacios. Esta funcion verifica si no existen valores para los PlayerPref y de ser así, les asigna unos valores predeterminados.
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