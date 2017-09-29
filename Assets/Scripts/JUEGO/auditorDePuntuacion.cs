using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class auditorDePuntuacion : MonoBehaviour {

    int puntos;

    public ADMIN_JUEGO administrador;
    public GameObject finDelJuego;
    public Text textoNombreGanador;

    int posicionGanada;

    [HideInInspector]
    public bool seRompioRecord = false;

    [HideInInspector]
    public string nombreGanador;

    

    public void buscarNuevoRecord() {

        puntos = this.GetComponent<HUD>().puntos;

        for (int i=0; i<10; i++) {
            if (puntos > GAMEMANAGER.MEJORESPUNTOS[i]) {
                posicionGanada = i;
                seRompioRecord = true;
                break;
            }
        }



        finDelJuego.SetActive(true);

        if (seRompioRecord)
        {
            finDelJuego.GetComponent<Animator>().SetBool("irARecord", true);
        }
        else
        {
            finDelJuego.GetComponent<Animator>().SetBool("irARecord", false);
        }
        
    }


    

    public void asignarGanador() {
        string nombre= textoNombreGanador.text;

        reacomodarPuntuaciones(posicionGanada, nombre);

        
        seRompioRecord = false;
        textoNombreGanador.text = "Nombre . . .";

        finDelJuego.GetComponent<Animator>().SetTrigger("salirRecord");
        
    }




    void reacomodarPuntuaciones(int j, string nuevoNombre) {

        for (int i=9; i > j ; i--) {
            GAMEMANAGER.MEJORESNOMBRES[i] = GAMEMANAGER.MEJORESNOMBRES[i - 1];
            GAMEMANAGER.MEJORESPUNTOS[i] = GAMEMANAGER.MEJORESPUNTOS[i - 1]; 
        }

        GAMEMANAGER.MEJORESNOMBRES[j] = nuevoNombre;
        GAMEMANAGER.MEJORESPUNTOS[j] = puntos;

        for (int i = 0; i < 10; i++) {

            PlayerPrefs.SetString(GAMEMANAGER.listaNombres[i], GAMEMANAGER.MEJORESNOMBRES[i]);
            PlayerPrefs.SetInt(GAMEMANAGER.listaPuntos[i], GAMEMANAGER.MEJORESPUNTOS[i]);
        }
    
    }


}
