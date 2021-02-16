using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialThreadBytesProtocol : AbstractSerialThread
{
    // Buffer where a single message must fit
    private byte[] buffer = new byte[1];
    public SerialThreadBytesProtocol(string portName,
                                       int baudRate,
                                       int delayBeforeReconnecting,
                                       int maxUnreadMessages)
        : base(portName, baudRate, delayBeforeReconnecting, maxUnreadMessages, false)
    {

    }

    protected override void SendToWire(object message, SerialPort serialPort)
    {
        byte[] binaryMessage = (byte[])message;
        serialPort.Write(binaryMessage, 0, binaryMessage.Length);
    }

    protected override object ReadFromWire(SerialPort serialPort)
    {
        if (serialPort.BytesToRead > 0)
        {
            serialPort.Read(buffer, 0, 1);
            Debug.Log("entra el dato");
            Debug.Log(buffer[0].ToString("X2"));
            return buffer;
        }
        else{
            return null;
        }  
            
    }
}
