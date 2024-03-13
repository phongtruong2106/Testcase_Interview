using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTarget : MonoBehaviour
{
    [SerializeField] protected float width = 10f;
    [SerializeField] protected float height = 5f;

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
}
