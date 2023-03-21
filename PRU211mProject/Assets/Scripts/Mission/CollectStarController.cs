using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStarController : MonoBehaviour
{
    BanDan bd;
    // Start is called before the first frame update
    void Start()
    {
        bd = FindObjectOfType<BanDan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrEnter2D(Collision2D collision)
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bd.attackSpeed = bd.attackSpeed * 0.5f;
            Destroy(gameObject);
        }
    }
}
