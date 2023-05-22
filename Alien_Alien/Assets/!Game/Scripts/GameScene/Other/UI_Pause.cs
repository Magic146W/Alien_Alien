using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Pause: MonoBehaviour
{
    [SerializeField] private Button m_exit;
    [SerializeField] private Button m_soundButton;
    [SerializeField] private Button m_musicButton;
    [SerializeField] private Button m_backButton;
    [SerializeField] private JSON_Manager JSON_Manager;
    private AudioManager m_audioManager;
    private bool m_soundPlay;
    private bool m_musicPlay;


    void Start()
    {
        Button btnSound = m_soundButton.GetComponent<Button>();
        btnSound.onClick.AddListener(ClickSound);
        Button btnMusic = m_musicButton.GetComponent<Button>();
        btnMusic.onClick.AddListener(ClickMusic);
        Button btnBack = m_backButton.GetComponent<Button>();
        btnBack.onClick.AddListener(ClickBack);
        Button btnExit = m_exit.GetComponent<Button>();
        btnExit.onClick.AddListener(ClickExit);
        m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void ClickSound()
    {
        ChangeButtonColor(m_soundButton.GetComponent<Image>());
        m_soundPlay = !m_soundPlay;
        m_audioManager.PlaySounds(m_soundPlay);
        JSON_Manager.SerializeSettings(m_soundPlay, m_musicPlay);
    }

    private void ClickMusic()
    {
        ChangeButtonColor(m_musicButton.GetComponent<Image>());
        m_musicPlay = !m_musicPlay;
        m_audioManager.PlayMusic(m_musicPlay);
        JSON_Manager.SerializeSettings(m_soundPlay, m_musicPlay);
    }

    private void ChangeButtonColor(Image btn)
    {
        if (btn.color == Color.red)
        {
            btn.color = Color.green;
        }
        else
        {
            btn.color = Color.red;
        }
    }

    private void ClickBack()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void ClickExit()
    {       
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void SetUIColor(bool soundPlaying, bool musicPlaying)
    {
        if (soundPlaying)
        {
            m_soundButton.GetComponent<Image>().color = Color.green;
            m_soundPlay = true;
        }
        else
        {
            m_soundButton.GetComponent<Image>().color = Color.red;
            m_soundPlay = false;
        }
        if (musicPlaying)
        {
            m_musicButton.GetComponent<Image>().color = Color.green;
            m_musicPlay = true;
        }
        else
        {
            m_musicButton.GetComponent<Image>().color = Color.red;
            m_musicPlay = false;
        }
    }
}

