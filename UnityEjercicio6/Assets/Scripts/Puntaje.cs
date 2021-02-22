using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public int puntos;
    public Text puntaje;
    void Start()
    {
        puntos = 0;
    }
    public void SumaPuntaje(int valor) {
        puntos += valor;
    }
    // Update is called once per frame
    void Update()
    {
        puntaje.text ="PUNTAJE: " + puntos.ToString();
             
    }
}
