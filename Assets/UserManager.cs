using UnityEngine;

using UnityEngine.Networking;

using System.Collections;
using UnityEngine.UI;


public class UserManager : MonoBehaviour

{

    public InputField userNameInput;

    public InputField passwordInput;

    public Text wrapperText;
    public string Username { get; private set; }

    public string Email { get; private set; }



    public void LogUser()

    {

        string userName = userNameInput.text;

        string password = passwordInput.text;


        StartCoroutine(LogUserCoroutine(userName, password));

    }


    private IEnumerator LogUserCoroutine(string userName, string password)

    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:4444/user/login?name=" + userName + "&password=" + password))

        {

            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();


            if (www.result == UnityWebRequest.Result.Success)

            {

                string userData = www.downloadHandler.text;

                User user = JsonUtility.FromJson<User>(userData);


                ActivateLogin(user);

                OnLoginSuccess(user.id);

            }

            else

            {

                wrapperText.text = "Wrong password or username.";

            }

        }

    }
    private void ActivateLogin(User user)

    {

        // Activate login logic here

        Debug.Log("Login successful!");
        Username = user.userName;

        Email = user.email;

    }


    private void OnLoginSuccess(int userId)

    {

        // Call callback function here

        Debug.Log("Login success callback: " + userId);

    }


    public void GetUser(int id)

    {

        StartCoroutine(GetUserCoroutine(id));

    }


    private IEnumerator GetUserCoroutine(int id)

    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:4444/user/find/" + id))

        {

            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string userData = www.downloadHandler.text;
                User user = JsonUtility.FromJson<User>(userData);
                OnGetUserSuccess(user);
            }
            else
            {
                wrapperText.text = "Error getting user info.";
            }
        }
    }

    private void OnGetUserSuccess(User user)
    {
        // Call callback function here
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