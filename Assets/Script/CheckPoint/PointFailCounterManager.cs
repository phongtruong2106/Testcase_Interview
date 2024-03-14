using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFailCounterManager : NewMonoBehaviour
{
    [SerializeField] private int point = 0;
    [SerializeField] private int PointEndGame = 5;
    public static PointFailCounterManager Instance { get; private set; }
    public delegate void ScoreChangedEventHandler(int newScore);
    public event ScoreChangedEventHandler OnScoreChanged;

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    protected virtual void Update()
    {
        this.EndGame();
    }
    public void AddScore(int points)
    {
        point += points;
        OnScoreChanged?.Invoke(point); // Notify observers about score change
    }
    public int ScoresPointFail()
    {
        return this.point;
    }
    protected virtual void EndGame()
    {
        if(point == PointEndGame)
        {
            Debug.Log("End");
        }
    }
}
