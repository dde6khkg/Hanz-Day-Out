using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 5f;
    public Camera cam;
    Vector3 mousePos;
    Vector3 shootDir;
    float nextFire;
    public float fireRate = .5f;
    GameObject Bullets;

    void Start()
    {
        nextFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Fire1") && Time.time > nextFire && Time.timeScale == 1f)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
        shootDir = mousePos - firePoint.position;
        Bullets = GameObject.FindGameObjectWithTag("Bullet"); //Find all bullets
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(Bullets.GetComponent<Collider2D>(), GetComponent<Collider2D>()); //Ignore all bullets
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(shootDir.x, shootDir.y).normalized * bulletForce;


        Destroy(bullet, 4f);
    }
}
