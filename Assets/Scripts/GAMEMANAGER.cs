using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{

    public static GAMEMANAGER instancia;


    public static string DIFICULTAD;
    public static string COLORSERPIENTE;


    private void Awake()
    {
        hacerUnico();
    }


    void hacerUnico()
    {
        if (instancia != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Start()
    {
        DIFICULTAD = "NORMAL";
        COLORSERPIENTE = "GREEN";
    }
    

}
