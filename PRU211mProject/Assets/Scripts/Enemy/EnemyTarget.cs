using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject character;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject walkers = GameObject.FindWithTag("Player");

        Vector3 distance = walkers.transform.position - transform.position;
        Vector3 targetPoint = walkers.transform.position - distance.normalized * 1;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, 1 * Time.deltaTime);

    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ReviceItems ri = other.GetComponent<ReviceItems>();
            // ri.ReciveItemSpeedUp(5f);
            Destroy(gameObject);
        }
    }
}
