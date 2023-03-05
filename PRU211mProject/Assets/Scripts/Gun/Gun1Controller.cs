using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1Controller : MonoBehaviour
{
    int radius;
    int size;
    [SerializeField]

    public float maxHP;
    public float currentHP;
    private Vector3 initialScale;
    bool isColliding = false;


    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        radius = (int)gameObject.transform.localScale.x;
       
        if(radius == 1)
        {
            maxHP = Random.Range(1, 11);
            currentHP = maxHP;
        }
        if (radius == 2)
        {
            maxHP = Random.Range(11, 21);
            currentHP = maxHP;
        }
        if (radius == 3)
        {
            maxHP = Random.Range(212, 312);
            currentHP = maxHP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            currentHP -= 1;
            float scaleRatio = currentHP / maxHP;
            transform.localScale = initialScale * scaleRatio;
            //size = radio;
            //gameObject.transform.localScale = new Vector3(size, size, 1f);
        }
        if (currentHP == 0)
        {
            Destroy(gameObject);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;


        }
    }



}
