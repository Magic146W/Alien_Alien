using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSwap: MonoBehaviour
{
    [SerializeField]
    private FixedJoystick m_colorJoystick;
    private Material m_material;
    private Color m_color;

    void Start()
    {
        m_material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (m_colorJoystick.Horizontal == 0 && m_colorJoystick.Vertical == 0)
        {
            if (m_material.color != Color.white)
            {
                m_material.color = Color.white;
            }
        }
        else UpdateColorJoystick();
    }

    private void UpdateColorJoystick()
    {
        if (m_colorJoystick.Horizontal < 0 && m_colorJoystick.Vertical < 0 && m_material.color != Color.blue)
        {
            m_material.color = Color.blue;
        }
        else if (m_colorJoystick.Horizontal > 0 && m_colorJoystick.Vertical < 0 && m_material.color != Color.yellow)
        {
            m_material.color = Color.yellow;
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
    //void Start()
    //{
    //    m_material = GetComponent<Renderer>().material;
    //    InvokeRepeating("UpdateColor", 0f, 0.5f);
    //}

    //private void UpdateColor()
    //{
    //    if (m_colorJoystick.Horizontal == 0 && m_colorJoystick.Vertical == 0)
    //    {
    //        if (m_material.color != Color.white)
    //        {
    //            m_material.color = Color.white;
    //        }
    //    }

    //    UpdateColorJoystick();
    //}

    //private void UpdateColorJoystick()
    //{
    //    if (m_colorJoystick.Horizontal < 0 && m_colorJoystick.Vertical < 0 && m_material.color != Color.blue)
    //    {
    //        m_material.color = Color.blue;
    //    }
    //    else if (m_colorJoystick.Horizontal > 0 && m_colorJoystick.Vertical < 0 && m_material.color != Color.yellow)
    //    {
    //        m_material.color = Color.yellow;
    //    }
    //    else if (m_colorJoystick.Horizontal < 0 && m_colorJoystick.Vertical > 0 && m_material.color != Color.red)
    //    {
    //        m_material.color = Color.red;
    //    }
    //    else if (m_colorJoystick.Horizontal > 0 && m_colorJoystick.Vertical > 0 && m_material.color != Color.green)
    //    {
    //        m_material.color = Color.green;
    //    }
    //}
