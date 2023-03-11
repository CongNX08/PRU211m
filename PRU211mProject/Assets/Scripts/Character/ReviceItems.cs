using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviceItems : MonoBehaviour
{
    // Start is called before the first frame update

    joystickCharacter js;
    float totalSpeed;
    private float timeSpawnSpeed = 0;
    private float timeDlaySpeed = 5;
    public float timeSpawnArmor = 0;
    public float timeDlayArmor = 4;
    bool hasBeenCalled = false;
    public int checkArmor = 1;
    public Color startColor = Color.red;
    public Color endColor = Color.black; 
    [Range(0,10)]
    public float speedBlink =1;
    Renderer ren; 
    void Start()
    {
        js = FindObjectOfType<joystickCharacter>();
    }
    void Awake() {
        ren = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenCalled == true)
        {
            this.timeSpawnSpeed += Time.deltaTime;
            if (this.timeSpawnSpeed < this.timeDlaySpeed) return;
            else
            {
                this.timeSpawnSpeed = 0;
                speedReduce();
            }
        }
        if (checkArmor == 3)
        {
            this.timeSpawnArmor += Time.deltaTime;
            if (this.timeSpawnArmor < this.timeDlayArmor) {
            ren.material.color =Color.Lerp(startColor, endColor,Mathf.PingPong(Time.time*speedBlink,1));
            return;
            }
            else
            {
                this.timeSpawnArmor = 0;
                immortalTime();
            }
        }
    }
    void speedReduce()
    {
        ReciveItemSpeedUp(-5f);
        hasBeenCalled = false;
    }
    void immortalTime(){
        ReciveItemArmor(false);
        checkArmor = 1 ;
    }
    public virtual void ReciveItemSpeedUp(float spUp)
    {
        totalSpeed = js.getSpeed();
        totalSpeed += spUp;
        js.setSpeed(totalSpeed);
        hasBeenCalled = true;
    }
    public virtual void ReciveItemArmor(bool armor)
    {
        js.setArmor(armor);
        checkArmor = 2;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (checkArmor == 2)
            {
                checkArmor = 3;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
