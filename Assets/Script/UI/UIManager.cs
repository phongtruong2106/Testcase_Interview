using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : NewMonoBehaviour
{
    [SerializeField] protected UIController uIController;

    private void Update() {
        this.UpdateScore();
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
}
