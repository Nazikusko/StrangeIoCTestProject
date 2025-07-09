using strange.extensions.command.impl;
using UnityEngine;

public class HandleBrickHitCommand : Command
{
    [Inject] public BrickViewBase Brick { get; private set; }
    [Inject] public GameModel Model { get; private set; }
    [Inject] public ScoreChangedSignal ScoreChanged { get; private set; }

    public override void Execute()
    {
        Model.AddScore(Brick.Score);
        ScoreChanged.Dispatch(Model.Score);

        switch (Brick.BrickType)
        {
            case BrickType.Simple:
                Object.Destroy(Brick.gameObject);
                break;
            case BrickType.DoubleHit:
                var doubleHitBrick = (BrickViewDoubleHit)Brick;
                if (doubleHitBrick.HitsLeft > 1)
                {
                    doubleHitBrick.HitsLeft--;
                }
                else
                {
                    Object.Destroy(Brick.gameObject);
                }
                break;
        }
    }
}