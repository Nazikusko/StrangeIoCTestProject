using System.Threading.Tasks;
using strange.extensions.command.impl;
using UnityEngine;

public class AppStartCommand : Command
{
    [Inject] public ChangeCoinsBalanceSignal ChangeCoinsBalanceSignal { get; private set; }

    public override void Execute()
    {
        Retain();
        Debug.Log("AppStartCommand executed");
        ChangeCoinsBalanceSignal.AddListener((int amount) => { Debug.Log($"Balnce chenged {amount}");});
        LoadAssetsAsync();
    }

    private async void LoadAssetsAsync()
    {
        await Task.Delay(4000);
        Debug.Log("Assets loaded");
        ChangeCoinsBalanceSignal.Dispatch(100);
        ChangeCoinsBalanceSignal.Dispatch(-50);
        ChangeCoinsBalanceSignal.RemoveAllListeners();

        Release();
    }
}
