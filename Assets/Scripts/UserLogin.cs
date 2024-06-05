using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using Newtonsoft.Json;

public class UserLogin : MonoBehaviour
{
    public InputField userNameInputField;
    public InputField passwordInputField;
    public Text wrapperText;

    public void LogUser(System.Action<int> onLoginSuccess)
    {
        string userName = "polpol";
        string password = "1234";
        wrapperText.text = string.Empty;

        StartCoroutine(LoginCoroutine(userName, password, onLoginSuccess));
    }

    private IEnumerator LoginCoroutine(string userName, string password, System.Action<int> onLoginSuccess)
    {
        string url = $"http://localhost:4444/user/login?name={userName}&password={password}";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                wrapperText.text = "Wrong password or username.";
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                User user = JsonConvert.DeserializeObject<User>(jsonResponse);

                Debug.Log("data: " + jsonResponse);
                ActivateLogin(user);
                onLoginSuccess?.Invoke(user.id);
            }
        }
    }

    private void ActivateLogin(User user)
    {
        // Implement the login activation logic here
        Debug.Log("User logged in: " + user.name);
    }
}

public class User
{
    public int id;
    public string name;
    public string password; // Depending on the response structure, add fields as necessary
}
