using System;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _maxScoreText;

    public event Action OnStartGame;
    public event Action OnExitGame;

    internal void Init()
    {
        _startButton.onClick.AddListener(() => OnStartGame?.Invoke());
        _exitButton.onClick.AddListener(() => OnExitGame?.Invoke());
    }

    public void SetMaxScore(int score)
    {
        _maxScoreText.text = $"Max Score: {score}";
    }
}