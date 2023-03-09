using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BanDan : MonoBehaviour
{
    float rotationSpeed = 5f;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
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
                   
                    GameObject bullet = Instantiate(bullet1, transform.position, transform.rotation);
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
                //Vector3 Dbullet2 = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {

                    GameObject bullet = Instantiate(bullet2, transform.position, transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    timers.arlarmTime = 0.3f;
                    timers.StartTime();
                }

            }
        }

        //Usung4
        if (collision.CompareTag("USung4"))
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

                    GameObject bullet = Instantiate(bullet4, transform.position, transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
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
