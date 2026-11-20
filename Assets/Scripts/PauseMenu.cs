using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public bool is_paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!is_paused)
            {
                PauseMenuScreen.SetActive(true);
                is_paused = true;
                Time.timeScale = 0;
            }
            else if(is_paused)
            {
                PauseMenuScreen.SetActive(false);
                is_paused = false;
                Time.timeScale = 1;
            }



        }



    }
}
