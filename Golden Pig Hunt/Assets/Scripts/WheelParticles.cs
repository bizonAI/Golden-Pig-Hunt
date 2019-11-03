using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticles : MonoBehaviour {

    public Transform player;
    //public GameObject dustParticleEffect;
    public ParticleSystem wheelParticleUp;
    public ParticleSystem wheelParticleDown;

    public float emissionRate = 200;


    Vector2 currentPos;
    Vector2 latestPos;

    private void Start()
    {
        
    }

    void Update ()
    {
        currentPos = transform.position;

        if (currentPos.y == latestPos.y)
        {
            var emissionDown = wheelParticleDown.emission;
            emissionDown.rateOverTime = 0;

            var emissionUp = wheelParticleUp.emission;
            emissionUp.rateOverTime = 0;
        }
        else
        {
            var emissionDown = wheelParticleDown.emission;
            emissionDown.rateOverTime = emissionRate;

            var emissionUp = wheelParticleUp.emission;
            emissionUp.rateOverTime = emissionRate;
        }

        latestPos = currentPos;
	}
}
