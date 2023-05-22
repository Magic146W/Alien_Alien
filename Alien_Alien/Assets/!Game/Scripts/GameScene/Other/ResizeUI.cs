using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeUI : MonoBehaviour
{
    [SerializeField] private RectTransform m_otherRectTransform;
    private RectTransform m_myRectTransform;

    void Start()
    {
        m_myRectTransform = gameObject.GetComponent<RectTransform>();
        m_myRectTransform.anchoredPosition = m_otherRectTransform.anchoredPosition;
    }
}
