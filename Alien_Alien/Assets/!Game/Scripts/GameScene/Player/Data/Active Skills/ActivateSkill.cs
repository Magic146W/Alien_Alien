using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSkill: MonoBehaviour
{
    [SerializeField] private GameObject m_blackHoleObject;
    [SerializeField] private GameObject m_teleport;
    [SerializeField] private GameObject m_activeSkillPanel;
    [SerializeField] private Button m_blackHoleBTN;
    [SerializeField] private Button m_teleportBTN;
    [SerializeField] private Button m_skillButtonBTN;
    private float m_time = 0;
    private float m_skillTime = 5;
    private Image m_image;
    private bool m_wait = true;
    private int m_skillIndex = 0;
    private Transform m_player;

    private void Awake()
    {
        m_image = gameObject.GetComponent<Image>();
        Button btnActiveSkill = m_skillButtonBTN.GetComponent<Button>();
        m_skillButtonBTN.onClick.AddListener(ClickSkill);
        Button btnBlackHole = m_blackHoleBTN.GetComponent<Button>();
        m_blackHoleBTN.onClick.AddListener(SelectBlackHole);
        Button btnTeleport = m_teleportBTN.GetComponent<Button>();
        m_teleportBTN.onClick.AddListener(SelectTeleport);

        m_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        m_time += Time.deltaTime;
        if (m_time > m_skillTime && m_wait)
        {
            m_wait = false;
            m_image.raycastTarget = true;
            var color = new Color32(255,173,0,180);
            m_image.color = color;
        }
    }

    public void ClickSkill()
    {
        if (!m_wait)
        {
            m_time = 0;
            m_wait = true;
            m_image.raycastTarget = false;
            var color = new Color32(30,30,30,180);
            m_image.color = color;

            if (m_skillIndex == 0)
            {
                Instantiate(m_blackHoleObject, m_player.position, new Quaternion(0, 0, 0, 0), transform);
            }
            else
            {
                Instantiate(m_teleport, m_player.position, new Quaternion(0, 0, 0, 0), transform);
            }
        }
    }

    private void SelectBlackHole()
    {
        m_skillIndex = 0;
        m_skillTime = 30;
        StartGame();
    }

    private void SelectTeleport()
    {
        m_skillTime = 15;
        m_skillIndex = 1;
        StartGame();
    }

    private void StartGame()
    {
        m_activeSkillPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
