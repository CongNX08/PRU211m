using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStones : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    float moveSpeed = 3f; // Tốc độ di chuyển của đối tượng
    public Vector2 targetPosition; // Vị trí đích của đối tượng
    Timer timer;
    void Start()
    {  
        timer = GetComponent<Timer>();
        timer.arlarmTime = 4;
        timer.StartTime();
        targetPosition = new Vector2(Random.Range(-60, 60), -24);
    }
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = new Vector2(Random.Range(-60, 60), -24);
        }
        if (timer.isFinish)
        {
            Destroy(gameObject);
        }
    }
}
