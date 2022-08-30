using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelection: MonoBehaviour
{
    [SerializeField]
    private GameObject m_skillUI;
    private SkillsContainer m_skillContainer;
    private PlayerAttributes m_playerAttributes;
    private PlayerAttributes m_playerSkills;

    [SerializeField]
    private Button m_button;
    [SerializeField]
    private Image m_image;
    [SerializeField]
    private TMP_Text m_text;

    void Awake()
    {
        Button btn = m_button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        m_skillContainer = GameObject.FindGameObjectWithTag("SkillContainer").GetComponent<SkillsContainer>();
        m_playerAttributes = GameObject.FindGameObjectWithTag("Attributes").GetComponent<PlayerAttributes>();
        m_playerSkills = GameObject.FindGameObjectWithTag("Skills").GetComponent<PlayerAttributes>();
    }

    private void TaskOnClick()
    {
        ResumeGame();
        m_skillUI.SetActive(false);


        m_playerAttributes.ShotDamage += 50; //change to skill selection
    }

    private void SkillImageAndText(int rnd)
    {
        m_image.sprite = m_skillContainer.PlayerSkillList[rnd].SkillImage;
        m_text.text = m_skillContainer.PlayerSkillList[rnd].SkillName;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        LevelUp.OnLevelUp += SkillSelect;
    }

    private void OnDisable()
    {
        LevelUp.OnLevelUp -= SkillSelect;
    }

    void SkillSelect()
    {
        int rnd = Random.Range(0,m_skillContainer.PlayerSkillList.Count);
        SkillImageAndText(rnd);

        int id = m_skillContainer.PlayerSkillList[rnd].SkillID;
        int groupID = m_skillContainer.PlayerSkillList[rnd].GroupID; 
        if (groupID == 0)           //get group ID
        {
            //       m_playerAttributes.dictionary.getkey(id).value = x     //find id by dictionary //change value?  
        }
        else if (groupID == 1)
        {

        }
    }
}
