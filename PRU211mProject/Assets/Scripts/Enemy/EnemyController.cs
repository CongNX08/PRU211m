using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int heal = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet1"))
        {
            heal--;

            Destroy(collision.gameObject);
            if (heal == 0)
            {
                Destroy(gameObject);
                scoreManager.instance.AddPoint();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
