using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void Push()
    {
        if(GetComponent<Actionable>().player.isHaveKey)
          Open();


        GetComponent<Actionable>().player.StrokeComplete();
    }

    /*
    Анимеция открытие двери\замка\сундука
    */
    void Open()
    {
        Destroy(gameObject);
    }
}
