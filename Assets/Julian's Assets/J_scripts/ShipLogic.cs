using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogic : MonoBehaviour
{
    // Start is called before the first frame update
 
    private Rigidbody2D ship_rigidbody;
    private Collider2D ship_collider;
    [SerializeField] protected float player_speed = 4;
    private float bullet_speed = 6;
    public GameObject ShipBulletPrefab;
    public static int lives = 3;
    public static bool No_Bullet = true;

    private void Awake()
    {
        ship_rigidbody = this.GetComponent<Rigidbody2D>();
        ship_collider = this.GetComponent<Collider2D>();
        lives = 3;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && No_Bullet)
        {
            Shoot();
        }
    }

    private void Move()
    {
        float Move_by_what = Input.GetAxisRaw("Horizontal");
        Vector2 currentVelocity = ship_rigidbody.velocity;
        ship_rigidbody.velocity = new Vector2(Move_by_what * player_speed, currentVelocity.y); 
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(ShipBulletPrefab, this.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bullet_speed);
        Physics2D.IgnoreCollision(ship_collider, newBullet.GetComponent<Collider2D>());
    }



}
