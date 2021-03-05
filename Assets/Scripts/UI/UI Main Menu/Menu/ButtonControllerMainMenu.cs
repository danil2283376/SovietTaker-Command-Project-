using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerMainMenu : MonoBehaviour
{
    public void NewGame()
    {
        // загружаю сцены
        // пока что перекидываю в сцену постройки
        SceneManager.LoadScene("Level");
    }

    public void ChapterSelect()
    {
        // сделать выбор уровней
    }

    public void Exit()
    {
        // выход из приложения
        Application.Quit();
    }
}
