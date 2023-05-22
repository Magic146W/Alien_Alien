using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
public class JSON_Manager: MonoBehaviour
{
    private class Json
    {
        private bool soundPlaying;
        private bool musicPlaying;
        private int m_kills;
        private int m_points;
        private float m_enemy;
        private int m_level;

        public Json()
        {

        }

        public Json(bool sound, bool music)
        {
            soundPlaying = sound;
            musicPlaying = music;
        }

        public Json(int kills, int points, float enemy, int level)
        {
            m_kills = kills;
            m_points = points;
            m_enemy = enemy;
            m_level = level;
        }

        public bool SoundPlaying
        {
            get { return soundPlaying; }
            set { soundPlaying = value; }
        }

        public bool MusicPlaying
        {
            get { return musicPlaying; }
            set { musicPlaying = value; }
        }

        public int Kills
        {
            get { return m_kills; }
            set { m_kills = value; }
        }
        public int Points
        {
            get { return m_points; }
            set { m_points = value; }
        }
        public float Enemy
        {
            get { return m_enemy; }
            set { m_enemy = value; }
        }
        public int Level
        {
            get { return m_level; }
            set { m_level = value; }
        }
    }


    [SerializeField] private DataToSerialize m_dataToSerialize;
    [SerializeField] private GameObject m_uiPanel = null;
    private UI_Pause m_uiPause;
    private UI_Settings m_uiSettings;
    [SerializeField] private AudioManager m_audioManager;
    private bool m_soundPlaying = true;
    private bool m_musicPlaying = true;
    private string m_jsonPath  = "/Achivements.json";
    private string m_jsonAudio = "/AudioSettings.json";
    private Json m_mydata;

    private void Start()
    {
        Json myData = new Json();
        try
        {
            myData = JsonConvert.DeserializeObject<Json>(File.ReadAllText(Application.dataPath + m_jsonAudio));
        }
        catch (Exception e) { Debug.LogError(e); }

        if (SceneManager.GetActiveScene().name == "MainMenu")
            m_uiSettings = m_uiPanel.GetComponent<UI_Settings>();
        else
            m_uiPause = m_uiPanel.GetComponent<UI_Pause>();

        try
        {
            var data = JsonConvert.DeserializeObject<Json>(File.ReadAllText(Application.dataPath + m_jsonPath));
            if (data != null)
            {
                myData.Kills = data.Kills;
                myData.Points = data.Points;
                myData.Level = data.Level;
                myData.Enemy = data.Enemy;              
            }
        }
        catch (Exception e) { Debug.LogError(e); }

        if (myData.Equals(null))
            return;

        m_mydata = myData;
        DeserializeAchivements();

        m_soundPlaying = myData.SoundPlaying;
        m_musicPlaying = myData.MusicPlaying;
        SetSettings();
    }

    private void SetSettings()
    {
        m_audioManager.SetAudio(m_soundPlaying, m_musicPlaying);
        if (m_uiSettings != null)
            m_uiSettings.SetUIColor(m_soundPlaying, m_musicPlaying);
        else if (m_uiPause != null)
            m_uiPause.SetUIColor(m_soundPlaying, m_musicPlaying);
    }

    public void SerializeSettings(bool soundPlaying, bool musicPlaying)
    {
        Json mySettings = new Json();
        mySettings.SoundPlaying = soundPlaying;
        mySettings.MusicPlaying = musicPlaying;
        var serializedSettings = JsonConvert.SerializeObject(mySettings);
        File.WriteAllText(Application.dataPath + m_jsonAudio, serializedSettings);
    }

    private void DeserializeAchivements()
    {
        m_dataToSerialize.Kills = m_mydata.Kills;
        m_dataToSerialize.Points = m_mydata.Points;
        m_dataToSerialize.Enemy = m_mydata.Enemy;
        m_dataToSerialize.Level = m_mydata.Level;
    }

    public void SerializeAchivements()
    {
        Json myAchivements = new Json();
        myAchivements.Kills = m_dataToSerialize.Kills;
        if (myAchivements.Kills < m_mydata.Kills)
            myAchivements.Kills = m_mydata.Kills;

        myAchivements.Points = m_dataToSerialize.Points;
        if (myAchivements.Points < m_mydata.Points)
            myAchivements.Points = m_mydata.Points;

        myAchivements.Enemy = m_dataToSerialize.Enemy;
        if (myAchivements.Enemy < m_mydata.Enemy)
            myAchivements.Enemy = m_mydata.Enemy;

        myAchivements.Level = m_dataToSerialize.Level;
        if (myAchivements.Level < m_mydata.Level)
            myAchivements.Level = m_mydata.Level;

        var serializedSettings = JsonConvert.SerializeObject(myAchivements);
        File.WriteAllText(Application.dataPath + m_jsonPath, serializedSettings);
    }
}
