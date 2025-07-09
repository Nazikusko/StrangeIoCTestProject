using System;
using UnityEngine;

public class BrickViewDoubleHit : BrickViewBase
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite _firstHitSprite;

    public override int Score => 100;
    public override BrickType BrickType => BrickType.DoubleHit;
    
    [NonSerialized] public int HitsLeft;

    void Start()
    {
        HitsLeft = 2;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            if (HitsLeft == 2)
            {
                _spriteRenderer.sprite = _firstHitSprite;
            }

            OnHit?.Invoke(this);
        }
    }
}