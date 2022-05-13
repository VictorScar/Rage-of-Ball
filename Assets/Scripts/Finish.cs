using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    //Триггер достижения финиша персонажем
    public GameObject player;
    
    void Start()
    {
        State.finishing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
           
            State.finishing = true;
        }
    }
}
