using strange.extensions.mediation.impl;

public class BrickSimpleMediator : Mediator
{
    [Inject] public BrickViewSimple View { get; set; }
    [Inject] public BrickHitSignal BrickHitSignal { get; set; }

    public override void OnRegister()
    {
        View.OnHit += OnBrickHit;
    }

    private void OnBrickHit(BrickViewBase brick)
    {
        BrickHitSignal.Dispatch(brick);
    }

    public override void OnRemove()
    {
        View.OnHit -= OnBrickHit;
    }
}