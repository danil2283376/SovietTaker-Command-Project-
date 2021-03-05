using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour
{
    public List<GameObject> detectObjects;

    //При появлении в зоне объекта с коллайдером
    //он добавляется в detectObjects
    void OnTriggerStay2D(Collider2D collider)
    {
        GameObject detectObject = collider.gameObject;
        if(detectObject.tag != "DetectZone" && !detectObjects.Contains(detectObject))
          detectObjects.Add(detectObject);
    }

    //При выходе объекта из зоны из detectObjects удаляется
    //gameObject
    void OnTriggerExit2D(Collider2D collider)
    {
        detectObjects.Remove(collider.gameObject);
        //CheckList();
    }


    //Выполняет проверку на null-объекты
    void CheckList()
    {
        bool end = false;
        while(!end)
        {
          int i = 0;
          while(detectObjects[i] != null)
            i++;

          if(i == detectObjects.Count)
            end = true;
        }
    }
}
