using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int health;
    public float moveSpeed = 50.0f;
    public float maxYPos = 7;

    [Header("Canvases")]
    public GameObject deathUI;
    public GameObject countUI;

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

    float dist;
    Vector2 latestPos;
    float initialSmoothTime;

    private void Awake()
    {
        died = false;
        deathUI.SetActive(false);
        initialHealth = health;
        initialSmoothTime = smoothTime;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 wolrdMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            dist = transform.position.y - wolrdMousePos.y;
        }

        if (Input.GetMouseButton(0) && !died)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 wolrdMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 newPosition = Vector2.Lerp(transform.position, new Vector2(transform.position.x, (wolrdMousePos.y + dist)), smoothTime * Time.deltaTime);

            float newYPos = newPosition.y;

            transform.position = new Vector2(transform.position.x, Mathf.Clamp(newYPos, -maxYPos, maxYPos));
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

        if(health == 0)
        {
            scoreSystem.GetComponent<ScoringSystem>().SetScore();
        }
    }

    void Death()
    {
        countUI.SetActive(false);
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
        countUI.SetActive(true);

        for(int i = 0; i < lifes.Length; i++)
        {
            lifes[i].GetComponent<Image>().sprite = healthyHeart;
        }
    }
}
