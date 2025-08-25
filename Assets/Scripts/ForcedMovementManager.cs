using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForcedMovementManager : MonoBehaviour
{
    public Transform player;
    public Transform movePoint;
    public LayerMask borderCheck;

    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileBehaviour> tileTypes;

    private Dictionary<TileBase, TileBehaviour> dataFromTiles;

    private Vector3Int pastGridCoordinate;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileBehaviour>();

        foreach (var tileBehaviour in tileTypes)
        {
            foreach (var tile in tileBehaviour.tiles)
            {
                dataFromTiles.Add(tile, tileBehaviour);
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pastGridCoordinate = map.WorldToCell(player.position);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3Int gridCoordinate = map.WorldToCell(player.position);
        Vector3Int gridCoordinatePointer = map.WorldToCell(movePoint.position);
        TileBase currentTile = map.GetTile(gridCoordinate);
        TileBase futureTile = map.GetTile(gridCoordinatePointer);

        int tileDirection = dataFromTiles[currentTile].direction;
        int futureTileDirection = dataFromTiles[futureTile].direction;

        if (futureTileDirection < 3 && futureTileDirection != 0)
        {
            PlayerController.inputCheck = false;
        }

        pastGridCoordinate = gridCoordinate;


        if (PlayerController.arrived)
        {
            switch (tileDirection)
            {


                // Down Conveyor Tile Case
                case -2:
                    PlayerController.direction = tileDirection;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, borderCheck))
                    {
                        PlayerController.inputCheck = false;
                        movePoint.position += new Vector3(0f, -1f, 0f);
                    }
                    else
                    {
                        PlayerController.inputCheck = true;
                    }
                    break;


                //Left Conveyor Tile Case
                case -1:
                    PlayerController.direction = tileDirection;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, borderCheck))
                    {
                        PlayerController.inputCheck = false;
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                    }
                    else
                    {
                        PlayerController.inputCheck = true;
                    }
                    break;


                // Slide Tile case
                case 0:
                    if (gridCoordinate != pastGridCoordinate)
                    {
                        PlayerController.inputCheck = false;
                    }
                    else
                    {
                        PlayerController.inputCheck = true;
                    }
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
                    break;


                // Right Conveyor Tile Case
                case 1:
                    PlayerController.direction = tileDirection;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, borderCheck))
                    {
                        PlayerController.inputCheck = false;
                        movePoint.position += new Vector3(1f, 0f, 0f);
                    }
                    else
                    {
                        PlayerController.inputCheck = true;
                    }
                    break;


                // Up Conveyor Tile Case
                case 2:
                    PlayerController.direction = tileDirection;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, borderCheck))
                    {
                        PlayerController.inputCheck = false;
                        movePoint.position += new Vector3(0f, 1f, 0f);
                    }
                    else
                    {
                        PlayerController.inputCheck = true;
                    }
                    break;


                //Regular Tiles
                case 3:
                    PlayerController.inputCheck = true;
                    break;
            }
        }


    }
}
