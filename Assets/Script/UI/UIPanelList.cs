using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelList : NewMonoBehaviour
{
    [SerializeField] protected GameObject panelList;
    [SerializeField] protected Button buttonList;
    public Button _buttonList => buttonList;
    [SerializeField] protected Button buttonCLoseList;
    public Button _buttonCLoseList => buttonCLoseList;
    [SerializeField] protected UIController uIController;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ":LoadUIController()", gameObject);
    }
    
    protected override void Start()
    {
        base.Start();
        RectTransform rectTransform = panelList.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-410f, rectTransform.anchoredPosition.y);
    }
    public void OpenPanelList()
    {
        RectTransform rectTransform = panelList.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(404f, rectTransform.anchoredPosition.y);
        AudioManager.Instance.StopMusic();
        uIController._uIFinish.isOpenPanelList = true;
        Time.timeScale = 0;
    }

    public void ClosePanelList()
    {
        RectTransform rectTransform = panelList.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-410f, rectTransform.anchoredPosition.y);
        AudioManager.Instance.StartMusic();
        Time.timeScale = 1;
    }
}
