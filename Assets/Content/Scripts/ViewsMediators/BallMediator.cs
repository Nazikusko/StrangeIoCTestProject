using strange.extensions.mediation.impl;
using UnityEngine;

public class BallMediator : Mediator
{
    [Inject] public BallView View { get; private set; }
    [Inject] public BallLostSignal BallLostSignal { get; private set; }
    [Inject] public GameModel GameModel { get; private set; }

    public override void OnRegister()
    {
        GameModel.BallView = View;
        View.OnBallLost += OnBallLost;
    }

    public override void OnRemove()
    {
        View.OnBallLost -= OnBallLost;
    }

    private void OnBallLost()
    {
        BallLostSignal.Dispatch();
    }
}