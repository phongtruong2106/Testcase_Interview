using Unity.VisualScripting;
using UnityEngine;

public class TileNormal : Tile
{
    [Header("Tile Normal")]
    [SerializeField] protected SpriteRenderer color;
    [SerializeField] private int pointsToAdd = 1;
    protected virtual void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            color.color = Color.white;
            ScoreManager.Instance.AddScore(pointsToAdd);
        }
    }
}