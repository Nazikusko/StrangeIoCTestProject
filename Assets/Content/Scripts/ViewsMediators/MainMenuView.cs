using System;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TMP_Text maxScoreText;

    public event Action OnStartGame;
    public event Action OnExitGame;

    internal void Init()
    {
        startButton.onClick.AddListener(() => OnStartGame?.Invoke());
        exitButton.onClick.AddListener(() => OnExitGame?.Invoke());
    }

    public void SetMaxScore(int score)
    {
        maxScoreText.text = $"Max Score: {score}";
    }
}