using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script tiene la responsabilidad de detectar todas las colisiones que tenga la serpiente con su entorno y realizar un acción dependiendo del objeto con el que haya chocado.
public class colisionSnake : MonoBehaviour {

    movimientoSnake codigoMovimiento;
    tamanioSnake codigoTamanio;
    manzana codigoManzana;
    HUD codigoHUD;

    public GameObject estrellas;

    // Inicializa las variables
    void Start () {
        codigoMovimiento = this.gameObject.GetComponent<movimientoSnake>();
        codigoTamanio = this.gameObject.GetComponent<tamanioSnake>();
        codigoManzana = GameObject.Find("Manzana").GetComponent<manzana>();
        codigoHUD = GameObject.Find("HUD").GetComponent<HUD>();
    }


    //Esta función es la que detecta las colisiones
    //Si colisiono con una manzana, aumenta los puntos del HUD, mueve la manzana a otra posición y hace que la serpiente incremente de tamaño.
    //Si colisiona con una pared o una seccion del propio cuerpo de la serpiente, detiene el movimiento del jugador y manda a llamar a la corrutina de irAGameOver.
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

    //Esta corrutina espera dos segundos para que se puedan ver las "Estrellitas" en la cabeza de la serpiente después del choque.
    //Trás esperar 2 segundos, invocando a la funcion jugadorMuerto() para avisar al administrador del juego que el jugador ha perdido.
    IEnumerator irAGameOver() {
        yield return new WaitForSeconds(2);
        GameObject.Find("ADMIN_JUEGO").GetComponent<ADMIN_JUEGO>().jugadorMuerto();
    }

}
