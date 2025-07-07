using UnityEngine;

public class MainContext : SignalContext
{
    public MainContext(MonoBehaviour view) : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();
        injectionBinder.Bind<MainModel>().ToSingleton();
        commandBinder.Bind<AppStartSignal>().InSequence().To<ShowLoadingCommand>().To<AppStartCommand>().To<HideLoadingCommand>().Once();
        commandBinder.Bind<ChangeCoinsBalanceSignal>().To<ChangeCoinsBalanceCommand>();
    }
}
