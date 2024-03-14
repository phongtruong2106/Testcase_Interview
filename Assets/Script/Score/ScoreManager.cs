using UnityEngine;

public class ScoreManager : NewMonoBehaviour
{
    private int score = 0;
    public static ScoreManager Instance { get; private set; }
    public delegate void ScoreChangedEventHandler(int newScore);
    public event ScoreChangedEventHandler OnScoreChanged;

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        OnScoreChanged?.Invoke(score); // Notify observers about score change
    }
}