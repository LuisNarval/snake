using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Este código se encarga de actualizar el HUD: Head Up Display. Su función principal es almacenar los puntos obtenidos por el jugador y actualizar el HUD con este valor. 
public class HUD : MonoBehaviour {
    
    public int puntos;
    public Text texto_puntos;


    //Inicializa variables
    void Start () {
        puntos = 0;
        actualizarPuntos();
    }
	

	

    //Actualiza la información mostrada en la interfaz dependiendo de la cantidad de puntos.
    public void actualizarPuntos() {
        if (puntos < 10)
            texto_puntos.text = "000" + puntos.ToString();
        
        else if (puntos < 100)
            texto_puntos.text = "00" + puntos.ToString();
        
        else if (puntos < 1000)
            texto_puntos.text = "0" + puntos.ToString();
        
        else 
            texto_puntos.text = puntos.ToString();
    }


    //Realiza un incremento a los puntos y manda a actualizar el HUD.
    public void incrementaPuntos() {
        puntos++;
        actualizarPuntos();
    }


}
