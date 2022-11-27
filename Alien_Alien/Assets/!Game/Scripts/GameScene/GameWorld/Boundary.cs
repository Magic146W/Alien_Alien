using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary: MonoBehaviour
{
    private Transform m_player;
    private Transform[] m_boundaries;
    [SerializeField] private GameObject m_boundaryHolder;
    [SerializeField] private ParticleSystem m_teleport;

    private void Awake()
    {
        m_teleport.Stop();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        int numberOfBoundaries = m_boundaryHolder.transform.childCount;
        m_boundaries = new Transform[numberOfBoundaries];

        for (int i = 0; i < numberOfBoundaries; i++)
        {
            m_boundaries[i] = m_boundaryHolder.transform.GetChild(i).gameObject.transform;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            GameObject bullet = collider.gameObject;
            Destroy(bullet, 0.1f);
        }

        if (collider.gameObject.tag == "Hurt")
        {
            int boundaryIndex = 0;
            if (transform.position.z < 0)
            {
                boundaryIndex = 0;
            }
            else if (transform.position.z > 0)
            {
                boundaryIndex = 1;
            }
            else if (transform.position.x > 0)
            {
                boundaryIndex = 2;
            }
            else if (transform.position.x < 0)
            {
                boundaryIndex = 3;
            }
            TeleportPlayer(boundaryIndex);
        }
    }
    private void TeleportPlayer(int bIndex)
    {
        if (m_boundaries[bIndex].position.z != 0)
        {
            StartTeleportParticles(0);
            if (m_boundaries[bIndex].position.z > 0)
            {
                m_player.transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_boundaries[bIndex - 1].position.z + 10);
            }
            else
            {
                m_player.transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_boundaries[bIndex + 1].position.z - 10);
            }
            StartTeleportParticles(0);
        }
        else
        {
            StartTeleportParticles(90);
            if (m_boundaries[bIndex].position.x > 0)
            {
                m_player.transform.position = new Vector3(m_boundaries[bIndex + 1].position.x + 5, m_player.transform.position.y, m_player.transform.position.z);
            }
            else
            {
                m_player.transform.position = new Vector3(m_boundaries[bIndex - 1].position.x - 5, m_player.transform.position.y, m_player.transform.position.z);
            }
            StartTeleportParticles(90);
        }
    }

    private void StartTeleportParticles(int rotateBy)
    {
        ParticleSystem teleport = Instantiate(m_teleport, new Vector3(m_player.transform.position.x, 9, m_player.transform.position.z), Quaternion.identity);

        teleport.transform.eulerAngles = new Vector3(teleport.transform.eulerAngles.x, teleport.transform.eulerAngles.y + rotateBy, teleport.transform.eulerAngles.z);

        teleport.Play();
        Destroy(teleport.gameObject, teleport.main.duration);
    }
}
