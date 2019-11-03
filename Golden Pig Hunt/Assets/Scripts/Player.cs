using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int health;
    public float moveSpeed = 50.0f;


    public GameObject theGate;
    public GameObject deathUI;

    [Header("Controller")]
    public GameObject scoreSystem;
    public GameController gameController;

    [Header("Lifes")]
    public GameObject[] lifes;
    public Sprite deadHeart;
    public Sprite healthyHeart;

    [Header("Extra Life")]
    public GameObject continueCanvas;
    public GameObject rewaredPanel;

    public static bool died;

    public float smoothTime = 0.1f;
    private Vector2 velocity = Vector2.zero;

    bool playedAd;

    int initialHealth;

    private void Awake()
    {
        died = false;
        deathUI.SetActive(false);
        initialHealth = health;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !died)
        {
            float yMovement = Input.GetAxis("Mouse Y");
            Vector2 currentGatePos = theGate.transform.position;
            float newYPosition = currentGatePos.y + yMovement;
            if(Mathf.Abs(newYPosition) < 6.5)
            {
                theGate.transform.position = Vector2.SmoothDamp(transform.position, new Vector2(currentGatePos.x, newYPosition), ref velocity, smoothTime);
            }            
        }

        if (health == 0)
        {
            died = true;
            Death();
        }
    }

    public void DecreaseHealth(int damage)
    {
        lifes[health - 1].GetComponent<Image>().sprite = deadHeart;
        health -= damage;
    }

    void Death()
    {
        scoreSystem.GetComponent<ScoringSystem>().SetScore();
        deathUI.SetActive(true);
        DeathAd();
    }

    void DeathAd()
    {
        if (!playedAd)
        {
            AdController.instance.ShowNormalAd();
            playedAd = true;
        }
    }

    //For Video Button
    public void GainExtraLife()
    {
        health = initialHealth;
        AdController.instance.ShowRewardedAd();
        continueCanvas.SetActive(true);
        deathUI.SetActive(false);
        rewaredPanel.SetActive(false);
    }

    public void ContinueGameAfterDeath()
    {
        died = false;
        continueCanvas.SetActive(false);

        for(int i = 0; i < lifes.Length; i++)
        {
            lifes[i].GetComponent<Image>().sprite = healthyHeart;
        }
    }
}
