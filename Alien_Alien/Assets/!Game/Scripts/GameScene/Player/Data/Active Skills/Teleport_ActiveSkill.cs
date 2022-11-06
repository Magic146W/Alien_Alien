using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Teleport_ActiveSkill: MonoBehaviour
{
    private Image m_grayPanelImage;
    private GameObject m_player;
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    private bool m_ready;

    private void Awake()
    {
        //var canvas = GameObject.FindGameObjectWithTag("Main_Canvas");
        //m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        //m_EventSystem = canvas.GetComponent<EventSystem>(); //!
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_grayPanelImage = GameObject.FindGameObjectWithTag("Gray").GetComponent<Image>();
    }

    private void Start()
    {
        m_grayPanelImage.color = new Color32(30,30,30,180);
        Time.timeScale = 0.1f;
        m_ready = true;
    }

    private void Update()
    {
        if (m_ready)
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                m_grayPanelImage.color = new Color32(0, 0, 0, 0);
                m_player.transform.position = Input.mousePosition;
                m_ready = false;
                Time.timeScale = 1;
            }
    }
}
