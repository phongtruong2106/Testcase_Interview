using UnityEngine;

public class CheckPoint : NewMonoBehaviour
{
    [SerializeField] private int defaultPoint = 30;
    [SerializeField] private int defaultPoint_1 = 100;
    [SerializeField] protected Transform target_1;
    [SerializeField] protected Transform target_2;
    [SerializeField] protected Transform target_default;
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 newPosition;

    protected override void Start()
    {
        base.Start();
        newPosition.y = target_default.position.y;
        transform.position = newPosition;
    }
    private void Update() {
        this.MoveCheckPoint();
    }
    protected virtual void MoveCheckPoint()
    {
        if(ScoreManager.Instance.Scores() == defaultPoint)
        {
            newPosition.y = target_1.position.y;
            transform.position = newPosition;
        }
        else if(ScoreManager.Instance.Scores() == defaultPoint_1)
        {
            newPosition.y = target_2.position.y;
            transform.position = newPosition;
        }
        else
        {
            newPosition.y = target_default.position.y;
            transform.position = newPosition;
        }
    }
}