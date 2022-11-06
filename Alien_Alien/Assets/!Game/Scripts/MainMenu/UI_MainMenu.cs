using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu: MonoBehaviour
{
    [SerializeField] private Button m_startButton;
    [SerializeField] private Button m_settingsButton;
    [SerializeField] private Button m_achivementsButton;
    [SerializeField] private Button m_logButton;
    [SerializeField] private GameObject m_mainMenuUI;
    [SerializeField] private GameObject m_settingsUI;
    [SerializeField] private GameObject m_achivementsUI;
    [SerializeField] private GameObject m_logUI;

    void Start()
    {
        Button btnStart = m_startButton.GetComponent<Button>();
        btnStart.onClick.AddListener(ClickStart);
        Button btnSettings = m_settingsButton.GetComponent<Button>();
        btnSettings.onClick.AddListener(ClickSettings);
        Button btnAchivement = m_achivementsButton.GetComponent<Button>();
        btnAchivement.onClick.AddListener(ClickAchivements);
        Button btnLog = m_logButton.GetComponent<Button>();
        btnLog.onClick.AddListener(ClickLog);
    }

    private void ClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void ClickSettings()
    {
        HideMainMenu();
        m_settingsUI.SetActive(true);
    }

    private void ClickAchivements()
    {
        m_achivementsUI.SetActive(true);   
        HideMainMenu();
    }

    private void ClickLog()
    {
        m_logUI.SetActive(true);
        HideMainMenu();
    }

    private void HideMainMenu()
    {
        m_mainMenuUI.SetActive(false);
    }
}
