using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int heal;
    HealthController ec;
     HPEnemyUI hpUI;
    // Start is called before the first frame update
    void Start()
    {
        ec = FindObjectOfType<HealthController>();
        heal = ec.maxHp;
        hpUI = FindObjectOfType<HPEnemyUI>();
        hpUI.SetHPText("" + heal);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bullet1
        if (collision.CompareTag("Bullet1"))
        {
            heal--;
             hpUI.SetHPText("" + heal);

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
             hpUI.SetHPText("" + heal);

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                scoreManager.instance.AddPoint();
            }

        }
        //bullet3
        if (collision.CompareTag("Bullet3"))
        {
            heal -= 3;
             hpUI.SetHPText("" + heal);

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                scoreManager.instance.AddPoint();
            }

        }
        //bullet4
        if (collision.CompareTag("Bullet4"))
        {
            heal -= 5;
             hpUI.SetHPText("" + heal);

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
                Destroy(gameObject);
                scoreManager.instance.AddPoint();
            }

        }
        if (collision.CompareTag("BulletPet"))
        {
            heal -= 1;
             hpUI.SetHPText("" + heal);

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.hpIc();
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
