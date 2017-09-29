using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablaPuntuaciones : MonoBehaviour {


    public Text[] textoNombres;
    public Text[] textoPuntos;

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
