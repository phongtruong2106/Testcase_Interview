using Unity.VisualScripting;
using UnityEngine;

public class TileNormal : Tile
{
    [SerializeField] protected SpriteRenderer color;
    protected virtual void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            color.color = Color.white;
        }
    }
}