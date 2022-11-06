using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyHealth: MonoBehaviour
{
    [SerializeField] private EnemyData m_enemyData;
    public EnemyData DataForEnemy => m_enemyData;
    [SerializeField] private ParticleSystem m_particleDeath;
    [SerializeField] private Slider m_slider;
    [SerializeField] private Image m_fillImage;
    [SerializeField] private TMP_Text m_damageTakenText;

    private Color m_fullHealthColor = Color.magenta;
    private Color m_noHealthColor = Color.black;
    private Material m_enemyMaterial;
    private PlayerAttributes m_playerAttributes;
    private GameplayStats m_pointsGameStats;
    private GameplayStats m_missionGameStats;
    private GameplayStats m_killsGameStats;
    private ParticleSystem.MainModule m_particleMain;
    private RectTransform m_mainCanvas;

    private float m_health = 1;
    public float Health => m_health;
    private float m_startingHealth = 1;
    private bool m_dead;

    private void Awake()
    {
        m_health = m_enemyData.Health;
        m_startingHealth = m_health;
        m_playerAttributes = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerAttributes>();
        m_pointsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_points").GetComponent<GameplayStats>();
        m_missionGameStats = GameObject.FindGameObjectWithTag("GameplayStats_mission").GetComponent<GameplayStats>();
        m_killsGameStats = GameObject.FindGameObjectWithTag("GameplayStats_kills").GetComponent<GameplayStats>();
        m_mainCanvas = GameObject.FindGameObjectWithTag("Dynamic_Canvas").GetComponent<RectTransform>();
        m_particleMain = m_particleDeath.main;
        m_dead = false;
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        m_slider.value = (m_health / m_startingHealth) * 100;
        m_fillImage.color = Color.magenta;/*Color.Lerp(m_noHealthColor, m_fullHealthColor, m_health / m_startingHealth);*/
    }

    private void OnTriggerEnter(Collider collider)
    {
        var levelCorrection = m_playerAttributes.LevelCorrection;
        if (collider.gameObject.tag == "Bullet")
        {
            if (m_enemyMaterial == null)
                m_enemyMaterial = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().material;

            GameObject bullet = collider.gameObject;
            Color color = bullet.GetComponent<Renderer>().material.color;

            if (m_enemyMaterial.color == color)
            {
                Destroy(bullet);
                bool crit = false;
                float damage = m_playerAttributes.ShotDamage * m_playerAttributes.AllDamageMult * levelCorrection;

                if (m_playerAttributes.CriticalChance * levelCorrection >= UnityEngine.Random.Range(1, 101))
                {
                    damage *= m_playerAttributes.CriticalDamageMult * levelCorrection;
                    crit = true;

                    Debug.Log("Crit chance: " + m_playerAttributes.CriticalChance + "Crit damage: " + damage);

                }
                SpawnDamageText(crit, damage);
                m_health -= damage;

                SetHealthUI();
                Death();
            }
            else
            {
                Destroy(bullet);
            }
        }
    }

    private void Death()
    {
        var levelCorrection = m_playerAttributes.LevelCorrection;
        if (m_health <= 0 && !m_dead)
        {
            m_dead = true;
            if (m_enemyMaterial == null)
                m_enemyMaterial = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().material;

            m_particleMain.startColor = new ParticleSystem.MinMaxGradient(m_enemyMaterial.color);
            SpawnDeathParticles();
            var points = m_pointsGameStats.MyPoints + (int)((Mathf.RoundToInt(m_enemyData.Points) + m_playerAttributes.ExtraPoints) * levelCorrection);
            m_pointsGameStats.MyPoints = points;

            if (m_enemyData.ID == m_missionGameStats.EnemyID)
                m_missionGameStats.CurrentEnemyIDKills++;

            m_killsGameStats.AllKills++;
            Destroy(gameObject);
        }
    }

    private void SpawnDeathParticles()
    {
        ParticleSystem death = Instantiate(m_particleDeath, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        death.Play();
        Destroy(death.gameObject, death.main.duration);
    }

    private void SpawnDamageText(bool isCriticalHit, float damage)
    {
        var damageTXT = Instantiate(m_damageTakenText,m_mainCanvas.transform);
        damageTXT.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position);

        if (isCriticalHit)
            damageTXT.color = Color.magenta;
        damageTXT.text = "-" + damage;
    }

    public void BlackHole()
    {
        var shot = m_playerAttributes.ShotDamage * m_playerAttributes.AllDamageMult;
        float damage = m_startingHealth*0.05f;

        if (damage > shot * 2)
            damage = shot * 2;

        if (!m_dead)
        {
            try
            {
                SpawnDamageText(false, damage);
                m_health -= damage;
                SetHealthUI();
                Death();
            }
            catch (Exception e)
            { }
        }
    }
}
