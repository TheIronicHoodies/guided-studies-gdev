using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu()]
public class TileBehaviour: ScriptableObject
{
    public TileBase[] tiles;

    // -2, -1, 1, 2 for down, left, right, up conveyors respectively, 0 for sliding tile, 3 for regular floor tile
    public int direction;

}
