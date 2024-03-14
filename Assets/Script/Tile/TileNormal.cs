using Unity.VisualScripting;
using UnityEngine;

public class TileNormal : Tile
{
    [Header("Tile Normal")]
    [SerializeField] protected SpriteRenderer color;
    [SerializeField] private int pointsToAdd = 1;
    protected virtual void OnMouseOver()
    {
        if(isDE)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(isPoint)
                {
                    color.color = Color.white;
                    ScoreManager.Instance.AddScore(pointsToAdd);
                    isDE = true;
                }
                else
                {
                    color.color = Color.black;
                    PointFailCounterManager.Instance.AddScore(pointsToAdd);
                    isDE = false;
                }
            }
        }
    }
}