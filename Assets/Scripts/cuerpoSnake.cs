using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuerpoSnake : MonoBehaviour {

    public Vector3 direccionSiguiente;
    public Vector3 direccionActual;
    
    
    //Le dice a esta sección del cuerpo cual será su siguiente posición
    public void moverse() {
        direccionActual = direccionSiguiente;

        this.transform.position += direccionActual;
        espejo(this.transform);
    }

    
    //Esta función hace el efecto del espejo, en cuanto toca una pared esta sección del cuerpo aparece del lado opuesto
    void espejo(Transform ubicacion) {
        
        if (Mathf.Abs(ubicacion.position.x) > 9)
            ubicacion.position = new Vector3(ubicacion.position.x * -1, ubicacion.position.y, ubicacion.position.z)+direccionActual;

        if (Mathf.Abs(ubicacion.position.y) > 5)
            ubicacion.position = new Vector3(ubicacion.position.x, ubicacion.position.y * -1, ubicacion.position.z)+direccionActual;
        
    }

}