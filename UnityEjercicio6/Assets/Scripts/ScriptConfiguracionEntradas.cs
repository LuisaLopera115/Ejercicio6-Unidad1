﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptConfiguracionEntradas : MonoBehaviour
{
    public GameObject Serialcontroler;
    public GameObject Serialcontroler2;
    public GameObject Aliens;
    void Start()
    {
        
    }

    public void ActivaController() {
        Serialcontroler.SetActive(true);
    }
    public void DesactivaController()
    {
        Serialcontroler.SetActive(false);
    }
    public void ActivaController2()
    {
        Serialcontroler2.SetActive(true);
    }
    public void DesactivaController2()
    {
        Serialcontroler2.SetActive(false);
    }

    public void ActivaJuego()
    {
        Aliens.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}