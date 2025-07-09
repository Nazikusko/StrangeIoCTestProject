using UnityEngine;

public class BrickViewUnbreakable : BrickViewBase
{
    public override int Score => 0;
    public override BrickType BrickType => BrickType.Unbreakable;
}