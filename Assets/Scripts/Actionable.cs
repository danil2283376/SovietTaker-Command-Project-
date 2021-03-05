using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actionable : MonoBehaviour
{
    public UnityEvent action;
    public Vector2 direction;
    public PlayerController player;                                                   
    public bool isWalkable;
}
