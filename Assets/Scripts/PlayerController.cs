using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   

    // ------------ MOVEMENT VARIABLES -------------------------

    public float moveSpeed = 10f;
    public float moveSpeedFocus = 5f;

    public int bomb_amount = 3;
    public int health = 3;
    public float invincibilityTime = 0.1f;        //Cooldown Invincibility Time after being hit
    private float invinciblity_timer = 0f;

    // ------------ INPUTS & STATES ----------------
    private Vector2 _moveDirection;

    public InputActionReference move;
    public InputActionReference fire;
    public InputActionReference bomb;
    public InputActionReference focus;

    public bool is_shooting = false;
    public bool is_bombing = false;
    public bool is_focussing = false;
    public bool is_invincible = false;
    public bool can_move = true;

    public float horizontalVelocity = 0f; //only used for Animation
    public float verticalVelocity = 0f; //only used for Animation

    // ----------- GAME OBJECTS ----------------------------   

    public Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public GameObject p_BulletSpawn;

    public GameObject Explosion;
    public AudioSource _audioSource;

    public GameObject GameOverScreen;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        // ---------------- INPUTS ---------------- //

        //set movement direction to input
        _moveDirection = move.action.ReadValue<Vector2>();
        horizontalVelocity = _moveDirection.x;
        verticalVelocity = _moveDirection.y;


        // --- FIRE/SHOOT ---
        if (fire.action.ReadValue<float>() != 0)
        {
            is_shooting = true;
            p_BulletSpawn.GetComponent<PlayerGun>().is_shooting = true;
        }
        else
        {
            is_shooting = false;
            p_BulletSpawn.GetComponent<PlayerGun>().is_shooting = false;
        }


        // --- BOMB ---
        if (bomb.action.ReadValue<float>() != 0)
        {
            //bomb stuff
            //use "OnBomb()" and a timer
        }

        // --- FOCUS ---
        if (focus.action.ReadValue<float>() != 0)
        {
            is_focussing = true;
        }
        else
        {
            is_focussing = false;
        }



        // ---------------- GAMEPLAY ---------------- //


        //Invincibility Time
        if(invinciblity_timer > 0)
        {
            invinciblity_timer -= Time.deltaTime;
            is_invincible = true;


            Color col = spriteRenderer.color;
            //col.a = 0.7f;
            col = new Color(0.8f, 0.8f, 1f, 0.7f);
            spriteRenderer.color = col;
        }
        else
        {
            Color col = spriteRenderer.color;
            //col.a = 1f;
            col = new Color(1f, 1f, 1f, 1f);
            spriteRenderer.color = col;


            is_invincible = false;
        }

        //Player Death
        if (health < 0)
        {
            Debug.Log("Player Dead");

            // !! SPAWN PLAYER DEATH VFX !! //
            Instantiate(Explosion, transform.position, transform.rotation);
            // !! PLAY PLAYER DEATH SFX !! //
            AudioManager.Instance.StopMusic();


            //GameOverScreen.SetActive(true);

            gameObject.SetActive(false);
        }



    

    }

    void FixedUpdate()
    {
        //move Player
        if (can_move && !is_focussing)
        {
            rb2D.linearVelocity = new Vector2(_moveDirection.x * moveSpeed * Time.deltaTime,
                                              _moveDirection.y * moveSpeed * Time.deltaTime);
        }
        else if (can_move && is_focussing)
        {
            rb2D.linearVelocity = new Vector2(_moveDirection.x * moveSpeedFocus * Time.deltaTime,
                                              _moveDirection.y * moveSpeedFocus * Time.deltaTime);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_Bullet")
        {
            if (!is_invincible)
            {
                invinciblity_timer = invincibilityTime;
                health -= 1;
                _audioSource.Play();
                Debug.Log("Player Damage");
            }
        }
    }


    void OnFire()
    {
        //Debug.Log("FIRE");
    }

    void OnBomb()
    {
        Debug.Log("BOMB");
    }
}
