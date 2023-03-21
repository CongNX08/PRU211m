using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int heal;
    HealthController ec;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        ec = FindObjectOfType<HealthController>();
        heal = ec.maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bullet1
        if (collision.CompareTag("Bullet1"))
        {
            heal--;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                scoreManager.instance.AddPoint();
            }

        }

        //bullet2
        if (collision.CompareTag("Bullet2"))
        {
            heal -= 2;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                StartExplosion();
                scoreManager.instance.AddPoint();
            }

        }
        //bullet3
        if (collision.CompareTag("Bullet3"))
        {
            heal -= 3;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                StartExplosion();
                scoreManager.instance.AddPoint();
            }

        }
        //bullet4
        if (collision.CompareTag("Bullet4"))
        {
            heal -= 5;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                StartExplosion();
                scoreManager.instance.AddPoint();
            }

        }
        if (collision.CompareTag("BulletPet"))
        {
            heal -= 1;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                StartExplosion();
                scoreManager.instance.AddPoint();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);


    }


}
