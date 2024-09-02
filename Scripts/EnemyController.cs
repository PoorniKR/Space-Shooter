using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    GameObject scoreUIText;
    public GameObject Explosion;
    float speed;

    GameObject killText;

    void Start()
    {
        speed = 2f;
        scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
        killText = GameObject.FindGameObjectWithTag("EnemyKillTag");
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        if(transform.position.y < min.y)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUIText.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);    
        }
    }

    public void OnDestroy()
    {
        killText.GetComponent<EnemyKill>().Kill += 1;
    }

    void PlayExplosion()
    {                                           
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
