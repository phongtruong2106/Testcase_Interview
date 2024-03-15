using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenClick : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color blackColor = Color.black;
    private Color whiteColor = Color.white;
    private bool isBlack = true;

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        if (isBlack)
            spriteRenderer.color = whiteColor;
        else
            spriteRenderer.color = blackColor;

        isBlack = !isBlack;
    }
    
}
