using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BulletEnemy : MonoBehaviour
{
    public GameObject enLamas;
    public GameObject gameOver;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bunker")
        {

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(gameOver, collision.gameObject.transform.position, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.explote);
            Destroy(gameObject);
            Instantiate(enLamas, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
}
