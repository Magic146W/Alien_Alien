using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[Serializable]
public class JSON_Data: MonoBehaviour
{
    private class Json
    {
        private bool soundPlaying;
        private bool musicPlaying;

        public Json()
        { 
        
        }

        public Json(bool sound, bool music)
        {
            soundPlaying = sound;
            musicPlaying = music;
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
    }

    [SerializeField] private UI_Settings m_uiSettings;
    [SerializeField] private AudioManager m_audioManager;
    private bool m_soundPlaying = true;
    private bool m_musicPlaying = true;
    private string m_jsonPath  = "/AudioSettings.json";


    private void Start()
    {
        //m_uiSettings = gameObject.GetComponent<UI_Settings>();
        //m_audioManager = gameObject.GetComponent<AudioManager>();

        Json mySettings = new Json(/*m_soundPlaying,m_musicPlaying*/);
        
        try
        {
            mySettings = JsonConvert.DeserializeObject<Json>(File.ReadAllText(Application.dataPath + m_jsonPath));
        }
        catch (Exception e) { Debug.LogError(e); }

        if (mySettings.Equals(null))
            return;

        m_soundPlaying = mySettings.SoundPlaying;
        m_musicPlaying = mySettings.MusicPlaying;
        SetSettings();
    }

    private void SetSettings()
    {
        m_audioManager.SetAudio(m_soundPlaying, m_musicPlaying);
        m_uiSettings.SetUIColor(m_soundPlaying, m_musicPlaying);
    }

    public void SerializeSettings(bool soundPlaying, bool musicPlaying)
    {
        Json mySettings = new Json();
        mySettings.SoundPlaying = soundPlaying;
        mySettings.MusicPlaying = musicPlaying;
        var serializedSettings = JsonConvert.SerializeObject(mySettings);
        File.WriteAllText(Application.dataPath + m_jsonPath, serializedSettings);
    }
}
