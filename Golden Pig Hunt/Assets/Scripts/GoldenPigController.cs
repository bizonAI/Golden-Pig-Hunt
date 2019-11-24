using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPigController : MonoBehaviour {

    public float speedPPS = 1.0f;
    public float endPos = 10.0f;

    public GameObject[] deathSounds;

    public GameObject deathEffect;
    private Animator camAnim;
    public Animator anim;

    public GameObject spriteObject;
    public Sprite overTheFence;
    public float rightBehindFence = -5.3f;


    private void Start()
    {
        
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        //speed = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().pigSpeed * speed;

        //CheckForNearPigs(transform.position, checkRadius);
    }

    public void SetSpeed (float speedPPS) {
        this.speedPPS = speedPPS;
        anim.speed = anim.speed * speedPPS * .3f;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speedPPS * Time.deltaTime);

        if (transform.position.x <= endPos)
        {
            Destroy(gameObject);
        }

        if(transform.position.x <= rightBehindFence)
        {
            spriteObject.GetComponent<SpriteRenderer>().sprite = overTheFence;
        }

        if (Player.died)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int rnd = Random.Range(0, deathSounds.Length);
            Instantiate(deathSounds[rnd], transform.position, Quaternion.identity);            

            //other.GetComponent<Player>().health -= damage;
            //other.GetComponent<Player>().DecreaseHealth(damage);

            camAnim.SetTrigger("shake");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
