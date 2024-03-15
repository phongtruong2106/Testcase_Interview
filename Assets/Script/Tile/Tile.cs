using UnityEngine;

public class Tile : NewMonoBehaviour
{   
    [Header("Tile")]
    [SerializeField] protected float speedfall;
    public float _speedfall => speedfall;
    [SerializeField] protected LayerMask targetLayer;
    protected bool isPoint;
    public bool isInput;
    protected int countFail;
    protected bool isDE = true;

    private float elapsedTime;
    private const float timePerMinute = 60f;
    private const float speedIncreasePerMinute = 5f;
    protected override void Start()
    {
        base.Start();
        this.isPoint = false;
        this.isInput = false;
        this.elapsedTime = 0f;
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
        UpdateSpeed();
    }
    public bool IsInput()
    {
        return isInput;
    }
    protected virtual void MoveTile()
    {
        Vector3 currentPosition = transform.position;
        float newYPosition = currentPosition.y - (speedfall * Time.deltaTime);
        transform.position = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
    }

    protected void UpdateSpeed()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timePerMinute)
        {
            speedfall += speedIncreasePerMinute;
            elapsedTime -= timePerMinute;
        }
    }
}