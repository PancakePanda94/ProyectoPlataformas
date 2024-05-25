using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int MaxHealth;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public PlayerMovement player = new PlayerMovement();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = player.getHealth();
        MaxHealth = player.getMaxHealth(); 
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if(i<MaxHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
