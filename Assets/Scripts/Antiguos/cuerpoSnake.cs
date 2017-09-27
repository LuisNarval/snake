using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuerpoSnake : MonoBehaviour {

    public Vector3 direccionSiguiente;
    public Vector3 direccionActual;



    public int spriteSiguiente;
    public int spriteActual;

    SpriteRenderer imagenDelCuerpo;
    
    public Sprite cuerpoVertical;
    public Sprite cuerpoHorizontal;

    public Sprite esquinaArribaDerecha;
    public Sprite esquinaArribaIzquierda;
    public Sprite esquinaAbajoDerecha;
    public Sprite esquinaAbajoIzquierda;

    public Sprite colaArriba;
    public Sprite colaDerecha;
    public Sprite colaAbajo;
    public Sprite colaIzquierda;


    
    public void Awake(){
        imagenDelCuerpo = this.GetComponent<SpriteRenderer>();
    }
    

    //Esta funcion es mandada a llamar por cabezaSnake.cs y le dice a esta sección del cuerpo cual será su siguiente posición
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





    //Esta funcion es mandada a llamar por cabezaSnake.cs y le dice a esta sección del cuerpo cual será el Sprite que deberá mostrar
    public void colocarSprite() {
        spriteActual = spriteSiguiente;

        switch (spriteActual) {
            case 0:
                imagenDelCuerpo.sprite = cuerpoVertical;
                break;

            case 1:
                imagenDelCuerpo.sprite = cuerpoHorizontal;
                break;

            case 2:
                imagenDelCuerpo.sprite = esquinaArribaDerecha;
                break;

            case 3:
                imagenDelCuerpo.sprite = esquinaArribaIzquierda;
                break;

            case 4:
                imagenDelCuerpo.sprite = esquinaAbajoDerecha;
                break;

            case 5:
                imagenDelCuerpo.sprite = esquinaAbajoIzquierda;
                break;

            case 6:
                imagenDelCuerpo.sprite = colaArriba;
                break;

            case 7:
                imagenDelCuerpo.sprite = colaDerecha;
                break;

            case 8:
                imagenDelCuerpo.sprite = colaAbajo;
                break;

            case 9:
                imagenDelCuerpo.sprite = colaIzquierda;
                break;
        }
    }


}