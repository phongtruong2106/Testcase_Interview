using UnityEngine;

public abstract class IOClickEvent : Tile
{
    protected override void Update()
    {
        this.ClickEvent();
    }
    public abstract  void ClickEvent();
}