﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

public class SerialController2 : MonoBehaviour
{
    
    [Tooltip("Port name with which the SerialPort object will be created.")]
    string portName = "COM7";

    [Tooltip("Baud rate that the serial device is using to transmit data.")]
    int baudRate = 57600;

    [Tooltip("Reference to an scene object that will receive the events of connection, " +
             "disconnection and the messages from the serial device.")]
    public GameObject messageListener;

    [Tooltip("After an error in the serial communication, or an unsuccessful " +
             "connect, how many milliseconds we should wait.")]
    public int reconnectionDelay = 1000;

    [Tooltip("Maximum number of unread data messages in the queue. " +
             "New messages will be discarded.")]
    public int maxUnreadMessages = 1;

    [Tooltip("Maximum number of unread data messages in the queue. " +
             "New messages will be discarded.")]

    // Internal reference to the Thread and the object that runs in it.
    protected Thread thread;
    protected SerialThreadBytesProtocol serialThread;
    public SerialStart serialStart;

    public void EntradaPuerto(Int32 val)
    {
        portName = serialStart.serialPorts[val];
    }
    public void BaudRate(Int32 val)
    {
        baudRate = int.Parse(serialStart.baudRates[val]);
        Debug.Log(baudRate.ToString());
    }

    void OnEnable()
    {
        Debug.Log(portName);
        serialThread = new SerialThreadBytesProtocol(portName,
                                                       baudRate,
                                                       reconnectionDelay,
                                                       maxUnreadMessages);
        thread = new Thread(new ThreadStart(serialThread.RunForever));
        thread.Start();
    }

    // ------------------------------------------------------------------------
    // Invoked whenever the SerialController gameobject is deactivated.
    // It stops and destroys the thread that was reading from the serial device.
    // ------------------------------------------------------------------------
    void OnDisable()
    {
        // If there is a user-defined tear-down function, execute it before
        // closing the underlying COM port.
        if (userDefinedTearDownFunction != null)
            userDefinedTearDownFunction();

        // The serialThread reference should never be null at this point,
        // unless an Exception happened in the OnEnable(), in which case I've
        // no idea what face Unity will make.
        if (serialThread != null)
        {
            serialThread.RequestStop();
            serialThread = null;
        }

        // This reference shouldn't be null at this point anyway.
        if (thread != null)
        {
            thread.Join();
            thread = null;
        }
    }

    // ------------------------------------------------------------------------
    // Polls messages from the queue that the SerialThread object keeps. Once a
    // message has been polled it is removed from the queue. There are some
    // special messages that mark the start/end of the communication with the
    // device.
    // ------------------------------------------------------------------------
    void Update()
    {
        // If the user prefers to poll the messages instead of receiving them
        // via SendMessage, then the message listener should be null.
        if (messageListener == null)
            return;

        // Read the next message from the queue
        byte[] message = ReadSerialMessage();
        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        messageListener.SendMessage("OnMessageArrived", message);
    }

    public byte[] ReadSerialMessage()
    {
        // Read the next message from the queue
        try
        {
            return (byte[])serialThread.ReadMessage();
        }
        catch(Exception e)
        {
            return null;
        }
    }

    public void SendSerialMessage(byte[] message)
    {
        serialThread.SendMessage(message);
    }

    public delegate void TearDownFunction();
    private TearDownFunction userDefinedTearDownFunction;
    public void SetTearDownFunction(TearDownFunction userFunction)
    {
        this.userDefinedTearDownFunction = userFunction;
    }
}
