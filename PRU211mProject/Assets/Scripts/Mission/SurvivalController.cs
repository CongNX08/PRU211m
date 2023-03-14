using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class SurvivalController : MonoBehaviour
{
    Timer timer;
    Survival sv;
    int curentSize;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 5;
        timer.StartTime();
        sv = FindObjectOfType<Survival>();

        curentSize = sv.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinish)
        {
            curentSize -= 1;
            gameObject.transform.localScale = new Vector3(curentSize, curentSize, 1f);

            timer.arlarmTime = 0.1f;
            timer.StartTime();

        }
        if(curentSize <= 20f)
        {
            Destroy(gameObject);
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
        }
    }


}
