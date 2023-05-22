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
    [SerializeField] private Button m_exitButton;
    [SerializeField] private GameObject m_mainMenuUI;
    [SerializeField] private GameObject m_settingsUI;
    [SerializeField] private GameObject m_achivementsUI;

    void Start()
    {
        Button btnStart = m_startButton.GetComponent<Button>();
        btnStart.onClick.AddListener(ClickStart);
        Button btnSettings = m_settingsButton.GetComponent<Button>();
        btnSettings.onClick.AddListener(ClickSettings);
        Button btnAchivement = m_achivementsButton.GetComponent<Button>();
        btnAchivement.onClick.AddListener(ClickAchivements);
        Button btnExit = m_exitButton.GetComponent<Button>();
        btnExit.onClick.AddListener(ClickExit);
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
        HideMainMenu();
        m_achivementsUI.SetActive(true);   
    }

    private void ClickExit()
    {
        Application.Quit();
    }

    private void HideMainMenu()
    {
        m_mainMenuUI.SetActive(false);
    }
}
