using UnityEngine;

public class Center_Sprite_to_Player : MonoBehaviour
{
    public Transform newParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(newParent.position.x, newParent.position.y, 0f);
    }
}
