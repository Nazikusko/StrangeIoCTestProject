using UnityEngine;

public class GameModel
{
    public BallView BallView;
    public PaddleView PaddleView;
    public Transform BricksRootTransform;

    public int CurrentLives;
    public int Score { get; private set; }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void Reset()
    {
        CurrentLives = 3;
        Score = 0;
    }
}