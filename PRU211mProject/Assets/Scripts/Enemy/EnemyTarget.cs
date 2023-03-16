using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject character;
    public float speed = 5; 
    public float timeIcSpeed=0; 
    public float timeIcDelaySpeed=30; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject walkers = GameObject.FindWithTag("Player");
        Vector3 distance = walkers.transform.position - transform.position;
        Vector3 targetPoint = walkers.transform.position - distance.normalized * 1;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, speed * Time.deltaTime);

        timeIcSpeed += Time.deltaTime; 
        if(timeIcSpeed <timeIcDelaySpeed) return;
        else{
            speed += 0.5f;
            timeIcSpeed =0;
        }
    }
}
