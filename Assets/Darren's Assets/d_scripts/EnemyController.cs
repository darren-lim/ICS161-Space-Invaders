using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    //This script will change the direction of the whole block of enemies as well as
    //choose a random enemy to fire the bullet.

    public Dictionary<EnemyScript, UnityEvent> HitWallEvent;
    public GameObject[,] EnemyObjectArray;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This method will go down every column and cache the bottom most enemy
    //then it will randomly choose which enemy fires the bullet.
    public void ChooseEnemyToFire()
    {

    }

    //This method will be called by an enemy that has hit a wall and send out a event signal
    public void ChangeDirectionEvent()
    {

    }
}
