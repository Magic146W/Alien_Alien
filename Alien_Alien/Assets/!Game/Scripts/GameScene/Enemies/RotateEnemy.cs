using UnityEngine;

public class RotateEnemy: MonoBehaviour
{
    [SerializeField]
    private Vector3 m_rotation;

    void Update()
    {
        transform.Rotate(m_rotation * Time.deltaTime);
    }
}