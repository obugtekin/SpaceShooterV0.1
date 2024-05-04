using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;
    public static StartGameDelegate onRespawnPickUp;
    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;
    public delegate void ScorePointsDelegate(int  amt);
    public static ScorePointsDelegate onScorePoints;
    public static void StartGame()
    {
        if(onStartGame!=null) 
            onStartGame();
    }
    public static void ReSpawnPickUp()
    {
        if (onRespawnPickUp != null)
            onRespawnPickUp();
    }
    public static void TakeDamage(float percent)
    {
        if (onTakeDamage != null)
            onTakeDamage(percent);
        Debug.Log("Damage taken");
    }
    public static void PlayerDeath()
    {
        Debug.Log("Player Died");
        if (onPlayerDeath != null)
            onPlayerDeath();
    }

    public static void ScorePoints(int score)
    {
        if (onScorePoints != null)
            onScorePoints(score);
    }
}
