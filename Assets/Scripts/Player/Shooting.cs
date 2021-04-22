using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject bullet;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public GameObject bouncePrefab;
    public float bulletForce = 5f;
    Camera cam;
    Vector3 mousePos;
    Vector3 shootDir;
    float nextFire;
    public float fireRate = .5f;
    public string Weapon;

    void Start()
    {
        nextFire = 0f;
        
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButton("Fire1") && Time.time > nextFire && Time.timeScale == 1f)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
        shootDir = mousePos - firePoint.position;
    }

    void Shoot()
    {

        if (Weapon == "Missile_Launcher")
        {
            bullet = Instantiate(missilePrefab, firePoint.position, firePoint.rotation) ;
            bulletForce = 15f;
        }
        else if (Weapon == "Gun")
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletForce = 20f;
        }
        else if (Weapon == "Bounce_Gun")
        {
           bullet = Instantiate(bouncePrefab, firePoint.position, firePoint.rotation);
           bulletForce = 10f;
        }
        else
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletForce = 9f;
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(shootDir.x, shootDir.y).normalized * bulletForce;


        //Destroy(bullet, 4f);
    }
}
