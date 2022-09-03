using System;
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
    private PlayerSkills m_playerSkills;
    private LevelUp m_levelUP;
    private int abilitySelection = 0;

    [SerializeField]
    private Button m_button;
    [SerializeField]
    private Image m_image;
    [SerializeField]
    private TMP_Text m_text;

    public delegate void UpdateAbilityVariables();
    public static event UpdateAbilityVariables OnAbilitySelect;

    void Awake()
    {
        Button btn = m_button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        m_skillContainer = GameObject.FindGameObjectWithTag("SkillContainer").GetComponent<SkillsContainer>();
        GameObject attributesTAG = GameObject.FindGameObjectWithTag("PlayerData");
        m_playerAttributes = attributesTAG.GetComponent<PlayerAttributes>();
        m_levelUP = attributesTAG.GetComponent<LevelUp>();
        m_playerSkills = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerSkills>();
    }

    private void TaskOnClick()
    {
        ResumeGame();
        m_skillUI.SetActive(false);

        PlayerChooseSkill();
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

    private void SkillSelect()
    {
        bool skillAvailable = false;
        while (!skillAvailable)
        {
            abilitySelection = UnityEngine.Random.Range(0, 3/* m_skillContainer.PlayerSkillList.Count*/);
            if (m_skillContainer.PlayerSkillList[abilitySelection].GroupID == 0)
            {
                if (m_playerAttributes.DictionaryAttributesLevel[abilitySelection] < m_playerAttributes.DictionaryAttributesProgress[abilitySelection].Count-1)
                {
                    skillAvailable = true;
                }
            }
            else
            {
                //same
                skillAvailable = false;
            }
        }
        
        SkillImageAndText(abilitySelection);        
    }

    private void LevelCorrection() //WHERE???
    {
        if (m_levelUP.CurrentLevel%5==0)
        {

        }
    }

    private void PlayerChooseSkill()
    {
        m_playerAttributes.DictionaryAttributesLevel[abilitySelection]++;
        m_playerAttributes.DictionarysAttributes[abilitySelection] = m_playerAttributes.DictionaryAttributesProgress[abilitySelection][m_playerAttributes.DictionaryAttributesLevel[abilitySelection]];
        
        if (OnAbilitySelect != null)
            OnAbilitySelect();

        #region old idea
        //int id = 0;             /*m_skillContainer.PlayerSkillList[randomSkill].SkillID;*/
        //int groupID = 0;        /*m_skillContainer.PlayerSkillList[randomSkill].GroupID;*/
        //bool isINT = false;

        //if (m_playerAttributes.DictionarysAttributes[id] == Math.Floor(m_playerAttributes.DictionarysAttributes[id])) //not needed
        //{
        //    isINT = true; //change to be float (number based) on start
        //}

        //if (groupID == 0)
        //{
        //    if (isINT)
        //    {
        //        m_playerAttributes.DictionarysAttributes[id] += (int)(5 + 1.1 * levelCorrection);
        //    }
        //    else
        //    {
        //        m_playerAttributes.DictionarysAttributes[id] += 5 * levelCorrection;
        //    }
        //}
        //else if (groupID == 1)
        //{
        //    //bool skill after check if available
        //}
        #endregion
    }
}
