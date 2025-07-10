using strange.extensions.command.impl;
using System.Collections.Generic;
using UnityEngine;

public class StartGamePlayCommand : Command
{
    [Inject] public GameModel GameModel { get; private set; }
    [Inject] public ScoreChangedSignal ScoreChangedSignal { get; private set; }
    [Inject] public LivesChangedSignal LivesChangedSignal { get; private set; }
    [Inject] public GameContext context { get; private set; }
    [Inject] public GameSpaceObjectsHolder GameSpaceObjectsHolder { get; private set; }
    [Inject] public Config Config { get; private set; }

    public override void Execute()
    {
        GameModel.Reset();
        ScoreChangedSignal.Dispatch(GameModel.Score);
        LivesChangedSignal.Dispatch(GameModel.CurrentLives);

        if (GameModel.PaddleView != null)
        {
            GameObject.Destroy(GameModel.PaddleView.gameObject);
        }

        if (GameModel.BallView != null)
        {
            GameObject.Destroy(GameModel.BallView.gameObject);
        }

        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in GameSpaceObjectsHolder.BricksHolder)
        {
            children.Add(child.gameObject);
        }

        foreach (GameObject child in children)
        {
            GameObject.Destroy(child);
        }

        GameModel.PaddleView = GameObject.Instantiate(GameSpaceObjectsHolder.PuddlePrefab, GameSpaceObjectsHolder.PaddleStartPoint.position, Quaternion.identity, GameSpaceObjectsHolder.transform);
        context.AddView(GameModel.PaddleView);

        GameModel.BallView = GameObject.Instantiate(GameSpaceObjectsHolder.BallPrefab, GameModel.PaddleView.BallStartPoint.position, Quaternion.identity, GameSpaceObjectsHolder.transform);
        context.AddView(GameModel.BallView);

        if (GameModel.BricksRootTransform != null)
        {
            GameObject.Destroy(GameModel.BricksRootTransform.gameObject);
        }

        var bricksSetup = GameObject.Instantiate(Config.BricksLevelsSetup[0], GameSpaceObjectsHolder.BricksHolder); // TODO level switching
        bricksSetup.Init();
        GameModel.BricksRootTransform = bricksSetup.transform;

        foreach (var brick in bricksSetup.AllBricks)
        {
            context.AddView(brick);
        }
    }
}