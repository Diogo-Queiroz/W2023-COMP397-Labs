using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementSystem : MonoBehaviour, IObserver
{
    public Subject subject;
    private int jumpCounter = 0;
    private int healthCounter = 0;
    private int deathCounter = 0;
    public TMP_Text achievementText;

    void OnEnable()
    {
        subject.AddObserver(this);
    }

    void OnDisable()
    {
        subject.RemoveObserver(this);
    }

    public void OnNotify(ActionType achievementType)
    {
        Debug.Log("Achievement System is Observing.");
        switch (achievementType)
        {
            case ActionType.Jump:
                jumpCounter++;
                if (jumpCounter == 3)
                {
                    Debug.Log("Very energetic. Achievement Unlocked");
                    PlayerPrefs.SetInt("achievement-jumpCounter-"+jumpCounter, 1);
                    UpdateAchievements("achievement-jumpCounter-" + jumpCounter);
                }
                break;
            case ActionType.Death:
                deathCounter++;
                if (deathCounter == 1)
                {
                    Debug.Log("Oh no. Your first death");
                    PlayerPrefs.SetInt("achievement-deathCounter-"+deathCounter, 1);
                    UpdateAchievements("achievement-deathCounter-"+deathCounter);
                }
                if (deathCounter == 10)
                {
                    Debug.Log("Ohhh...do you need assistance?");
                    PlayerPrefs.SetInt("achievement-deathCounter-"+deathCounter, 2);
                    UpdateAchievements("achievement-deathCounter-"+deathCounter);
                }
                break;
            case ActionType.Health:
                healthCounter++;
                if (healthCounter == 1)
                {
                    Debug.Log("Niiiice. First health pack acquired.");
                    PlayerPrefs.SetInt("achievement-healthCounter-"+healthCounter, 1);
                    UpdateAchievements("achievement-healthCounter-"+healthCounter);
                }
                if (healthCounter == 2)
                {
                    Debug.Log("Very good. Second health pack acquired");
                    PlayerPrefs.SetInt("achievement-healthCounter-"+healthCounter, 2);
                    UpdateAchievements("achievement-healthCounter-"+healthCounter);
                }
                break;
            default:
                break;
        }
        PlayerPrefs.Save();
    }

    public void UpdateAchievements(string achievementName)
    {
        string start = achievementText.text;
        var achievement = PlayerPrefs.GetInt(achievementName);
        switch (achievement)
        {
            case 1:
                start += "\n" + achievementName + "-Bronze!!";
                break;
            case 2:
                start += "\n" + achievementName + "-Silver!!";
                break;
            case 3:
                start += "\n" + achievementName + "-Gold!!";
                break;
            case 4:
                start += "\n" + achievementName + "-Platinum!!";
                break;
            default:
                break;
        }
        achievementText.text = start;
    }
}


