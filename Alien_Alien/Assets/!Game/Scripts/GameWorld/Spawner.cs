using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    private List<float[]> m_spawnChanceList = new List<float[]>();

    private GameObject m_player;
    [SerializeField]
    GameObject m_triangleCone;
    float m_timer;
    PlayerHealth m_playerHealth;

    private GameObject[] m_enemies;
    [SerializeField]
    private GameObject m_enemyHolder;

    private GameplayStats m_missionGameStats;

    private float m_maxZSpawnPoint = 40;
    private float m_minZSpawnPoint = -40;
    private float m_maxXSpawnPoint = 90;
    private float m_minXSpawnPoint = -90;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_missionGameStats = GameObject.FindGameObjectWithTag("GameplayStats_mission").GetComponent<GameplayStats>();

        Transform playerTransform = m_player.transform;
        foreach (Transform item in playerTransform)
        {
            if (item.tag == "Hurt")
            {
                m_playerHealth = item.GetComponent<PlayerHealth>();
                break;
            }
        }

        m_timer = 0;
        int numberOfEnemies = m_enemyHolder.transform.childCount;
        m_enemies = new GameObject[numberOfEnemies];

        for (int i = 0; i < numberOfEnemies; i++)
        {
            m_enemies[i] = m_enemyHolder.transform.GetChild(i).gameObject;
        }

        SpawnChance();
    }

    private void SpawnChance()
    {
        m_spawnChanceList.Add(new float[8] { 1, 0, 0, 0, 0, 0, 0, 0 });
        m_spawnChanceList.Add(new float[8] { 0.8f, 0.2f, 0, 0, 0, 0, 0, 0 });
        m_spawnChanceList.Add(new float[8] { 0.6f, 0.3f, 0.1f, 0, 0, 0, 0, 0 });
        m_spawnChanceList.Add(new float[8] { 0.3f, 0.4f, 0.2f, 0.1f, 0, 0, 0, 0 });
        m_spawnChanceList.Add(new float[8] { 0.2f, 0.3f, 0.2f, 0.2f, 0.1f, 0, 0, 0 });
        m_spawnChanceList.Add(new float[8] { 0, 0.2f, 0.3f, 0.2f, 0.2f, 0.1f, 0, 0 });
        m_spawnChanceList.Add(new float[8] { 0, 0.1f, 0.2f, 0.2f, 0.3f, 0.1f, 0.1f, 0 });
        m_spawnChanceList.Add(new float[8] { 0, 0, 0.1f, 0.3f, 0.2f, 0.1f, 0.2f, 0.1f });
        m_spawnChanceList.Add(new float[8] { 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f, 0.125f });
    }

    private void FixedUpdate()
    {
        if (m_playerHealth.Dead == false)
        {
            m_timer += Time.deltaTime;
            if (m_timer > 2)
            {
                Vector3 spawnTransform = CalculateSpawnPoint();
                Instantiate(ChooseEnemyToSpawn(), spawnTransform, Quaternion.identity);
                m_timer = 0;
            }

        }
    }

    private Vector3 CalculateSpawnPoint()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);

        do
        {
            spawnPosition.x = Random.Range(m_minXSpawnPoint, m_maxXSpawnPoint);
            spawnPosition.z = Random.Range(m_minZSpawnPoint, m_maxZSpawnPoint);

        } while (Vector3.Distance(m_player.transform.position, spawnPosition) < 20);

        return spawnPosition;
    }

    private GameObject ChooseEnemyToSpawn()
    {
        float rnd = Random.value;
        float chance = 0;

        float[] spawnTable = m_spawnChanceList[m_missionGameStats.EnemyID];
        for (int i = 0; i < spawnTable.Length; i++)
        {
            chance = spawnTable[i]+chance;
            if (chance>=rnd)
            {
                return m_enemies[i];
            }
        }

        return m_enemies[0];
    }
}
