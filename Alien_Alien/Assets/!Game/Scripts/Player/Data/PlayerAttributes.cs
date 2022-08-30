using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes: MonoBehaviour
{

    #region !Player Data
    private float so_rotateSpeed = 4f;              //rotation speed while acceleration animation
    private float so_maxXAngle = 10f;               //max rotation angle (of above)
    private float so_AOEArea = 3f;                  //area range of explosion/AOE skill
    private int so_health = 3;                      //player health
    private float so_maxSpeed = 20f;                //max player speed
    private float so_acceleration = 10f;            //acceleration of player

    public float RotateSpeed => so_rotateSpeed;
    public float MaxXAngle => so_maxXAngle;
    public float AOEArea => so_AOEArea;
    public int Health => so_health;
    public float MaxSpeed => so_maxSpeed;
    public float Acceleration => so_acceleration;
    #endregion
    #region !Attributes

    private float so_ID0_shotDamage = 10;             //damage of shoots
    private float so_ID1_allDamageMult = 1f;        //all damage (all actions) multiplier
    private float so_ID3_moreProjectiles = 0;         //more projectiles spawned/shot
    private float so_ID4_shotSpeedMult = 1f;        //shot speed
    private float so_ID6_extraLife = 0;               //extra life
    private float so_ID8_moveSpeedUp = 0;             //move speed increase to move based actions (acceleration, max speed)
    private float so_ID9_extraPoints = 0;             //bonus points added to action
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

    List<float> listOfVariables = new List<float>();
    Dictionary<int,float> DictionaryVariablesAttributes = new Dictionary<int, float>();

    private void Awake()
    {
        DictionaryVariablesAttributes.Add(0, ShotDamage);
        DictionaryVariablesAttributes.Add(1, AllDamageMult);
        DictionaryVariablesAttributes.Add(3, MoreProjectiles);
        DictionaryVariablesAttributes.Add(4, ShotSpeedMult);
        DictionaryVariablesAttributes.Add(6, ExtraLife);
        DictionaryVariablesAttributes.Add(8, MoveSpeedUp);
        DictionaryVariablesAttributes.Add(9, ExtraPoints);
    }
}