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
    public float bulletForce = 6f;
    public float fireRate;
    float nextFire;
    public Rigidbody2D rb;
    public Rigidbody2D fp;
    Rigidbody2D Target;
    public int pelletCount = 4;
    //Moving
    float nextMove;
    public Animator animator;

    private Vector2 dir(float min, float max) {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
     }

    void Start()
    {
        shootDelay(Random.Range(.75f, 1.1f));
        nextMove = Random.Range(2f, 3f);

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //Shooting
        Vector3 tarPos = Target.position;
        fp.position = new Vector2(rb.position.x, rb.position.y + .4f);
        Vector2 shootDir = tarPos - firePoint.position;

        if(Time.time > nextFire && enemy.name[6] == '1')
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
            Destroy(bullet, 4f);

            rbB.velocity = new Vector2(shootDir.x, shootDir.y).normalized * bulletForce;
            
            nextFire = Time.time + fireRate;
        }
        if(Time.time > nextFire && enemy.name[6] == '2')
        {
            for(int i = 0; i < pelletCount ; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), FindObjectOfType<Enemy>().GetComponent<Collider2D>());

                Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
                
                Destroy(bullet, 4f);

                rbB.velocity = new Vector2(shootDir.x + Random.Range(-3,3), shootDir.y + Random.Range(-3,3)).normalized * bulletForce;
            }

            nextFire = Time.time + fireRate;
        }

        if(Time.time > nextMove)
        {
            nextMove = Time.time + Random.Range(2f, 5f);;

            rb.velocity = dir(-4f, 4f);
            StartCoroutine(stopMoving(Random.Range(.2f, .5f)));
        }

        //Animation
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

        if(shootDir.x <= 1 || shootDir.x <= -1 || shootDir.y <= 1 || shootDir.y <= -1)
        {
            animator.SetFloat("lastHorizontal", shootDir.x);
            animator.SetFloat("lastVertical", shootDir.y);
        }
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
