using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuerpoSnake : MonoBehaviour {

    public Vector3 direccionSiguiente;
    public Vector3 direccionActual;
    
    // Update is called once per frame
    void Update(){}

    public void moverse() {
        direccionActual = direccionSiguiente;
        this.transform.position += direccionActual;
    }

}