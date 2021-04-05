using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 1;
    PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            collision.gameObject.GetComponent<Enemy>().rb.velocity = new Vector2(0,0);
        }
        if(collision.gameObject.tag == "Player")
        {
            player.takeDamage(damage);
            player.rb.velocity = new Vector2(0,0);
        }
        
        Destroy(gameObject);
    }
}
