
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //public GameObject hitEffect;
    public Rigidbody2D rb;
    public int damage = 10;
    public int aoe_radius = 1;
    PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 2f);

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            collision.gameObject.GetComponent<Enemy>().rb.velocity = new Vector2(0, 0);
        }
        if (collision.gameObject.tag == "Player")
        {
            player.takeDamage(damage);
            player.rb.velocity = new Vector2(0, 0);
        }
        MissileExplode();

        Destroy(gameObject);
    }


    void MissileExplode()
    {

        var hitColliders = Physics2D.OverlapCircleAll(transform.position, 1);
        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.takeDamage(SplashCalc(aoe_radius, damage));
            }
        }

        Vector2 Pos = transform.position;
        Debug.Log(transform.position);
        Debug.Log("Reached Explosion");

    }

    //I know this isn't that neccessary but I need something to more easily unit test
    //The player will do more damage on direct hits but splash damage is an option with this function
    public int SplashCalc(int aoe_radius, int damage)
    {
        int splash;

        splash = (aoe_radius * damage) / 4;

        return splash;

    }
}
