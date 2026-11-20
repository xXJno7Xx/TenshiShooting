using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    private string currentAnimation = "";

    private bool is_shooting = false;
    private bool is_bombing = false;
    private bool is_focussing = false;
    private float horizontalVelocity = 0f;
    private float verticalVelocity = 0f;


    public float downwardYscale = 0.9f;
    public float upwardYscale = 1.05f;



    void Awake()
    { player = GameObject.Find("Player"); }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        is_shooting = GetComponent<PlayerController>().is_shooting;
        is_bombing = GetComponent<PlayerController>().is_bombing;
        is_focussing = GetComponent<PlayerController>().is_focussing;
        horizontalVelocity = GetComponent<PlayerController>().horizontalVelocity;
        verticalVelocity = GetComponent<PlayerController>().verticalVelocity;


        // --- ANIMATION HORIZONTAL --- //

        if (is_shooting)
        {
            if(horizontalVelocity > 0.1)
            {
                ChangeAnimation("PlayerShootingForward");
            }
            else if (horizontalVelocity < -0.1)
            {
                ChangeAnimation("PlayerShootingBackward");
            }
            else
            {
                ChangeAnimation("PlayerShooting");
            }
        }
        else
        {
            if (horizontalVelocity > 0.1)
            {
                ChangeAnimation("PlayerNeutralForward");
            }
            else if (horizontalVelocity < -0.1)
            {
                ChangeAnimation("PlayerNeutralBackward");
            }
            else
            {
                ChangeAnimation("PlayerNeutral");
            }
        }


        // --- "ANIMATION" VERTICAL --- //      WARNING: THIS ALSO CHANGES THE HITBOX SIZE! - Fix later or Disable!

        if (verticalVelocity > 0.1)
        {
            transform.localScale = new Vector3(1, upwardYscale, 1);
        }
        else if (verticalVelocity < -0.1)
        {
            transform.localScale = new Vector3(1, downwardYscale, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }



    }

    private void ChangeAnimation(string animation)
    {
        if(currentAnimation != animation)
        {
            //for smooth transition: "animator.Crossfade(animation, [transition duration]);"
            animator.Play(animation);
            currentAnimation = animation;
        }
    }



}