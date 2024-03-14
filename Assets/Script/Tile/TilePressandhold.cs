using UnityEngine;

public class TilePressandhold : Tile
{
    private SpriteRenderer spriteRenderer;
    private Gradient gradient;
    private MaterialPropertyBlock propertyBlock;
    [SerializeField] protected Color mainColor = Color.blue;
    [SerializeField] private bool isPressed = false;
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
            if (isPressed)
            {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                float t = Mathf.InverseLerp(Screen.height, 0, worldMousePosition.y);
                Color color = gradient.Evaluate(t);
                propertyBlock.SetColor("_Color", color);
                spriteRenderer.SetPropertyBlock(propertyBlock);
            }
        }
        else
        {
            Debug.LogWarning("Không tìm thấy SpriteRenderer!");
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        Debug.Log(isPressed);
    }

    private void OnMouseUp()
    {
        isPressed = false;
        Debug.Log(isPressed);
    }
}
