using UnityEngine;

public class TilePressandhold : Tile
{
    [Header("Tile Press And Hold")]
    private SpriteRenderer spriteRenderer;
    private Gradient gradient;
    private MaterialPropertyBlock propertyBlock;
    [SerializeField] protected Color mainColor = Color.blue;
    [SerializeField] private bool isPressed = false;
    [SerializeField] private float timeToIncrement = 1f;
    [SerializeField] private int pointsPerIncrement = 1;
    [SerializeField] private int pointsToAdd = 1;

    private float pressTime = 0f;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.red, 0f), new GradientColorKey(Color.blue, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) }
        );
        propertyBlock = new MaterialPropertyBlock();
    }

    protected override void Update()
    {
        if (spriteRenderer != null)
        {  
            base.Update();
            if(isPressed)
            {
                    float heldTime = Time.time - pressTime;
                    if (heldTime >= timeToIncrement)
                    {
                        ScoreManager.Instance.AddScore(pointsPerIncrement);
                        pressTime = Time.time;
                    }

                    float t = Mathf.InverseLerp(0f, timeToIncrement, heldTime);
                    Color color = gradient.Evaluate(t);
                    propertyBlock.SetColor("_Color", color);
                    spriteRenderer.SetPropertyBlock(propertyBlock);
                    isDE = true;
                
            }
        }
        else
        {
            Debug.LogWarning("Dont Find Sprite Render");
        }
    }
    private void OnMouseDown()
    {
        if(isDE)
        {
            if(isPoint)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isPressed = true;
                    pressTime = Time.time;
                }
            }
            else
            {
                PointFailCounterManager.Instance.AddScore(pointsToAdd);
                isDE = false;
            }
        }

    }
    private void OnMouseUp()
    {
        if(isDE)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isPressed = false;
                Debug.Log(isPressed);
            }
        }
    }
}
