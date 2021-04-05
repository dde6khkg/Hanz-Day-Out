using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public GameObject enemy;
    //Shooting
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;
    public float fireRate;
    public float nextFire;
    public Rigidbody2D rb;
    public Rigidbody2D fp;
    public Rigidbody2D Target;
    //Moving
    public float nextMove;
    public Animator animator;

    public Vector2 dir(float min, float max) {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
     }

    void Start()
    {
        shootDelay(Random.Range(.5f, .75f));
        nextMove = Random.Range(.5f, .75f);

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //Shooting
        Vector3 tPos = Target.position;
        fp.position = new Vector2(rb.position.x, rb.position.y + .4f);
        Vector2 lookDir = tPos - firePoint.position;

        if(Time.time > nextFire)
        {
            shoot(lookDir);
        }

        if(Time.time > nextMove)
        {
            move();
        }

        //Animation
        if(Time.timeScale == 1)
        {
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical", rb.velocity.y);
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        }

        if(lookDir.x <= 1 || lookDir.x <= -1 || lookDir.y <= 1 || lookDir.y <= -1 && Time.timeScale == 1)
        {
            animator.SetFloat("lastHorizontal", lookDir.x);
            animator.SetFloat("lastVertical", lookDir.y);
        }
    }

    public virtual void shoot(Vector2 lookDir)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
        Destroy(bullet, 4f);

        rbB.velocity = new Vector2(lookDir.x, lookDir.y).normalized * bulletForce;
            
        nextFire = Time.time + fireRate;
    }
    public virtual void move()
    {
        nextMove = Time.time + Random.Range(2f, 5f);;

        rb.velocity = dir(-4f, 4f);
        StartCoroutine(stopMoving(Random.Range(.2f, .5f)));
    }

    public IEnumerator stopMoving(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = new Vector2(0f, 0f);
    }

    public void shootDelay(float delay)
    {
        nextFire = delay + Time.time;
    }

    public void die()
    {
        Destroy(enemy);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            GetComponent<Enemy>().die();
        }
    }
}
