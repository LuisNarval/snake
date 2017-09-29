using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Este código se encarga de verificar los puntos obtenidos después de cada partida y evaluar si se ha roto un nuevo record.
//Si se rompió un nuevo record, este código acomoda el nuevo valor en la posición que le correspondría dentre de los arreglos de MEJORESNOMBRES y MEJORESPUNTOS del GAMEMANAGER.
//Posteriormente actualiza los PlayerPref con base a estos arreglos.
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



    //Esta función es llamada por el administrador del juego y evalua si se ha roto un record.
    //Si se rompio un record se almacena en una variable la posición que fue ganada.
    //También, si se rompio un record, por medio de una animación se manda a llamar al Panel de Escribir Nombre
    //Si no se rompio un record, por medio de una animación manda a llamar al Panel del Sub Menu
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


    
    //Un boton dentro del panel de Escribir Nombre manda a llamar a esta función.
    //Se manda a llamar a la función de reacomodar las puntuaciones
    //Por medio de una animación se activa el Panel del Sub Menu
    public void asignarGanador() {
        string nombre= textoNombreGanador.text;

        reacomodarPuntuaciones(posicionGanada, nombre);

        
        seRompioRecord = false;
        textoNombreGanador.text = "Nombre . . .";

        finDelJuego.GetComponent<Animator>().SetTrigger("salirRecord");
        
    }



    //A partir de la posición ganadora que fue almacenada en una variable, se recorre de la posición ganada hasta abajo todos los valores.
    //Se guarda el nuevo nombre y puntuación en la posición correspondiente
    //Se actualizan los Player Pref con base a la nueva información almacenada en los arreglos del GAMEMANAGER
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
