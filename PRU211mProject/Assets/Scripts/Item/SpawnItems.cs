using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itSpeedUp;
    public GameObject itArmor;
    public GameObject itPet;

    Timer timer;

    // Update is called once per frame
    private void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 5;
        timer.StartTime();
    }
    void Update()
    {

        this.Spawn();
    }
    private void Spawn()
    {
        if (timer.isFinish)
        {
            int rand = Random.Range(1, 11);
            if (rand < 4)
            {
                GameObject minion = Instantiate(this.itArmor);
                minion.transform.position = new Vector3(Random.Range(-8, 7), Random.Range(-8, 7), 0);
            }
            else if (rand > 3 && rand < 8)
            {
                GameObject minion = Instantiate(this.itSpeedUp);
                minion.transform.position = new Vector3(Random.Range(-8, 7), Random.Range(-8, 7), 0);
            }
            else if (rand > 7 && rand < 11)
            {
                GameObject minion = Instantiate(this.itPet);
                minion.transform.position = new Vector3(Random.Range(-8, 7), Random.Range(-8, 7), 0);
            }
            else
            {
                return;
            }
            timer.arlarmTime = 5;
            timer.StartTime();
        }
        else return;
    }
}
