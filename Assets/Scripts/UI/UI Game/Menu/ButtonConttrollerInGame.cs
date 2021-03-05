using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonConttrollerInGame : MonoBehaviour
{

    public void Resume()
    {
        GetComponent<MenuController>().ActivateMenu(false);
    }

    public void SkipLvl()
    {
        print("следующий уровень");
    }

    public void MusicVolume()
    {
        print("Регулировка музыки");
    }

    public void SoundVolume()
    {
        print("регулировка звуков");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
