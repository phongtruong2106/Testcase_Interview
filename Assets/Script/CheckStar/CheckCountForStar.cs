using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCountForStar : NewMonoBehaviour
{
   [SerializeField] private SpriteRenderer star1;
   public SpriteRenderer _star1 => star1;
   [SerializeField] private SpriteRenderer star2;
   public SpriteRenderer _star2 => star2;
   [SerializeField] private SpriteRenderer star3;
   public SpriteRenderer _star3 => star3;


    protected override void Start()
    {
        base.Start();
        this.star1.color = Color.black;
        this.star2.color = Color.black;
        this.star3.color = Color.black;
    }
}
