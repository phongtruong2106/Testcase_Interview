using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : NewMonoBehaviour
{   
    [SerializeField] protected UIController uIController;
    [SerializeField] protected PointFailCounterManager pointFailCounterManager;
    [SerializeField] protected float pointStar_1 = 40;
    [SerializeField] protected float pointStar_2 = 100;
    [SerializeField] protected float pointStar_3 = 150;
    protected int currentScore;
    protected bool isOpen = false;

    private void Update() {
        this.UpdateScore();
        this.UpdateStarSlide();
        this.UpdateCheckStar();
        this.PressOpenPanelPause();
        this.PressClosePanelPause();
        this.UpdateMaxValue();
        this.UpdateScoreFinish();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadPointFailCounterManager();
    }

    protected virtual void LoadPointFailCounterManager()
    {
        if(this.pointFailCounterManager != null) return;
        this.pointFailCounterManager = FindAnyObjectByType<PointFailCounterManager>();
        Debug.Log(transform.name + ": LoadPointFailCounterManager()", gameObject);
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ":LoadUIController()", gameObject);
    }

    protected virtual void UpdateScore()
    {
        currentScore = ScoreManager.Instance.Scores();
        uIController._uIScore._score.text = currentScore.ToString();
    }

    protected virtual void UpdateStarSlide()
    {
        currentScore = ScoreManager.Instance.Scores();
        uIController._uiSliderStar.slider.value = currentScore;
    }

    protected virtual void UpdateMaxValue()
    {
        int maxValue;
        uIController._uiSliderStar.slider.maxValue  = AudioManager.Instance.GetEndMusicTime();
        maxValue = Mathf.FloorToInt(uIController._uiSliderStar.slider.maxValue);

        int starRange = maxValue / 3;
        pointStar_1 = starRange;
        pointStar_2 = 2 * starRange;
        pointStar_3 = 3 * starRange;
        
    }

    protected virtual void UpdateCheckStar()
    {
        if(uIController._uiSliderStar.slider.value == pointStar_1)
        {
            uIController._checkCountForStar._star1.color = Color.white;
        }
        else if(uIController._uiSliderStar.slider.value == pointStar_2)
        {
            uIController._checkCountForStar._star2.color = Color.white;
        }
        else if(uIController._uiSliderStar.slider.value == pointStar_3)
        {
            uIController._checkCountForStar._star2.color = Color.white;
        }
    }

    protected virtual void PressOpenPanelPause()
    {
        if(!isOpen)
        {   
            uIController._uIGame.buttonPause.onClick.AddListener(uIController._uIGamePause.OpenPanel);
            isOpen = true;
        }
    }

    protected virtual void PressClosePanelPause()
    {
        if(isOpen)
        {   
            uIController._uIGamePause.buttonContinue.onClick.AddListener(uIController._uIGamePause.ClosePanel);
            isOpen = false;
        }
    }
    protected virtual void UpdateScoreFinish()
    {
        if(AudioManager.Instance.IsMusicEnd() || pointFailCounterManager.isFinish)
        {
            uIController._uIFinish.OpenPanelFinish(currentScore);
        }
    } 

}
