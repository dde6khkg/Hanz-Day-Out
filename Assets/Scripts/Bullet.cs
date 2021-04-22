using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Damage set on the bullet prefabs to make them do different amounts
    public int damage;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks to see if the bullet is hitting the enemy or the player
        if(collision.gameObject.tag == "Enemy")
        {
            //Makes enemy take damage
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
        }
        else if(collision.gameObject.tag == "Player")
        {
            //Makes the player take damage
            collision.gameObject.GetComponent<PlayerMovement>().takeDamage(damage);
        }
        
        //Destroy the gameobject after it hits something
        Destroy(gameObject);
    }
}
