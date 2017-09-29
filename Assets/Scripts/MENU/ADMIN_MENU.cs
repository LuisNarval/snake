using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Este script es el administrador de la escena de Menu. Su principal función es llevar a cabo la transición entre distintas ventanas.
public class ADMIN_MENU : MonoBehaviour {

    public Animator animadorMenu;
    public Text textoDificultad;
   
    public tablaPuntuaciones tabla;

    public string dificultad {
        get {
            return GAMEMANAGER.DIFICULTAD;
        }

        set {
            GAMEMANAGER.DIFICULTAD=value;
        }
    }


    private void Start()
    {
        asignarDificultad(dificultad);
    }


    //Esta función existe para que un botón acceda a ella y aparezca la opción de seleccionar color, para posteriormente ir al juego.
    public void irAJuego()
    {
        animadorMenu.Play("irAJuego");
    }


    //Cuando el jugador da aceptar en el panel de seleccionar color, se llama al Fader para ir a la escena del Juego.
    public void seleccionarColor() {
        FADER.instancia.siguienteEscena("Juego");
    }
    


    //Un botón accede a esta función para que por medio de una animación se muestre el panel de Elegir Dificultad.
    public void irADificultad()
    {
        animadorMenu.SetTrigger("irADificultad");
    }


    //Un botón accede a esta función para que por medio de una animación se muestre el panel de Ver Puntuaciones.
    public void irAPuntuaciones()
    {
        tabla.colocarTabla();
        animadorMenu.SetTrigger("irAPuntuaciones");
    }


    //Un botón accede a esta función para que por medio de una animación se cierre el panel de Elegir Dificultad.
    public void salirDificultad()
    {
        animadorMenu.SetTrigger("salirDificultad");
    }


    //Un botón accede a esta función para que por medio de una animación se cierre el panel de Ver Puntuaciones.
    public void salirPuntuaciones()
    {
        animadorMenu.SetTrigger("salirPuntuaciones");
    }


    //Un botón accede a esta función para decirle al Fader que cierre el juego
    public void salir()
    {
        FADER.instancia.salirDelJuego();
    }


    ////Un botón desde el panel de seleccionar dificultad accede a esta función y actualiza el valor de la dificultad, tanto en este script como en el GAMEMANAGER.cs
    public void asignarDificultad(string valor){
        dificultad = valor;
        textoDificultad.text = dificultad;
    }


    
}
