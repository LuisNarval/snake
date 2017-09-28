using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADMIN_JUEGO : MonoBehaviour {

    public GameObject snake;
    public GameObject manzana;

    GameObject instanciaSnake;

    public HUD hud;

    public GameObject instrucciones;
    public GameObject cuentaRegresiva;
    public GameObject finDelJuego;

    Animator panelesGameOver;


    public Text puntosResultado;
    public Text puntosNuevoRecord;

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

        StartCoroutine(conteoRegresivo(1.0f));
    }


    IEnumerator conteoRegresivo(float tiempo) {
        yield return new WaitForSeconds(tiempo);
        instrucciones.SetActive(false);
        finDelJuego.SetActive(false);

        cuentaRegresiva.SetActive(true);
        cuentaRegresiva.GetComponent<Animator>().Play("mostrarDificultad");


        yield return new WaitForSeconds(8.5f);
        manzana.GetComponent<manzana>().cambiarPosicion();
        instanciaSnake.GetComponent<movimientoSnake>().jugadorVivo=true;
        instanciaSnake.GetComponent<movimientoSnake>().comenzarMovimiento();

        yield return new WaitForSeconds(1.5f);
        cuentaRegresiva.SetActive(false);
    }



    public void jugadorMuerto() {
        puntosResultado.text = hud.puntos.ToString();
        puntosNuevoRecord.text = hud.puntos.ToString();

        finDelJuego.SetActive(true);
        finDelJuego.GetComponent<Animator>().SetBool("irARecord",true);
    }


    public void guardarRecord() {
        finDelJuego.GetComponent<Animator>().SetTrigger("salirRecord");
    }


    //Inicializa los puntos a cero, la manzana a su posicion original, destruye la serpiente actual junto a todas sus secciones, desvanece el submenu y comienza la corrutina de conteo regresivo
    public void volverAJugar() {

        manzana.transform.position = new Vector3(-8.5f,5.5f,2);
        hud.puntos = 0;
        hud.actualizarPuntos();
        
        for (int i=1; i< instanciaSnake.GetComponent<tamanioSnake>().serpiente.Count; i++) {
            Destroy(instanciaSnake.GetComponent<tamanioSnake>().serpiente[i].gameObject);
        }
        
        Destroy(instanciaSnake.gameObject);
        instanciaSnake = Instantiate(snake, snake.transform.position, snake.transform.rotation);


        finDelJuego.GetComponent<Animator>().SetTrigger("salirSubMenu");        
        StartCoroutine(conteoRegresivo(1.5f));
    }

}