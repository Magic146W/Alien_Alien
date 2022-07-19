using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player")]
public class PlayerData : ScriptableObject //so_p - Scriptable Object Player 
{
    [SerializeField]
    private int so_p_health = 3;                   //health
    [SerializeField]
    private int so_p_healAmount = 1;               //amount of health replenished after heal

    [SerializeField]
    private float so_p_maxSpeed = 20f;             //max speed
    [SerializeField]
    private float so_p_acceleration = 10f;         //acceleration
    [SerializeField]
    private float so_p_speedMult = 1f;             //speed multiplier
    [SerializeField]
    private float so_p_rotateSpeed = 4f;           //rotation speed while acceleration animation
    [SerializeField]
    private float so_p_maxXAngle = 10;              //max rotation angle

    [SerializeField]
    private float so_p_pointMult = 1f;              //point multiplier
    [SerializeField]
    private int so_p_bonusPointToAction = 0;        //bonus points added to action

    [SerializeField]
    private float so_p_baseDamageMult = 1f;         //main damage (to actions) multiplier
    [SerializeField]
    private float so_p_shotDamage = 10f;            //damage of shoots
    [SerializeField]
    private float so_p_shotSpeedMult = 1f;          //bullet speed
    [SerializeField]
    private int so_p_shotThroughEnemyCount = 0;     //ability for bullet to move after hitting enemy

    [SerializeField]
    private bool so_p_isAOE = false;                //apply? area of damage (explosion) after hit
    [SerializeField]
    private float so_p_AOEDamage = 1f;              //damage to enemies in area
    [SerializeField]
    private float so_p_AOEDamegeMult = 1f;          //damage to enemies in area multiplier
    [SerializeField]
    private float so_p_AOEArea = 3f;                //area range 
    [SerializeField]
    private float so_p_AOEAreaMult = 1f;            //area range multiplier

    public int Health => so_p_health;               //=> so_p_health    to inaczej    { get { return so_p_health; } }
    public int HealAmount => so_p_healAmount;

    public float MaxSpeed => so_p_maxSpeed;
    public float Acceleration => so_p_acceleration;
    public float SpeedMult => so_p_speedMult;
    public float RotateSpeed => so_p_rotateSpeed;
    public float MaxXAngle => so_p_maxXAngle;

    public float PointMult => so_p_pointMult;
    public int BonusPointToAction => so_p_bonusPointToAction;

    public float BaseDamageMult => so_p_baseDamageMult;
    public float ShotDamage => so_p_shotDamage;
    public float ShotSpeedMult => so_p_shotSpeedMult;
    public int ShotThroughEnemyCount => so_p_shotThroughEnemyCount;

    public bool IsAOE => so_p_isAOE;
    public float AOEDamage => so_p_AOEDamage;
    public float AOEDamegeMult => so_p_AOEDamegeMult;
    public float AOEArea => so_p_AOEArea;
    public float AOEAreaMult => so_p_AOEAreaMult;
}
