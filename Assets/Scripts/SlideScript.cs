using UnityEngine;

public class Slide_Script : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask borderCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // -2, -1, 1, 2 for down, left, right, up respectively
        switch (PlayerController.direction)
        {
            case -2:
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (PlayerController.direction) / 2, 0f), .2f, borderCheck))
                {
                    movePoint.position += new Vector3(0f, (PlayerController.direction) / 2, 0f);
                }
                break;
            case -1:
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((PlayerController.direction), 0f, 0f), .2f, borderCheck))
                {
                    movePoint.position += new Vector3(PlayerController.direction, 0f, 0f);
                }
                break;
            case 1:
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((PlayerController.direction), 0f, 0f), .2f, borderCheck))
                {
                    movePoint.position += new Vector3(PlayerController.direction, 0f, 0f);
                }
                break;
            case 2:
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (PlayerController.direction) / 2, 0f), .2f, borderCheck))
                {
                    movePoint.position += new Vector3(0f, (PlayerController.direction) / 2, 0f);
                }
                break;
        }
    }
}
