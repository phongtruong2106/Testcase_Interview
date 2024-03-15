using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSpawner : MonoBehaviour
{
   [SerializeField] protected LayerMask targetLayer;
   protected virtual void OnTriggerEnter2D(Collider2D other)
   {
    
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            Destroy(other.gameObject);
        }
   }
}
