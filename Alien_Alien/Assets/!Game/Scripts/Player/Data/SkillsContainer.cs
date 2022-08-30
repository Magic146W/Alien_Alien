using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsContainer: MonoBehaviour
{
    [SerializeField]
    private List<PlayerSkillsScriptableObject> m_playerSkillList = new List<PlayerSkillsScriptableObject>();
    public List<PlayerSkillsScriptableObject> PlayerSkillList => m_playerSkillList;
}
