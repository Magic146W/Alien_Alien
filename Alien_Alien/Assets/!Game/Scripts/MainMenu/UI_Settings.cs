using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings: MonoBehaviour
{
    [SerializeField] private GameObject m_mainMenuUI;
    [SerializeField] private Button m_soundButton;
    [SerializeField] private Button m_musicButton;
    [SerializeField] private Button m_backButton;
    [SerializeField] private JSON_Manager m_json;
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
        m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void ClickSound()
    {
        ChangeButtonColor(m_soundButton.GetComponent<Image>());
        m_soundPlay = !m_soundPlay;
        m_audioManager.PlaySounds(m_soundPlay);
        m_json.SerializeSettings(m_soundPlay, m_musicPlay);
    }

    private void ClickMusic()
    {
        ChangeButtonColor(m_musicButton.GetComponent<Image>());
        m_musicPlay = !m_musicPlay;
        m_audioManager.PlayMusic(m_musicPlay);
        m_json.SerializeSettings(m_soundPlay, m_musicPlay);
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
        m_mainMenuUI.SetActive(true);
        this.gameObject.SetActive(false);
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
