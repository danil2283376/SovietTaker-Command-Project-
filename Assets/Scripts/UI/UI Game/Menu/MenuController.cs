using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endPosition;
    public EventSystem eventSystem;
    public GameObject player;
    public Button firstSelectedButton;

    private bool menuBehindScreen = true;
    private Vector2 positionBehindScreen;
    private Vector2 positionInScreen;

    private PlayerController playerController;

    private void Start()
    {
        // по дефолту время возобновлено
        Time.timeScale = 1f;
        // кэширую данные для игрока
        playerController = player.GetComponent<PlayerController>();

        positionInScreen = pauseMenu.transform.position;
        positionBehindScreen = endPosition.transform.position;

        // скрываю при старте меню
        pauseMenu.transform.position = positionBehindScreen;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //menuBehindScreen = !menuBehindScreen;

            ActivateMenu(menuBehindScreen);

            menuBehindScreen = !menuBehindScreen;
        }
    }
    // активировать меню или убирать
    public void ActivateMenu(bool activateMenu)
    {
        if (activateMenu)
        {
            // показываю меню
            eventSystem.enabled = true;
            // устанавливаю первый выбранный элемент меню
            eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);

            pauseMenu.transform.position = positionInScreen;
            // останавливаю время на фоне
            Time.timeScale = 0f;
            // деактивирую скрипт на игроке
            playerController.enabled = false;
        }
        else
        {
            // скрываю меню
            eventSystem.enabled = false;
            // убираю выбранный элемент
            eventSystem.SetSelectedGameObject(null);

            pauseMenu.transform.position = positionBehindScreen;
            // возобновляю время на фоне
            Time.timeScale = 1f;
            // активирую скрипт на игроке
            playerController.enabled = true;
        }
    }
}
