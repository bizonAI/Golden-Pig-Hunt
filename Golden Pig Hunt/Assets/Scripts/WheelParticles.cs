using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticles : MonoBehaviour {

    public Transform player;
    public GameObject[] dustParticlePos;
    public GameObject dustParticleEffect;

    private Vector2 playersPos;

	void Update ()
    {
        playersPos = player.position;

        if(player.hasChanged)
        {
            for (int i = 0; i < dustParticlePos.Length; i++)
            {
                Instantiate(dustParticleEffect, dustParticlePos[i].transform.position, Quaternion.identity);
            }
            player.hasChanged = false;
        }
	}
}
