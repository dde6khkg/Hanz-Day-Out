using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Move
    public GameObject Player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    //Shooting
    Camera cam;
    Vector2 mousePos;
    public Rigidbody2D fp;
    //Health
    static int maxHealth = 4;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Animation
        if(Time.timeScale == 1)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        if(Input.GetAxisRaw("Horizontal")  == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 
        || Input.GetAxisRaw("Vertical") == -1 && Time.timeScale == 1)
        {
            animator.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
        }

        //Shooting
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Test
        if(Input.GetButtonDown("Jump"))
        {
            takeDamage(1);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //FirePoint Position
        fp.position = new Vector2(rb.position.x, rb.position.y + .4f);

        //Shooting
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        fp.rotation = angle;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Debug.Log("Dead...");
            Destroy(Player);
            Destroy(canvas);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void Awake() 
    {
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(Camera.main);
        DontDestroyOnLoad(canvas);
    }

    public void resetPos()
    {
        rb.position = new Vector2(0f, -4.9f);
    }

    public void Destroy()
    {
        Destroy(Player);
        Destroy(canvas);
    }
}
