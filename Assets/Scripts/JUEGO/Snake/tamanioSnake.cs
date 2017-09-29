using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script es el responsable de almacenar a la cabeza y todas sus secciones en una lista. 
//Tiene dos objetivos principales. La primera es crear el cuerpo base para la serpiente consistente de una cabeza y dos secciones.  
//La segunda es agregar una sección más a la serpiente, instanciando el GameObject y agregandolo a la lista.

public class tamanioSnake : MonoBehaviour {
    

    public List<GameObject> serpiente;
    public GameObject nuevoCuerpo;

    public float separacionEntreSecciones=0.5f;

    movimientoSnake codigoMovimiento;
    

    //Inicializa variables, instancia el cuerpo base y comienza la corrutina para el movimiento
    void Start()
    {
        codigoMovimiento = this.GetComponent<movimientoSnake>();
        this.gameObject.GetComponent<SpriteRenderer>().color = GAMEMANAGER.COLORSERPIENTE;
        crearCuerpo();
    }



    //Crea la estructura básica de la serpiente, cabeza, cuerpo y cola. Agrega estas primeras secciones a una lista de GameObjects
    void crearCuerpo()
    {
        serpiente = new List<GameObject>();
        serpiente.Add(this.gameObject);

        for (int i = 0; i < 2; i++)
        {
            GameObject instancia = Instantiate(nuevoCuerpo, new Vector3(serpiente[i].transform.position.x - separacionEntreSecciones, this.transform.position.y, this.transform.position.z+1), this.transform.rotation);
            serpiente.Add(instancia);
            instancia.GetComponent<seccionSnake>().direccionSiguiente = codigoMovimiento.obtenerVectorDireccion();

            instancia.GetComponent<SpriteRenderer>().color = GAMEMANAGER.COLORSERPIENTE;
        }
        
    }



    //Agrega una nueva seccion a la serpiente y a la lista de GameObjects
    //Esta función esta pensada para ejecutarse cada vez que colisionSnake.cs detecte una colisión de la serpiente con la manzana.
    public void agregarSeccion()
    {       
        GameObject instancia = Instantiate(nuevoCuerpo, serpiente[serpiente.Count - 1].GetComponent<Transform>().position, serpiente[serpiente.Count - 1].GetComponent<Transform>().rotation) as GameObject;
        serpiente.Add(instancia);

        instancia.GetComponent<seccionSnake>().direccionSiguiente = serpiente[serpiente.Count - 1].GetComponent<seccionSnake>().direccionActual;

        instancia.GetComponent<SpriteRenderer>().color = GAMEMANAGER.COLORSERPIENTE;
    }


  


}
