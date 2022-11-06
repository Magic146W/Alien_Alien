using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole_ActiveSkill: MonoBehaviour
{
    private float m_forcePull= 30;
    private float m_lifeTime = 10;
    private List<EnemyHealth> m_health = new List<EnemyHealth>();

    private void Awake()
    {
        Destroy(gameObject, m_lifeTime);
        InvokeRepeating("DamageToEnemy", 0f, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var health = other.gameObject.GetComponent<EnemyHealth>();
            m_health.Add(health);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var pulledEnemy = other.gameObject;
            pulledEnemy.transform.position = Vector3.MoveTowards(pulledEnemy.transform.position, transform.position, m_forcePull * Time.deltaTime);
        }
    }

    private void DamageToEnemy()
    {
        for (int item = 0; item < m_health.Count; item++)
        {
            if (m_health[item].Health <= 0)
                m_health.Remove(m_health[item]);
            else
                m_health[item].BlackHole();
        }
    }
}
