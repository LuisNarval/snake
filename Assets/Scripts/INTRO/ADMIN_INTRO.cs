using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Este script sirve para Administrar la escena de Intro. Como es una escena muy sencilla, este script solamente tiene una función*/
public class ADMIN_INTRO : MonoBehaviour {

    //Esta función existe para que la animación del Intro acceda a ella y pueda decirle al Fader que comience la corrutina de siguiente escena con dirección al Menu.
    public void irAMenu() {
        FADER.instancia.siguienteEscena("Menu");
    }


}
