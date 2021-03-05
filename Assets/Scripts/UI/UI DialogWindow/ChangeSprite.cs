using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public GameObject canvasController;
    private Image imageCharacter;

    private DialogsPanel dialogsPanel;
    private bool stateHasChanged = false;

    private void Start()
    {
        dialogsPanel = canvasController.GetComponent<DialogsPanel>();
        imageCharacter = GetComponent<Image>();
        // Устанавливаю дефолтный спрайт
        imageCharacter.sprite = dialogsPanel.idleCharacter;
    }

    private void Update()
    {
        // Проверяю какой сейчас надо ставит спрайт
        ChoiceSprite();
    }

    private void ChoiceSprite()
    {
        switch (dialogsPanel.stateCharacter)
        {
            case "Idle":
                ChangeImageForSprite(dialogsPanel.idleCharacter);
                break;
            case "Glad":
                ChangeImageForSprite(dialogsPanel.gladCharacter);
                break;
            case "Sad":
                ChangeImageForSprite(dialogsPanel.sadCharacter);
                break;
            default:
                ChangeImageForSprite(dialogsPanel.idleCharacter);
                break;
        }
    }

    // присваиваю спрайту необходимый
    private void ChangeImageForSprite(Sprite stateCharacter)
    {
        imageCharacter.sprite = stateCharacter;
    }
}
