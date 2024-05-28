using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class KillCountDisplay : MonoBehaviour
{
    // Update is called once per frame
    private int score;
    void Update()
    {
        score = EnemyStomp.enemiesKilled;
        //ScoreText.text = "Score: " + score; <--connect to ScoreText (TMP)
    }
}