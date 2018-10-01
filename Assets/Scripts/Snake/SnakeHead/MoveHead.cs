using UnityEngine;

public class MoveHead : MonoBehaviour {
    [SerializeField] private float INITIAL_MOVEMENT_INTERVAL;
    private const float OFFSET = .5f;
    private float movementInterval;
    private Vector2 dir;
    private InputHandler ih;
    private const float MIN_INTERVAL = .05f;
    public Vector2 lastPosition;

	// Use this for initialization
	void Start () {
        movementInterval = INITIAL_MOVEMENT_INTERVAL;
        ih = GetComponent<InputHandler>();
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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.IsGameActive())
        {
            if (collision.gameObject.CompareTag("SnakeBit"))
            {
                Destroy(collision.gameObject);
                SpawnManager.DecrementNumSpawns();
                SetInitMovementInterval(movementInterval - MIN_INTERVAL);
            }
        }
    }

    public Vector2 getLastPosition()
    {
        return lastPosition;
    }

    void SetInitMovementInterval(float initMovementInterval)
    {
        if (initMovementInterval > MIN_INTERVAL)
        {
            INITIAL_MOVEMENT_INTERVAL = initMovementInterval;
        }
        else INITIAL_MOVEMENT_INTERVAL = MIN_INTERVAL;
    }
}
