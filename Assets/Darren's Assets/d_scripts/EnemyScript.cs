using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{
    //The enemy stores points based on its position in the 2d array.
    //It must also shoot and detect if it hits a wall.

    public int Points;
    public float Speed = 2f;
    public bool MovingRight = true;
    public float MoveDownOffset;

    public bool WallChecker = false;
    public bool Shooter = false;
    public int[] arrPos = new int[] { };

    //public UnityEvent hitWall;

    public EnemySpawnerScript EnemyArrScript;
    public GameObject[,] EArray;

    // Start is called before the first frame update
    void Start()
    {
        MoveDownOffset = 0.5f;
        //EnemyArrScript = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawnerScript>();
        //EArray = EnemyArrScript.EnemyArray;
        /*
         * implement later
        if (hitWall == null)
            hitWall = new UnityEvent();
        
        hitWall.AddListener(ChangeDirection);
        */

    }

    // Update is called once per frame
    void Update()
    {
        //move enemies
        if (MovingRight)
        {
            transform.Translate(Speed*Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
    }

    public void Shoot()
    {
        //instantiate bullet prefab at this enemy's location
    }

    public void ChangeDirection()
    {
        //if hit wall, move down some pixels and change direction
        if (MovingRight)
            MovingRight = false;
        else
            MovingRight = true;
        transform.position = new Vector3(transform.position.x, transform.position.y - MoveDownOffset, 0);
    }

    public void GetEnemies(bool IsRightWall)
    {
        //only use in the ontrigger enter for hitting wall
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (EArray[i, j] == null)
                    continue;
                else
                {
                    EnemyScript enemy = EArray[i, j].GetComponent<EnemyScript>();
                    if (IsRightWall)
                    {
                        if (enemy.MovingRight)
                        {
                            enemy.ChangeDirection();
                        }
                    }
                    else
                    {
                        if (!enemy.MovingRight)
                        {
                            enemy.ChangeDirection();
                        }
                    }
                }
                    //hitWall.Invoke();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyArrScript = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawnerScript>();
        EArray = EnemyArrScript.EnemyArray;
        //using unity event
        if (collision.gameObject.tag == "RightWall")
        {
            GetEnemies(true);
        }
        if(collision.gameObject.tag == "LeftWall")
        {
            GetEnemies(false);
        }
    }
}
