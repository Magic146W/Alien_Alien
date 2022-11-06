using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class PlayerHealth: MonoBehaviour
{
    private bool m_dead = false;
    public bool Dead { get { return m_dead; } }

    private GameObject m_player;
    private PlayerAttributes m_playerAttributes;

    private EnemyHealth m_enemy;
    [SerializeField] private GameObject m_TMDeath;
    [SerializeField] private GameObject m_hpUI;
    [SerializeField] private GameObject m_Restart;
    [SerializeField] private GameObject m_healthLayout;
    [SerializeField] private GameObject m_playerBody;
    private Material m_playerMaterial;
    private List<GameObject> m_healthList = new List<GameObject>();

    private int m_currentMaxHealth = 3;
    private int m_health;
    private bool m_invincibility;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_playerAttributes = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerAttributes>();
        m_playerMaterial = m_playerBody.GetComponent<Renderer>().material;
        m_currentMaxHealth = m_playerAttributes.Health;
        m_health = m_currentMaxHealth;
        m_invincibility = false;
        for (int i = 0; i < m_health; i++)
        {
            HealthManagement();
        }

        InvokeRepeating("UpdateHealth", 0, 0.1f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            m_enemy = collider.GetComponent<EnemyHealth>();
            int damage = (int)m_enemy.DataForEnemy.BaseDamage;
            if (!m_invincibility)
            {
                TakeDamage(damage);
            }
            Destroy(collider.gameObject, 0.1f);
        }
    }

    private void UpdateHealth()
    {
        if (m_playerAttributes.Health + m_playerAttributes.ExtraLife > m_currentMaxHealth)
        {
            m_health++;
            m_currentMaxHealth = (int)(m_playerAttributes.Health + m_playerAttributes.ExtraLife);
            HealthManagement();
        }

        if (m_health <= 0 && !m_dead)
        {

            Death();
            Destroy(m_player);
        }
    }

    private void TakeDamage(int damage)
    {
        StartCoroutine(ImmuneToDamage());

        m_health -= damage;
        for (int i = 0; i < damage; i++)
        {
            for (int j = (m_healthList.Count - 1); j >= 0; j--)
            {
                if (m_healthList[j].activeSelf)
                {
                    m_healthList[j].SetActive(false);
                    break;
                }
            }
        }
    }

    private void Death()
    {
        m_TMDeath.SetActive(true);
        m_TMDeath.GetComponent<TextMeshProUGUI>().text = "DEATH";
        m_Restart.SetActive(true);
        m_dead = true;
    }

    private void HealthManagement()
    {
        GameObject health = Instantiate(m_hpUI);
        m_healthList.Add(health);
        health.SetActive(true);
        health.transform.SetParent(m_healthLayout.transform, false);
        SortHealthUI();
    }

    private void SortHealthUI()
    {
        int activeHP=0;
        foreach (var hp in m_healthList)
        {
            if (hp.activeSelf)
            {
                activeHP++;
            }
            hp.SetActive(false);
        }

        for (int i = 0; i < activeHP; i++)
        {
            m_healthList[i].SetActive(true);
        }
    }

    private void Heal()
    {
        int health = 0;
        foreach (var hp in m_healthList)
        {
            hp.SetActive(true);
            health++;
        }
        m_health = health;
    }

    private IEnumerator ImmuneToDamage()
    {
        m_invincibility = true;
        var playerColor = m_playerMaterial.color;
        Sequence flashColor = DOTween.Sequence();
        flashColor.Append(m_playerMaterial.DOColor(Color.black, 0.25f)).Append(m_playerMaterial.DOColor(playerColor, 0.25f).SetLoops(20, LoopType.Restart));
        yield return new WaitForSeconds(3f);
        flashColor.Complete();
        m_invincibility = false;
    }
}
