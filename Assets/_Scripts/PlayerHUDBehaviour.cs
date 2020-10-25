using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHUDBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text LivesCounter;
    [SerializeField]
    private TMP_Text ScoreCounter;

    [SerializeField]
    private int lives;
    [SerializeField]
    private int score;

    public int Lives
    {
        get { return lives; }
    }

    public int Score
    {
        get { return score; }
    }

    private void Awake()
    {
        LivesCounter.text = "Lives: " + Lives;
        ScoreCounter.text = "Score: " + Score;
    }
    public void Add2Score(int points)
    {
        score += points;
        ScoreCounter.text = "Score: " + Score;
    }
    public void ReduceLives()
    {
        FindObjectOfType<AudioManager>().PlaySound("DamagePlayer");
        lives--;
        LivesCounter.text = "Lives: " + Lives;
        if(lives <= 0)
        {
            var finalScore = FindObjectOfType<ScoreboardBehaviour>();
            finalScore.currentPlayerScore.points = score;
            FindObjectOfType<AudioManager>().StopPlaying("PlayMusic");
            SceneManager.LoadScene("Lose");
        }
    }

    public void IncreaseLives()
    {
        lives++;
        LivesCounter.text = "Lives: " + Lives;
    }
}
