using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private string currentAnimation = "";
    public string animation;

    public GameObject ObjectPool;
    public float speedX = 10f;
    public float speedY = 10f;
    public float accelerationX = 10f;
    public float accelerationY = 10f;


    public float bulletFrequency = 0.1f;        //Minimal time difference between Bullet
    private float freq_timer = 0f;              //timer for Bullet Frequency

    public int shooting_type = 1;

    public int health;

    public GameObject sm;
    public GameObject Explosion;


    void Start()
    {
        sm = GameObject.Find("StageManager");
        animator = GetComponent<Animator>();
        ObjectPool = GameObject.Find("EnemyBulletPool");
    }


    void Update()
    {
        if(currentAnimation != animation)
        {
            //for smooth transition: "animator.Crossfade(animation, [transition duration]);"
            animator.Play(animation);
            currentAnimation = animation;
        }



        if (freq_timer > 0f)
        { freq_timer -= Time.deltaTime; }

        if (freq_timer <= 0f)
        {
            //var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            GameObject bullet = ObjectPool.GetComponent<ObjectPool>().GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                bullet.SetActive(true);

                bullet.GetComponent<EnemyBullet>().speedX = speedX;
                bullet.GetComponent<EnemyBullet>().speedY = speedY;
                bullet.GetComponent<EnemyBullet>().accelerationX = accelerationX;
                bullet.GetComponent<EnemyBullet>().accelerationY = accelerationY;

                freq_timer = bulletFrequency;
            }
        }


        //Enemy Death
        if (health < 0)
        {
            Debug.Log("Enemy Dead");
            sm.GetComponent<StageManager>().score += 100;
            Debug.Log("Score: " + sm.GetComponent<StageManager>().score);
            Instantiate(Explosion, transform.position, transform.rotation);

            // !! SPAWN ENEMY DEATH VFX !!
            // !! PLAY ENEMY DEATH SFX !!

            gameObject.SetActive(false);
        }

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            health -= 1;
        }
    }

}
