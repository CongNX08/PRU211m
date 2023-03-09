using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int heal = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bullet1
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

        //bullet2
        if (collision.CompareTag("Bullet2"))
        {
            heal -= 2;

            Destroy(collision.gameObject);
            if (heal == 0)
            {
                Destroy(gameObject);

            }

        }
        //bullet4
        if (collision.CompareTag("Bullet4"))
        {
            heal -= 5;

            Destroy(collision.gameObject);
            if (heal == 0)
            {
                Destroy(gameObject);

            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
