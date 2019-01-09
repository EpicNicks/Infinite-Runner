using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager //: MonoBehaviour
{
    public static int score;
    public static int coinCount;

    public static IEnumerator UpdateScore()
    {
        Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        
        score++;
        scoreText.text = "SCORE: " + score;
        scoreText.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        scoreText.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        scoreText.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        scoreText.color = new Color(0, 1, 55 / 255);
    }

    public static void UpdateCoinCount(int value)
    {
        coinCount += value;
        PlayerPrefsManager.SetCoinCount(coinCount);
        //adds directly to lifetime coins
        PlayerPrefsManager.SetLifetimeCoins(PlayerPrefsManager.GetLifetimeCoins() + value);
    }

    public static void ResetScores()
    {
        score = 0;
    }

    /// Use if MonoBehaviours become necessary
    //void Start()
    //{
    //    score = 0;
    //    scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    //    scoreText.text = "Score: " + score;
    //}
}
