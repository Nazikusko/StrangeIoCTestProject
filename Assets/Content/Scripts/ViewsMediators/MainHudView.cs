using UnityEngine;
using strange.extensions.mediation.impl;
using TMPro;

public class MainHudView : View
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _livesText;

    public void SetScoreText(int score)
    {
        _scoreText.text = $"Score: {score}";
    }

    public void SetLivesText(int lives)
    {
        _livesText.text = $"Lives: {lives}";
    }
}