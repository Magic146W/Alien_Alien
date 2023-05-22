using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button pauseButton;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(PauseMenu);
    }

    void PauseMenu()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
