using strange.extensions.mediation.impl;

public class MainMenuMediator : Mediator
{
    [Inject] public MainMenuView view { get; set; }
    [Inject] public StartGameSignal startGameSignal { get; set; }
    [Inject] public ExitGameSignal exitGameSignal { get; set; }
    [Inject] public PlayerStatsModel playerStatsModel { get; set; }

    public override void OnRegister()
    {
        view.OnStartGame += StartGame;
        view.OnExitGame += ExitGame;
        view.Init();

        int score = playerStatsModel.MaxScore;
        view.SetMaxScore(score);
    }

    public override void OnRemove()
    {
        view.OnStartGame -= StartGame;
        view.OnExitGame -= ExitGame;
    }

    private void StartGame()
    {
        startGameSignal.Dispatch();
    }

    private void ExitGame()
    {
        exitGameSignal.Dispatch();
    }
}