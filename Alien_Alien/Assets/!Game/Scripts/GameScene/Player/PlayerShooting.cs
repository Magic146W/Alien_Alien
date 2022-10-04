using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour
{
    List<Collider> m_enemiesInRange = new List<Collider>();
    private Material m_helpMaterial;
    private Transform m_gunTransform;
    private PlayerAttributes m_playerAttributes;
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private ParticleSystem m_gunShot;
    [SerializeField] private Transform m_gunMuzzle;

    private float m_bulletSpeed = 5000;
    private float m_timeToShoot;
    private float m_shotSpeed = 1f;

    void Start()
    {
        m_playerAttributes = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerAttributes>();
        m_helpMaterial = GameObject.FindGameObjectWithTag("PlayerMaterial").GetComponent<Renderer>().material;
        m_gunTransform = GameObject.FindGameObjectWithTag("Gun").transform;

        m_gunShot.Stop();
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
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
        if (m_timeToShoot > m_playerAttributes.ShotSpeedMult)
        {
            m_timeToShoot = 0;
            StartCoroutine(ShotBullet(target.transform));
        }
    }

    private IEnumerator ShotBullet(Transform target)
    {
        for (int i = 0; i < 3/*(int)m_playerAttributes.MoreProjectiles*/; i++)
        {
            m_gunShot.Play();
            GameObject instantiated = Instantiate(m_bullet, transform.position, transform.rotation);
            instantiated.GetComponent<Renderer>().material.color = m_helpMaterial.color;
            if (target != null)
            {
                instantiated.GetComponent<Rigidbody>().AddForce((target.position - instantiated.transform.position).normalized * m_bulletSpeed);
            }
            else
            {
                instantiated.GetComponent<Rigidbody>().AddForce(m_gunMuzzle.forward.normalized * m_bulletSpeed);
            }
            yield return new WaitForSeconds(0.15f);
        }
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
}

