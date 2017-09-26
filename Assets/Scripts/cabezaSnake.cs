﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabezaSnake : MonoBehaviour {

    public float velocidad = 4.0f;

    string direccion;
    

    List<GameObject> serpiente;
    public GameObject nuevoCuerpo;

    
    SpriteRenderer spriteCabeza;

    public Sprite cabezaArriba;
    public Sprite cabezaAbajo;
    public Sprite cabezaDerecha;
    public Sprite cabezaIzquierda;
    

    bool jugadorVivo = true;
    bool giroReciente = false;
    


    //Inicializa variables, instancia el cuerpo base y comienza la corrutina para el movimiento
    void Awake(){
        spriteCabeza = this.gameObject.GetComponent<SpriteRenderer>();
        crearCuerpo();
        StartCoroutine(movimiento());
    }
    


    //Crea la estructura básica de la serpiente, cabeza, cuerpo y cola. Agrega estas primeras secciones a una lista de GameObjects
    void crearCuerpo() {

        direccion = "DERECHA";
       
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

        if (direccion != "ABAJO" && Input.GetKeyDown(KeyCode.W)) {
            direccion = "ARRIBA";
            giroReciente = true;
        }
            
        if (direccion != "DERECHA" && Input.GetKeyDown(KeyCode.A)) {
            direccion = "IZQUIERDA";
            giroReciente = true;
        }
            
        if (direccion != "ARRIBA" && Input.GetKeyDown(KeyCode.S)) {
            direccion = "ABAJO";
            giroReciente = true;
        }
            
        if (direccion != "IZQUIERDA" && Input.GetKeyDown(KeyCode.D)) {
            direccion = "DERECHA";
            giroReciente = true;
        }
            

        if (Input.GetKeyDown(KeyCode.F))
            agregarSeccion();
    }

    
   //Asigna el Vector 3 correspondiente para la siguiente posicion
    public Vector3 obtenerDireccion(){
        switch (direccion){

            case "ARRIBA":
                return Vector3.up;
              
            case "IZQUIERDA":
                return Vector3.left;
                
            case "DERECHA":
                return Vector3.right;
             
            case "ABAJO":
                return Vector3.down;
              
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
            spriteCabeza.sprite = asignarCabeza();
            espejo(this.transform);
            moverCuerpoEntero();

            yield return new WaitForSeconds(1 / velocidad);
        }
    }

    //Asigna el sprite correcto para la posición de la cabeza
    Sprite asignarCabeza() {
        switch (direccion)
        {
            case "ARRIBA":
                return cabezaArriba;
            case "IZQUIERDA":
                return cabezaIzquierda;
            case "DERECHA":
                return cabezaDerecha;
            case "ABAJO":
                return cabezaAbajo;
            default:
                return cabezaDerecha;
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

    
    //Esta función hace el efecto del espejo, en cuanto toca una pared la cabeza aparece del lado opuesto
    void espejo(Transform ubicacion) {
        
        if (Mathf.Abs(ubicacion.position.x)>9)
            ubicacion.position=new Vector3 (ubicacion.position.x * -1, ubicacion.position.y, ubicacion.position.z)+obtenerDireccion();
        
        if (Mathf.Abs(ubicacion.position.y) > 5) 
            ubicacion.position = new Vector3(ubicacion.position.x, ubicacion.position.y * -1, ubicacion.position.z)+obtenerDireccion();

    }

}