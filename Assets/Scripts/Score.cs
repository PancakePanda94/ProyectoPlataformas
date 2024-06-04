using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public string username;
    public string email;
    public TextMeshProUGUI scoreUI;

    private UserManager userManager;

    void Start()
    {
        userManager = GetComponent<UserManager>();
        if (userManager == null)
        {
            Debug.LogError("UserManager component not found on the GameObject.");
            return;
        }

        // Attempt to log the user
        userManager.LogUser();

        // Initialize the UI
        UpdateScoreUI();
    }

    void Update()
    {
        if (userManager != null)
        {
            username = userManager.Username;
            email = userManager.Email;

            // Log to confirm the properties are being accessed
            Debug.Log($"Accessing Username: {username}, Email: {email}");
        }

        score = EnemyStomp.enemiesKilled;
        UpdateScoreUI();
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