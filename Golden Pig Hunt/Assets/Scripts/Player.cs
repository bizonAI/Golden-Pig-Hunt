using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float moveSpeed = 50.0f;
    public Text lifeText;
    public GameObject deathUI;
    public GameObject scoreSystem;

    private float yPos;
    private Vector3 mousePos;

    public static bool died;

    private void Start()
    {
        died = false;
        deathUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !died)
        {
            mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            yPos = mousePos.y;

            //transform.position = new Vector2(transform.position.x, yPos);
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, yPos), moveSpeed * Time.deltaTime);

        lifeText.text = health.ToString() + " x";

        if(health == 0)
        {
            died = true;
            Death();
        }
    }

    void Death()
    {
        scoreSystem.GetComponent<ScoringSystem>().SetScore();
        deathUI.SetActive(true);
    }
}
