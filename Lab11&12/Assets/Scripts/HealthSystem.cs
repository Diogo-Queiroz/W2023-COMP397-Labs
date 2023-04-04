using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health = 2;
    public int maxHearts = 6;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;

    void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (health > maxHearts)
        {
            health = maxHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            // Change the sprite based on the health value
            if (i < health)
            {
                hearts[i].sprite = heartFull;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
            
            // Enable hearts based on MaxHearts variable number
            if (i < maxHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Damage()
    {
        health--;
        UpdateUI();
    }

    public void SelfHeal()
    {
        health++;
        UpdateUI();
    }

    public void IncreaseHeart()
    {
        maxHearts++;
        UpdateUI();
    }
}
