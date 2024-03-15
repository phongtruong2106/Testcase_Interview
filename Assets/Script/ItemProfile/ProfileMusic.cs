using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMusic : NewMonoBehaviour
{
    [SerializeField] protected SOMusic sOMusic;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    [SerializeField] protected Button button_Player;
    [SerializeField] protected UIController uIController;

    protected bool isInput;

    protected override void Start()
    {
        this.UpdateName();
        this.isInput = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
    }
    protected virtual void Update()
    {
        this.PressButtonPlay();
        this.UpdateNameAudio();
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ":LoadUIController()", gameObject);
    }
    protected virtual void profileItem()
    {
        isInput = true;
    }

    protected virtual void UpdateName()
    {
        textMeshProUGUI.text = sOMusic.nameText;
    }

    protected virtual void PressButtonPlay()
    {
        button_Player.onClick.AddListener(profileItem);
    }

    protected virtual void UpdateNameAudio()
    {
        if(isInput)
        {
            AudioManager.Instance.nameMusic = sOMusic.nameText;
            AudioManager.Instance.PlayMusic(AudioManager.Instance.nameMusic);
            uIController._uIFinish.ClosePanelFinish();
            uIController._IPanelList.ClosePanelList();

            isInput = false;
        }
    }
}
