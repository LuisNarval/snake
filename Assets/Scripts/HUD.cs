using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    
    int puntos;
    public Text texto_puntos;
    

	// Use this for initialization
	void Start () {
        puntos = 0;
        actualizarPuntos();
    }
	

	// Update is called once per frame
	void Update () {}


    void actualizarPuntos() {
        if (puntos < 10)
            texto_puntos.text = "000" + puntos.ToString();
        
        else if (puntos < 100)
            texto_puntos.text = "00" + puntos.ToString();
        
        else if (puntos < 1000)
            texto_puntos.text = "0" + puntos.ToString();
        
        else 
            texto_puntos.text = puntos.ToString();
    }


    public void incrementaPuntos() {
        puntos++;
        actualizarPuntos();
    }


}
