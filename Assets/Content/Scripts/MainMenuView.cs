using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class MainMenuView : View
{
    public Button startButton;
    public Button exitButton;

    public System.Action onStartGame;
    public System.Action onExitGame;


    internal void Init()
    {
        startButton.onClick.AddListener(() => onStartGame?.Invoke());
        exitButton.onClick.AddListener(() => onExitGame?.Invoke());
    }
}