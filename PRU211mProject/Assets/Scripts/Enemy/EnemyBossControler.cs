using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossControler : MonoBehaviour
{
    int heal;
    float rotationSpeed = 5f;
    public GameObject bulletPrefab;
    private float bulletSpeed = 15f;
    HealthController ec;
    public float timeSpawnBullet = 0f;
    public float timeDlaybullet = 0.5f;
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
                ec.maxboss();
                Destroy(gameObject);
                scoreManager.instance.AddPointBoss();
            }

        }

        //bullet2
        if (collision.CompareTag("Bullet2"))
        {
            heal -= 2;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.maxboss();
                Destroy(gameObject);
                scoreManager.instance.AddPointBoss();
            }

        }
        //bullet3
        if (collision.CompareTag("Bullet3"))
        {
            heal -= 3;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.maxboss();
                Destroy(gameObject);
                scoreManager.instance.AddPointBoss();
            }

        }
        //bullet4
        if (collision.CompareTag("Bullet4"))
        {
            heal -= 5;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.maxboss();
                Destroy(gameObject);
                scoreManager.instance.AddPointBoss();
            }

        }
        if (collision.CompareTag("BulletPet"))
        {
            heal -= 1;

            Destroy(collision.gameObject);
            if (heal <= 0)
            {
                ec.maxboss();
                Destroy(gameObject);
                scoreManager.instance.AddPointBoss();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject walkers = GameObject.FindGameObjectWithTag("Player");

        Vector2 closestWalkerDirection = Vector2.zero;
        float closestDistance = Mathf.Infinity;

        float distance = Vector2.Distance(transform.position, walkers.transform.position);
        if (distance < closestDistance && distance <= 10f)
        {
            closestDistance = distance;
            closestWalkerDirection = (walkers.transform.position - transform.position).normalized;
        }
        if (closestDistance <= 10f)
        {
            float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            timeSpawnBullet += Time.deltaTime;
            if (timeSpawnBullet < timeDlaybullet) return;
            else
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                timeSpawnBullet = 0;
            }


        }
    }
}
