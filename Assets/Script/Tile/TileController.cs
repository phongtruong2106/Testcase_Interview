using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : NewMonoBehaviour
{
    [SerializeField] protected TileList tileList;
    public TileList _tileList => tileList;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileList();
    }

    protected virtual void LoadTileList()
    {
        if(this.tileList != null)
        {
            if(this.tileList != null) return;
            this.tileList = transform.GetComponentInChildren<TileList>();
            Debug.Log(transform.name + ": LoadTileList()", gameObject);
        }
    }
}
