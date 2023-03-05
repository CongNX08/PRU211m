using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSenderPet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    private float distances = 1f;
    public bool isTarget = false;
    public GameObject bulletPrefab;
    float bulletSpeed = 1000;
    float liveTime = 0;
    float existTime = 10;
    float timeDestroy = 0;
    float arlarmTimeDestroy = 30;
    Timer timer;

    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 0.5f;
        timer.StartTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == true)
        {
            flower();
        }
        this.timeDestroy += Time.deltaTime;
        if(timeDestroy>= arlarmTimeDestroy){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTarget = true;
        }
    }
    void flower()
    {
        GameObject walkers = GameObject.FindWithTag("Player");
        GameObject enermy = GameObject.FindWithTag("Enemy");

        Vector3 distance = walkers.transform.position - transform.position;
        Vector3 targetPoint = walkers.transform.position - distance.normalized * this.distances;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, 8 * Time.deltaTime);
        Vector2 closestWalkerDirection = Vector2.zero;
        closestWalkerDirection = (enermy.transform.position - transform.position).normalized;

         float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50f);
        if (timer.isFinish)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            Destroy(bullet, 2f);
            timer.arlarmTime =0.5f;
            timer.StartTime();
        }
        this.liveTime += Time.deltaTime;
        if(liveTime>= existTime){
            Destroy(gameObject);
        }
    }
}
