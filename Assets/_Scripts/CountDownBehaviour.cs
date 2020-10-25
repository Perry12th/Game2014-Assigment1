using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownBehaviour : MonoBehaviour
{
    [SerializeField]
    private float startingTime = 60;
    [SerializeField]
    private TMP_Text counterText;
    // Start is called before the first frame update
    void Start()
    {
        counterText.text = startingTime.ToString();
        FindObjectOfType<AudioManager>().PlaySound("PlayMusic");
    }

    // Update is called once per frame
    void Update()
    {
        startingTime -= Time.deltaTime;
        counterText.text = Mathf.Round(startingTime).ToString();
        if (startingTime <= 0)
        {
            var finalScore = FindObjectOfType<ScoreboardBehaviour>();
            var playerScore = FindObjectOfType<PlayerHUDBehaviour>().Score;
            var playerLives = FindObjectOfType<PlayerHUDBehaviour>().Lives;
            finalScore.currentPlayerScore.points = (playerScore + finalScore.LivesBonus * playerLives + finalScore.WinBonus);
            FindObjectOfType<AudioManager>().StopPlaying("PlayMusic");
            SceneManager.LoadScene("Win");
        }
    }

    void OnDestroy()
    {
        FindObjectOfType<AudioManager>().StopPlaying("PlayMusic");
    }
}
