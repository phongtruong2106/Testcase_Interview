using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : NewMonoBehaviour
{
    [SerializeField] protected AudioMixer myMixer;
    [SerializeField] protected Slider musicSlider;

    protected override void Start()
    {
        base.Start();
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }
}
