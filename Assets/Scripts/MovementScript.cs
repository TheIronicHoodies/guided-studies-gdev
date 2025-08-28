using UnityEngine;

public class MovementScript : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        //variable to check if Player and Movement point at the same point

        arrived = (Vector3.Distance(transform.position, movePoint.position) <= 0f);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (arrived && (inputCheck))
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                direction = Input.GetAxisRaw("Horizontal");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, borderCheck|creatureCheck))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    idle = 0;
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                direction = Input.GetAxisRaw("Vertical") * 2;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, borderCheck|creatureCheck))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    idle = 0;
                }
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

}
