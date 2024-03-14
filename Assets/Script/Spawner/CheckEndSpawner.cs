using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndSpawner : MonoBehaviour
{
   [SerializeField] protected LayerMask targetLayer;
   protected virtual void OnTriggerEnter2D(Collider2D other)
   {
    
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            Tile tileComponent = other.GetComponent<Tile>();
            if(tileComponent.isInput == false)
            {
                PointFailCounterManager.Instance.AddScore(1);
            }
        }
   }
}
