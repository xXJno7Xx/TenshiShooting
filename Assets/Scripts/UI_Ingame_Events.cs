using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UI_Ingame_Events : MonoBehaviour
{


    private PanelRenderer _panelRenderer;
    private GameObject _stageManager;
    private GameObject _player;


    private Label m_Score;
    private Label m_HiScore;
    private Label m_Life;
    private Label m_Bomb;



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
        m_HiScore = root.Q<Label>("HiScore");
        m_Score = root.Q<Label>("Score");
        m_Life = root.Q<Label>("Life");
        m_Bomb = root.Q<Label>("Bomb");
    }


    void Awake()
    {
        _panelRenderer = GetComponent<PanelRenderer>();
        _stageManager = GameObject.Find("StageManager");
        _player = GameObject.Find("Player");
    }


    void Update()
    {
        if (m_HiScore == null)
            return;

        m_HiScore.text = PlayerPrefs.GetFloat("highscore").ToString();
        m_Score.text = _stageManager.GetComponent<StageManager>().score.ToString();
        m_Life.text = _player.GetComponent<PlayerController>().health.ToString();
        m_Bomb.text = _player.GetComponent<PlayerController>().bomb_amount.ToString(); 


    }

}



