using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightScript: MonoBehaviour
{
    [SerializeField]
    private Transform m_sunlight;
    private float speed = 1.0f;

    void Update()
    {
        Vector3 targetDirection = m_sunlight.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
