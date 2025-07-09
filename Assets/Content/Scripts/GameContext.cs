using strange.extensions.context.impl;
using UnityEngine;

public class GameContext : MVCSContext
{
    private GameRoot _gameRoot;

    public GameContext(MonoBehaviour view) : base(view)
    {
    }

    protected override void mapBindings()
    {
        _gameRoot = ((GameObject)contextView).GetComponent<GameRoot>();
        
        injectionBinder.Bind<GameContext>().ToValue(this).ToSingleton();
        injectionBinder.Bind<Camera>().ToValue(_gameRoot.GameSpaceObjectsHolder.MainCamera).ToSingleton();
        injectionBinder.Bind<InputManager>().ToValue(_gameRoot.InputManager).ToSingleton();
        injectionBinder.Bind<GameSpaceObjectsHolder>().ToValue(_gameRoot.GameSpaceObjectsHolder).ToSingleton();
        injectionBinder.Bind<Config>().ToValue(_gameRoot.Config).ToSingleton();

        // Models
        injectionBinder.Bind<GameModel>().ToSingleton();
        injectionBinder.Bind<PlayerStatsModel>().ToSingleton();

        // Signals
        injectionBinder.Bind<StartGamePlaySignal>().ToSingleton();
        injectionBinder.Bind<BallLostSignal>().ToSingleton();
        injectionBinder.Bind<BrickHitSignal>().ToSingleton();
        injectionBinder.Bind<ScoreChangedSignal>().ToSingleton();
        injectionBinder.Bind<LivesChangedSignal>().ToSingleton();

        // Commands
        commandBinder.Bind<StartGamePlaySignal>().To<StartGamePlayCommand>();
        commandBinder.Bind<BallLostSignal>().To<HandleBallLostCommand>();
        commandBinder.Bind<BrickHitSignal>().To<HandleBrickHitCommand>();

        // Mediation
        mediationBinder.Bind<BrickViewSimple>().To<BrickSimpleMediator>();
        mediationBinder.Bind<BrickViewDoubleHit>().To<BrickDoubleHitMediator>();
        mediationBinder.Bind<BrickViewUnbreakable>().To<BrickUnbreakableMediator>();

        mediationBinder.Bind<BallView>().To<BallMediator>();
        mediationBinder.Bind<PaddleView>().To<PaddleMediator>();
        mediationBinder.Bind<MainHudView>().To<MainHudMediator>();
    }
}