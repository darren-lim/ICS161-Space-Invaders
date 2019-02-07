using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
 
    private Rigidbody2D ship_rigidbody;
    [SerializeField] protected float speed = 4;

    private void Awake()
    {
        ship_rigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float Move_by_what = Input.GetAxisRaw("Horizontal");
        Vector2 currentVelocity = ship_rigidbody.velocity;
        ship_rigidbody.velocity = new Vector2(Move_by_what * speed, currentVelocity.y); 
    }
}
