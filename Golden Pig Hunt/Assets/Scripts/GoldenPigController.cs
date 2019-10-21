using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPigController : MonoBehaviour {

    public float speed = 1.0f;
    public int damage = 1;
    public float endPos = 10.0f;
    /*
     * NOT NEEDED ANYMORE
     * 
    public float checkRadius = 1.0f;
    public float normalPigOffset = 0.5f;
    */

    public GameObject[] deathSounds;

    public GameObject deathEffect;
    private Animator camAnim;
    public Animator anim;

    public GameObject spriteObject;
    public Sprite overTheFence;
    public float rightBehindFence = -5.3f;


    private void Start()
    {
        anim.speed = anim.speed * speed;

        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        speed = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().pigSpeed * speed;

        //CheckForNearPigs(transform.position, checkRadius);
    }

    /* 
     * NOT NEEDED ANYMORE BUT MAYBE NEEDED SOMEWHERE ELSE
     * 
    void CheckForNearPigs(Vector2 _center, float _radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_center, _radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Pig")
            {
                if(hitColliders[i].gameObject.transform.position.y > transform.position.y)
                {
                    hitColliders[i].gameObject.transform.position = new Vector2(hitColliders[i].gameObject.transform.position.x, hitColliders[i].gameObject.transform.position.y + normalPigOffset);
                }                   

                if(hitColliders[i].gameObject.transform.position.y <= transform.position.y)
                {
                    hitColliders[i].gameObject.transform.position = new Vector2(hitColliders[i].gameObject.transform.position.x, hitColliders[i].gameObject.transform.position.y - normalPigOffset);
                }

                Debug.Log("Coll hittetetet");
            }
        }
    }
    */

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

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

            other.GetComponent<Player>().health -= damage;
            camAnim.SetTrigger("shake");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
