using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanDan : MonoBehaviour
{
    float rotationSpeed = 5f;
    public GameObject bulletPrefab;
    private float bulletSpeed = 12f;
    Timer timers;
   




    // Start is called before the first frame update
    public void Start()
    {

        timers = GetComponent<Timer>();
        timers.arlarmTime = 1;
        timers.StartTime();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("USung1"))
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            Vector2 closestWalkerDirection = Vector2.zero;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject e in enemys)
            {
                float distance = Vector2.Distance(transform.position, e.transform.position);
                if (distance < closestDistance && distance <= 10f)
                {
                    closestDistance = distance;
                    closestWalkerDirection = (e.transform.position - transform.position).normalized;

                }
            }
           
            if (closestDistance <= 10f)
            {
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {
                   
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    timers.arlarmTime = 0.3f;
                    timers.StartTime();
                }
               
            }
        }
        // U 2
        if (collision.CompareTag("USung2"))
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            Vector2 closestWalkerDirection = Vector2.zero;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject e in enemys)
            {
                float distance = Vector2.Distance(transform.position, e.transform.position);
                if (distance < closestDistance && distance <= 10f)
                {
                    closestDistance = distance;
                    closestWalkerDirection = (e.transform.position - transform.position).normalized;

                }
            }

            if (closestDistance <= 10f)
            {
                Vector3 Dbullet2 = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {

                    GameObject bullet1 = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    GameObject bullet2 = Instantiate(bulletPrefab, Dbullet2, transform.rotation);
                    bullet1.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    bullet2.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;


                    timers.arlarmTime = 0.3f;
                    timers.StartTime();
                }

            }
        }
    }



    //private float FindclosestEnemy()
    //{
    //    GameObject[] walkers = GameObject.FindGameObjectsWithTag("Enemy");

    //    Vector2 closestWalkerDirection = Vector2.zero;
    //    float closestDistance = Mathf.Infinity;

    //    foreach (GameObject walker in walkers)
    //    {
    //        float distance = Vector2.Distance(transform.position, walker.transform.position);
    //        if (distance < closestDistance && distance <= 10f)
    //        {
    //            closestDistance = distance;
    //            closestWalkerDirection = (walker.transform.position - transform.position).normalized;

    //        }
    //    }
    //    return closestDistance;
    //}
   










}
