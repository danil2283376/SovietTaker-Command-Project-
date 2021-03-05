using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    PlayerController playerController;
    public bool isActive;
    public bool isPerionActive;

    int lastPlayerStrokeCount;

    public Sprite activeSprite;
    public Sprite deactiveSprite;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        lastPlayerStrokeCount = playerController.strokeCounter;
    }

    void Update()
    {
        if(isPerionActive && lastPlayerStrokeCount != playerController.strokeCounter)
        {
            isActive = !isActive;
            Boom();
        }
        
        if(isActive)
          GetComponent<SpriteRenderer>().sprite = activeSprite;
        else
          GetComponent<SpriteRenderer>().sprite = deactiveSprite;
    }

    void Boom()
    {
        lastPlayerStrokeCount = playerController.strokeCounter;
    }

    /*
    Когда игрок напарывается на АКТИВНУЮ мину, у него отнимается один дополнительный ход
    */
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(isActive)
            {
                playerController.strokeCounter--;
                Boom();
            }
        }
    }
}
