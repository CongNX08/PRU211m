using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviceItems : MonoBehaviour
{
    // Start is called before the first frame update

    joystickCharacter js;
    float totalSpeed;
    public float timeSpawn=0;
    public float timeDlay=0;
    void Start()
    {
        js = FindObjectOfType<joystickCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(js.setSpeed(5));
        // Debug.Log("Đây là Speed " + js.getSpeed());
        // this.timeSpawn += Time.deltaTime;
        // if (this.timeSpawn < this.timeDlay) return;
        // else
        // {
        //     this.timeSpawn = 0;
        //     Debug.Log(timeDlay);
        //     this.ReciveItemSpeedUp(5);
        // }


        // if(timeDlay!= 0){
        //     this.timeSpawn += Time.deltaTime;
        //     Debug.Log("Da vao day");
        //     if(timeSpawn > timeDlay){
        //     this.ReciveItemSpeedUp(-5f);
        //     this.timeDlay=0 ;
        //     Debug.Log("da tru");
        //     }
        // }
    }
    public virtual void ReciveItemSpeedUp(float spUp)
    {
        totalSpeed = js.getSpeed();
        totalSpeed += spUp;
        js.setSpeed(totalSpeed);
        // this.timeDlay= 5;
        // Debug.Log("in recive"+timeDlay);

    }
    public virtual void ReciveItemArmor(bool armor)
    {
        js.setArmor(armor);
    }
}
