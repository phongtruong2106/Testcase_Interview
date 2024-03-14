using UnityEngine;

public class CheckPoint : NewMonoBehaviour
{
   [SerializeField] protected LayerMask targetLayer;
   public bool isPoint;

    protected override void Start()
    {
        base.Start();
        this.isPoint = false;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
   {
    
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            this.isPoint = true;
        }
   }
}