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
    private float responseTime = 5f;
    private float minResponseTime = .01f;
    private float maxHeight = 4f;
    private float lastPigTime = 0f;

    //decaying function
    // f(x) = 1/dx + c
    private float timeOffset = 0f;
    private float decayRate = .005f;


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
                lastPigTime = currentTime + responseTime;
                Vector2 spawnPos = new Vector2(transform.position.x, Random.Range(-maxHeight, maxHeight));
                GameObject go = Instantiate(goldenPig, spawnPos, Quaternion.identity);
                go.SendMessage("SetSpeed", 10 / responseTime);
                //Debug.Log(responseTime + " : " + 10 / responseTime);
            }
        }

    }
}
