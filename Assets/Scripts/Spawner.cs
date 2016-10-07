using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    
    float oldTime = 0;
    float newTime = 0;
    Queue<float> spawnTimes = new Queue<float>();
    Queue<int> spawnCounts = new Queue<int>();
    Queue<GameObject> spawns = new Queue<GameObject>();

    float currentSpawn = 0;
    int currentCount = 0;

    public GameObject enemy;

    void Start()
    {
        //spawnTimes.Enqueue(1f);
        //spawnCounts.Enqueue(1);
        //spawns.Enqueue(enemy);

        //currentCount = spawnCounts.Dequeue();
        //currentSpawn = spawnTimes.Dequeue();
    }
    
	void Update () {

        newTime = Time.deltaTime + oldTime;

        if (newTime >= currentSpawn && currentSpawn > oldTime)
        {
            for (int i = 0; i < currentCount; i++)
            {
                Instantiate(spawns.Dequeue());
            }
            if (spawnTimes.Count > 0)
            {
                currentCount = spawnCounts.Dequeue();
                currentSpawn = spawnTimes.Dequeue();
            }else
            {
                //KILL THIS
            }
        }

        oldTime = newTime;
	
	}
}
