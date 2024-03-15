using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : NewMonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] protected Sound[] musicSounds;
    [SerializeField] protected AudioSource musicSource;
    public String nameMusic;

    protected override void Awake()
    {
        base.Awake();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        this.PlayMusic(nameMusic);
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            this.musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Pause();

    }
    public void StartMusic()
    {
        musicSource.UnPause();
    }

   public float GetCurrentMusicTime()
    {
        return Mathf.FloorToInt(musicSource.time);
    }

    public float GetEndMusicTime()
    {
        return Mathf.FloorToInt(musicSource.clip.length);
    }
    public bool IsMusicEnd()
    {
        return Mathf.Approximately(GetCurrentMusicTime(), GetEndMusicTime());
    }
}
