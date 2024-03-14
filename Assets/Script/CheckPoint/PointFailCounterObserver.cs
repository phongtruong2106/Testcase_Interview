using UnityEngine;

public class PointFailCounterObserver : NewMonoBehaviour
{
    protected override void OnEnable()
    {
        ScoreManager.Instance.OnScoreChanged += HandleScoreChanged;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= HandleScoreChanged;
    }

    private void HandleScoreChanged(int newScore)
    {
        Debug.Log("Score changed! New score: " + newScore);
    }
}