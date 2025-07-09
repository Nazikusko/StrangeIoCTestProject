using UnityEngine;

public class BrickViewSimple : BrickViewBase
{
    public override int Score => 100;
    public override BrickType BrickType => BrickType.Simple;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            OnHit?.Invoke(this);
        }
    }
}