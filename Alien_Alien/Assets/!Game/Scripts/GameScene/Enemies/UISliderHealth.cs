using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISliderHealth: MonoBehaviour
{
    public bool m_isRelativeRotation = true;
    private Quaternion m_relativeRotation;

    private void Start()
    {
        m_relativeRotation = transform.parent.localRotation;
    }

    private void Update()
    {
        if (m_isRelativeRotation)
        {
            transform.rotation = m_relativeRotation;
        }
    }
}
