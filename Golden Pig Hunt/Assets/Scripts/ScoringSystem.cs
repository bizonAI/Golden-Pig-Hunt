using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour {

    public Text scoreText;

    public TMP_Text highscoreText;
    public TMP_Text currentScore;
    public TMP_Text myMoneyText;

    public GameObject goldEnd;
    public int normalPigScore = 1;
    public int goldenPigScore = 5;

    private int score;
    private int highscoreValue;
    private int myMoney;

    public Animator camAnim;

    public int speedUpScore = 10;

    AudioSource song;

    private void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        song = GetComponent<AudioSource>();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();        
    }

    public void SetScore()
    {
        currentScore.text = score.ToString();

        if(score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }

        PlayerPrefs.SetInt("MyMoney", PlayerPrefs.GetInt("MyMoney", 0) + score);

        myMoneyText.text = PlayerPrefs.GetInt("MyMoney", 0).ToString() + "$";
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Player.died)
        {
            if (other.CompareTag("Pig"))
            {

                score += normalPigScore;
            }

            if (other.CompareTag("Golden Pig"))
            {
                //camAnim.SetTrigger("shake");
                Instantiate(goldEnd, other.transform.position, Quaternion.identity);
                score += goldenPigScore;
            }

            UpdateScore();
        }
    }
}
