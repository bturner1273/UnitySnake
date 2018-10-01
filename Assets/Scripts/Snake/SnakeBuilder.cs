using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBuilder : MonoBehaviour {
    private List<GameObject> snake;
    private GameObject head;
    private bool initial_load = true;

	// Use this for initialization
	void Start () {
        head = GameObject.Find("SnakeHead");
        snake = new List<GameObject>{head};
    }

	
	// Update is called once per frame
	void Update () {
        

    }
}
