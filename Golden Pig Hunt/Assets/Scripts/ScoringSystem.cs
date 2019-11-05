using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour {

    public Text scoreText;

    public TMP_Text highscoreText;
    public TMP_Text currentScore;

    public GameObject goldEnd;
    public Spawner spaner;

    public int normalPigScore = 1;
    public int goldenPigScore = 5;

    private int score;
    private int highscoreValue;

    public Animator camAnim;

    public int speedUpScore = 10;
    int speedUpScoreCounter;

    AudioSource song;
    public float speedUpSongAmount = 0.1f;

    private void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        song = GetComponent<AudioSource>();
    }

    void Update ()
    {
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
    }

    void SpeedUp()
    {
        spaner.IncreaseSpeed();
        speedUpScoreCounter = 0;
        song.pitch += speedUpSongAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Player.died)
        {
            if (other.CompareTag("Pig"))
            {

                score += normalPigScore;
                speedUpScoreCounter += normalPigScore;
            }

            if (other.CompareTag("Wild Pig"))
            {
                score -= other.GetComponent<WildPigController>().damage;
            }

            if (other.CompareTag("Golden Pig"))
            {
                //camAnim.SetTrigger("shake");
                Instantiate(goldEnd, other.transform.position, Quaternion.identity);
                score += goldenPigScore;
                speedUpScoreCounter += goldenPigScore;
            }

            UpdateScore();

            if(speedUpScoreCounter >= speedUpScore)
            {
                SpeedUp();
            }
        }
    }
}
