using System;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialStart : MonoBehaviour
{
    public string[] baudRates = { "9600", "19200", "38400", "57600", "74880", "115200" };
    public string[] serialPorts;
    public Dropdown listaPotenciometro, listaBoton, baudRatepoten, baudRatesBoton;

    void Start()
    {
        List<String> listaPuertos = new List<string>();
        List<String> listaBaudRate = new List<string>();

        serialPorts = SerialPort.GetPortNames();

        for (int i = 0; i < serialPorts.Length; i++)
        {
            listaPuertos.Add(serialPorts[i]);
        }

        listaPotenciometro.AddOptions(listaPuertos);
        listaBoton.AddOptions(listaPuertos);

        for (int i = 0; i < baudRates.Length; i++)
        {
            listaBaudRate.Add(baudRates[i]);
        }
        baudRatepoten.AddOptions(listaBaudRate);
        baudRatesBoton.AddOptions(listaBaudRate);
    }

    void Update()
    {
        
    }
}
