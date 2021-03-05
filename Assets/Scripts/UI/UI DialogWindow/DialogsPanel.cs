using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogsPanel : MonoBehaviour
{
    [Header("Перенесите картинки спокойного, веселого, и грустного персонажа!")]
    public Sprite idleCharacter;
    public Sprite gladCharacter;
    public Sprite sadCharacter;

    [Header("Текстовое поле для вывода реплик игроку.")]
    public Text textForOutputReplics;

    [Header("Введите кол-во реплик, и сами реплики!")]
    public string[] heroReplics;

    [Header ("Введите в какой момент выдать игроку выбор")]
    public int choicePlayer;

    [Header("Введите выбор игроком")]
    public string[] changePlayer = new string[2];

    [Header("Введите в какой кнопке будет победа при выборе")]
    [Range(1, 2)]
    public int win;

    [HideInInspector]
    public string stateCharacter;
    [HideInInspector]
    public int quantityReplicsPassed;

    [Header("Это для прогеров")]
    public GameObject gameBackground;
    public GameObject mainMenu;

    private void Start()
    {
        // отключаю остальные взаимодействия
        gameBackground.SetActive(false);
        mainMenu.SetActive(false);
    }
}
