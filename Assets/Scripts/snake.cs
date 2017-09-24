using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour {

    public float velocidad = 1.0f;
    
    public string direccion;

    
    public Vector3 siguientePosicion;


    public bool jugadorVivo = true;



    // Use this for initialization
    void Awake () {
        direccion = "DERECHA";
        actualizarDireccion();
        StartCoroutine(movimiento());
    }
    
    // Update is called once per frame
    void Update () {
        capturarTeclas();
        
        
    }




    void capturarTeclas() {

        if (direccion!="ABAJO"&&Input.GetKeyDown(KeyCode.W)) {
            direccion = "ARRIBA";
            actualizarDireccion();
        }

        if (direccion!="DERECHA"&&Input.GetKeyDown(KeyCode.A)){
            direccion = "IZQUIERDA";
            actualizarDireccion();
        }

        if (direccion!="ARRIBA" && Input.GetKeyDown(KeyCode.S)){
            direccion = "ABAJO";
            actualizarDireccion();
        }

        if (direccion!="IZQUIERDA" && Input.GetKeyDown(KeyCode.D)){
            direccion = "DERECHA";
            actualizarDireccion();
        }

    }




    IEnumerator movimiento(){

        while (jugadorVivo) {
            this.transform.position += siguientePosicion;
            yield return new WaitForSeconds(1/velocidad);
        }
    
    }


    void actualizarDireccion(){

        switch (direccion)
        {

            case "ARRIBA":
                siguientePosicion = Vector3.up;
                break;

            case "IZQUIERDA":
                siguientePosicion = Vector3.left;
                break;

            case "DERECHA":
                siguientePosicion = Vector3.right;
                break;

            case "ABAJO":
                siguientePosicion = Vector3.down;
                break;

        }

    }







}
