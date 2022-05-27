using UnityEngine;

public class AnimateHelper: MonoBehaviour
{
    [SerializeField]
    private Vector3 m_rotation;

    void Update()
    {
        transform.Rotate(m_rotation * Time.deltaTime);
        //Add move up and down
    }
}