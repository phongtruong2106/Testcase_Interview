using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFinish : NewMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text_Score;
    [SerializeField] protected GameObject panel_Finishz;
    [SerializeField] protected Button button_Home;
    public Button _button_Home => button_Home;
    [SerializeField] protected Button button_Playlist;
    public Button _button_Playlist => button_Playlist;
    [SerializeField] protected GameObject panel_Spawner;
    [SerializeField] protected UIManager uIManager;
    public bool isOpenPanelList;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIManager();
    }

    protected override void Start()
    {
        base.Start();
        this.panel_Finishz.SetActive(false);
        this.isOpenPanelList = false;
    }

    protected virtual void LoadUIManager()
    {
        if(this.uIManager != null) return;
        this.uIManager = FindAnyObjectByType<UIManager>();
        Debug.Log(transform.name + ": LoadUIManager()", gameObject);
    }
    public void OpenPanelFinish(int score)
    {
        panel_Finishz.SetActive(true);
        text_Score.text = "SCORE: " + score.ToString();
        AudioManager.Instance.StopMusic();
        panel_Spawner.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClosePanelFinish()
    {
        panel_Finishz.SetActive(false);
        uIManager._pointFailCounterManager.point = 0;
        ScoreManager.Instance.score = 0;
        AudioManager.Instance.StartMusic();
        panel_Spawner.SetActive(true);
        Time.timeScale = 1;
               
    }

}
