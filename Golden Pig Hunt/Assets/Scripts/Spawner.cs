using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Input
    public GameObject normalPig;
    public GameObject wildPig;
    public GameObject goldenPig;

    //setting
    private float responseTime = 1f;
    private float minResponseTime = .01f;
    private float maxHeight = 5.0f;
    private float lastPigTime = 0f;

    //decaying function
    // f(x) = 1/dx + c
    private float timeOffset = 0f;
    private float decayRate = .02f;

    private void Start()
    {
        // solve timeOffset
        timeOffset = 1 / ((responseTime - minResponseTime) * decayRate);
    }

    void Update()
    {

        float currentTime = Time.timeSinceLevelLoad;
        if (!Player.died)
        {
            responseTime = 1 / (decayRate * (currentTime + timeOffset)) + minResponseTime;
            if (lastPigTime < currentTime){
                lastPigTime = currentTime + responseTime;
                Vector2 spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));
                Instantiate(goldenPig, spawnPos, Quaternion.identity);
            }
            // if (timeBtwSpawnGolden <= 0 + rndSpawnTimeGolden)
            // {
            //     //int rnd = Random.Range(0, spawnObjs.Length);

                //     spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));

                //     Instantiate(goldenPig, spawnPos, Quaternion.identity);
                //     rndSpawnTimeGolden = Random.Range(startTimeBtwSpawnGold / -2, startTimeBtwSpawnGold / 2);


                //     timeBtwSpawnGolden = startTimeBtwSpawnGold;
                // }
                // else
                // {
                //     timeBtwSpawnGolden -= Time.deltaTime;
                // }

                // // SPAWN NORMAL PIG
                // if (timeBtwSpawn <= 0 + rndSpawnTime)
                // {
                //     spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));

                //     Instantiate(normalPig, spawnPos, Quaternion.identity);
                //     rndSpawnTime = Random.Range(startTimeBtwSpawn / -2, startTimeBtwSpawn / 2);

                //     timeBtwSpawn = startTimeBtwSpawn;
                // }
                // else
                // {
                //     timeBtwSpawn -= Time.deltaTime;
                // }

                // // SPAWN WILD PIG 
                // if (timeBtwSpawnWild <= 0 + rndSpawnTime)
                // {
                //     spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));

                //     Instantiate(wildPig, spawnPos, Quaternion.identity);
                //     rndSpawnTimeWild = Random.Range(startTimeBtwSpawnWild / -2, startTimeBtwSpawnWild / 2);

                //     timeBtwSpawnWild = startTimeBtwSpawnWild;
                // }
                // else
                // {
                //     timeBtwSpawnWild -= Time.deltaTime;
                // }
        }

    }
}
