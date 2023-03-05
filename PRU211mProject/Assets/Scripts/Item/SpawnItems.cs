using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itSpeedUp;
    public GameObject itArmor;
    public GameObject itPet;
    GameObject getItem;
    List<GameObject> items;

    Timer timer;

    // Update is called once per frame
    private void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 30;
        timer.StartTime();
        this.items = new List<GameObject>();
    }
    void Update()
    {

        this.Spawn();
       // this.CheckMinionDeath();
    }
    private void Spawn()
    {
        Bounds bounds = OrthographicBounds(Camera.main);
        float X = Random.Range(bounds.min.x, bounds.max.x);
        float Y = Random.Range(bounds.min.y, bounds.max.y);
        if (timer.isFinish)
        {
            int rand = Random.Range(1, 11);
            // if (this.items.Count > 3)
            // {
            //     Debug.Log("vào đây if");
            //     return;
            // }

            // int index = this.items.Count + 1;
            Debug.Log("vào else");
            if (rand < 4)
            {
                getItem = itArmor;
            }
            else if (rand > 3 && rand < 8)
            {
                getItem = itSpeedUp;
            }
            else if (rand > 7 && rand < 11)
            {
                getItem = itPet;
            }
            else
            {
                return;
            }

            GameObject item = Instantiate(this.getItem);
            item.transform.position = new Vector2(X, Y);
            items.Add(getItem);
            Debug.Log(items.Count);
            timer.arlarmTime = 31;
            timer.StartTime();
        }
        else return;
    }
    private Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
        camera.transform.position,
        new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
    // void CheckMinionDeath()
    // {
    //     foreach (var i in items)
    //     {
    //        Debug.Log("Đã vào check death ");

    //         if (i == null)
    //         {
    //             items.Remove(i);
    //             Debug.Log(items.Count);
    //         }
    //     }
    // }
}
