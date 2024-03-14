using UnityEngine;

public class UIController : NewMonoBehaviour
{
    [SerializeField] protected UIScore uIScore;
    public UIScore _uIScore => uIScore;
    [SerializeField] protected ScoreManager scoreManager;
    public ScoreManager _scoreManager => scoreManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIScore();
        this.LoadScoreManager();
    }
    
    protected virtual void LoadUIScore()
    {
        if(this.uIScore != null) return;
            this.uIScore = transform.GetComponentInChildren<UIScore>();
            Debug.Log(transform.name + ":LoadUIScore()", gameObject);
    }

    protected virtual void LoadScoreManager()
    {
        if(this.scoreManager != null) return;
        this.scoreManager = FindAnyObjectByType<ScoreManager>();
        Debug.Log(transform.name + ":LoadScoreManager()", gameObject);
    }
}