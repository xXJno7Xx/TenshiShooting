using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speedX = 10f;
    public float speedY = 10f;

    public float life = 4f;
    private float life_timer;

    public bool can_move = true;

    void Start()
    {
        life_timer = life;
    }

   
    void Update()
    {
        LifetimeKiller(); //disables bullet after lifetime
    }

    void FixedUpdate()
    {
        //move Bullet
        if (can_move)
        {
            rb.linearVelocity = new Vector2(speedX * Time.deltaTime, speedY * Time.deltaTime);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
        //die = 100;
        gameObject.SetActive(false);
    }


    void LifetimeKiller()
    {
        life_timer -= Time.deltaTime;
        if (life_timer <= 0)
        {
            life_timer = life;
            gameObject.SetActive(false);
        }
    }
}
