using strange.extensions.mediation.impl;

public class BrickDoubleHitMediator : Mediator
{
    [Inject] public BrickViewDoubleHit View { get; set; }
    [Inject] public BrickHitSignal brickHitSignal { get; set; }

    public override void OnRegister()
    {
        View.OnHit += OnBrickHit;
    }

    private void OnBrickHit(BrickViewBase brick)
    {
        brickHitSignal.Dispatch(brick);
    }

    public override void OnRemove()
    {
        View.OnHit -= OnBrickHit;
    }
}