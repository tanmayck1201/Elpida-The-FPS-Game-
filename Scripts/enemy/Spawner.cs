using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;
    public int count = 0;

    private void Awake() {
        spawners = new GameObject[5];
        for (int i = 0; i < spawners.Length; i ++) {
            spawners [i] = transform.GetChild(i).gameObject;
        }

        SpawnEnemy();   
    }

    private void start() {
        spawners = new GameObject[5];
        for (int i = 0; i < spawners.Length; i ++) {
            spawners [i] = transform.GetChild(i).gameObject;
        }

        SpawnEnemy();
    }

    
    /*private void FixedUpdate() {
        
        float t = 0.025f;
        t += 0.025f;
        if (t % 3*60000f == 0)
          
        //if (count < 500)  
            //SpawnEnemy();
    }*/

    private void SpawnEnemy() {
        //int spawnerID = Random.Range(0, spawners.Length);
        for (int i = 0; i < 5; i ++)
            Instantiate(enemy, spawners[i].transform.position,spawners[i].transform.rotation);
            count += 1;
    }
}
