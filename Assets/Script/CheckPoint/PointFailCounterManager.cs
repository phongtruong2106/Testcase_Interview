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
    public bool isFinish;
    protected override void Start()
    {
        base.Start();
        this.isFinish = false;
    }

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
        OnScoreChanged?.Invoke(point);
    }
    public int ScoresPointFail()
    {
        return this.point;
    }
    protected virtual void EndGame()
    {
        if(point == PointEndGame)
        {
            isFinish = true;
        }
    }
}
