using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Este script se encuentra dentro de cada uno de los prefabs correspondientes a las secciones de la serpiente. Su principal objetivo es seguir todos los movimientos que haga la cabeza 
en un respectivo orden.*/

public class seccionSnake : MonoBehaviour {

    public Vector3 direccionSiguiente;
    public Vector3 direccionActual;

    //Esta funcion es mandada a llamar por movimientoSnake.cs y le dice a esta sección del cuerpo cual será su siguiente posición
    public void moverse()
    {
        direccionActual = direccionSiguiente;

        this.transform.position += direccionActual;
        espejo(this.transform);
    }



    //Esta función hace el efecto del espejo, en cuanto toca una pared esta sección del cuerpo aparece del lado opuesto
    void espejo(Transform ubicacion)
    {

        if (Mathf.Abs(ubicacion.position.x) > 9)
            ubicacion.position = new Vector3(ubicacion.position.x * -1, ubicacion.position.y, ubicacion.position.z) + direccionActual;

        if (Mathf.Abs(ubicacion.position.y) > 5)
            ubicacion.position = new Vector3(ubicacion.position.x, ubicacion.position.y * -1, ubicacion.position.z) + direccionActual;

    }

    
}
