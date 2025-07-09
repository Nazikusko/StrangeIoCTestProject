using strange.extensions.context.impl;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameRoot : ContextView
{
    [field: SerializeField] public InputManager InputManager { get; private set; }
    [field: SerializeField] public Canvas Canvas { get; private set; }
    [field: SerializeField] public GameSpaceObjectsHolder GameSpaceObjectsHolder { get; private set; }

    public Config Config { get; private set; }

    void Awake()
    {
        Config = Resources.Load<Config>("Config");
        context = new GameContext(this);
    }

    IEnumerator Start()
    {
        yield return null;
        InputManager.Init(Canvas.GetComponent<GraphicRaycaster>());

        //var puddle = Instantiate(PuddlePrefab, GameSpaceObjectsHolder.PaddleStartPoint.position, Quaternion.identity, GameSpaceObjectsHolder.transform);
        //context.AddView(puddle);

        //var ball = Instantiate(BallPrefab, puddle.BallStartPoint.position, Quaternion.identity, GameSpaceObjectsHolder.transform);
        //context.AddView(ball);

        //var bricksSetup = Instantiate(Config.BricksLevelsSetup[0], GameSpaceObjectsHolder.BricksHolder);
        //bricksSetup.Init();
        //foreach (var brick in bricksSetup.AllBricks)
        //{
        //    context.AddView(brick);
        //}

        var startSignal = ((GameContext)context).injectionBinder.GetInstance<StartGamePlaySignal>();
        startSignal.Dispatch();
    }
}