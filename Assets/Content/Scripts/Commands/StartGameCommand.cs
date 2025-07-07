using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameCommand : Command
{
    public override void Execute()
    {
        Debug.Log("StartGameCommand: �������� ������� �����...");
        SceneManager.LoadScene("GameScene"); // �������� �� ��� ����� ������� �����
    }
}