using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu(fileName = "Skill")]
public class PlayerSkills: ScriptableObject
{
    [SerializeField]
    private Sprite so_s_skillImage;
    public Sprite SkillImage => so_s_skillImage;
    [SerializeField]
    private TMP_Text so_s_skillText;
    public TMP_Text SkillText => so_s_skillText;


}
