using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    [SerializeField] private AudioSource m_music;
    [SerializeField] private List<AudioSource> m_sounds = new List<AudioSource>();

    void Awake()
    {
        foreach (var sound in m_sounds)
        {
            sound.volume = 0;
            sound.playOnAwake =true;
            sound.volume = 0.5f;
        }
    }

    public void SetAudio(bool sound, bool music)
    {
        PlaySounds(sound);
        PlayMusic(music);
    }

    public void PlayMusic(bool musicPlay)
    {
        if (!musicPlay)
        {
            m_music.volume = 0;
        }
        else
        {
            m_music.volume = 1;
        }
    }

    public void PlaySounds(bool soundPlay)
    {
        if (!soundPlay)
        {
            foreach (var sound in m_sounds)
            {
                sound.volume = 0;
            }
        }
        else
        {
            foreach (var sound in m_sounds)
            {
                sound.volume = 0.5f;
            }
        }
    }
}
