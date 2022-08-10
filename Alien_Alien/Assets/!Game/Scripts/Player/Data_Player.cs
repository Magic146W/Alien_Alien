using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Player: MonoBehaviour
{
    private int so_p_health = 3;                   //health
    private int so_p_healAmount = 1;               //amount of health replenished after heal

    private float so_p_maxSpeed = 20f;             //max speed
    private float so_p_acceleration = 10f;         //acceleration
    private float so_p_speedMult = 1f;             //speed multiplier
    private float so_p_rotateSpeed = 4f;           //rotation speed while acceleration animation
    private float so_p_maxXAngle = 10;              //max rotation angle

    private float so_p_pointMult = 1f;              //point multiplier
    private int so_p_bonusPointToAction = 0;        //bonus points added to action
    private float so_p_baseDamageMult = 1f;         //main damage (to actions) multiplier

    private float so_p_shotDamage = 10f;            //damage of shoots
    private float so_p_bulletSpeedMult = 1f;        //bullet speed
    private float so_p_shotSpeedMult = 1f;          //shot speed
    private int so_p_shotThroughEnemyCount = 0;     //ability for bullet to move after hitting enemy

    private bool so_p_isAOE = false;                //apply? area of damage (explosion) after hit
    private float so_p_AOEDamage = 1f;              //damage to enemies in area
    private float so_p_AOEDamegeMult = 1f;          //damage to enemies in area multiplier
    private float so_p_AOEArea = 3f;                //area range 
    private float so_p_AOEAreaMult = 1f;            //area range multiplier

    //Health
    public int Health
    {
        get { return so_p_health; }
        set { so_p_health = value; }
    }
    public int HealAmount
    {
        get { return so_p_healAmount; }
        set { so_p_healAmount = value; }
    }
    //Movement
    public float MaxSpeed
    {
        get { return so_p_maxSpeed; }
        set { so_p_maxSpeed = value; }
    }
    public float Acceleration
    {
        get { return so_p_acceleration; }
        set { so_p_acceleration = value; }
    }
    public float SpeedMult
    {
        get { return so_p_speedMult; }
        set { so_p_speedMult = value; }
    }
    public float RotateSpeed
    {
        get { return so_p_rotateSpeed; }
        set { so_p_rotateSpeed = value; }
    }
    public float MaxXAngle
    {
        get { return so_p_maxXAngle; }
        set { so_p_maxXAngle = value; }
    }
    //Points
    public float PointMult
    {
        get { return so_p_pointMult; }
        set { so_p_pointMult = value; }
    }
    public int BonusPointToAction
    {
        get { return so_p_bonusPointToAction; }
        set { so_p_bonusPointToAction = value; }
    }
    //Shooting
    public float BaseDamageMult
    {
        get { return so_p_baseDamageMult; }
        set { so_p_baseDamageMult = value; }
    }
    public float ShotDamage
    {
        get { return so_p_shotDamage; }
        set { so_p_shotDamage = value; }
    }
    public float ShotSpeedMult
    {
        get { return so_p_shotSpeedMult; }
        set { so_p_shotSpeedMult = value; }
    }
    public float BulletSpeedMult
    {
        get { return so_p_bulletSpeedMult; }
        set { so_p_bulletSpeedMult = value; }
    }
    public int ShotThroughEnemyCount
    {
        get { return so_p_shotThroughEnemyCount; }
        set { so_p_shotThroughEnemyCount = value; }
    }
    //AOE
    public bool IsAOE
    {
        get { return so_p_isAOE; }
        set { so_p_isAOE = value; }
    }
    public float AOEDamage
    {
        get { return so_p_AOEDamage; }
        set { so_p_AOEDamage = value; }
    }
    public float AOEDamegeMult
    {
        get { return so_p_AOEDamegeMult; }
        set { so_p_AOEDamegeMult = value; }
    }
    public float AOEArea
    {
        get { return so_p_AOEArea; }
        set { so_p_AOEArea = value; }
    }
    public float AOEAreaMult
    {
        get { return so_p_AOEAreaMult; }
        set { so_p_AOEAreaMult = value; }
    }
}