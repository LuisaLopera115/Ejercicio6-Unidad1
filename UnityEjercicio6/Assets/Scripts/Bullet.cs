using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite invaderDie;

    void Start()
    {
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
            Destroy(collision.gameObject,0.5f);
        }
    }
}
