using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_Pause_Events : MonoBehaviour
{
    private PanelRenderer _panelRenderer;
    private Button _buttonQuit;

    //private Label m_Score; //                                    TESTTESTESTESTTESTTEST

    //public AudioSource _audioSource;


    private void OnEnable()
    {
        _panelRenderer
            .RegisterUIReloadCallback(OnUIReload);
    }
    private void OnDisable()
    {
        _panelRenderer
            .UnregisterUIReloadCallback(OnUIReload);
    }

    private void OnUIReload(PanelRenderer renderer, VisualElement root)
    {
        _buttonQuit = root.Q("Quit") as Button;
        //m_Score = root.Q<Label>("Score"); //                                    TESTTESTESTESTTESTTEST
    }


    void Awake()
    {
        _panelRenderer = GetComponent<PanelRenderer>();
        //_audioSource = GetComponent<AudioSource>();
        /*
        _panelRenderer = GetComponent<PanelRenderer>();
        _buttonEndless = _panelRenderer.rootVisualElement.Q("StartEndless") as Button;
        _buttonEndless.RegisterCallback<ClickEvent>(OnPlayGameClick);
        */
    }

    void Update()
    {
       
        if (_buttonQuit == null)
            return;

        _buttonQuit.RegisterCallback<ClickEvent>(OnQuitClick);


        //m_Score.text = PlayerPrefs.GetFloat("highscore").ToString(); //                                    TESTTESTESTESTTESTTEST
    }


    private void OnQuitClick(ClickEvent evt)
    {
        Debug.Log("Quit Game");
        //_audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
