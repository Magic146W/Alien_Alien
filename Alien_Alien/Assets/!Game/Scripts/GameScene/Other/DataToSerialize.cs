using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataToSerialize : MonoBehaviour
{
    private int m_kills = 0;
    private int m_points = 0;
    private float m_enemy = 0;
    private int m_level = 0;

    public int Kills { 
        get { return m_kills; }
        set { m_kills = value; }
    }
    public int Points
    {
        get { return m_points; }
        set { m_points = value; }
    }
    public float Enemy
    {
        get { return m_enemy; }
        set { m_enemy = value; }
    }
    public int Level
    {
        get { return m_level ; }
        set { m_level = value; }
    }
}
