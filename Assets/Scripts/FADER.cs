using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FADER : MonoBehaviour
{

    public static FADER instancia;
    
    public GameObject cortina;
    public Animator animadorCortina;


    private void Awake()
    {
        hacerUnico();
    }


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

    private IEnumerator apagarJuego()
    {
        cortina.SetActive(true);
        animadorCortina.Play("cortinaEntra");

        yield return new WaitForSeconds(0.7f);

        Application.Quit();
    }

    

    public void siguienteEscena(string escena)
    {
        StartCoroutine(desvanecer(escena));
    }


    public void salirDelJuego() {
        StartCoroutine(apagarJuego());
    }

}