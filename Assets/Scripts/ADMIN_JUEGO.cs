using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADMIN_JUEGO : MonoBehaviour {

    public GameObject snake;
    public GameObject manzana;

    GameObject instanciaSnake;

    public GameObject instrucciones;
    public GameObject cuentaRegresiva;

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
        cuentaRegresiva.SetActive(true);

        yield return new WaitForSeconds(8.5f);
        manzana.GetComponent<manzana>().cambiarPosicion();
        instanciaSnake.GetComponent<movimientoSnake>().jugadorVivo=true;
        instanciaSnake.GetComponent<movimientoSnake>().comenzarMovimiento();

        yield return new WaitForSeconds(1.5f);
        cuentaRegresiva.SetActive(false);
    }




}