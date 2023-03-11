using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStones : MonoBehaviour
{
    float moveSpeed = 3f; // Tốc độ di chuyển của đối tượng
    public Vector2 targetPosition; // Vị trí đích của đối tượng
    Timer timer;
    void Start()
    {  
        targetPosition = new Vector2(Random.Range(-60, 60), -24);
    }
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = new Vector2(Random.Range(-60, 60), -24);
        }
        if (transform.position.y <=-23)
        {   
            Destroy(gameObject);
        }
    }
}
