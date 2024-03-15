using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour
{
    [SerializeField] protected List<GameObject> normalTiles = new List<GameObject>();
    public List<GameObject> NormalTiles => normalTiles;
    [SerializeField] protected GameObject pressAndHoldTile;
    public GameObject _pressAndHoldTile => pressAndHoldTile;

    
    
}
