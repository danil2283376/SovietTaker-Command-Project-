using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector2 direction;

    public DetectZone upZone;
    public DetectZone leftZone;
    public DetectZone downZone;
    public DetectZone rightZone;


    Vector2 targetPosition;                                                     ///Координаты места, куда надо двигать вражину
    public float speed;                                                          ///Скорость, с которой надо двигать ящик
    bool isMoving;                                                              ///Определяет находится ли ящик в данный момент в движении

    void Update()
    {
        if(isMoving)
          Move();
    }

    //Плавное движение к точке
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPosition) <= 0.05f)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x),
                                             Mathf.Round(transform.position.y));
            isMoving = false;
        }
    }

    public void Push()
    {
        direction = GetComponent<Actionable>().direction;

        if(CheckDirection())
        {
            targetPosition = transform.position + new Vector3(direction.x, direction.y);
            isMoving = true;
        }
        else
          Death();                                                              //Если толкать некуда, то СМЭЭЭРТ

        GetComponent<Actionable>().player.StrokeComplete();
    }

    /*
    Возвращает зону для проверки в соответствии с толканием
    Например, если игрок толкнул коробку наверх, то
    будет возвращено upZone, чтобы проверить есть ли объекты над коробкой
    */
    DetectZone GetZone()
    {
        if(direction == Vector2.up)
            return upZone;

        if(direction == -Vector2.right)
            return leftZone;

        if(direction == -Vector2.up)
            return downZone;

        if(direction == Vector2.right)
            return rightZone;

        return null;
    }

    /*
    Возвращает true, если на пути не обноруженно препятсвий
                прим. : ключ не препятсвие

    В ином случае возвращает false
    */
    bool CheckDirection()
    {
        if(GetZone().detectObjects.Count == 0)
          return true;

        bool returnValue = false;
        for(int i = 0; i < GetZone().detectObjects.Count; i++)
        {
            GameObject detectObject = GetZone().detectObjects[i];

            if(detectObject == null)
                returnValue = true;

            if(detectObject.tag == "Key")
                returnValue = true;
        }


        return returnValue;
    }

    /*
    Отвечает за уничтожение врага и анимацию разрушения
    */
    void Death()
    {
        Destroy(gameObject);
    }
}
