using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection{
    UP, DOWN, LEFT, RIGHT
}

public class InputHandler : MonoBehaviour {
    private MovementDirection currentDir;
    private MovementDirection lastDir;

    private void Start()
    {
        currentDir = MovementDirection.RIGHT;
        lastDir = currentDir;
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.IsGameActive())
        {
            lastDir = currentDir;
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                currentDir = MovementDirection.LEFT;
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                currentDir = MovementDirection.RIGHT;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                currentDir = MovementDirection.DOWN;
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                currentDir = MovementDirection.UP;
            }
        }
    }

    public MovementDirection GetCurrentDirection()
    {
        return currentDir;
    }

    public MovementDirection GetLastDirection()
    {
        return lastDir;
    }
}
