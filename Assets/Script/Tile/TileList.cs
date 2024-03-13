using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour
{
    [SerializeField] protected List<GameObject> tileList = new List<GameObject>();
    public List<GameObject> _tileList => tileList;
}
