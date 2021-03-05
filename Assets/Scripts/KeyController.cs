using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {

        if(collider.tag == "Player")
        {
          GetComponent<Actionable>().player.isHaveKey = true;
          GetComponent<Actionable>().player.StrokeComplete();

          Destroy(gameObject);
        }
    }
}
