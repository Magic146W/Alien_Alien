using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour
{
    List<Collider> m_enemiesInRange = new List<Collider>();
    private float m_timeToShoot = 2f;
    private Material m_playerMaterial;
    GameObject m_playerObject;

    [SerializeField]
    private GameObject m_bullet;

    private float m_bulletSpeed = 10000;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        m_playerObject = player.transform.GetChild(0).gameObject;
        m_playerMaterial = m_playerObject.GetComponent<Renderer>().material;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    private void FixedUpdate()
    {
        m_timeToShoot += Time.deltaTime;
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject neareastEnemy = null;
        foreach (Collider enemy in m_enemiesInRange)
        {
            if (enemy == null)
            {
                m_enemiesInRange.Remove(enemy);
                return;
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                neareastEnemy = enemy.gameObject;
            }
        }
        if (neareastEnemy != null)
        {
            ShootNearest(neareastEnemy);
        }
    }

    private void ShootNearest(GameObject target)
    {
        if (m_timeToShoot > 1)
        {
            GameObject enemy = target.transform.GetChild(0).GetChild(0).gameObject;
            Material material = enemy.GetComponent<Renderer>().material;
            ShotBullet(target);
            m_timeToShoot = 0;



            //if (m_playerMaterial.color == material.color)
            //{
            //    Destroy(target, 0.5f);
            //}
        }

    }

    private void ShotBullet(GameObject target)
    {
        GameObject instantiated = Instantiate(m_bullet, transform.position, transform.rotation);
        instantiated.GetComponent<Renderer>().material.color = m_playerMaterial.color;
        instantiated.GetComponent<Rigidbody>().AddForce((target.transform.position - instantiated.transform.position).normalized *m_bulletSpeed);
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

