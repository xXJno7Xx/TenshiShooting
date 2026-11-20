using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_MainMenu_Events : MonoBehaviour
{

    private PanelRenderer _panelRenderer;
    private Button _buttonStory;
    private Button _buttonEndless;
    private Button _buttonQuit;

    public AudioSource _audioSource;


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
        _buttonStory = root.Q("StartStory") as Button;
        _buttonEndless = root.Q("StartEndless") as Button;
        _buttonQuit = root.Q("Quit") as Button;
    }


    void Awake()
    {
        _panelRenderer = GetComponent<PanelRenderer>();
        _audioSource = GetComponent<AudioSource>();
        /*
        _panelRenderer = GetComponent<PanelRenderer>();
        _buttonEndless = _panelRenderer.rootVisualElement.Q("StartEndless") as Button;
        _buttonEndless.RegisterCallback<ClickEvent>(OnPlayGameClick);
        */
    }

    void Update()
    {
        if (_buttonStory == null)
            return;

        if (_buttonEndless == null)
            return;

        if (_buttonQuit == null)
            return;

        _buttonStory.RegisterCallback<ClickEvent>(OnStoryClick);
        _buttonEndless.RegisterCallback<ClickEvent>(OnEndlessClick);
        _buttonQuit.RegisterCallback<ClickEvent>(OnQuitClick);
    }


    private void OnStoryClick(ClickEvent evt)
    {
        Debug.Log("Start Endless");
        _audioSource.Play();
    }

    private void OnEndlessClick(ClickEvent evt)
    {
        Debug.Log("Start Endless");
        _audioSource.Play();
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    private void OnQuitClick(ClickEvent evt)
    {
        Debug.Log("Quit Game");
        _audioSource.Play();
        Application.Quit();
    }


}
