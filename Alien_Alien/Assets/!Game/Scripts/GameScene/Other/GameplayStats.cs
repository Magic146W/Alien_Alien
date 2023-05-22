using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayStats: MonoBehaviour
{
    [SerializeField] private TMP_Text m_GameplayStatsText;
    [SerializeField] private int m_selection = 0;
    [SerializeField] private DataToSerialize  m_dataToSerialize;

    private int m_enemyID;
    public int EnemyID
    {
        get { return m_enemyID; }
    }

    private int m_enemiesToKill = 10;
    private int m_killCountCurrent = 0;
    private int m_killCount = 0;

    public int CurrentEnemyIDKills
    {
        get { return m_killCount; }
        set { m_killCount = value; }
    }
    private int m_allKillsCurrent = 0;
    private int m_allKills = 0;
    public int AllKills
    {
        get { return m_allKills; }
        set { m_allKills = value; }
    }

    private int m_pointsCurrent = 0;
    private int m_points = 0;
    public int MyPoints
    {
        get { return m_points; }
        set { m_points = value; }
    }

    private void Awake()
    {
        InvokeRepeating("UpdateList", 0f, 0.2f);
    }

    private void UpdateList()
    {
        if (m_selection == 0)
        {
            if (m_pointsCurrent != m_points)
            {
                m_GameplayStatsText.text = "Points: " + m_points;
                m_pointsCurrent = m_points;
                m_dataToSerialize.Points = m_pointsCurrent;
            }
        }
        else if (m_selection == 1)
        {
            if (m_killCount == m_enemiesToKill && m_enemyID < 8)
            {
                m_enemyID++;
                m_killCount = 0;
                m_killCountCurrent = 0;
                m_GameplayStatsText.text = CountingEnemyName(m_enemyID);
            }

            if (m_killCountCurrent != m_killCount)
            {
                m_GameplayStatsText.text = CountingEnemyName(m_enemyID);
                m_killCountCurrent = m_killCount;
            }
        }
        else if (m_selection == 2)
        {
            if (m_allKills != m_allKillsCurrent)
            {
                m_GameplayStatsText.text = "Kills: " + m_allKills;
                m_allKillsCurrent = m_allKills;
                m_dataToSerialize.Kills = m_allKillsCurrent;
            }
        }
    }

    private string CountingEnemyName(int count)
    {
        m_dataToSerialize.Enemy = count;
        switch (count)
        {
            case 0:
                return "Triangle enemy killed: " + m_killCount + "/10";
            case 1:
                return "Square enemy killed: " + m_killCount + "/10";
            case 2:
                return "Pentagon enemy killed: " + m_killCount + "/10";
            case 3:
                return "Hexagon enemy killed: " + m_killCount + "/10";
            case 4:
                return "Heptagon enemy killed: " + m_killCount + "/10";
            case 5:
                return "Octagon enemy killed: " + m_killCount + "/10";
            case 6:
                return "Nonagon enemy killed: " + m_killCount + "/10";
            case 7:
                return "Decagon enemy killed: " + m_killCount + "/10";
            default:
                return "Missions done!";
        }
    }
}
