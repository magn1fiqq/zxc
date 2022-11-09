using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange(string nameScene) // Используется в скрипте Game для перехода к сцене после прохождения
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Exit() // функция выхода из игры
    {
        Application.Quit();
        
    }

    public void Restart() // функция перезапуска игры
    {
        SceneManager.LoadScene(0);
    }

    public void GameStart() // функция начала игры
    {
        SceneManager.LoadScene(1);
    }
}
