using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementNotification : IObserver
{
    public void OnNotify()
    {
        Debug.Log("Congratulation! You have used 10 Health Packs!");
    }
}
