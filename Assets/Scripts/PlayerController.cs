using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public enum Direction {Up, Left, Down, Right};

    public Text textWithSteps;                                                  // текст с счетчиком
    public int strokeCounter;

    public bool isHaveKey;

    public DetectZone upZone;
    public DetectZone leftZone;
    public DetectZone downZone;
    public DetectZone rightZone;

    //public AudioSource soundMovePlayer; // звук ходьбы

    Vector2 targetPosition;                                                     ///Координаты места, куда надо двигать игрока
    public float speed;                                                          ///Скорость, с которой надо двигать ящик
    bool isMoving;                                                              ///Определяет находится ли ящик в данный момент в движении

    void Update()
    {
        if(!isMoving)
        {
            if(Input.GetButtonDown("Up"))
            {
                SetDirection(Direction.Up);
            }

            if(Input.GetButtonDown("Down"))
            {
                SetDirection(Direction.Down);
            }

            if(Input.GetButtonDown("Left"))
            {
                SetDirection(Direction.Left);
            }

            if(Input.GetButtonDown("Right"))
            {
                SetDirection(Direction.Right);
            }
        }

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
            //soundMovePlayer.pitch = Random.Range(0.7f, 1.3f); // проверка работоспособности звука
            //soundMovePlayer.Play(); // проигрываю звук
            isMoving = false;
        }
    }

    //Выбирает направление, на котором нужно проверить наличие объектов
    void SetDirection(Direction dir)
    {
        if (strokeCounter <= 0)
            Decommunization();

        switch (dir)
        {
            case Direction.Up:
            if(CheckDirection(Vector2.up, upZone))
            {
              targetPosition = transform.position + Vector3.up;
              isMoving = true;
            }
            break;

            case Direction.Left:
            if(CheckDirection(-Vector2.right, leftZone))
            {
              targetPosition = transform.position - Vector3.right;
              isMoving = true;
            }
            break;

            case Direction.Down:
            if(CheckDirection(-Vector2.up, downZone))
            {
              targetPosition = transform.position - Vector3.up;
              isMoving = true;
            }
            break;

            case Direction.Right:
            if(CheckDirection(Vector2.right, rightZone))
            {
              targetPosition = transform.position + Vector3.right;
              isMoving = true;
            }
            break;
        }
    }

    /*
    Возвращает true, если на пути не обноруженно препятсвий
                прим. : ключ не препятсвие

    В ином случае возвращает false
    */
    bool CheckDirection(Vector2 direction, DetectZone detectZone)
    {
        try
        {
            bool isWalkable = true;

            for(int i = 0; i < detectZone.detectObjects.Count; i++)
            {
                Actionable actionable = detectZone.detectObjects[i].GetComponent<Actionable>();
                actionable.direction = direction;
                actionable.player = this;
                actionable.action.Invoke();

                if(!actionable.isWalkable)
                  isWalkable = false;
            }

            if(isWalkable)
              StrokeComplete();


            return isWalkable;
        }
        catch(UnassignedReferenceException){}
        catch(System.NullReferenceException){}

        StrokeComplete();


        return true;
    }


    void Decommunization()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StrokeComplete()
    {
        strokeCounter--;

        // обновляю текст с шагами
        //textWithSteps.GetComponent<UpdateStepsOnText>().UpdateTextWithQuantitySteps(strokeCounter);
    }
}
