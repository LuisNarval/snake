using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manzana : MonoBehaviour {
    
    public void cambiarPosicion() {

        float X = Random.Range(-18.0f,18.0f);
        float Y = Random.Range(-10.0f, 10.0f);


        int posicionX = (int)X;
        int posicionY = (int)Y;

        this.transform.position = new Vector3(posicionX*0.5f, posicionY*0.5f, 2);

    }
    
    public void OnCollisionEnter(Collision invasor)
    {
        if (invasor.gameObject.tag == "Seccion") {
            cambiarPosicion();
        }
    }
    
}