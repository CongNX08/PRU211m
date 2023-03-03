using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanDan : MonoBehaviour
{
    float rotationSpeed = 5f;
    public GameObject bulletPrefab;
    private float bulletSpeed = 12f;
    Timer timers;
    bool isColliding = false;
  



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
        if (isColliding)
        {
            GameObject[] walkers = GameObject.FindGameObjectsWithTag("Player");

            Vector2 closestWalkerDirection = Vector2.zero;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject walker in walkers)
            {
                float distance = Vector2.Distance(transform.position, walker.transform.position);
                if (distance < closestDistance && distance <= 10f)
                {
                    closestDistance = distance;
                    closestWalkerDirection = (walker.transform.position - transform.position).normalized;

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

                    timers.arlarmTime = 0.5f;
                    timers.StartTime();
                }
            }
        }




    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("USung"))
        {
            isColliding = true;
          

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("USung"))
        {
            isColliding = false;
          

        }
    }



}
