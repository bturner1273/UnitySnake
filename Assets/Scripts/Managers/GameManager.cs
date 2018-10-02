using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static bool gameActive = false;
    private static int score;
    private static UIManager ui;


    // Use this for initialization
    void Start () {
        gameActive = true;
        score = 0;
        ui = new UIManager();
	}


    public static void IncrementScore()
    {
        score++;
        ui.UpdateScoreDisplay();
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetScore(int initScore)
    {
        score = initScore;
    }
	
    public static bool IsGameActive()
    {
        return gameActive;
    }

    public static void SetGameActive(bool initGameActive)
    {
        gameActive = initGameActive;
        if (!gameActive)
        {
            ui.ShowGameOver();
        }
    }
}
