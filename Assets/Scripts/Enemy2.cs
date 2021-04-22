using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public int pelletCount = 4;
    
    public override void shoot(Vector2 lookDir)
    {
        for(int i = 0; i < pelletCount ; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), FindObjectOfType<Enemy>().GetComponent<Collider2D>());

            Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
                
            Destroy(bullet, 4f);

            rbB.velocity = new Vector2(lookDir.x + Random.Range(-3,3), lookDir.y + Random.Range(-3,3)).normalized * bulletForce;
        }

        nextFire = Time.time + fireRate;
    }
}
