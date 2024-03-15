using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFinish : NewMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text_Score;
    [SerializeField] protected GameObject panel_Finish;
    [SerializeField] protected Button button_Home;
    [SerializeField] protected Button button_Playlist;
    [SerializeField] protected GameObject panel_Spawner;

    protected override void Start()
    {
        base.Start();
        this.panel_Finish.SetActive(false);
    }
    public void OpenPanelFinish(int score)
    {
        panel_Finish.SetActive(true);
        text_Score.text = "SCORE: " + score.ToString();
        AudioManager.Instance.StopMusic();
        panel_Spawner.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClosePanelFinish()
    {
        panel_Finish.SetActive(false);
    }

}
