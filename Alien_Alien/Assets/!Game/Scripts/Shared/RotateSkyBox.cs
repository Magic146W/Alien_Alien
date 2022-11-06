using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateSkyBox: MonoBehaviour
{
    [SerializeField] private float m_rotateSpeed = 1.5f;
    GameplayStats m_missionGameStats;
    int m_currentGamePhase;

    private void Start()
    {
        var scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("GameScene"))
        {
            m_rotateSpeed *= m_rotateSpeed;
        }

        if (GameObject.FindGameObjectWithTag("GameplayStats_mission"))
        {
            m_missionGameStats = GameObject.FindGameObjectWithTag("GameplayStats_mission").GetComponent<GameplayStats>();
            m_currentGamePhase = m_missionGameStats.EnemyID;
            InvokeRepeating("SkyBoxRotationSpeedUpdate", 0, 0.5f);
        }
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * m_rotateSpeed);
    }

    private void SkyBoxRotationSpeedUpdate()
    {
        if (m_currentGamePhase != m_missionGameStats.EnemyID)
        {
            m_currentGamePhase = m_missionGameStats.EnemyID;
            m_rotateSpeed *= m_rotateSpeed;
        }
    }
}
