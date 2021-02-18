/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Text;
using System.Threading;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    private Thread _t1;
    private Thread _t2;

    public GameObject player;
    public GameObject bullet;

    public SerialController serialController;
    public SerialController2 SerialController2;
    public Transform firepoint;

    float convert = 0;
    // Initialization
    void Start()
    {

    }

    void Update()
    {
        Bonton();
        Potenciometro();
        
    }

    void Bonton()
    {
        while (true)
        {
            byte[] message2 = SerialController2.ReadSerialMessage();
            if (message2 == null) { return; }

            Debug.Log("DISPARA USER");
            string mg = message2[0].ToString("X2");

            if (mg == "3E")
            {
                Shoot();
            }
        }
    }
    void Potenciometro()
    {
        string message = serialController.ReadSerialMessage();

        if (message == null) { return; }

        convert = int.Parse(message);
        player.transform.position = new Vector3((float)convert, player.transform.position.y, transform.position.z);
    }
    void Shoot() {
        Instantiate(bullet,firepoint.position,firepoint.rotation);
    }
}
