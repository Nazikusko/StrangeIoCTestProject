using strange.extensions.mediation.impl;
using System;

public abstract class BrickViewBase : View
{
    public Action<BrickViewBase> OnHit;
    public abstract int Score { get; }
    public abstract BrickType BrickType { get; }
}

public enum BrickType
{
    Simple,
    DoubleHit,
    Unbreakable
}