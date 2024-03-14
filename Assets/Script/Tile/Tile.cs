using UnityEngine;

public class Tile : NewMonoBehaviour
{   
    [Header("Tile")]
    [SerializeField] protected float speedfall;

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