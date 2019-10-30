using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticles : MonoBehaviour {

    public Transform player;
    public GameObject dustParticleEffect;

	void Update ()
    {
        if(player.hasChanged)
        {
            Debug.Log("Pos has changed");
        }
	}
}
