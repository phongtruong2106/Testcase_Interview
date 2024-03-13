using Unity.VisualScripting;
using UnityEngine;

public class TileNormal : Tile
{
    [SerializeField] protected SpriteRenderer color;
    protected virtual void OnMouseOver()
    {
        color.color = Color.white;
    }
}