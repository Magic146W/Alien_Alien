using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[CreateAssetMenu(fileName = "Skill")]
public class PlayerSkillsScriptableObject: ScriptableObject
{
    [SerializeField]
    private int so_skillID;
    public int SkillID => so_skillID;

    [SerializeField]
    private int so_groupID;
    public int GroupID => so_groupID;

    [SerializeField]
    private Sprite so_skillImage;
    public Sprite SkillImage => so_skillImage;

    [SerializeField]
    private string so_skillName;
    public string SkillName => so_skillName;

    [TextArea]
    [SerializeField]
    private string so_skillText;
    public string SkillText => so_skillText;
}
