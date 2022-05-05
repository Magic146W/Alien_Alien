using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour
{
    private Transform m_target;
    List<GameObject> m_enemiesInRange = new List<GameObject>();

    void Start()
    {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject neareastEnemy = null;

        foreach (GameObject enemy in m_enemiesInRange)
        {
            if (enemy == null)
            {
                m_enemiesInRange.Remove(enemy);
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <  shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                neareastEnemy = enemy;
            }
        }
        if (neareastEnemy!=null)
        {
            m_target = neareastEnemy.transform;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            m_enemiesInRange.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            try
            {
                m_enemiesInRange.Remove(collider.gameObject);
            }
            catch (System.Exception)
            {
                Debug.Log("Nie ma obiektu do usuniêcia");
            }
        }
    }
}
