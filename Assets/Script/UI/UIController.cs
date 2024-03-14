using UnityEngine;

public class UIController : NewMonoBehaviour
{
    [SerializeField] protected UIScore uIScore;
    public UIScore _uIScore => uIScore;
    [SerializeField] protected ScoreManager scoreManager;
    public ScoreManager _scoreManager => scoreManager;
    [SerializeField] protected UISliderStar uisliderStar;
    public UISliderStar _uiSliderStar => uisliderStar;
    [SerializeField] protected CheckCountForStar checkCountForStar;
    public CheckCountForStar _checkCountForStar => checkCountForStar;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIScore();
        this.LoadScoreManager();
        this.LoadUISliderStar();
        this.LoadCheckCountForStar();
    }
    
    protected virtual void LoadUIScore()
    {
        if(this.uIScore != null) return;
        this.uIScore = transform.parent.parent.GetComponentInChildren<UIScore>();
        Debug.Log(transform.name + ":LoadUIScore()", gameObject);
    }
    protected virtual void LoadUISliderStar()
    {
        if(this.uisliderStar != null) return;
        this.uisliderStar = transform.parent.parent.GetComponentInChildren<UISliderStar>();
        Debug.Log(transform.name + ":LoadUISliderStar()", gameObject);
    }

    protected virtual void LoadScoreManager()
    {
        if(this.scoreManager != null) return;
        this.scoreManager = FindAnyObjectByType<ScoreManager>();
        Debug.Log(transform.name + ":LoadScoreManager()", gameObject);
    }
    protected virtual void LoadCheckCountForStar()
    {
        if(this.checkCountForStar != null) return;
        this.checkCountForStar = GetComponentInChildren<CheckCountForStar>();
        Debug.Log(transform.name + ":LoadCheckCountForStar()", gameObject);
    }
}