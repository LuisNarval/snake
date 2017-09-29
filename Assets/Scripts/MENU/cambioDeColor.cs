using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void cambiarColor(string nuevo) {
        Color nuevoColor = new Color();
        ColorUtility.TryParseHtmlString(nuevo, out nuevoColor);
        
        cola.color = nuevoColor;
        cuerpo.color = nuevoColor;
        cabeza.color = nuevoColor;

        GAMEMANAGER.COLORSERPIENTE=nuevoColor;
    }

    

}
