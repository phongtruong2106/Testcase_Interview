using UnityEngine;

public class Tile : NewMonoBehaviour
{   
    [Header("Tile")]
    [SerializeField] protected float speedfall;
    [SerializeField] protected LayerMask targetLayer;
    protected bool isPoint;
    protected int countFail;
    protected bool isDE = true;
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
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
    
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            this.isPoint = false;
        }
    }
    protected virtual void Update()
    {
        MoveTile();
    }
    protected virtual void MoveTile()
    {
        Vector3 currentPosition = transform.position;
        float newYPosition = currentPosition.y - (speedfall * Time.deltaTime);
        transform.position = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
    }

    
}