using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    public void irAJuego()
    {
        FADER.instancia.siguienteEscena("Juego");
    }
    
    public void irADificultad()
    {
        animadorMenu.SetTrigger("irADificultad");
    }

    public void irAPuntuaciones()
    {
        tabla.colocarTabla();
        animadorMenu.SetTrigger("irAPuntuaciones");
    }

    public void salirDificultad()
    {
        animadorMenu.SetTrigger("salirDificultad");
    }

    public void salirPuntuaciones()
    {
        animadorMenu.SetTrigger("salirPuntuaciones");
    }

    public void salir()
    {
        FADER.instancia.salirDelJuego();
    }



    public void asignarDificultad(string valor){
        dificultad = valor;
        textoDificultad.text = dificultad;
    }


    
}
