using strange.extensions.command.impl;
using UnityEngine;

public class HideLoadingCommand : Command
{
    public override void Execute()
    {
        Debug.Log("HideLoadingCommand executed");
    }
}
