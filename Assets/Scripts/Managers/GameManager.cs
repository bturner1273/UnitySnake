using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static bool gameActive = false;

	// Use this for initialization
	void Start () {
        gameActive = true;
	}
	
    public static bool IsGameActive()
    {
        return gameActive;
    }

    public static void SetGameActive(bool initGameActive)
    {
        gameActive = initGameActive;
    }
}
