using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    //Singleton
    static Boss _instance;
    public static Boss Instance { get { return _instance; } }
    //Shooting
    int shotType;

    //Signleton
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public override void move()
    {
        nextMove = Time.time + Random.Range(.75f, 1.75f);;

        //Set direction for moving and time to move
        rb.velocity = dir(-5f, 5f);
        StartCoroutine(stopMoving(Random.Range(.4f, .7f)));
    }

   public override void shoot(Vector2 lookDir)
    {
        shotType = Random.Range(1, 4);

        if(shotType == 1)
        {
            bulletPrefab.transform.localScale = new Vector2(1f, 1f);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();

            Destroy(bullet, 4f);

            rbB.velocity = new Vector2(lookDir.x, lookDir.y).normalized * bulletForce;
            
            nextFire = Time.time + fireRate;
        }
        else if(shotType == 2)
        {
            bulletPrefab.transform.localScale = new Vector2(.65f, .65f);

            for(int i = 0; i < 4 ; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
                
                Destroy(bullet, 4f);

                rbB.velocity = new Vector2(lookDir.x + Random.Range(-3,3), lookDir.y + Random.Range(-3,3)).normalized * bulletForce;
            }

            nextFire = Time.time + (fireRate + .35f);
            
        }
        else if(shotType == 3)
        {
            bulletPrefab.transform.localScale = new Vector2(3.5f, 3.5f);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();

            Destroy(bullet, 7f);

            rbB.velocity = new Vector2(lookDir.x, lookDir.y).normalized * (bulletForce - 7f);
            
            nextFire = Time.time + (fireRate + .25f);
        }
    }
}
