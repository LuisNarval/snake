using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*Este script se encarga de realizar las transiciones entre escenas y ejecutar la animacion de una cortinilla para que la transición sea más amena. Este código estará presente en todas las escenas
del juego.*/
public class FADER : MonoBehaviour
{

    public static FADER instancia;
    
    public GameObject cortina;
    public Animator animadorCortina;


    private void Awake()
    {
        hacerUnico();
    }


    //Esta funcion se encarga de que el Game Object que almacena a este script este presente en todas las escenas y no se repita.
    void hacerUnico()
    {
        if (instancia != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    //Esta corrutina se encarga de hacer la transicion de una escena a otra usando SceneManager.LoadScene y reproduciendo una animación de transición.
    private IEnumerator desvanecer(string escena)
    {

        cortina.SetActive(true);
        animadorCortina.Play("cortinaEntra");

        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(escena);
        animadorCortina.Play("cortinaSale");

        yield return new WaitForSeconds(1.0f);

        cortina.SetActive(false);

    }


    //Esta corrutina se encarga de cerrar el juego usando Application.Quit y reproduciendo una animación de transición.
    private IEnumerator apagarJuego()
    {
        cortina.SetActive(true);
        animadorCortina.Play("cortinaEntra");

        yield return new WaitForSeconds(0.7f);

        Application.Quit();
    }

    
    //Esta funcion existe para que un botón externo pueda acceder a ella y ejecute la corrutina de siguiente escena.
    public void siguienteEscena(string escena)
    {
        StartCoroutine(desvanecer(escena));
    }


    //Esta funcion existe para que un botón externo pueda acceder a ella y ejecute la corrutina de apagar el juego.
    public void salirDelJuego() {
        StartCoroutine(apagarJuego());
    }

}