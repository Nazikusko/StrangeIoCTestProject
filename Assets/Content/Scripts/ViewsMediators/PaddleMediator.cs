using strange.extensions.mediation.impl;

public class PaddleMediator : Mediator
{
    [Inject] public PaddleView View { get; private set; }
    [Inject] public GameModel GameModel { get; private set; }

    public override void OnRegister()
    {
        GameModel.PaddleView = View;
    }
}
