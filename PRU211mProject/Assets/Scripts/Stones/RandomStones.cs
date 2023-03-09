using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStones : MonoBehaviour
{
  public GameObject stones;
    public float spawnTime;
    float m_spawnTime = 2f;
    void Start(){
        m_spawnTime =0;
    } 
    void Update(){
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <0){
            spawnBall();
            m_spawnTime = spawnTime; 
        }
    }
    public void spawnBall(){
        Vector2 spawnPos = new Vector2(Random.Range(-40,40),22);
        if(stones){
            Instantiate(stones,spawnPos,Quaternion.identity);
        }
    }
}
