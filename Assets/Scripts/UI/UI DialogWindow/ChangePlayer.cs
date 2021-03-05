using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    // канвас который сохраняет все изменения
    public GameObject canvasController;
    // кнопки с выбором
    public Button choiceButton;
    public Button choiceButton1;
    // в тексте используется выбор
    public Text choiceText;
    public Text choiceText1;
    public Text outputReplics;

    public GameObject winPanel;
    public GameObject losePanel;

    private DialogsPanel dialogsPanel;

    private void Start()
    {
        dialogsPanel = canvasController.GetComponent<DialogsPanel>();

        SetSelectionText();
    }

    private void SetSelectionText()
    {
        // устанавливаю в кнопки текст
        choiceText.text = dialogsPanel.changePlayer[0];
        choiceText1.text = dialogsPanel.changePlayer[1];

        // проверяю где будет победа
        if (dialogsPanel.win == 1)
        {
            choiceButton.onClick.AddListener(Win);
            choiceButton1.onClick.AddListener(Lose);
        }
        else
        {
            choiceButton1.onClick.AddListener(Win);
            choiceButton.onClick.AddListener(Lose);
        }
    }

    public void Win()
    {
        print("Победил");
        dialogsPanel.stateCharacter = "Glad";
        //outputReplics.GetComponent<OutputReplics>().OutputNextReplic();

        choiceButton.gameObject.SetActive(false);
        choiceButton1.gameObject.SetActive(false);
        winPanel.SetActive(true);
        // довывести все реплики которые остались, и активировать игру на заднем плане
    }

    public void Lose()
    {
        print("Проебал");
        dialogsPanel.stateCharacter = "Sad";

        choiceButton.gameObject.SetActive(false);
        choiceButton1.gameObject.SetActive(false);
        losePanel.SetActive(true);
        // Выдать Panel с поражением, и перезапустить уровень
    }
}
