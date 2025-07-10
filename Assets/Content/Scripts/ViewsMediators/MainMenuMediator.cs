using strange.extensions.mediation.impl;

public class MainMenuMediator : Mediator
{
    [Inject] public MainMenuView View { get; set; }
    [Inject] public StartGameSignal StartGameSignal { get; set; }
    [Inject] public ExitGameSignal ExitGameSignal { get; set; }
    [Inject] public PlayerStatsModel PlayerStatsModel { get; set; }

    public override void OnRegister()
    {
        View.OnStartGame += StartGame;
        View.OnExitGame += ExitGame;
        View.Init();

        int score = PlayerStatsModel.MaxScore;
        View.SetMaxScore(score);
    }

    public override void OnRemove()
    {
        View.OnStartGame -= StartGame;
        View.OnExitGame -= ExitGame;
    }

    private void StartGame()
    {
        StartGameSignal.Dispatch();
    }

    private void ExitGame()
    {
        ExitGameSignal.Dispatch();
    }
}