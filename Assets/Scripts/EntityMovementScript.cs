using UnityEngine;

public class EntityMovementScript : MonoBehaviour
{
    public static float moveSpeed;
    public Transform movePoint;
    public LayerMask borderCheck, creatureCheck;
    public static bool inputCheck, arrived, stationary;
    public static float direction;
    private int idle;
    private Vector3 previousPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movePoint.parent = null;
        inputCheck = true;
        previousPosition = transform.position;
        moveSpeed = 3f;
        Time.fixedDeltaTime = 1;
    }

    public void ChooseDirection()
    {
        direction = Random.Range(-2, 2);
    }


    // Update is called once per frame
    void Update()
    {
        arrived = (Vector3.Distance(transform.position, movePoint.position) <= 0f);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (arrived && (inputCheck))
        {
            switch (direction)
            {
                case -2:
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, borderCheck|creatureCheck))
                    {
                            movePoint.position += new Vector3(0f, -1f, 0f);
                            idle = 0;
                    }
                    break;
                case -1:
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((MovementScript.direction), 0f, 0f), .2f, borderCheck|creatureCheck))
                    {
                            movePoint.position += new Vector3(-1f, 0f, 0f);
                            idle = 0;
                    }
                    break;
                case 1:
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, borderCheck|creatureCheck))
                    {
                            movePoint.position += new Vector3(1f, 0f, 0f);
                            idle = 0;
                    }
                    break;
                case 2:
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, borderCheck|creatureCheck))
                    {
                            movePoint.position += new Vector3(0f, 1f, 0f);
                            idle = 0;
                    }
                    break;
            }
        
        }
        if (previousPosition == transform.position)
        {
            idle += 1;
        }

        if (idle >= 10)
        {
            stationary = true;
        }
        else
        {
            stationary = false;
        }

        previousPosition = transform.position;
    }
    private void FixedUpdate()
    {
        ChooseDirection();
    }

}
