using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public GameObject GameOverScreen;
    public GameObject Player;
    public bool is_paused = false;
    public bool is_gameover = false;


    public InputActionReference pause_Input;

    private float timer = 1f;


    void Start()
    {
        Time.timeScale = 1;
        Player = GameObject.Find("Player");
        is_gameover = false;
        is_paused = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (pause_Input.action.ReadValue<float>() != 0 && timer <= 0 && !is_gameover)
        {
            if(!is_paused)
            {
                PauseMenuScreen.SetActive(true);
                is_paused = true;
                Time.timeScale = 0;
                //timer = 1;
            }
            else if(is_paused)
            {
                PauseMenuScreen.SetActive(false);
                is_paused = false;
                Time.timeScale = 1;
            }
        }

        if(Player.GetComponent<PlayerController>().health < 0)
        {  
            GameOverScreen.SetActive(true);
            PauseMenuScreen.SetActive(false);

            is_gameover = true;
            is_paused = false;
            Time.timeScale = 0.1f;

        }



    }
}
