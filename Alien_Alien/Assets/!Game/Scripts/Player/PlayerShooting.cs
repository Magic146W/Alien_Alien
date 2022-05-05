using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour
{
    private Transform m_target;
    List<Collider> m_enemiesInRange = new List<Collider>();
    private SphereCollider m_sphereCollider;
    private float m_timeToShoot = 2f;

    void Start()
    {
        m_sphereCollider = GetComponent<SphereCollider>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void FixedUpdate()
    {
        m_timeToShoot += Time.deltaTime;
    }

    void UpdateTarget()
    {
        Debug.Log("0.5s?");

        float shortestDistance = Mathf.Infinity;
        GameObject neareastEnemy = null;

        foreach (Collider enemy in m_enemiesInRange)
        {
            if (enemy == null)
            {
                m_enemiesInRange.Remove(enemy);
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <  shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                neareastEnemy = enemy.gameObject;
            }
        }
        if (neareastEnemy!=null)
        {
            ShootNearest(neareastEnemy);
        }
    }

    private void ShootNearest(GameObject target)
    {     
        if (m_timeToShoot > 2)
        {
            Destroy(target,0.5f);
            m_timeToShoot = 0;
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (!m_enemiesInRange.Contains(collider))
            {
            m_enemiesInRange.Add(collider);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (m_enemiesInRange.Contains(collider))
            {
                m_enemiesInRange.Remove(collider);
            }
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy" && !m_enemiesInRange.Contains(collider))
        {
            m_enemiesInRange.Add(collider);
        }
    }
}

