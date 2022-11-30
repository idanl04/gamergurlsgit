using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
   // public TextMeshProUGUI highScoreText;

    private int score = 0;
   // private int highScore = 33;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINT";
        //highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = score.ToString() + " POINT";
    }
}
