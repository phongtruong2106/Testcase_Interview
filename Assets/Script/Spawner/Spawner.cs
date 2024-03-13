using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : NewMonoBehaviour
{
    [SerializeField] protected float width = 10f;
    [SerializeField] protected float height = 5f;
    [SerializeField] protected TileController tileController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileController();
    }

    protected override void Start()
    {
        this.spawner();
    }
    protected virtual void Update()
    {
        this.CheckSpawner();
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    protected virtual void LoadTileController()
    {
        if(this.tileController != null)
        {
            if(this.tileController != null) return;
            this.tileController = transform.parent.GetComponent<TileController>();
            Debug.Log(transform.name + ": LoadTileController()", gameObject);
        }
    }

    protected virtual void spawner()
    {
        foreach(Transform child in transform)
        {
            foreach(GameObject tileList in tileController._tileList._tileList)
            {
                GameObject tile = Instantiate(tileList, child.position, Quaternion.identity);
                tile.transform.parent = child;
            } 
        }
    }

    protected virtual bool CheckForEmpty()
    {
        foreach (Transform child in transform)
        {
            if(child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    protected virtual void CheckSpawner(){
        if(CheckForEmpty())
        {
            this.spawner();
        }
    }
}
