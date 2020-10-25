using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class ScoreTextBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        var scoreBoard = FindObjectOfType<ScoreboardBehaviour>();
        scoreText.text = "Your Score: " + scoreBoard.GetComponent<ScoreboardBehaviour>().GetScore.points;
    }
}
