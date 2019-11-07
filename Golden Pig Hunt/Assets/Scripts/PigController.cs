using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour {

    public float speed = 1.0f;
    public int damage = 1;
    public float endPos = -13.0f;

    public GameObject deathEffect;
    public GameObject[] deathSounds;

    private Animator camAnim;

    public float rightBeforeFence = -0;
    public float rightBehindFence = -5.3f;
    public float happySpace = 0.8f;
    public GameObject spriteObject;

    [Header("Sprites")]
    public Sprite normalFace;
    public Sprite suprisedFace;
    public Sprite happyFace;

    float pigXPos;
    float pigYPos;
    private GameObject player;

    GameOver gameOver;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        speed = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().pigSpeed * speed;
        player = GameObject.FindGameObjectWithTag("Player");
        gameOver = GetComponent<GameOver> ();
    }

    void Update ()
    {
        pigXPos = transform.position.x;
        pigYPos = transform.position.y;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= endPos)
        {
            Destroy(gameObject);
        }

        if (pigXPos <= rightBeforeFence && pigXPos > rightBehindFence)
        {
            float yDistToPlayer = Mathf.Abs(player.transform.position.y - pigYPos);

            if(yDistToPlayer <= happySpace)
            {
                spriteObject.GetComponent<SpriteRenderer>().sprite = normalFace;
            }
            else
            {
                spriteObject.GetComponent<SpriteRenderer>().sprite = suprisedFace;
            }
            
        }

        if (pigXPos <= rightBehindFence)
        {
            spriteObject.GetComponent<SpriteRenderer>().sprite = happyFace;
        }

        if (Player.died) 
        {
            gameOver.DestroyPig(deathEffect);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int rnd = Random.Range(0, deathSounds.Length);
            Instantiate(deathSounds[rnd], transform.position, Quaternion.identity);
            //other.GetComponent<Player>().health -= damage;
            //camAnim.SetTrigger("shake");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);


            other.GetComponent<Player>().DecreaseHealth(damage);
        }        
    }
}
