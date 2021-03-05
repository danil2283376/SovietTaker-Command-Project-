using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerChangePlayer : MonoBehaviour
{
    public GameObject canvasController;

    private DialogsPanel dialogsPanel;

    private void Start()
    {
        dialogsPanel = canvasController.GetComponent<DialogsPanel>();
    }

    public void Replay()
    {
        // перезагрузка уровня
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLvl()
    {
        if ((dialogsPanel.quantityReplicsPassed) == dialogsPanel.heroReplics.Length)
        {
            // загрузить следующий уровень
            SceneManager.LoadScene("MainMenu");
        }
    }
}
