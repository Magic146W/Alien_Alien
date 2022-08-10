using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUp: MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_currentLevelText;
    [SerializeField]
    private TMP_Text m_nextLevelText;
    [SerializeField]
    private Image m_fillUpBar;

    private int m_startingPointsToLevel = 20;
    private float m_multiplierPoints = 1.5f;
    private int m_pointsToLevel = 0;
    private int m_currentLevel = 0;
    private int m_fillUpBarCorrectionPoints = 0;

    private GameplayStats m_pointsGameStats;
    private GameplayStats m_missionGameStats;
    private Data_Player m_playerData;

    void Start()
    {
        m_playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Data_Player>();
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

            m_playerData.ShotDamage += 50; //change
            m_pointsToLevel += CountPointsToLevel();

            m_currentLevel++;
            m_currentLevelText.text = m_currentLevel.ToString();
            m_nextLevelText.text = (m_currentLevel + 1).ToString();        
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
}
