using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabezaSnake : MonoBehaviour {

    public string direccion;
    public Vector3 siguientePosicion;

    public float velocidad = 4.0f;


    public List<GameObject> serpiente;
    public GameObject nuevoCuerpo;


    public bool jugadorVivo = true;


    //En cuanto el juego inicia se crea el cuerpo de la serpiente y enseguida comienza la corrutina para el movimiento
    void Awake(){
        crearCuerpo();
        StartCoroutine(movimiento());
    }
    


    //Crea la estructura básica de la serpiente, cabeza, cuerpo y cola. Agrega estas primeras secciones a una lista de GameObjects
    void crearCuerpo() {

        direccion = "DERECHA";
        siguientePosicion = obtenerDireccion();

        serpiente = new List<GameObject>();
        serpiente.Add(this.gameObject);

        for (int i=0;i<2;i++) {
            GameObject instancia = Instantiate(nuevoCuerpo, new Vector3(serpiente[i].transform.position.x- 1, this.transform.position.y,this.transform.position.z), this.transform.rotation);
            serpiente.Add(instancia);
            instancia.GetComponent<cuerpoSnake>().direccionSiguiente = obtenerDireccion();
        }
        
    }
    


    //Se ejecuta una vez cada frame
    void Update(){
        capturarTeclas();
    }


    //Captura las teclas y modifica la dirección actual de movimiento
    void capturarTeclas(){
        if (direccion != "ABAJO" && Input.GetKeyDown(KeyCode.W))
            direccion = "ARRIBA";
         
        if (direccion != "DERECHA" && Input.GetKeyDown(KeyCode.A))
            direccion = "IZQUIERDA";
          
        if (direccion != "ARRIBA" && Input.GetKeyDown(KeyCode.S))
            direccion = "ABAJO";

        if (direccion != "IZQUIERDA" && Input.GetKeyDown(KeyCode.D))
            direccion = "DERECHA";

        if (Input.GetKeyDown(KeyCode.F))
            agregarSeccion();
    }

    
   //Asigna el Vector 3 correspondiente para la siguiente posicion
    public Vector3 obtenerDireccion(){
        switch (direccion){

            case "ARRIBA":
                return siguientePosicion = Vector3.up;
              
            case "IZQUIERDA":
                return siguientePosicion = Vector3.left;
                
            case "DERECHA":
                return siguientePosicion = Vector3.right;
             
            case "ABAJO":
                return siguientePosicion = Vector3.down;
              
            default:
                return new Vector3(0,0,0);
        }

    }



    //Esta corrutina nos permite que la serpiente se mueva solamente n veces por segundo, dependiendo de la velocidad asignada.
    IEnumerator movimiento()
    {
        while (jugadorVivo)
        {
            this.transform.position += obtenerDireccion();
            moverCuerpoEntero();

            yield return new WaitForSeconds(1 / velocidad);
        }
    }





    //Hace que cada seccion de la serpiente se mueva a la dirección correcta de manera independiente.
    void moverCuerpoEntero()
    {
        for (int i = 1; i < serpiente.Count; i++)
        {
            cuerpoSnake instancia = serpiente[i].GetComponent<cuerpoSnake>();
            instancia.moverse();

            if (i > 1)
                instancia.direccionSiguiente = serpiente[i - 1].GetComponent<cuerpoSnake>().direccionActual;
            else
                instancia.direccionSiguiente = obtenerDireccion();
        }
    }




    //Agrega una nueva seccion a la serpiente y a la lista de GameObjects
    public void agregarSeccion()
    {
        GameObject instancia = Instantiate(nuevoCuerpo, serpiente[serpiente.Count - 1].GetComponent<Transform>().position, serpiente[serpiente.Count - 1].GetComponent<Transform>().rotation) as GameObject;
        serpiente.Add(instancia);

        instancia.GetComponent<cuerpoSnake>().direccionSiguiente = serpiente[serpiente.Count - 1].GetComponent<cuerpoSnake>().direccionActual;

        print(serpiente.Count);
    }

}