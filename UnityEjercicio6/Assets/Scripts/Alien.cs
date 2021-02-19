using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    float alienSpeed = 2f;

    public Rigidbody2D rigibodiAlien;
    public GameObject alienBullet;

    private float minFireRate = 3.0f;
    private float maxFireRate = 20.0f;
    private float fireWaitTime = 3.0f;
    public float timeStar;
    public bool activarTiempo = false;
    //public bool EnemigosDisparan
    void OnEnable()
    {
        rigibodiAlien = GetComponent<Rigidbody2D>();
        rigibodiAlien.velocity = new Vector2(1,0)* alienSpeed;
        fireWaitTime = fireWaitTime + Random.Range(minFireRate, maxFireRate);
    }
    // gira cada vez que coliciona con los muros
    void Gira(int direccion) {
        Vector2 newVelocidad = rigibodiAlien.velocity;
        newVelocidad.x = alienSpeed * direccion;
        rigibodiAlien.velocity = newVelocidad;
    }
    // Se mueve hacia abajo cada vez que coliciona con los muros
    void MueveAbajo() {
        Vector2 posicion = transform.position;
        posicion.y -= 1;
        transform.position = posicion;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MuroDere") {
            Gira(-1);
            MueveAbajo();
        }
        if (collision.gameObject.name == "MuroIzq")
        {
            Gira(1);
            MueveAbajo();
        }
    }

    
    void FixedUpdate()
    {
        
    }
    void Update()
    {
        timeStar = Time.time;
        if (timeStar > fireWaitTime)
        {
            fireWaitTime = fireWaitTime + Random.Range(minFireRate, maxFireRate);
            Instantiate(alienBullet, transform.position, Quaternion.identity);
            
        }
        Debug.Log(timeStar.ToString("F2"));

    }
}
