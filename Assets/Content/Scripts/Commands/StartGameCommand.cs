using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameCommand : Command
{
    public override void Execute()
    {
        Debug.Log("StartGameCommand: Загрузка игровой сцены...");
        SceneManager.LoadScene("GameScene"); // Замените на имя вашей игровой сцены
    }
}