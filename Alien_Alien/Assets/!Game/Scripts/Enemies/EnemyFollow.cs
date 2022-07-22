using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rb;
    [SerializeField] 
    EnemyData enemyData;
    PlayerHealth m_playerHealth;
    private Transform m_player;
    private float m_speed = 5; 

    private void Awake()
    {
        m_speed = enemyData.Speed;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        m_playerHealth = player.transform.GetChild(2).GetComponent<PlayerHealth>();
        m_player = player.transform;
    }

    private void FixedUpdate()
    {
        if (m_playerHealth.Dead == false)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        // stop Follow if shooting type
        //if (!m_player.dead)
        Vector3 follow = Vector3.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime);
        m_rb.MovePosition(follow);
    }
}
