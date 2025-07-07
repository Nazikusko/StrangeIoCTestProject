using strange.extensions.mediation.impl;

public class MainMenuMediator : Mediator
{
    [Inject] public MainMenuView view { get; set; }
    [Inject] public StartGameSignal startGameSignal { get; set; }
    [Inject] public ExitGameSignal exitGameSignal { get; set; }


    public override void OnRegister()
    {
        view.onStartGame = () => startGameSignal.Dispatch();
        view.onExitGame = () => exitGameSignal.Dispatch();
        view.Init();
    }

    public override void OnRemove()
    {
        view.onStartGame = null;
        view.onExitGame = null;
    }
}