using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int health;
    public float moveSpeed = 50.0f;
    public Text lifeText;
    public GameObject theGate;
    public GameObject deathUI;
    public GameObject scoreSystem;
    public static bool died;

    private void Start()
    {
        died = false;
        deathUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float yMovement = Input.GetAxis("Mouse Y");
            Vector2 currentGatePos = theGate.transform.position;
            float newYPosition = currentGatePos.y + yMovement;
            if(Mathf.Abs(newYPosition) < 6.5)
            {
                theGate.transform.position = new Vector2(currentGatePos.x, newYPosition);
            }            
        }
        lifeText.text = health.ToString() + " x";

        if (health == 0)
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
