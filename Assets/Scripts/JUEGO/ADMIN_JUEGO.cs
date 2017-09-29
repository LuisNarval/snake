using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Este script es el administrador de la escena del Juego. Su función principal es hacer la transición entre las pantallas y momentos del juego.
//Pasa por estos puntos: Instrucciones, Mostrar Dificultad, Conteo Regresivo, Juego, Resultado, Escribir Nombre, Sub Menu.
//Del Sub Menu puede elegir salir de la aplicaión, cambiar dificultad, cambiar color y volver a jugar. Lo cual cerraria el ciclo omitiendo unicamente las instrucciones.
public class ADMIN_JUEGO : MonoBehaviour {

    public GameObject snake;
    public GameObject manzana;

    GameObject instanciaSnake;

    public HUD hud;
    public auditorDePuntuacion auditor;

    public GameObject paredes;

    public GameObject instrucciones;
    public GameObject cuentaRegresiva;
    public GameObject finDelJuego;

    Animator panelesGameOver;

    public Text textoDificultad_cuentaRegresiva;
    public Text textoDificultad_subMenu;


    public Text puntosResultado;
    public Text puntosNuevoRecord;

    
    [HideInInspector]
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


    
    //Inicializa la variable dificultad y activa el panel de instrucciones.
    void Start () {
        asignarDificultad(dificultad);
        instrucciones.SetActive(true);
    }
    
   
    //Esta función es activada desde un botón en las instrucciones. Instancia al jugador, verifica las paredes y comienza la corrutina de cuenta regresiva.
    public void iniciarElJuego() {
        instanciaSnake=Instantiate(snake,snake.transform.position,snake.transform.rotation) as GameObject;
        instrucciones.GetComponent<Animator>().Play("salida_instrucciones");

        colocarParedes();
        StartCoroutine(conteoRegresivo(1.0f));
    }


    //Esta corrutina muestra una animación de cuenta regresiva y una vez que termina activa el movimiento del jugador y hace que la manzana realice su primer cambio de posición.
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



    //Esta función verifica si se deben colocar las paredes alrededor de la pantalla dependiendo de la dificultad asignada.
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




    //Esta función es mandada a llamar por la Colision de la Serpiente y se ejecuta una vez que el jugador pierde.
    //Asigna a dos campos dentro de los paneles la cantidad de puntos conseguidos durante el juego.
    //Le dice al Auditor que verifique si se ha roto un nuevo record.
    public void jugadorMuerto() {
        
        puntosResultado.text = hud.puntos.ToString();
        puntosNuevoRecord.text = hud.puntos.ToString();

        auditor.buscarNuevoRecord();
        
    }





    //Un botón accede a esta función para que por medio de una animación se abrá el panel de Elegir Dificultad.
    public void irAMenuDificultad() {
        finDelJuego.GetComponent<Animator>().SetTrigger("irADificultad");
    }

    //Un botón accede a esta función para que se guarde un nuevo valor elegido por el usuario para la dificultad.
    public void asignarDificultad(string valor)
    {
        dificultad = valor;
        textoDificultad_subMenu.text = dificultad;
    }

    //Un botón accede a esta función para que por medio de una animación se cierre el panel de Elegir Dificultad.
    public void salirDeMenuDificultad() {
        finDelJuego.GetComponent<Animator>().SetTrigger("salirDificultad");
    }


    //Un botón accede a esta función para que por medio de una animación se abrá el panel de Elegir Color.
    public void irAColor() {
        finDelJuego.GetComponent<Animator>().SetTrigger("irAColor");

    }

    //Un botón accede a esta función para que por medio de una animación se cierre el panel de Elegir Color.
    public void salirDeColor() {
        finDelJuego.GetComponent<Animator>().SetTrigger("salirDeColor");
    }


    //Un botón accede a esta función para que el Fader nos regrese a la escena del Menu.
    public void regresarAlMenu()
    {
        FADER.instancia.siguienteEscena("Menu");
    }




    //Un botón accede a esta función para poder volver a jugar.
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
    
}