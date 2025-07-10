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

        var startSignal = ((GameContext)context).injectionBinder.GetInstance<StartGamePlaySignal>();
        startSignal.Dispatch();
    }
}