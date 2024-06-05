using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int id;
    public string username;
    public string email;
    public TextMeshProUGUI scoreUI;
    public int stomp = 0;
    private UserManager userManager = new UserManager();

    void Start()
    {
       //userManager = GetComponent<UserManager>();
        //if (userManager == null)
        //{
        //    Debug.LogError("UserManager component not found on the GameObject.");
        //    return;
        //}

        // Attempt to log the user
       // userManager.LogUser();
       //email = userManager.getEmail();
       //username = userManager.getUsername();
       // id = userManager.getId();
       // // Initialize the UI
       // Debug.Log($"Accessing Username: {username}, Email: {email}");
       // UpdateScoreUI();
    }

    void Update()
    {
        if (userManager != null)
        {
            //username = userManager.Username;
            // email = userManager.Email;
            email = userManager.getEmail();
            username = userManager.getUsername();
            // Log to confirm the properties are being accessed
            //Debug.Log($"Accessing Username: {username}, Email: {email}");
        }

        score = EnemyStomp.enemiesKilled;
        if (score != stomp) {
            stomp = score;
            UpdateScoreUI();
        }
        
    }

    void UpdateScoreUI()
    {

        if (scoreUI != null)
        {
            scoreUI.text = $"Nombre: {username} Email: {email} Puntaje: {score}";
            Debug.Log($"Updating UI: Nombre: {username} Email: {email} Puntaje: {score}");
        }
        else
        {
            Debug.LogError("scoreUI is not assigned.");
        }
    }
}