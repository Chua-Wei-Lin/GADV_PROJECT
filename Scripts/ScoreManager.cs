using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        ItemDestruction.BoostCollect += ScoreAddTen;
        ItemDestruction.PowerCollect += ScoreAddFifty;
        ItemDestruction.LetterScore += ScoreAddHun;

    }
    void ScoreAddTen()
    {
        currentScore += 10;
        scoreText.text = "Score: "+ currentScore;
    }
    void ScoreAddFifty()
    {
        currentScore += 50;
        scoreText.text = "Score: " + currentScore;
    }
    void ScoreAddHun()
    {
        currentScore += 100;
        scoreText.text = "Score: " + currentScore;
    }
}
