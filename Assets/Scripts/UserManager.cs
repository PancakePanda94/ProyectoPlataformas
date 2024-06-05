using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    public UserManager()
    {

    }
    public Text wrapperText;
    public string Username { get; private set; }
    public string Email { get; private set; }
    public int EnemiesDefeated { get; private set; }
    public string userName;
    public string password;
    public void LogUser()
    {

        userName = "Martin";
        password = "1234";
        //Debug.Log($"Accessing Username: {userName}, Email: {password}");
        StartCoroutine(LogUserCoroutine(userName, password));
    }

    public string getUsername() { return Username; }

    public string getEmail() {  return Email; }

    private IEnumerator LogUserCoroutine(string userName, string password)
    {
        string url = $"http://localhost:4444/user/login?name={userName}&password={password}";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string userData = www.downloadHandler.text;
                Debug.Log("User data received: " + userData);
                User user = JsonUtility.FromJson<User>(userData);
                ActivateLogin(user);
                OnLoginSuccess(user.id);
            }
            else
            {
                Debug.LogError($"Error: {www.error}");
                Debug.LogError($"Response Code: {www.responseCode}");
                wrapperText.text = "Wrong password or username.";
            }
        }
    }

    private void ActivateLogin(User user)
    {
        Debug.Log("Login successful!");
        Username = user.userName;
        Email = user.email;
        EnemiesDefeated = user.enemiesDefeated;

        // Additional log to confirm the properties are set
        Debug.Log($"Username: {Username}, Email: {Email}");
    }

    private void OnLoginSuccess(int userId)
    {
        Debug.Log("Login success callback: " + userId);
    }

    public void GetUser(int id)
    {
        StartCoroutine(GetUserCoroutine(id));
    }

    private IEnumerator GetUserCoroutine(int id)
    {
        string url = $"http://localhost:4444/user/find/{id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string userData = www.downloadHandler.text;
                Debug.Log("User data received: " + userData);
                User user = JsonUtility.FromJson<User>(userData);
                OnGetUserSuccess(user);
            }
            else
            {
                Debug.LogError($"Error: {www.error}");
                Debug.LogError($"Response Code: {www.responseCode}");
                wrapperText.text = "Error getting user info.";
            }
        }
    }

    private void OnGetUserSuccess(User user)
    {
        Debug.Log("Get user success callback: " + user.userName);
    }

    [System.Serializable]
    private class User
    {
        public int id;
        public string userName;
        public string gamerTag;
        public string email;
        public string password;
        public string profilePictureURL;
        public string creationDate;
        public int enemiesDefeated;
    }
}
