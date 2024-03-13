using Unity.VisualScripting;
using UnityEngine;

public class TileNormal : IOClickEvent
{
    public override void ClickEvent()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void OneClick()
    {
        if(Input.GetMouseButton(0))  
        {
            Destroy(gameObject);
        }
    }
}