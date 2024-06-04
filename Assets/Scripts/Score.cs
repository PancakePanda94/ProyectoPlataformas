using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Update is called once per frame
    public int score;
    public TextMeshProUGUI scoreUI;
    void Update()
    {
        
        score = 100*EnemyStomp.enemiesKilled;
        scoreUI.text=score.ToString();
        //ScoreText.text = "Score: " + score; <--connect to ScoreText (TMP)
    }
}