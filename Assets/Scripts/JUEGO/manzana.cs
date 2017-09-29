using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script se ubica en el Game Object de la manza y su principal objetivo es realizar los cambios de posición.
public class manzana : MonoBehaviour {

    public float rangoEnX = 18.0f;
    public float rangoEnY = 10.0f;


    //Esta funcion realiza un Random con base a un valor mínimo y máximo sobre X y Y, con lo cual cambia de posición aleatoriamente dentro del escenario.
    //Este rango cambia dependiendo de la dificultad, si hay paredes en las orillas o no. El rango es proporcionado por el administrador del juego.
    //Esta función esta pensada para ejecutarse cada vez que colisionSnake.cs detecte una colisión de la serpiente con la manzana.
    public void cambiarPosicion() {

        float X = Random.Range(-rangoEnX,rangoEnX);
        float Y = Random.Range(-rangoEnY, rangoEnY);


        int posicionX = (int)X;
        int posicionY = (int)Y;

        this.transform.position = new Vector3(posicionX*0.5f, posicionY*0.5f, 2);

    }
    

    //Si después de cambiar de posición la manzana aparece dentro de una sección del jugador, este función vuelve a cambiarla de posición.
    public void OnCollisionEnter(Collision invasor)
    {
        if (invasor.gameObject.tag == "Seccion") {
            cambiarPosicion();
        }
    }
    
}