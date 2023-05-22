using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthPickupScript: MonoBehaviour
{
    private Vector3 m_originalScale;
    private Vector3 m_scaleTo;

    private void Awake()
    {
        transform.Rotate(70, 0, 0);
        m_originalScale = transform.localScale;
        m_scaleTo = m_originalScale * 1.5f;
    }

    private void OnScale()
    {
        transform.DOScale(m_scaleTo, 2f).SetEase(Ease.InOutQuad).OnComplete(()=> {
            transform.DOScale(m_originalScale, 2f).SetEase(Ease.OutElastic).SetDelay(0.8f).OnComplete(OnScale);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurt")
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph.Heal();
            Destroy(gameObject, 0.1f);
        }
        if (other.tag == "Enemy")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
