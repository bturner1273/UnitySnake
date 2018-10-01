using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private GameObject toSpawn;
    [SerializeField] private int MAX_SPAWNS; //MAX_SPAWNS is one for Snake
    private static int numSpawns;
    private float MAX_Y_BOUNDS = 4f;
    private float MAX_X_BOUNDS = 11f;
	
    // Use this for initialization
	void Start () {
        numSpawns = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.IsGameActive())
        {
            if (numSpawns < MAX_SPAWNS)
            {
                numSpawns++;
                float x = Mathf.Floor(Random.Range(-MAX_X_BOUNDS, MAX_X_BOUNDS)) < 0 ? Mathf.Floor(Random.Range(-MAX_X_BOUNDS, MAX_X_BOUNDS)) + .5f : Mathf.Floor(Random.Range(-MAX_X_BOUNDS, MAX_X_BOUNDS)) - .5f;
                float y = Mathf.Floor(Random.Range(-MAX_Y_BOUNDS, MAX_Y_BOUNDS)) < 0 ? Mathf.Floor(Random.Range(-MAX_Y_BOUNDS, MAX_Y_BOUNDS)) + .5f : Mathf.Floor(Random.Range(-MAX_Y_BOUNDS, MAX_Y_BOUNDS)) - .5f;
                Instantiate(toSpawn, new Vector3(x, y), Quaternion.identity);
            }
        }
	}

    public static int GetNumSpawns()
    {
        return numSpawns;
    }

    public static void SetNumSpawns(int initNumSpawns)
    {
        numSpawns = initNumSpawns;
    }

    public static void DecrementNumSpawns()
    {
        if (numSpawns > 0)
        {
            numSpawns -= 1;
        }
        else numSpawns = 0;
    }
}
