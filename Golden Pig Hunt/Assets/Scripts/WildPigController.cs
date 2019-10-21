using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPigController : MonoBehaviour {

    public float speed = 5.0f;
    public int damage = 2;
    public float endPos = -13.0f;

    public GameObject deathEffect;
    public GameObject[] deathSounds;
    private Animator camAnim;
    public Animator anim;

    public float rightBeforeFence = -3;
    public GameObject spriteObject;
    public Sprite angryFace;

    private void Start()
    {
        anim.speed = anim.speed * speed;
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        speed = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().pigSpeed * speed;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endPos)
        {
            Destroy(gameObject);
        }

        if(transform.position.x <= rightBeforeFence)
        {
            spriteObject.GetComponent<SpriteRenderer>().sprite = angryFace;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int rnd = Random.Range(0, deathSounds.Length);
            Instantiate(deathSounds[rnd], transform.position, Quaternion.identity);

            camAnim.SetTrigger("shake");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
