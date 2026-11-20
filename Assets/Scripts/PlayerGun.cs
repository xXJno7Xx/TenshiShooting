using UnityEngine;

public class PlayerGun : MonoBehaviour
{


    public GameObject bulletPrefab;             //Bullet Object
    public GameObject ObjectPool;
    public GameObject gm;                       //GameManager Script

    public float speedX = 1000f;                  //Movement Speed of the Bullet
    public float speedY = 1000f;         
    
    public float bulletFrequency = 0.1f;        //Minimal time difference between Bullet
    private float freq_timer = 0f;              //timer for Bullet Frequency

    public bool is_shooting = false;

    void Start()
    {
        //gm = GameObject.Find("Game Manager");
    }

    void Update()
    {

        if (freq_timer > 0f)
        { freq_timer -= Time.deltaTime; }

        if (is_shooting)
        {
            if (freq_timer <= 0f)
            {
                //var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                GameObject bullet = ObjectPool.GetComponent<ObjectPool>().GetPooledObject();

                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;

                    bullet.SetActive(true);

                    bullet.GetComponent<PlayerBullet>().speedX = speedX;
                    bullet.GetComponent<PlayerBullet>().speedY = speedY;

                    freq_timer = bulletFrequency;
                }
            }        
        }



    }
}
