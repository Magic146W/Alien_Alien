using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSwap: MonoBehaviour
{
    [SerializeField]
    private FixedJoystick m_colorJoystick;
    private Material m_material;

    void Start()
    {
        m_material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        UpdateColorJoystick();
    }

    private void UpdateColorJoystick()
    {
        if (m_colorJoystick.Horizontal < 0 && m_colorJoystick.Vertical < 0 && m_material.color != Color.cyan)
        {
            m_material.color = Color.cyan;
        }
        else if (m_colorJoystick.Horizontal > 0 && m_colorJoystick.Vertical < 0 && m_material.color != Color.white)
        {
            m_material.color = Color.white;
        }
        else if (m_colorJoystick.Horizontal < 0 && m_colorJoystick.Vertical > 0 && m_material.color != Color.red)
        {
            m_material.color = Color.red;
        }
        else if (m_colorJoystick.Horizontal > 0 && m_colorJoystick.Vertical > 0 && m_material.color != Color.green)
        {
            m_material.color = Color.green;
        }
    }
}
