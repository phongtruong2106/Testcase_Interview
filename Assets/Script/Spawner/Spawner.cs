using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : NewMonoBehaviour
{
    [SerializeField] protected float width = 10f;
    [SerializeField] protected float height = 5f;
    [SerializeField] protected TileController tileController;

    [SerializeField] protected float normalTileWeight = 1f;
    [SerializeField] protected float pressAndHoldTileWeight = 1f;
    [SerializeField] protected float delay = 0.5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileController();
    }

    protected override void Start()
    {
        this.spawnuntill();
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
        //tam thoi
        foreach (Transform child in transform)
        {
            float randomValue = Random.Range(0f, 100f);
            if (randomValue < (normalTileWeight / (normalTileWeight + pressAndHoldTileWeight)) * 100)
            {
                Instantiate(tileController._tileList._normalTile, child.position, Quaternion.identity, child);
            }
            else
            {
                Instantiate(tileController._tileList._pressAndHoldTile, child.position, Quaternion.identity, child);
            }
        }
    }
    protected virtual void spawnuntill()
    {
        Transform position = freeposition();
        if(position)
        {
            float randomValue = Random.Range(0f, 100f);
            if (randomValue < (normalTileWeight / (normalTileWeight + pressAndHoldTileWeight)) * 100)
            {
                GameObject tileNormal = Instantiate(tileController._tileList._normalTile, position.transform.position, Quaternion.identity);
                tileNormal.transform.parent = position;
            }
            else
            {
                GameObject tilePressAndHold = Instantiate(tileController._tileList._pressAndHoldTile,position.transform.position, Quaternion.identity);
                tilePressAndHold.transform.parent = position;
            }
            // GameObject tile = Instantiate(tileController._tileList._normalTile, position.transform.position, Quaternion.identity);
            // tile.transform.parent = position;
        }
        if(freeposition())
        {
            Invoke("spawnuntill", delay);
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
            this.spawnuntill();
        }
    }

    protected virtual Transform freeposition()
    {
        foreach(Transform child in transform)
        {
            if(child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }
}
