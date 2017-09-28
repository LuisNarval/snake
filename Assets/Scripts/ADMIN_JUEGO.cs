using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADMIN_JUEGO : MonoBehaviour {

    public GameObject snake;
    public GameObject manzana;

    GameObject instanciaSnake;

    public HUD hud;

    public GameObject instrucciones;
    public GameObject cuentaRegresiva;
    public GameObject finDelJuego;

    Animator panelesGameOver;


    // Use this for initialization
    void Start () {
        instrucciones.SetActive(true);
    }
    
    // Update is called once per frame
    void Update () {
        
    }


    public void iniciarElJuego() {
        instanciaSnake=Instantiate(snake,snake.transform.position,snake.transform.rotation) as GameObject;
        instrucciones.GetComponent<Animator>().Play("salida_instrucciones");

        StartCoroutine(conteoRegresivo());
    }


    IEnumerator conteoRegresivo() {
        yield return new WaitForSeconds(1.0f);
        instrucciones.SetActive(false);
        finDelJuego.SetActive(false);
        cuentaRegresiva.SetActive(true);

        yield return new WaitForSeconds(8.5f);
        manzana.GetComponent<manzana>().cambiarPosicion();
        instanciaSnake.GetComponent<movimientoSnake>().jugadorVivo=true;
        instanciaSnake.GetComponent<movimientoSnake>().comenzarMovimiento();

        yield return new WaitForSeconds(1.5f);
        cuentaRegresiva.SetActive(false);
    }



    public void jugadorMuerto() {

        finDelJuego.SetActive(true);
        finDelJuego.GetComponent<Animator>().SetBool("irARecord",false);


    }


    public void guardarRecord() {

    }


    public void volverAJugar() {
        Destroy(instanciaSnake.gameObject);
        instanciaSnake = Instantiate(snake,snake.transform.position,snake.transform.rotation);
        hud.puntos = 0;
        hud.actualizarPuntos();
        finDelJuego.GetComponent<Animator>().SetTrigger("salirSubMenu");
        StartCoroutine(conteoRegresivo());
    }

}