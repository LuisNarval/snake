using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta función captura el teclado y cambia la dirección de la cabeza y sus secciones con base en ello. También incluye el efecto de espejo.
public class movimientoSnake : MonoBehaviour {

    public float velocidad = 8.0f;
    string direccion;
    
    tamanioSnake codigoTamanio;

    public bool jugadorVivo = false;



    //Inicializa variables
    void Awake()
    {
        direccion = "DERECHA";
        codigoTamanio = this.gameObject.GetComponent<tamanioSnake>();
    }

    //Comienza la corrutina para el movimiento. Esta función es llamada unicamente por ADMIN_JUEGO.cs
    public void comenzarMovimiento() {
        StartCoroutine(movimiento());
    }


    //Manda a llamar a la funcion capturarTeclas una vez por frame
    void Update()
    {
        if(jugadorVivo)
           capturarTeclas();
    }


    //Captura las teclas y modifica la dirección actual de movimiento
    void capturarTeclas()
    {
        if (direccion != "ABAJO" && Input.GetKeyDown(KeyCode.W))
            direccion = "ARRIBA";
        
        if (direccion != "DERECHA" && Input.GetKeyDown(KeyCode.A))
            direccion = "IZQUIERDA";
        
        if (direccion != "ARRIBA" && Input.GetKeyDown(KeyCode.S))
            direccion = "ABAJO";
           
        if (direccion != "IZQUIERDA" && Input.GetKeyDown(KeyCode.D))
            direccion = "DERECHA";

        if (Input.GetKeyDown(KeyCode.F))
            codigoTamanio.agregarSeccion();
    }


    //Regresa el Vector 3 correspondiente para la siguiente posicion
    public Vector3 obtenerVectorDireccion()
    {
        switch (direccion)
        {
            case "ARRIBA":
                return Vector3.up*codigoTamanio.separacionEntreSecciones;

            case "IZQUIERDA":
                return Vector3.left * codigoTamanio.separacionEntreSecciones;

            case "DERECHA":
                return Vector3.right * codigoTamanio.separacionEntreSecciones;

            case "ABAJO":
                return Vector3.down * codigoTamanio.separacionEntreSecciones;

            default:
                return new Vector3(0, 0, 0);
        }
    }



    //Esta corrutina nos permite que la serpiente se mueva solamente n veces por segundo, dependiendo de la velocidad asignada.
    IEnumerator movimiento()
    {
        while (jugadorVivo)
        {
            this.transform.position += obtenerVectorDireccion();

            rotarCabeza();
            moverCuerpoEntero();
            espejo(this.transform);

            yield return new WaitForSeconds(1 / velocidad);
        }
    }



    //Gira la cabeza para que coincida con la dirección adecuada.
    void rotarCabeza()
    {
        switch (direccion)
        {
            case "ARRIBA":
                this.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                break;

            case "IZQUIERDA":
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;

            case "DERECHA":
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;

            case "ABAJO":
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                break;

            default:
                break;
        }
    }



    //Hace que cada seccion de la serpiente se mueva a la dirección correcta de manera independiente.
    void moverCuerpoEntero()
    {
        for (int i = 1; i < codigoTamanio.serpiente.Count; i++)
        {
            seccionSnake instancia = codigoTamanio.serpiente[i].GetComponent<seccionSnake>();
            instancia.moverse();

            if (i > 1)
                instancia.direccionSiguiente = codigoTamanio.serpiente[i - 1].GetComponent<seccionSnake>().direccionActual;
            else
                instancia.direccionSiguiente = obtenerVectorDireccion();
        }
    }


   
    //Esta función hace el efecto del espejo, en cuanto toca una pared la cabeza aparece del lado opuesto
    void espejo(Transform ubicacion)
    {

        if (Mathf.Abs(ubicacion.position.x) > 9)
            ubicacion.position = new Vector3(ubicacion.position.x * -1, ubicacion.position.y, ubicacion.position.z) + obtenerVectorDireccion();

        if (Mathf.Abs(ubicacion.position.y) > 5)
            ubicacion.position = new Vector3(ubicacion.position.x, ubicacion.position.y * -1, ubicacion.position.z) + obtenerVectorDireccion();

    }

}