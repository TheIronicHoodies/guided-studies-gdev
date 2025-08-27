using UnityEngine;

public class Center_to_Player : MonoBehaviour
{
    public Transform newParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.SetParent(newParent);
<<<<<<< HEAD
=======
        transform.position = new Vector3(0f, 0f, 5f);
>>>>>>> b9627096bef7ef75581d2597554388d190a98d6e
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
