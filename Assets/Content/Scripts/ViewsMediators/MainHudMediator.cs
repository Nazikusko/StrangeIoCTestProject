using strange.extensions.mediation.impl;

public class MainHudMediator : Mediator
{
    [Inject] public MainHudView View { get; set; }
    [Inject] public ScoreChangedSignal ScoreChangedSignal { get; set; }
    [Inject] public LivesChangedSignal LivesChangedSignal { get; set; }

    public override void OnRegister()
    {
        ScoreChangedSignal.AddListener(OnScoreUpdateHandler);
        LivesChangedSignal.AddListener(OnLivesUpdateHandler);
    }

    public override void OnRemove()
    {
        ScoreChangedSignal.RemoveListener(OnScoreUpdateHandler);
        LivesChangedSignal.RemoveListener(OnLivesUpdateHandler);
    }

    private void OnScoreUpdateHandler(int newScore)
    {
        View.SetScoreText(newScore);
    }

    private void OnLivesUpdateHandler(int newLives)
    {
        View.SetLivesText(newLives);
    }
}