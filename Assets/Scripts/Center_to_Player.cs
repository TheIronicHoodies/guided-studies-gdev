using UnityEngine;

public class Center_to_Player : MonoBehaviour
{
    public Transform newParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.SetParent(newParent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
