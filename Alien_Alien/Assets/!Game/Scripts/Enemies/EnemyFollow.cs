using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rb;
    //[SerializeField] EnemyData eData;

    private Transform m_player;
    private float m_speed = 4; //Add scriptable object in awake

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        // stop Follow if shooting type

        //if (!m_player.dead)
        Vector3 follow = Vector3.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime);
        m_rb.MovePosition(follow);
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
