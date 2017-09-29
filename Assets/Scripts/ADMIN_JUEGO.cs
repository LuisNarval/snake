using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADMIN_JUEGO : MonoBehaviour {

    public GameObject snake;
    public GameObject manzana;

    GameObject instanciaSnake;

    public HUD hud;

    public GameObject paredes;

    public GameObject instrucciones;
    public GameObject cuentaRegresiva;
    public GameObject finDelJuego;

    Animator panelesGameOver;

    public Text textoDificultad_cuentaRegresiva;
    public Text textoDificultad_subMenu;


    public Text puntosResultado;
    public Text puntosNuevoRecord;


    public string dificultad
    {
        get
        {
            return GAMEMANAGER.DIFICULTAD;
        }

        set
        {
            GAMEMANAGER.DIFICULTAD = value;
        }
    }






    // Use this for initialization
    void Start () {
        asignarDificultad(dificultad);
        instrucciones.SetActive(true);
    }
    
   
    public void iniciarElJuego() {
        instanciaSnake=Instantiate(snake,snake.transform.position,snake.transform.rotation) as GameObject;
        instrucciones.GetComponent<Animator>().Play("salida_instrucciones");

        colocarParedes();
        StartCoroutine(conteoRegresivo(1.0f));
    }


    IEnumerator conteoRegresivo(float tiempo) {
        yield return new WaitForSeconds(tiempo);

        textoDificultad_cuentaRegresiva.text = dificultad;

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


    public void colocarParedes() {
        if (dificultad == "DIFICIL")
        {
            paredes.SetActive(true);
            paredes.GetComponent<Animator>().Play("cerrrarParedes");

            manzana.GetComponent<manzana>().rangoEnX = 16.0f;
            manzana.GetComponent<manzana>().rangoEnY = 8.0f;

        }
        else
        {
            manzana.GetComponent<manzana>().rangoEnX = 18.0f;
            manzana.GetComponent<manzana>().rangoEnY = 10.0f;

            paredes.SetActive(false);
        }
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
    
    public void irAMenuDificultad() {
        finDelJuego.GetComponent<Animator>().SetTrigger("irADificultad");
    }

    public void asignarDificultad(string valor)
    {
        dificultad = valor;
        textoDificultad_subMenu.text = dificultad;
    }


    public void salirDeMenuDificultad() {
        finDelJuego.GetComponent<Animator>().SetTrigger("salirDificultad");
    }






    //Inicializa los puntos a cero, la manzana a su posicion original, destruye la serpiente actual junto a todas sus secciones, desvanece el submenu y comienza la corrutina de conteo regresivo
    public void volverAJugar() {

        manzana.transform.position = new Vector3(-8.5f,7.5f,2);
        hud.puntos = 0;
        hud.actualizarPuntos();
        
        for (int i=1; i< instanciaSnake.GetComponent<tamanioSnake>().serpiente.Count; i++) {
            Destroy(instanciaSnake.GetComponent<tamanioSnake>().serpiente[i].gameObject);
        }
        
        Destroy(instanciaSnake.gameObject);
        instanciaSnake = Instantiate(snake, snake.transform.position, snake.transform.rotation);


        finDelJuego.GetComponent<Animator>().SetTrigger("salirSubMenu");
        colocarParedes();
        StartCoroutine(conteoRegresivo(1.5f));
    }



    public void regresarAlMenu() {
        FADER.instancia.siguienteEscena("Menu");
    }
}