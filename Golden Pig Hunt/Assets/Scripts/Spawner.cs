using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject normalPig;
    public GameObject wildPig;
    public GameObject goldenPig;

    public float maxHeight = 5.0f;

    public float pigSpeed = 2.0f;
    public float increasePigSpeed = 0.05f;
    public float decreaseSpawnTime = 0.08f;
    public float maxPigSpeed = 10.0f;

    private float minTime;

    [Header("Normal Pig")]
    public float startTimeBtwSpawn = 1.5f;
    
    private float timeBtwSpawn;
    private float rndSpawnTime;

    [Header("Wild Pig")]
    public float startTimeBtwSpawnWild = 1.5f;

    private float timeBtwSpawnWild;
    private float rndSpawnTimeWild;

    [Header("Golden Pig")]
    public float startTimeBtwSpawnGold = 4.0f;

    private float timeBtwSpawnGolden;
    private float rndSpawnTimeGolden;

    Vector2 spawnPos;

    private void Start()
    {
        minTime = startTimeBtwSpawn / 4;
    }

    void Update ()
    {
        // SPAWN GOLDEN PIG
        if(timeBtwSpawnGolden <= 0 + rndSpawnTimeGolden && !Player.died)
        {
            //int rnd = Random.Range(0, spawnObjs.Length);

            spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));

            Instantiate(goldenPig, spawnPos, Quaternion.identity);
            rndSpawnTimeGolden = Random.Range(startTimeBtwSpawnGold / -2, startTimeBtwSpawnGold / 2);

            if(pigSpeed <= maxPigSpeed)
            {
                pigSpeed += increasePigSpeed;
            }            

            if(startTimeBtwSpawn >= minTime)
            {
                startTimeBtwSpawn -= decreaseSpawnTime;
                startTimeBtwSpawnGold -= decreaseSpawnTime;
            }

            timeBtwSpawnGolden = startTimeBtwSpawnGold;
        }
        else
        {
            timeBtwSpawnGolden -= Time.deltaTime;
        }

        // SPAWN NORMAL PIG
		if(timeBtwSpawn <= 0 + rndSpawnTime)
        {
            spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));

            Instantiate(normalPig, spawnPos, Quaternion.identity);
            rndSpawnTime = Random.Range(startTimeBtwSpawn / -2, startTimeBtwSpawn / 2);

            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        // SPAWN WILD PIG 
        if (timeBtwSpawnWild <= 0 + rndSpawnTime)
        {
            spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));

            Instantiate(wildPig, spawnPos, Quaternion.identity);
            rndSpawnTimeWild = Random.Range(startTimeBtwSpawnWild / -2, startTimeBtwSpawnWild / 2);

            timeBtwSpawnWild = startTimeBtwSpawnWild;
        }
        else
        {
            timeBtwSpawnWild -= Time.deltaTime;
        }
    }
}
