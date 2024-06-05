using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyStomp : MonoBehaviour
{
    // Static counter to keep track of the number of enemies killed
    public static int enemiesKilled = 0;
    public int id;
    private UserManager userManager = new UserManager();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        id = userManager.getId();
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(gameObject);
            string url = "http://localhost:4444/user/increase/3";
            StartCoroutine(MakePutRequest(url));

            enemiesKilled++; // Increment the counter when the weak point is hit

            player.Regen();

            // Send a PUT request to update the enemiesKilled value
            //StartCoroutine(UpdateEnemiesKilled(id, enemiesKilled));
        }

        if (player != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
            enemiesKilled++; // Increment the counter when the player destroys the enemy
            string url = $"http://localhost:4444/user/increase/3";
            StartCoroutine(MakePutRequest(url));
            player.Regen();

            // Send a PUT request to update the enemiesKilled value
            //StartCoroutine(UpdateEnemiesKilled(id, enemiesKilled));
        }
    }
    private IEnumerator MakePutRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Put(url, "");
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error: {request.error}");
        }
        else
        {
            Debug.Log("PUT request sent successfully");
        }
    }
    //private IEnumerator UpdateEnemiesKilled(int userId, int enemiesKilled)
    //{
    //    // Create a JSON payload with the updated enemiesKilled value
    //    string json = $"{{ \"enemiesKilled\": {enemiesKilled} }}";
    //    byte[] payload = Encoding.UTF8.GetBytes(json);

    //    // Create a PUT request
    //    using (UnityWebRequest www = UnityWebRequest.Put($"http://localhost:4444/user/{userId}", json))
    //    {
    //        www.uploadHandler = new UploadHandlerRaw(payload);
    //        www.downloadHandler = new DownloadHandlerBuffer();
    //        www.SetRequestHeader("Content-Type", "application/json");

    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Enemies killed updated successfully!");
    //        }
    //        else
    //        {
    //            Debug.Log("Error updating enemies killed: " + www.error);
    //        }
    //    }
    //}
}