using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePause : NewMonoBehaviour
{
    [SerializeField] protected GameObject panelGamePause;
    [SerializeField] protected Button buttonHome;
    public Button _buttonHome => buttonHome;
    public Button buttonContinue;
    protected override void Start()
    {
        base.Start();
        this.panelGamePause.SetActive(false);
    }
    public void OpenPanel()
    {
        panelGamePause.SetActive(true);
        AudioManager.Instance.StopMusic();
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        panelGamePause.SetActive(false);
        AudioManager.Instance.StartMusic();
        Time.timeScale = 1;
    }
}
