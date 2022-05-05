using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float m_timeBetweenAttacks;
    private bool m_ifAttacked;
    private float m_attackRange;
    private void AttackPlayer()
    {
        if (!m_ifAttacked)
        {
            //Attack
            m_ifAttacked = true;
            Invoke(nameof(ResetAttack), m_timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        m_ifAttacked = false;
    }
}
