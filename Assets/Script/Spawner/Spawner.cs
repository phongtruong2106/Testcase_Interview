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

    protected virtual void spawnuntill()
    {
        Transform position = freeposition();
        if(position)
        {
            float randomValue = Random.Range(0f, 100f);
            if (randomValue < (normalTileWeight / (normalTileWeight + pressAndHoldTileWeight)) * 100)
            {
                GameObject selectedTile = ChooseTileFromList(tileController._tileList.NormalTiles);
                if (selectedTile != null)
                {
                    GameObject tileNormal = Instantiate(selectedTile, position.transform.position, Quaternion.identity);
                    tileNormal.transform.parent = position;
                }
            }
            else
            {
                GameObject tilePressAndHold = Instantiate(tileController._tileList._pressAndHoldTile, position.transform.position, Quaternion.identity);
                tilePressAndHold.transform.parent = position;
            }
        }
        if(freeposition())
        {
            Invoke("spawnuntill", delay);
        }
    }

    protected virtual GameObject ChooseTileFromList(List<GameObject> tileList)
    {
        float totalWeight = 0f;
        foreach (GameObject tile in tileList)
        {
            totalWeight += 1f;
        }
        float randomWeight = Random.Range(0f, totalWeight);
        float weightSum = 0f;
        foreach (GameObject tile in tileList)
        {
            weightSum += 1f;
            if (randomWeight <= weightSum)
            {
                return tile;
            }
        }
        return null;
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
