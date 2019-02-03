using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //The enemy stores points based on its position in the 2d array.
    //It must also shoot and detect if it hits a wall.

    public int Points;
    public float Speed = 2f;
    public bool MovingRight = true;
    public float MoveDownOffset = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move enemies
        if (MovingRight)
        {
            transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
        }
    }

    public void Shoot()
    {
        //instantiate bullet prefab at this enemy's location
    }

    public void ChangeDirection()
    {
        //if hit wall, move down some pixels and change direction
        MovingRight = false;
        transform.position = new Vector3(transform.position.x, transform.position.y - MoveDownOffset, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //using unity events
    }
}
