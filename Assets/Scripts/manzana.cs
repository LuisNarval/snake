using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manzana : MonoBehaviour {

    public float rangoEnX = 18.0f;
    public float rangoEnY = 10.0f;


    public void cambiarPosicion() {

        float X = Random.Range(-rangoEnX,rangoEnX);
        float Y = Random.Range(-rangoEnY, rangoEnY);


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