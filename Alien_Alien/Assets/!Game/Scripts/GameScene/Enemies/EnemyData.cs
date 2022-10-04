using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy")]
public class EnemyData : ScriptableObject //so_e - Scriptable Object Enemy
{
    [SerializeField]
    private int so_e_id = 0;                        //ID of enemy type
    [SerializeField]
    private int so_e_health = 10;                   //health
    [SerializeField]
    private float so_e_speed = 5f;                  //max speed   
    [SerializeField]
    private float so_e_points = 1f;                 //point multiplier
    [SerializeField]
    private float so_e_baseDamage = 1f;             //main damage (to actions) multiplier


    public int ID => so_e_id;                       
    public int Health => so_e_health;               
    public float Speed => so_e_speed;
    public float Points => so_e_points;
    public float BaseDamage => so_e_baseDamage;
}
