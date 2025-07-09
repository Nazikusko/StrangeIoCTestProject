using strange.extensions.command.impl;

public class HandleBallLostCommand : Command
{
    [Inject] public GameModel GameModel { get; private set; }
    [Inject] public ScoreChangedSignal ScoreChangedSignal { get; private set; }
    [Inject] public LivesChangedSignal LivesChangedSignal { get; private set; }
    [Inject] public PlayerStatsModel GameStatsModel { get; private set; }
    [Inject] public StartGamePlaySignal StartGamePlaySignal { get; private set; }

    public override void Execute()
    {
        if (GameModel.CurrentLives >= 1)
        {
            GameModel.CurrentLives--;
        }
        else
        {
            GameStatsModel.MaxScore = GameModel.Score;
            GameModel.Reset();
            ScoreChangedSignal.Dispatch(GameModel.Score);
            StartGamePlaySignal.Dispatch();
        }

        LivesChangedSignal.Dispatch(GameModel.CurrentLives);

        var ball = GameModel.BallView;
        var paddle = GameModel.PaddleView;

        ball.ReturnToPaddle(paddle);
    }
}