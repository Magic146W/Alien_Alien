using UnityEngine;

public class AnimateHelper: MonoBehaviour
{
    [SerializeField]
    private Vector3 m_rotation;
    private float m_moveToHeight; 
    private float m_amountToMove = 0.05f;
    private float m_scale = 5;
    private bool m_flip;

    private void Awake()
    {
        InvokeRepeating("UpdateTransform", 0f, 0.05f);
        m_moveToHeight = transform.position.y;
        m_flip = true;
    }

    void UpdateTransform()
    {
        transform.Rotate(m_rotation * Time.deltaTime);

        float heightMax = m_moveToHeight+1, heightMin = m_moveToHeight-1;    
        if (m_flip)
        {
            transform.position += -transform.forward * m_amountToMove;
            transform.localScale += new Vector3(m_scale, m_scale, m_scale);

            if (transform.position.y > heightMax)
            {
                m_flip = false;
            }
        }
        else if (!m_flip)
        {
            transform.position -= -transform.forward * m_amountToMove;
            transform.localScale -= new Vector3(m_scale, m_scale, m_scale);

            if (transform.position.y < heightMin)
            {
                m_flip = true;
            }
        }
    }
}