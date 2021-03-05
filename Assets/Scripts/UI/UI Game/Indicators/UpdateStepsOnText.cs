using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStepsOnText : MonoBehaviour
{
    Text quantitySteps;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        
        quantitySteps = gameObject.GetComponent<Text>();
        quantitySteps.text = playerController.strokeCounter.ToString();
    }

    public void UpdateTextWithQuantitySteps(int steps)
    { 
        // проверяю шаг что бы был больше 0, если меньше 0, то не менять текст и оставить X
        quantitySteps.text = steps > 0 ? steps.ToString() : "X";
    }
}
