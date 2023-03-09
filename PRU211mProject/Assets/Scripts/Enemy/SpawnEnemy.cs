using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> enemys;
    protected float timeSpawn = 0f;
    protected float timeDlay = 3f;
    public GameObject Enermy;
    void Start()
    {
        this.enemys = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        this.timeSpawn += Time.deltaTime;
        if (this.timeSpawn < this.timeDlay) return;
        this.timeSpawn = 0;
        if (this.enemys.Count > 10) return;
        int index = this.enemys.Count + 1;
        GameObject minion = Instantiate(Enermy);
        minion.transform.position = new Vector2(Random.Range(-60,60), Random.Range(-23,23));
        this.enemys.Add(minion);
        CheckEnemysDeath();
    }
    void CheckEnemysDeath()
    {
        GameObject enemysdie;
        for (int i = 0; i < this.enemys.Count; i++)
        {
            enemysdie = this.enemys[i];
            if (enemysdie == null)
            {
                this.enemys.RemoveAt(i);
            }
        }
    }
}
