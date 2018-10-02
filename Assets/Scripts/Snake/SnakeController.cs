using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {
    [SerializeField] private float INITIAL_MOVEMENT_INTERVAL;
    private const float OFFSET = .5f;
    private float movementInterval;
    private Vector2 dir;
    private InputHandler ih;
    private const float MIN_INTERVAL = .05f;
    private Vector2 lastPosition;
    private List<GameObject> body;

	// Use this for initialization
	void Start () {
        movementInterval = INITIAL_MOVEMENT_INTERVAL;
        ih = GetComponent<InputHandler>();
        body = new List<GameObject> { this.gameObject };
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.IsGameActive())
        {
            if (movementInterval - Time.deltaTime > 0)
            {
                movementInterval -= Time.deltaTime;
            }
            else
            {
                lastPosition = transform.position;
                movementInterval = INITIAL_MOVEMENT_INTERVAL;
                if (ih.GetCurrentDirection() == MovementDirection.UP)
                {
                    transform.Translate(Vector2.up*OFFSET);
                }
                else if (ih.GetCurrentDirection() == MovementDirection.DOWN)
                {
                    transform.Translate(Vector2.down*OFFSET);
                }
                else if (ih.GetCurrentDirection() == MovementDirection.RIGHT)
                {
                    transform.Translate(Vector2.right*OFFSET);
                }
                else
                {
                    transform.Translate(Vector2.left*OFFSET);
                }

                //update body list positions
                for (int i = 0; i < body.Count; i++)
                {
                    if (body.Count == 1)
                    {
                        return;
                    }
                    if (i == 0 && body.Count > 1)
                    {
                        body[i + 1].GetComponent<BodyController>().SetCurrentLocation(lastPosition);
                        i++;
                    }
                    else
                    {
                        body[i].GetComponent<BodyController>().SetCurrentLocation(body[i - 1].GetComponent<BodyController>().GetLastLocation());
                    }

                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.IsGameActive())
        {
            if (collision.gameObject.CompareTag("SnakeBit"))
            {
                if (!collision.gameObject.GetComponent<BodyController>().GetIsBody()) {
                    SpawnManager.DecrementNumSpawns();
                    SetInitMovementInterval(movementInterval - MIN_INTERVAL);
                    collision.gameObject.GetComponent<BodyController>().SetIsBody(true);
                    body.Add(collision.gameObject);
                }
            }
        }
    }


    public Vector2 getLastPosition()
    {
        return lastPosition;
    }

    public void SetInitMovementInterval(float initMovementInterval)
    {
        if (initMovementInterval > MIN_INTERVAL)
        {
            INITIAL_MOVEMENT_INTERVAL = initMovementInterval;
        }
        else INITIAL_MOVEMENT_INTERVAL = MIN_INTERVAL;
    }
}
