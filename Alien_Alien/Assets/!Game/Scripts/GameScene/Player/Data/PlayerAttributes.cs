using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes: MonoBehaviour
{
    private void Awake()
    {
        FillAttributes();
        FillAttributeLevel();
        FillAttributeData();
    }


    private void OnEnable()
    {
        SkillSelection.OnAbilitySelect += UpdateAttributes;
    }

    private void OnDisable()
    {
        SkillSelection.OnAbilitySelect -= UpdateAttributes;
    }

    #region !Player Data
    private float so_rotateSpeed = 4f;              //rotation speed while acceleration animation
    private float so_maxXAngle = 10f;               //max rotation angle (of above)
    private float so_AOEArea = 3f;                  //area range of explosion/AOE skill
    private int so_health = 3;                      //player health
    private float so_maxSpeed = 20f;                //max player speed
    private float so_acceleration = 10f;            //acceleration of player
    private float so_levelCorrection = 1f;          //level correction multiplier

    public float RotateSpeed => so_rotateSpeed;
    public float MaxXAngle => so_maxXAngle;
    public float AOEArea => so_AOEArea;
    public int Health => so_health;
    public float MaxSpeed => so_maxSpeed;
    public float Acceleration => so_acceleration;
    public float LevelCorrection
    {
        get { return so_levelCorrection; }
        set { so_levelCorrection = value; }
    }
    #endregion
    #region !Attributes

    private float so_ID0_shotDamage = 10;             //damage of shoots
    private float so_ID1_allDamageMult = 1f;        //all damage (all actions) multiplier
    private float so_ID3_moreProjectiles = 1;         //more projectiles spawned/shot
    private float so_ID4_shotSpeedMult = 1f;        //shot speed
    private float so_ID6_extraLife = 0;               //extra life
    private float so_ID8_moveSpeedUp = 0;             //move speed increase to move based actions (acceleration, max speed)
    private float so_ID9_extraPoints = 10;             //bonus points added to action
    private float so_ID11_criticalChance = 0;         //chance to hit extra hard (shoots damage for more)
    private float so_ID12_criticalDamageMult = 1f;  //Critical hits hit for more damage

    public float ShotDamage                         //ID 0
    {
        get { return so_ID0_shotDamage; }
        set { so_ID0_shotDamage = value; }
    }
    public float AllDamageMult                     //ID 1
    {
        get { return so_ID1_allDamageMult; }
        set { so_ID1_allDamageMult = value; }
    }
    public float MoreProjectiles                      //ID 3
    {
        get { return so_ID3_moreProjectiles; }
        set { so_ID3_moreProjectiles = value; }
    }
    public float ShotSpeedMult                      //ID 4
    {
        get { return so_ID4_shotSpeedMult; }
        set { so_ID4_shotSpeedMult = value; }
    }
    public float ExtraLife                            //ID 6
    {
        get { return so_ID6_extraLife; }
        set { so_ID6_extraLife = value; }
    }
    public float MoveSpeedUp                          //ID 8
    {
        get { return so_ID8_moveSpeedUp; }
        set { so_ID8_moveSpeedUp = value; }
    }
    public float ExtraPoints                          //ID 9
    {
        get { return so_ID9_extraPoints; }
        set { so_ID9_extraPoints = value; }
    }
    public float CriticalChance                       //ID 11
    {
        get { return so_ID11_criticalChance; }
        set { so_ID11_criticalChance = value; }
    }
    public float CriticalDamageMult                 //ID 12
    {
        get { return so_ID12_criticalDamageMult; }
        set { so_ID12_criticalDamageMult = value; }
    }



    #endregion
    #region !Not used
    private float so_AOEDamegeMult = 1f;          //damage to enemies in area multiplier
    private float so_bulletSpeedMult = 1f;        //bullet speed
    private bool so_heal = false;               //amount of health replenished after heal

    public float AOEDamegeMult
    {
        get { return so_AOEDamegeMult; }
        set { so_AOEDamegeMult = value; }
    }
    public float BulletSpeedMult
    {
        get { return so_bulletSpeedMult; }
        set { so_bulletSpeedMult = value; }
    }
    public bool Heal
    {
        get { return so_heal; }
        set { so_heal = value; }
    }
    #endregion

    Dictionary<int,float> m_dictionaryAttributes = new Dictionary<int, float>();
    public Dictionary<int, float> DictionarysAttributes
    {
        get { return m_dictionaryAttributes; }
        set { m_dictionaryAttributes = value; }
    }

    Dictionary<int,int> m_dictionaryAttributesLevel = new Dictionary<int, int>();
    public Dictionary<int, int> DictionaryAttributesLevel
    {
        get { return m_dictionaryAttributesLevel; }
        set { m_dictionaryAttributesLevel = value; }
    }

    Dictionary<int,List<float>> m_dictionaryAttributesProgress = new Dictionary<int, List<float>>();
    public Dictionary<int, List<float>> DictionaryAttributesProgress
    {
        get { return m_dictionaryAttributesProgress; }
        set { m_dictionaryAttributesProgress = value; }
    }

    private void FillAttributes()
    {
        m_dictionaryAttributes.Add(0, ShotDamage);
        m_dictionaryAttributes.Add(1, AllDamageMult);
        m_dictionaryAttributes.Add(3, MoreProjectiles);
        m_dictionaryAttributes.Add(4, ShotSpeedMult);
        m_dictionaryAttributes.Add(6, ExtraLife);
        m_dictionaryAttributes.Add(8, MoveSpeedUp);
        m_dictionaryAttributes.Add(9, ExtraPoints);
        m_dictionaryAttributes.Add(11, CriticalChance);
        m_dictionaryAttributes.Add(12, CriticalDamageMult);
    }

    private void FillAttributeLevel()
    {
        m_dictionaryAttributesLevel.Add(0, 0);
        m_dictionaryAttributesLevel.Add(1, 0);
        m_dictionaryAttributesLevel.Add(3, 0);
        m_dictionaryAttributesLevel.Add(4, 0);
        m_dictionaryAttributesLevel.Add(6, 0);
        m_dictionaryAttributesLevel.Add(8, 0);
        m_dictionaryAttributesLevel.Add(9, 0);
        m_dictionaryAttributesLevel.Add(11, 0);
        m_dictionaryAttributesLevel.Add(12, 0);
    }

    private void FillAttributeData()
    {
        m_dictionaryAttributesProgress.Add(0, new List<float> { 10, 15, 20, 31, 45, 64, 88, 119, 160, 213, 282 });
        m_dictionaryAttributesProgress.Add(1, new List<float> { 1, 1.1f, 1.25f, 1.5f, 1.8f, 2.1f, 2.5f });
        m_dictionaryAttributesProgress.Add(3, new List<float> { 1, 2, 3 });
        m_dictionaryAttributesProgress.Add(4, new List<float> { 1, 0.95f, 0.9f, 0.85f, 0.8f, 0.7f, 0.6f });
        m_dictionaryAttributesProgress.Add(6, new List<float> { 0, 2, 3, 5 });
        m_dictionaryAttributesProgress.Add(8, new List<float> { 0, 2, 3, 5 });
        m_dictionaryAttributesProgress.Add(9, new List<float> { 0, 3, 4, 5 });
        m_dictionaryAttributesProgress.Add(11, new List<float> { 0, 2, 4, 7, 13, 20 });
        m_dictionaryAttributesProgress.Add(12, new List<float> { 1, 1.2f, 1.5f, 1.9f, 2.4f, 3f });
    }

    private void UpdateAttributes()
    {
        so_ID0_shotDamage = m_dictionaryAttributes[0];
        so_ID1_allDamageMult = m_dictionaryAttributes[1];
        so_ID3_moreProjectiles = m_dictionaryAttributes[3];
        so_ID4_shotSpeedMult = m_dictionaryAttributes[4];
        so_ID6_extraLife = m_dictionaryAttributes[6];
        so_ID8_moveSpeedUp = m_dictionaryAttributes[8];
        so_ID9_extraPoints = m_dictionaryAttributes[9];
        so_ID11_criticalChance = m_dictionaryAttributes[11];
        so_ID12_criticalDamageMult = m_dictionaryAttributes[12];
    }
}