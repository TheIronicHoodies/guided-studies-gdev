using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask borderCheck;
    public string selftag = GameObject.tag;
    public GameObject[] similar_tagged; // should be fixed at two

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Look for all tiles with the same tag as this one
        similar_tagged = GameObject.FindGameObjectsWithTag(selftag);

        // Grab the tile that is NOT this tile
        foreach (var t in similar_tagged)
        {
            if(t != GameObject) {
                movePoint = t.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player enters the tile their coordinates are moved to those of the "partner" tile
        Player.transform = movePoint;
    }
}
