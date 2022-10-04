using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class EnemyHealth: MonoBehaviour
{
    private float m_health = 1;
    private bool m_dead;
    [SerializeField]
    private EnemyData m_enemyData;
    public EnemyData DataForEnemy => m_enemyData;

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
        m_health = m_enemyData.Health;
        m_playerAttributes = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerAttributes>();
        m_pointsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_points").GetComponent<GameplayStats>();
        m_missionGameStats = GameObject.FindGameObjectWithTag("GameplayStats_mission").GetComponent<GameplayStats>();
        m_killsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_kills").GetComponent<GameplayStats>();
        m_particleMain = m_particleDeath.main;
        m_dead = false;
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

                float damage = m_playerAttributes.ShotDamage * m_playerAttributes.AllDamageMult;
                if (m_playerAttributes.CriticalChance <= UnityEngine.Random.Range(1,101))
                {
                    damage *= damage * m_playerAttributes.CriticalDamageMult;
                }

                m_health -= damage;
                Debug.Log("Damage: " + (m_playerAttributes.ShotDamage * m_playerAttributes.AllDamageMult));
                if (m_health <= 0 && !m_dead)
                {
                    m_dead = true;
                    m_particleMain.startColor = new ParticleSystem.MinMaxGradient(m_enemyMaterial.color);
                    SpawnDeathParticles();
                    m_pointsGameStats.MyPoints = m_pointsGameStats.MyPoints + Mathf.RoundToInt(m_enemyData.Points) + (int)m_playerAttributes.ExtraPoints;

                    if (m_enemyData.ID == m_missionGameStats.EnemyID)
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
