using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Teleport_ActiveSkill: MonoBehaviour
{
    [SerializeField] ParticleSystem m_teleport;
    private Image m_grayPanelImage;
    private GameObject m_player;
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    private bool m_ready;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_grayPanelImage = GameObject.FindGameObjectWithTag("Gray").GetComponent<Image>();
    }

    private void Start()
    {
        m_grayPanelImage.color = new Color32(30, 30, 30, 180);
        Time.timeScale = 0.2f;
        m_ready = true;
    }

    private void Update()
    {
        if (m_ready)
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                m_grayPanelImage.color = new Color32(0, 0, 0, 0);
                SetPosition();
                m_ready = false;
                Time.timeScale = 1;
            }
    }

    private void SetPosition()
    {
        Plane plane = new Plane(Vector3.up,0);
        float rayDistance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out rayDistance))
        {
            StartTeleportParticles();
            var newPosition = ray.GetPoint(rayDistance);
            m_player.transform.position = new Vector3(newPosition.x, m_player.transform.position.y, newPosition.z);
            StartTeleportParticles();
        }
    }

    private void StartTeleportParticles()
    {
        ParticleSystem teleport = Instantiate(m_teleport, new Vector3(m_player.transform.position.x, 0, m_player.transform.position.z), Quaternion.identity);
        teleport.transform.eulerAngles = new Vector3(teleport.transform.eulerAngles.x - 90, teleport.transform.eulerAngles.y, teleport.transform.eulerAngles.z);

        teleport.Play();
        Destroy(teleport.gameObject, teleport.main.duration);
    }
}
