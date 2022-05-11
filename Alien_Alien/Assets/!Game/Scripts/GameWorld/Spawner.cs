using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] EnemyData eData;
    //private int damage;
    //public float health;
    //private float speed;
    //Health player;
    //Points points;  
    //[SerializeField] int spawnChild;
    
    private GameObject m_player;
    [SerializeField] 
    GameObject m_triangleCone;
    float m_timer;

    private float m_maxZSpawnPoint = 40;
    private float m_minZSpawnPoint = -40;
    private float m_maxXSpawnPoint = 90;
    private float m_minXSpawnPoint = -90;

    void Start()
    {
        //points = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
        //damage = eData.damage;
        //health = eData.health;
        //speed = eData.speed;
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_timer = 0;
    }

    //void Update()
    //{
    //    if (health <= 0)
    //    {
    //        points.PointsGet(Mathf.RoundToInt(100 * eData.pointMult));
    //        Destroy(gameObject);
    //    }
    //}

    void FixedUpdate()
    {
        m_timer += Time.deltaTime;
        if (m_timer > 2)
        {
            Vector3 spawnTransform = CalculateSpawnPoint();     
            Instantiate(m_triangleCone, spawnTransform, Quaternion.identity);
            m_timer = 0;
        }

        //if (!player.dead)
        //{
        //    Vector3 follow = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //    rb.MovePosition(follow);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    Vector3 CalculateSpawnPoint()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);

        do
        {
            spawnPosition.x = Random.Range(m_minXSpawnPoint,m_maxXSpawnPoint);
            spawnPosition.z = Random.Range(m_minZSpawnPoint, m_maxZSpawnPoint);

        } while (Vector3.Distance(m_player.transform.position, spawnPosition) < 15);

        return spawnPosition;

    }
}
