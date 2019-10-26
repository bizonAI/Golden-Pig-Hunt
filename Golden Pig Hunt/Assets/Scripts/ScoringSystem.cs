using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour {

    public Text scoreText;

    //public Text currentScore;
    //public Text highscoreText;

    public TMP_Text highscoreText;
    public TMP_Text currentScore;

    public GameObject goldEnd;

    private int score;
    private int highscoreValue;

    public Animator camAnim;
    

    private void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update ()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Player.died)
        {
            if (other.CompareTag("Pig"))
            {
                score -= other.GetComponent<PigController>().damage;
            }

            if (other.CompareTag("Wild Pig"))
            {
                score -= other.GetComponent<WildPigController>().damage;
            }

            if (other.CompareTag("Golden Pig"))
            {
                camAnim.SetTrigger("shake");
                Instantiate(goldEnd, other.transform.position, Quaternion.identity);
                score++;
            }
        }
    }
}
