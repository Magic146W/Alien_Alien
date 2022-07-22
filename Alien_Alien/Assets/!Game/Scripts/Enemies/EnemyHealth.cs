using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float m_health = 1;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private PlayerShooting m_playerShooting;


    private void Awake()
    {
        m_health = enemyData.Health;
        m_playerShooting = GameObject.FindGameObjectWithTag("Shooting").GetComponent<PlayerShooting>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            GameObject bullet = collider.gameObject;
            Color color = bullet.GetComponent<Renderer>().material.color;
            Material enemyMaterial = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().material;
            if (enemyMaterial.color == color)
            {
                Destroy(bullet);
                m_health -= m_playerShooting.ShotDamage;
                if (m_health <= 0)
                {
                    Destroy(gameObject);
                    //points.PointsGet(Mathf.RoundToInt(5 *eData.pointMult));
                }
                Destroy(gameObject);
            }
            else
            {
                Destroy(bullet);
            }
        }
    }
}
