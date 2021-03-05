using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentLvl : MonoBehaviour
{
    Text currentLvl;
    private void Start()
    {
        currentLvl = GetComponent<Text>();


        currentLvl.text = GetLvl();
    }

    // получение текущего уровня
    private string GetLvl()
    {
        // строка из чисел
        string numberScene = "";
        // получаю название сцены и перевожу ее в символы
        char[] nameScene = SceneManager.GetActiveScene().name.ToCharArray();
        // прохожу по символам
        for (int i = 0; i < nameScene.Length; i++)
        {
            // если символ является числом
            if (Char.IsDigit(nameScene[i]))
            {
                // то добавить строке число
                numberScene += nameScene[i];
            }
        }
        // вывод строки
        return numberScene;
    }
}
