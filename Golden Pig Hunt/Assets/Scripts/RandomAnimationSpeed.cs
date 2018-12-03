using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationSpeed : MonoBehaviour {

    private Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();

        float rnd = Random.Range(0.5f, 1);
        anim.speed = rnd;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wild Pig"))
        {
            anim.SetTrigger("shakeIt");
        }

        if (other.CompareTag("Golden Pig"))
        {
            anim.SetTrigger("shakeIt");
        }

        if (other.CompareTag("Pig"))
        {
            anim.SetTrigger("shakeIt");
        }
    }
}
