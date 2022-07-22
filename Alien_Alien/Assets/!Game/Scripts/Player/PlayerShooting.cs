using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour
{
    List<Collider> m_enemiesInRange = new List<Collider>();
    private Material m_helpMaterial;
    private Transform m_gunTransform;
    [SerializeField]
    private GameObject m_bullet;
    [SerializeField]
    private PlayerData playerData;

    private float m_bulletSpeed = 5000;
    private float m_timeToShoot;
    private float m_shotDamage = 1f;
    private float m_shotSpeed = 1f;

    void Start()
    {
        SetStats();

        m_helpMaterial = GameObject.FindGameObjectWithTag("PlayerMaterial").GetComponent<Renderer>().material;
        m_gunTransform = GameObject.FindGameObjectWithTag("Gun").transform;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    private void SetStats()
    {
        m_shotDamage = playerData.ShotDamage * playerData.BaseDamageMult;
        m_bulletSpeed *= playerData.BulletSpeedMult;
        m_shotSpeed *= playerData.ShotSpeedMult;
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
        MoveGun(target);
        if (m_timeToShoot > m_shotSpeed)
        {
            ShotBullet(target);
            m_timeToShoot = 0;
        }
    }

    private void ShotBullet(GameObject target)
    {
        GameObject instantiated = Instantiate(m_bullet, transform.position, transform.rotation);
        instantiated.GetComponent<Renderer>().material.color = m_helpMaterial.color;
        instantiated.GetComponent<Rigidbody>().AddForce((target.transform.position - instantiated.transform.position).normalized * m_bulletSpeed);
    }

    private void MoveGun(GameObject target)
    {
        Vector3 relativePos = target.transform.position - m_gunTransform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        m_gunTransform.rotation = rotation;
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

    public float ShotDamage => m_shotDamage;
}

