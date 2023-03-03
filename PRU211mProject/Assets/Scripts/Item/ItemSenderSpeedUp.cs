using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSenderSpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    Timer timer;
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 0;
        // timer.StartTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.arlarmTime!= 0){
            timer.StartTime();
            Debug.Log(timer.elapseTime)
;        }
        // if (timer.isFinish)
        // {
        //     Debug.Log(timer.elapseTime);
        //     // timer.arlarmTime = 5;
        //     // timer.StartTime();
        // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ReviceItems ri = other.GetComponent<ReviceItems>();
            ri.ReciveItemSpeedUp(5f);
            // Debug.Log("đây là elapsetime"+timer.elapseTime);
            timer.arlarmTime = 5;
            // timer.StartTime();
            // Debug.Log("đây là arlarm tiem"+timer.arlarmTime);
            Destroy(gameObject);
        }
    }
}
