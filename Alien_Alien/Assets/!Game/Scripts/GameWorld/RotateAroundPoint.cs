using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    [SerializeField]
    private float m_rotationSpeed;
    [SerializeField]
    private GameObject m_pivotObject;

    void Update()
    {
        transform.RotateAround(m_pivotObject.transform.position, new Vector3(0, 1, 0), m_rotationSpeed * Time.deltaTime);
    }
}
