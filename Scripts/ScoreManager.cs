using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Event-based updates ensure score changes respond exactly to gameplay events
        ItemDestruction.BoostCollect += ScoreAddTen;
        ItemDestruction.PowerCollect += ScoreAddFifty;
        ItemDestruction.LetterScore += ScoreAddHun;

    }
    void ScoreAddTen() // Small reward for basic boost pickup
    {
        currentScore += 10;
        scoreText.text = "Score: "+ currentScore;
    }
    void ScoreAddFifty()// Larger reward for power-up collection
    {
        currentScore += 50;
        scoreText.text = "Score: " + currentScore;
    }
    void ScoreAddHun() // Biggest reward for completing letter objectives
    {
        currentScore += 100;
        scoreText.text = "Score: " + currentScore;
    }
}
