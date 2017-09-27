using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionSnake : MonoBehaviour {


    tamanioSnake codigoTamanio;
    manzana codigoManzana;
    HUD codigoHUD;

    // Use this for initialization
    void Start () {
        codigoTamanio = this.gameObject.GetComponent<tamanioSnake>();
        codigoManzana = GameObject.Find("Manzana").GetComponent<manzana>();
        codigoHUD = GameObject.Find("HUD").GetComponent<HUD>();
    }



    void OnCollisionEnter2D(Collision2D invasor) {

        if (invasor.gameObject.tag == "Manzana") {
            codigoTamanio.agregarSeccion();
            codigoManzana.cambiarPosicion();
            codigoHUD.incrementaPuntos();
        }

        if (invasor.gameObject.tag == "Seccion")
        {
            print("Has Muerto");
        }
    }

}
