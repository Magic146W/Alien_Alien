using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills: MonoBehaviour
{
    private Transform m_player;
    private float m_time = 6;

    Dictionary<int,bool> m_dictionaryVariablesSkills = new Dictionary<int, bool>();
    public Dictionary<int, bool> DictionaryVariablesSkills
    {
        get { return m_dictionaryVariablesSkills; }
        set { m_dictionaryVariablesSkills = value; }
    }

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;

        m_dictionaryVariablesSkills.Add(2, AOEFinal);
        m_dictionaryVariablesSkills.Add(5, Laser);
        m_dictionaryVariablesSkills.Add(10, PointMult);
        m_dictionaryVariablesSkills.Add(13, Death);
    }

    #region !Passive Skills

    private bool so_ID2_AOEFinal = false;                   //area of damage (explosion) after hit
    private bool so_ID5_Laser = false;                      //now you shot one laser
    private bool so_ID10_pointMultFinal = false;            //2x point multiplier   
    private bool so_ID13_Death = false;                     //small chance to kill on hit

    public bool AOEFinal                                    //ID 2
    {
        get { return so_ID2_AOEFinal; }
        set { so_ID2_AOEFinal = value; }
    }
    public bool Laser                                       //ID 5
    {
        get { return so_ID5_Laser; }
        set { so_ID5_Laser = value; }
    }
    public bool PointMult                                   //ID9
    {
        get { return so_ID10_pointMultFinal; }
        set { so_ID10_pointMultFinal = value; }
    }
    public bool Death                                       //ID13
    {
        get { return so_ID13_Death; }
        set { so_ID13_Death = value; }
    }

    #endregion

    #region !Active Skills

    //[SerializeField] GameObject m_blackHolePrefab;
    //public void BlackHoleActiveSkill()
    //{
    //    var blackHole = Instantiate(m_blackHolePrefab, transform);
    //}

    //private void TeleportActiveSkill()
    //{
    //    player position transform to position tap ==> stop on border(map teleport) and teleport without loosing hp;
    //    (easy vs hard / border vs teleport)
    //    PlayerMovement(with direction)
    //    flaming border
    //}

    //private void ShieldActiveSkill()
    //{
    //    3 layers of shields kill enemies with touch no points or mission done
    //    own script +enemyhealth(event)
    //}

    //private void PorcupineShotActiveSkill()
    //{
    //    fire shots around the player with rainbow colors/ magenta;
    //    Playershoting
    //}

    //private void FiretActiveSkill()
    //{
    //    flamethrower wave, with dot for affected enemies
    //    own script => enemyhealth(dot + fire)
    //}

    //private void IcetActiveSkill()
    //{
    //    dot and slow down affected enemies(snowflakes particel effect)
    //    own script => enemyhealth / enemymovement(dot / ice)
    //}

    #endregion
}
