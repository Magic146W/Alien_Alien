using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    private float m_health = 1;
    [SerializeField]
    private EnemyData enemyData;    
    [SerializeField]
    private ParticleSystem m_particleDeath;

    private Material m_enemyMaterial;
    private PlayerAttributes m_playerAttributes;
    private GameplayStats m_pointsGameStats;
    private GameplayStats m_missionGameStats;
    private GameplayStats m_killsGameStats;
    private ParticleSystem.MainModule m_particleMain;

    private void Awake()
    {
        m_health = enemyData.Health;
        m_playerAttributes = GameObject.FindGameObjectWithTag("Attributes").GetComponent<PlayerAttributes>();
        m_pointsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_points").GetComponent<GameplayStats>();
        m_missionGameStats = GameObject.FindGameObjectWithTag("GameplayStats_mission").GetComponent<GameplayStats>();
        m_killsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_kills").GetComponent<GameplayStats>();
        m_particleMain = m_particleDeath.main;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            if (m_enemyMaterial == null)
            {
                m_enemyMaterial = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().material;
            }

            GameObject bullet = collider.gameObject;
            Color color = bullet.GetComponent<Renderer>().material.color;
            
            if (m_enemyMaterial.color == color)
            {
                Destroy(bullet);
                m_health -= m_playerAttributes.ShotDamage;
                if (m_health <= 0)
                {
                    m_particleMain.startColor = new ParticleSystem.MinMaxGradient(m_enemyMaterial.color);
                    SpawnDeathParticles();
                    m_pointsGameStats.MyPoints = m_pointsGameStats.MyPoints + Mathf.RoundToInt(enemyData.Points);

                    if (enemyData.ID == m_missionGameStats.EnemyID)
                    {
                        m_missionGameStats.CurrentEnemyIDKills++;
                    }
                    m_killsGameStats.AllKills++;

                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(bullet);
            }
        }
    }

    private void SpawnDeathParticles()
    {
        ParticleSystem death = Instantiate(m_particleDeath, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        death.Play();   
        Destroy(death.gameObject, death.main.duration);
    }
}
