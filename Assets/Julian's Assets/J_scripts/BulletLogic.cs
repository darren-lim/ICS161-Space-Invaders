using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShipLogic.No_Bullet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        ShipLogic.No_Bullet = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("DeadBox") || collider.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

}
