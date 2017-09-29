using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Este script se encuentra en el panel de Cambio de Color y su función principal es actualizar la variable COLORSERPIENTE del GAMEMANAGER a gusto del usuario.
public class cambioDeColor : MonoBehaviour {

    public Image cola;
    public Image cuerpo;
    public Image cabeza;


    public void Start()
    {
        cola.color = GAMEMANAGER.COLORSERPIENTE;
        cuerpo.color = GAMEMANAGER.COLORSERPIENTE;
        cabeza.color = GAMEMANAGER.COLORSERPIENTE;
    }


    /*Esta funcion es accedida por distintos botones que le otorgan un valor hexadecimal en una cadena y la función combierte el valor de la cadena a un color y la asigna a la variable
    COLORSERPIENTE ubicada dentro del GAMEMANAGER.*/ 
    public void cambiarColor(string nuevo) {
        Color nuevoColor = new Color();
        ColorUtility.TryParseHtmlString(nuevo, out nuevoColor);
        
        cola.color = nuevoColor;
        cuerpo.color = nuevoColor;
        cabeza.color = nuevoColor;

        GAMEMANAGER.COLORSERPIENTE=nuevoColor;
    }

    

}
