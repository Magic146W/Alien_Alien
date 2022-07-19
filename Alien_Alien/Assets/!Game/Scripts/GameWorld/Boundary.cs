using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary: MonoBehaviour
{
    private Transform m_player;
    [SerializeField]
    private Transform[] m_boundaryTransform = new Transform[4];

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();       
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
        if (m_boundaryTransform[bIndex].position.z != 0)
        {
            if (m_boundaryTransform[bIndex].position.z > 0)
            {
                m_player.transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_boundaryTransform[bIndex-1].position.z + 10);
            }
            else
            {
                m_player.transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_boundaryTransform[bIndex+1].position.z - 10);
            }
        }
        else
        {
            if (m_boundaryTransform[bIndex].position.x > 0)
            {
                m_player.transform.position = new Vector3(m_boundaryTransform[bIndex+1].position.x + 5, m_player.transform.position.y, m_player.transform.position.z);
            }
            else
            {
                m_player.transform.position = new Vector3(m_boundaryTransform[bIndex-1].position.x - 5, m_player.transform.position.y, m_player.transform.position.z);
            }
        }      
    }
}
