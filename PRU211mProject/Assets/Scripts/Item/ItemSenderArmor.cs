using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSenderArmor : MonoBehaviour
{
    // Start is called before the first frame update
    float x=  1/3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(x);
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){ 
            ReviceItems ri = other.GetComponent<ReviceItems>();
            ri.ReciveItemArmor(true);
            Destroy(gameObject);
        }
    }
}
