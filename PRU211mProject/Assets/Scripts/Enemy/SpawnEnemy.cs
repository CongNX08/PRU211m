using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected float timeSpawn = 0f;
    protected float timeDlay = 3f;
    public GameObject WalkPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.timeSpawn += Time.deltaTime;
        if (this.timeSpawn < this.timeDlay) return;
        else
        {
            this.timeSpawn = 0;
            GameObject minion = Instantiate(WalkPrefab);
            minion.transform.position = transform.position;
        }

    }
}
