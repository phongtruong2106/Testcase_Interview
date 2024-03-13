using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSpawner : MonoBehaviour
{
   protected virtual void OnCollisionEnter2D(Collision2D other)
   {
        Destroy(other.gameObject);
   }
}
