using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADMIN_MENU : MonoBehaviour {

    public Animator animadorMenu;

    // Use this for initialization
    void Start () {}
    
    // Update is called once per frame
    void Update () {}

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


}
