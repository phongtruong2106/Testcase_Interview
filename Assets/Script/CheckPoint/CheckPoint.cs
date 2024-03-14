using UnityEngine;

public class CheckPoint : NewMonoBehaviour
{
    [SerializeField] private int defaultPoint = 30;
    [SerializeField] private int defaultPoint_1;
    [SerializeField] protected Transform target_1;
    [SerializeField] protected Transform target_2;
    [SerializeField] protected Transform target_default;

    protected virtual void MoveCheckPoint()
    {
        if(ScoreManager.Instance.Scores() == defaultPoint)
        {
            
        }
    }
}