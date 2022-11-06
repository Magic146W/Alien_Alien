using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickPlacement: MonoBehaviour
{
    [SerializeField] private Image m_joystickArea;
    [SerializeField] private GameObject m_joystick;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    private void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            bool areaRay = false;
            bool joystickRay = false;
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == m_joystickArea.name)
                    areaRay = true;
                if (result.gameObject.name == m_joystick.name)
                    joystickRay = true;
            }

            if (areaRay && !joystickRay)
                m_joystick.transform.position = Input.mousePosition;

        }
    }
}
