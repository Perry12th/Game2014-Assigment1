using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ScoreboardBehaviour : MonoBehaviour
{
    public struct Score
    {
        public int points;
        public string playerName;
    }
    public Score currentPlayerScore;
    private List<Score> ScoreList;

    public Score GetScore
    {
        get { return currentPlayerScore; }
    }

    static int SortByScore(Score score1, Score score2)
    {
        return score1.points.CompareTo(score2.points);
    }
    public List<Score> GetScoreList()
    {
        ScoreList.Sort(SortByScore);
        return ScoreList;
    }

    public void SetPlayerName(string playerName)
    {
        currentPlayerScore.playerName = playerName;
    }

    public void SetPlayerScore(int pointsEarned)
    {
        currentPlayerScore.points = pointsEarned;
    }

    public void AddPlayerScoreToList()
    {
        ScoreList.Add(currentPlayerScore);
    }

    [SerializeField]
    public int WinBonus;
    [SerializeField]
    public int LivesBonus;

    // Start is called before the first frame update
    void Start()
    {
        // This object will stay within the game between scenes
        DontDestroyOnLoad(this);
        // Load up the ScoreList (order it from top to bottom points)
        ScoreList = new List<Score>();
                
    }
}
