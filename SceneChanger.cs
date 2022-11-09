using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange(string nameScene) // ������������ � ������� Game ��� �������� � ����� ����� �����������
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Exit() // ������� ������ �� ����
    {
        Application.Quit();
        
    }

    public void Restart() // ������� ����������� ����
    {
        SceneManager.LoadScene(0);
    }

    public void GameStart() // ������� ������ ����
    {
        SceneManager.LoadScene(1);
    }
}
