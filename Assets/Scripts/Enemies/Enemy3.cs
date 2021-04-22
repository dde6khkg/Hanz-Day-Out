using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public override void shoot(Vector2 lookDir)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();

        Destroy(bullet, 4f);

        rbB.velocity = new Vector2(lookDir.x, lookDir.y).normalized * bulletForce;
        
        StartCoroutine(shot2());
        nextFire = Time.time + fireRate;
    }

    IEnumerator shot2()
    {
        yield return new WaitForSeconds(.1f);
        
        Vector3 tPos = Target.position;
        Vector2 ld = tPos - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();

        Destroy(bullet, 4f);

        rbB.velocity = new Vector2(ld.x, ld.y).normalized * bulletForce;
        
        StartCoroutine(shot3());
    }

    public IEnumerator shot3()
    {
        yield return new WaitForSeconds(.1f);

        Vector3 tPos = Target.position;
        Vector2 ld = tPos - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();

        Destroy(bullet, 4f);

        rbB.velocity = new Vector2(ld.x, ld.y).normalized * bulletForce;
    }
}
