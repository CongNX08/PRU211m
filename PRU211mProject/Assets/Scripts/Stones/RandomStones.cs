using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStones : MonoBehaviour
{
    public GameObject stones;
    Timer timer;
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 0;
        timer.StartTime();
    }
    void Update()
    {
        if (timer.isFinish)
        {
            spawnBall();
            timer.arlarmTime = 0.7f;
            timer.StartTime();
        }
    }
    public void spawnBall()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-70, 70), 60);
        if (stones)
        {
            Instantiate(stones, spawnPos, Quaternion.identity);
        }
    }
}
