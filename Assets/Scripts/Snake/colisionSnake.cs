using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionSnake : MonoBehaviour {

    movimientoSnake codigoMovimiento;
    tamanioSnake codigoTamanio;
    manzana codigoManzana;
    HUD codigoHUD;

    public GameObject estrellas;

    // Use this for initialization
    void Start () {
        codigoMovimiento = this.gameObject.GetComponent<movimientoSnake>();
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
            estrellas.SetActive(true);
            codigoMovimiento.jugadorVivo = false;
            StartCoroutine(irAGameOver());

        }

    }


    IEnumerator irAGameOver() {
        yield return new WaitForSeconds(3);
        GameObject.Find("ADMIN_JUEGO").GetComponent<ADMIN_JUEGO>().jugadorMuerto();
    }

}
