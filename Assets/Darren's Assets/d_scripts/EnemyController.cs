using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    //This script will change the direction of the whole block of enemies as well as
    //choose a random enemy to fire the bullet.

    public delegate void HitWallEvent(bool HitRightWall);
    public static event HitWallEvent HitWall;

    //public Dictionary<EnemyScript, UnityEvent> HitWallEvent;
    public GameObject[,] EnemyObjectArray;
    public List<GameObject> EnemyFireList;

    public float ShootTimer;
    public float RandTime;
    public int RandEnemyNum;

    // Start is called before the first frame update
    void Start()
    {
        RandTime = Random.Range(1f, 3f);
        ShootTimer = 0f;
        RandEnemyNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShootTimer += Time.deltaTime;
        if(ShootTimer > RandTime)
        {
            ChooseEnemyToFire();
            ShootTimer = 0f;
            RandTime = Random.Range(1f, 3f);
        }
    }

    //This method will go down every column and cache the bottom most enemy
    //then it will randomly choose which enemy fires the bullet.
    public void ChooseEnemyToFire()
    {
        EnemyFireList = new List<GameObject>();
        for(int i = 0; i < 11; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if(EnemyObjectArray[i,j] != null)
                {
                    EnemyFireList.Add(EnemyObjectArray[i, j]);
                    break;
                }
            }
        }
        RandEnemyNum = Random.Range(0, EnemyFireList.Count);
        if (EnemyFireList[RandEnemyNum] != null)
        {
            EnemyFireList[RandEnemyNum].GetComponent<EnemyScript>().Shoot();
        }
    }

    //This method will be called by an enemy that has hit a wall and send out a event signal
    public void ChangeDirectionEvent(bool HitRightWall)
    {
        if (HitWall != null)
        {
            HitWall(HitRightWall);
        }
    }
}
