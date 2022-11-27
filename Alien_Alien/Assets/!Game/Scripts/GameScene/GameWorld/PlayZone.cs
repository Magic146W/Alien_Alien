using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone: MonoBehaviour
{
    private GameObject m_player;
    private PlayerHealth m_hurt;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_hurt = GameObject.FindGameObjectWithTag("Hurt").GetComponent<PlayerHealth>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hurt")
        {
            m_hurt.Death();
            Destroy(m_player, 0.2f);
        }
        else
            Destroy(other.gameObject);
    }
}
