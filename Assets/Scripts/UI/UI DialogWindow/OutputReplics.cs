using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputReplics : MonoBehaviour
{
    //public GameObject activateButton;
    public GameObject canvasController;
    public Text outputForReplics;

    private DialogsPanel dialogsPanel;

    private void Start()
    {
        dialogsPanel = canvasController.GetComponent<DialogsPanel>();

        outputForReplics.text = dialogsPanel.heroReplics[dialogsPanel.quantityReplicsPassed];
        dialogsPanel.quantityReplicsPassed++;
    }

    public void OutputNextReplic()
    {
        if (dialogsPanel.quantityReplicsPassed < dialogsPanel.heroReplics.Length)
        {
            outputForReplics.text = dialogsPanel.heroReplics[dialogsPanel.quantityReplicsPassed];
            dialogsPanel.quantityReplicsPassed++;
        }
    }
}
