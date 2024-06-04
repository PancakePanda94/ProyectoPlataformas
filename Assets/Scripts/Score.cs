using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour

{
    // Update is called once per frame
    public int score;
    public string username;
    public string email;
    public TextMeshProUGUI scoreUI;

    private UserManager userManager;


    void Start()

    {

        userManager = GetComponent<UserManager>();

        Debug.Log("Username: " + userManager.Username);

        Debug.Log("Email: " + userManager.Email);

    }
    void Update()
    {
        username = userManager.Username;
        email = userManager.Email;
        score = EnemyStomp.enemiesKilled;
        scoreUI.text = "Nombre: "+username +" Email: "+email+" Puntaje: "+score.ToString();
    }
}