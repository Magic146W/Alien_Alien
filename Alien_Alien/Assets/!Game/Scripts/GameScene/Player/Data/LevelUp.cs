using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUp: MonoBehaviour
{
    [SerializeField] private TMP_Text m_currentLevelText;
    [SerializeField] private TMP_Text m_nextLevelText;
    [SerializeField] private Image m_fillUpBar;
    [SerializeField] private GameObject m_skillTab;
    [SerializeField] private DataToSerialize  m_dataToSerialize;

    private int m_startingPointsToLevel = 10;
    private float m_multiplierPoints = 1.5f;
    private int m_pointsToLevel = 0;
    private int m_fillUpBarCorrectionPoints = 0;
    private int m_currentLevel = 0;
    public int CurrentLevel => m_currentLevel;

    private GameplayStats m_pointsGameStats;
    private GameplayStats m_missionGameStats;

    public delegate void SkillSelectAction();
    public static event SkillSelectAction OnLevelUp;

    void Awake()
    {
        m_pointsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_points").GetComponent<GameplayStats>();
        m_missionGameStats = GameObject.FindGameObjectWithTag("GameplayStats_mission").GetComponent<GameplayStats>();
        m_pointsToLevel = m_startingPointsToLevel;
        InvokeRepeating("UpdateLevel", 0f, 0.1f);
    }


    private void UpdateLevel()
    {
        FillUpBar();
        if (m_pointsGameStats.MyPoints >= m_pointsToLevel)
        {
            m_fillUpBarCorrectionPoints = m_pointsToLevel;
            m_pointsToLevel = CountPointsToLevel()+m_pointsToLevel/2;
            m_currentLevel++;
            m_dataToSerialize.Level = m_currentLevel;
            m_currentLevelText.text = m_currentLevel.ToString();
            m_nextLevelText.text = (m_currentLevel + 1).ToString();

            m_skillTab.SetActive(true);

            if (OnLevelUp!=null)
                OnLevelUp();
            
            PauseGame();
        }
    }
    private int CountPointsToLevel()
    {
        int calculations;

        if (m_missionGameStats.EnemyID == 0)
        {
            calculations = (int)(m_startingPointsToLevel * Mathf.Pow(m_multiplierPoints, m_currentLevel)) / (m_missionGameStats.EnemyID + 1);
        }
        else
        {
            calculations = (int)(m_startingPointsToLevel * Mathf.Pow(m_multiplierPoints, m_currentLevel)) / m_missionGameStats.EnemyID;
        }

        return calculations;
    }

    private void FillUpBar()
    {
        m_fillUpBar.fillAmount = (float)(m_pointsGameStats.MyPoints - m_fillUpBarCorrectionPoints) / (float)(m_pointsToLevel - m_fillUpBarCorrectionPoints);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
}
