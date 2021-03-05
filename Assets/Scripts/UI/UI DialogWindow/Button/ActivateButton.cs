using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateButton : MonoBehaviour
{
    public GameObject canvasController;
    public GameObject resumeDialogButton;
    public GameObject changePlayerPanel;
    public GameObject choiceButton;
    [HideInInspector]
    public bool isCheck = true;

    private DialogsPanel dialogsPanel;

    private void Start()
    {
        dialogsPanel = canvasController.GetComponent<DialogsPanel>();
        SelectButton(resumeDialogButton);
    }

    private void Update()
    {
        // нужно ли сейчас проверять, иначе тупо зациклено будет включать и выключать элементы
        if (isCheck)
        {
            // количество реплик пройденных == выбору геймдизанера
            // активируем выбор
            if (dialogsPanel.quantityReplicsPassed == dialogsPanel.choicePlayer)
            {
                ActiveOrDeactive(resumeDialogButton, false);
                ActiveOrDeactive(changePlayerPanel, true);
                SelectButton(choiceButton);
            }
            // активация кнопки продолжения
            else
            {
                ActiveOrDeactive(resumeDialogButton, true);
                ActiveOrDeactive(changePlayerPanel, false);
                SelectButton(resumeDialogButton);
            }
        }
    }
    // если пользователь нажал на кнопку, то можно делать проверку
    public void ActivateCheckingState()
    {
        isCheck = true;
    }
    // Активировать или деактивировать элемент
    private void ActiveOrDeactive(GameObject gameObjectForActivate, bool activate)
    {
        gameObjectForActivate.SetActive(activate);
        // отключить проверку
        isCheck = false;
    }
    // Что бы EventSystem был сконцентрирован на кнопке всегда
    private void SelectButton(GameObject button)
    {
        if (EventSystem.current != button) 
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);
        }
    }
}
