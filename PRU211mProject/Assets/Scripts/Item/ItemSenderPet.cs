using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSenderPet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    private float distances = 1f;
    public bool isTarget = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == true)
        {
           flower();
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
        Vector3 distance = walkers.transform.position - transform.position;
        Vector3 targetPoint = walkers.transform.position - distance.normalized * this.distances;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, 8 * Time.deltaTime);
    }
}
