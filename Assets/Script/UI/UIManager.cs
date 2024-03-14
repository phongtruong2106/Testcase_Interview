using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : NewMonoBehaviour
{   
    [SerializeField] protected UIController uIController;
    [SerializeField] protected int pointStar_1 = 100;
    [SerializeField] protected int pointStar_2 = 140;
    [SerializeField] protected int pointStar_3 = 240;

    private void Update() {
        this.UpdateScore();
         this.UpdateStarSlide();
        this.UpdateCheckStar();
    }
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

    protected virtual void UpdateScore()
    {
        int currentScore = ScoreManager.Instance.Scores();
        uIController._uIScore._score.text = currentScore.ToString();
    }

    protected virtual void UpdateStarSlide()
    {
        int currentScore = ScoreManager.Instance.Scores();
        uIController._uiSliderStar.slider.value = currentScore;
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
}
