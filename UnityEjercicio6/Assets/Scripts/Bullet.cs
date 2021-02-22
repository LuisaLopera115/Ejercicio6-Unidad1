using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int puntaje;
    public Sprite invaderDie;

    void Start()
    {
        //Puntaje = GetComponent<Puntaje>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bunker") {

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Colisiona con enemigo");
            collision.GetComponent<SpriteRenderer>().sprite = invaderDie;

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.invaderKilled);
            Destroy(gameObject);
            Destroy(collision.gameObject, 0.5f);
        }
    }

}
