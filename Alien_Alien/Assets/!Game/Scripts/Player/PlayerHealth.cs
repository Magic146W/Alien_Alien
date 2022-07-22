using TMPro;
using UnityEngine;

public class PlayerHealth: MonoBehaviour
{
    private bool m_dead = false;
    public bool Dead { get { return m_dead; } }

    private GameObject m_player;
    [SerializeField] TextMeshProUGUI m_TMDeath;
    [SerializeField] GameObject m_textMeshEnable;
    [SerializeField] GameObject m_hp1;
    [SerializeField] GameObject m_hp2;
    [SerializeField] GameObject m_hp3;
    private int m_health = 3;
    private int m_getHealth;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void UpdateHealth()
    {
        m_getHealth = m_health;
        if (m_health <= 0)
        {
            m_hp1.SetActive(false);
            m_hp2.SetActive(false);
            m_hp3.SetActive(false);
        }
        else if (m_health == 1)
        {
            m_hp1.SetActive(false);
            m_hp2.SetActive(false);
            m_hp3.SetActive(true);
        }
        else if (m_health == 2)
        {
            m_hp1.SetActive(false);
            m_hp2.SetActive(true);
            m_hp3.SetActive(true);
        }
        else
        {
            m_hp1.SetActive(true);
            m_hp2.SetActive(true);
            m_hp3.SetActive(true);
        }

        if (m_health <= 0 && !m_dead)
        {
            Death();
            Destroy(m_player);
        }
    }

    private void Death()
    {
        m_textMeshEnable.SetActive(true);
        m_TMDeath.text = "DEATH";
        m_dead = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(collider.gameObject, 0.1f);
            m_health -= 1; // enemy attack
            UpdateHealth();
        }
    }
}
