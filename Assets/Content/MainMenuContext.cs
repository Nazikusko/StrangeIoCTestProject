using strange.extensions.context.impl;
using UnityEngine;

public class MainMenuContext : MVCSContext
{
    public MainMenuContext(MonoBehaviour view) : base(view) { }


    protected override void mapBindings()
    {
        // Signals
        injectionBinder.Bind<StartGameSignal>().ToSingleton();
        injectionBinder.Bind<ExitGameSignal>().ToSingleton();

        // Commands
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
        commandBinder.Bind<ExitGameSignal>().To<ExitGameCommand>();
        
        // Views and Mediators
        mediationBinder.Bind<MainMenuView>().To<MainMenuMediator>();
    }
}