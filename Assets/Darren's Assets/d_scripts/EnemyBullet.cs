using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed = 5f;
    public float LifeTime = 5f;
    public float LifeTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
        LifeTimer += Time.deltaTime;
        if(LifeTimer > LifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //decrement player health? or do in player script
            Destroy(this.gameObject);
            ShipLogic.lives -= 1;
        }
    }
}
