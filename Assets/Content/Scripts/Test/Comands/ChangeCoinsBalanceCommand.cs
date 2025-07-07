using strange.extensions.command.impl;
using UnityEngine;

public class ChangeCoinsBalanceCommand : Command
{
    [Inject] public MainModel Model { get; private set; }
    [Inject] public int Amount { get; private set; }

    public override void Execute()
    {
        Model.Coins += Amount;
        Debug.Log($"New balance: {Model.Coins}");
    }
}
