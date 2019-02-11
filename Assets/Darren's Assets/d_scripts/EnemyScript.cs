﻿using System.Collections;
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
    public bool hitRightWall = false;
    public float MoveDownOffset;

    public int[] arrPos = new int[] { };

    //public UnityEvent hitWall;
    public EnemyController eController;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        MoveDownOffset = 0.5f;
        eController = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyController>();
        
    }

    private void OnEnable()
    {
        EnemyController.HitWall += ChangeDirection;
    }
    private void OnDisable()
    {
        EnemyController.HitWall -= ChangeDirection;
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
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }

    public void ChangeDirection(bool RightWall)
    {
        //if hit wall, move down some pixels and change direction
        if (RightWall && MovingRight)
        {
            MovingRight = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - MoveDownOffset, 0);
        }
        else if (!RightWall && !MovingRight)
        {
            MovingRight = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - MoveDownOffset, 0);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //using unity event
        if (collision.gameObject.tag == "RightWall")
        {
            eController.ChangeDirectionEvent(true);
        }
        if(collision.gameObject.tag == "LeftWall")
        {
            eController.ChangeDirectionEvent(false);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            //GAME OVER
        }
    }

    private void OnDestroy()
    {
        if (arrPos[1] <= 1)
        {
            //give 10 points
        }
        else if (arrPos[1] <= 3)
        {
            //give 20 points
        }
        else if (arrPos[1] == 4)
        {
            //give 40 points
        }
    }
}
