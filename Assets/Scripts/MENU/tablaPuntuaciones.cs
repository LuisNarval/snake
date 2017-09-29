using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*Este script se encuentra dentro del Panel de Puntuaciones y su objetivo principal es llenar los campos del panel con los valores actuales de los PlayerPref que se encuentran almacenados en dos
arreglos por el GAMEMANAGER*/
public class tablaPuntuaciones : MonoBehaviour {


    public Text[] textoNombres;
    public Text[] textoPuntos;



    /*Esta función es llamada por al administrador del menu y llena los campos de la tabla de puntuaciones con los valovalores actuales de los PlayerPref que se encuentran almacenados en dos
    arreglos por el GAMEMANAGER*/
    public void colocarTabla() {

        for (int i = 0; i < 10; i++) {

            textoNombres[i].text = GAMEMANAGER.MEJORESNOMBRES[i];

            if (GAMEMANAGER.MEJORESPUNTOS[i] < 10)
                textoPuntos[i].text = "000" + GAMEMANAGER.MEJORESPUNTOS[i].ToString();
            else if (GAMEMANAGER.MEJORESPUNTOS[i] < 100)
                textoPuntos[i].text = "00" + GAMEMANAGER.MEJORESPUNTOS[i].ToString();
            else if (GAMEMANAGER.MEJORESPUNTOS[i] < 1000)
                textoPuntos[i].text = "0" + GAMEMANAGER.MEJORESPUNTOS[i].ToString();
            else
                textoPuntos[i].text = GAMEMANAGER.MEJORESPUNTOS[i].ToString();
        }


    }

}
