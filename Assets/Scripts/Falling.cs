using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    //Триггер падения персонажа
    private float startY;
    private float distancefall=15f;
    
    void Start()
    {
        startY = transform.position.y;
        State.falling = false;
    }

    
    void Update()
    {
       if (startY - transform.position.y > distancefall)
        {
            State.falling = true;
        }
    }
}
