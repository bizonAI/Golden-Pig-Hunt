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
    private float responseTime = 3f;
    private float minResponseTime = .3f;
    private float maxHeight = 4f;
    private float lastPigTime = 0f;

    //decaying function
    // f(x) = 1/dx + c
    private float timeOffset = 0f;
    private float decayRate = .005f;

    //never meet at the same time
    private float timeToGoBack = 6;

    private float GetPigSpeed(float responseTime)
    {
        return 10 / responseTime;
    }

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
            if (lastPigTime < currentTime)
            {
                GameObject spawningPig = Random.Range(0,10) > 7 ? goldenPig : normalPig;
                lastPigTime = currentTime + responseTime;
                float pigSpeed = GetPigSpeed(responseTime);
                // from once to twice
                pigSpeed += Random.Range(0, pigSpeed);
                Vector2 spawnPos = new Vector2(transform.position.x + pigSpeed * timeToGoBack, Random.Range(-maxHeight, maxHeight));
                GameObject pig = Instantiate(spawningPig, spawnPos, Quaternion.identity);
                pig.SendMessage("SetSpeed", pigSpeed);
            }
        }

    }
}
