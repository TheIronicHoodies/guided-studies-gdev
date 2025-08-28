using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntityForcedMovement : MonoBehaviour
{
    public Transform entity;
    public Transform movePoint;
    public LayerMask borderCheck, creatureCheck;

    public Transform[] orange;
    public Transform[] green;
    private int tpIndex;

    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileBehaviour> tileTypes;

    private Dictionary<TileBase, TileBehaviour> dataFromTiles;

    private Vector3Int pastGridCoordinate;

    private bool landingPoint;

    public static bool teleported, stopAnimation;
    public bool specialTile;

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
        pastGridCoordinate = map.WorldToCell(entity.position);
        teleported = false;
        landingPoint = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3Int gridCoordinate = map.WorldToCell(entity.position);
        Vector3Int gridCoordinatePointer = map.WorldToCell(movePoint.position);
        TileBase currentTile = map.GetTile(gridCoordinate);
        TileBase futureTile = map.GetTile(gridCoordinatePointer);

        int tileDirection = dataFromTiles[currentTile].direction;
        int futureTileDirection = dataFromTiles[futureTile].direction;

        if (futureTileDirection < 3)
        {
            EntityMovementScript.inputCheck = false;
            specialTile = true;
        }
        else
        {
            stopAnimation = false;
        }

        if (tileDirection > -7)
        {
            teleported = false;
        }

        if (EntityMovementScript.arrived && specialTile)
        {
            stopAnimation = true;
            switch (tileDirection)
            {
                case -8:
                    if (!teleported)
                    {
                        for (int i = 0; i < orange.Length; i++)
                        {
                            if (map.WorldToCell(orange[i].position) == gridCoordinate)
                            {
                                tpIndex = i;
                                break;
                            }
                        }

                        entity.position = green[tpIndex].position;
                        movePoint.position = green[tpIndex].position;
                        teleported = true;
                        tpIndex = 0;

                    }
                    else
                    {
                        EntityMovementScript.inputCheck = true;
                        specialTile = false;
                    }
                    break;

                case -7:
                    if (!teleported)
                    {
                        for (int i = 0; i < green.Length; i++)
                        {
                            if (map.WorldToCell(green[i].position) == gridCoordinate)
                            {
                                tpIndex = i;
                                break;
                            }
                        }
                        entity.position = orange[tpIndex].position;
                        movePoint.position = orange[tpIndex].position;
                        teleported = true;
                        tpIndex = 0;

                    }
                    else
                    {
                        EntityMovementScript.inputCheck = true;
                        specialTile = false;
                    }
                    break;

                // Down Jump Tile Case
                case -6:
                    {
                        EntityMovementScript.direction = -2;
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -4f, 0f), .2f, borderCheck|creatureCheck))
                        {
                            EntityMovementScript.moveSpeed = 7;
                            movePoint.position += new Vector3(0f, -4f, 0f);
                        }
                        else
                        {
                            for (float i = 5; i < 9; i++)
                            {
                                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -i, 0f), .2f, borderCheck|creatureCheck))
                                {
                                    EntityMovementScript.moveSpeed = 7;
                                    landingPoint = true;
                                    movePoint.position += new Vector3(0f, -i, 0f);
                                    break;
                                }
                            }

                            if (!landingPoint)
                            {
                                EntityMovementScript.moveSpeed = 3;
                                EntityMovementScript.inputCheck = true;
                                specialTile = false;
                            }
                        }
                        break;
                    }

                // Left Jump Tile Case
                case -5:
                            EntityMovementScript.direction = -1;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-4f, 0f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.moveSpeed = 7;
                                movePoint.position += new Vector3(-4f, 0f, 0f);
                            }
                            else
                            {
                                for (float i = 5; i < 9; i++)
                                {
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-i, 0f, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        EntityMovementScript.moveSpeed = 7;
                                        landingPoint = true;
                                        movePoint.position += new Vector3(-i, 0f, 0f);
                                        break;
                                    }
                                }

                                if (!landingPoint)
                                {
                                    EntityMovementScript.moveSpeed = 3;
                                    EntityMovementScript.inputCheck = true;
                                    specialTile = false;
                                }
                            }
                            break;

                        // Right Jump Tile Case
                        case -4:
                            EntityMovementScript.direction = 1;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(4f, 0f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.moveSpeed = 7;
                                movePoint.position += new Vector3(4f, 0f, 0f);
                            }
                            else
                            {
                                for (float i = 5; i < 9; i++)
                                {
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(i, 0f, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        EntityMovementScript.moveSpeed = 7;
                                        landingPoint = true;
                                        movePoint.position += new Vector3(i, 0f, 0f);
                                        break;
                                    }
                                }

                                if (!landingPoint)
                                {
                                    EntityMovementScript.moveSpeed = 3;
                                    EntityMovementScript.inputCheck = true;
                                    specialTile = false;
                                }
                            }
                            break;

                        // Up Jump Tile Case
                        case -3:
                            EntityMovementScript.direction = 2;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 4f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.moveSpeed = 7;
                                movePoint.position += new Vector3(0f, 4f, 0f);
                            }
                            else
                            {
                                for (float i = 5; i < 9; i++)
                                {
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -i, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        EntityMovementScript.moveSpeed = 7;
                                        landingPoint = true;
                                        movePoint.position += new Vector3(0f, -i, 0f);
                                        break;
                                    }
                                }

                                if (!landingPoint)
                                {
                                    EntityMovementScript.moveSpeed = 3;
                                    EntityMovementScript.inputCheck = true;
                                    specialTile = false;
                                }
                            }
                            break;

                        // Down Conveyor Tile Case
                        case -2:
                            EntityMovementScript.direction = tileDirection;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.inputCheck = false;
                                movePoint.position += new Vector3(0f, -1f, 0f);
                            }
                            else
                            {
                                EntityMovementScript.inputCheck = true;
                                specialTile = false;
                            }
                            break;


                        //Left Conveyor Tile Case
                        case -1:
                            EntityMovementScript.direction = tileDirection;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.inputCheck = false;
                                movePoint.position += new Vector3(-1f, 0f, 0f);
                            }
                            else
                            {
                                EntityMovementScript.inputCheck = true;
                                specialTile = false;
                            }
                            break;


                        // Slide Tile case
                        case 0:
                            if (gridCoordinate != pastGridCoordinate)
                            {
                                EntityMovementScript.inputCheck = false;
                            }
                            else
                            {
                                EntityMovementScript.inputCheck = true;
                                specialTile = false;
                            }
                            switch (EntityMovementScript.direction)
                            {
                                case -2:
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (EntityMovementScript.direction) / 2, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        movePoint.position += new Vector3(0f, (EntityMovementScript.direction) / 2, 0f);
                                    }
                                    break;
                                case -1:
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((EntityMovementScript.direction), 0f, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        movePoint.position += new Vector3(EntityMovementScript.direction, 0f, 0f);
                                    }
                                    break;
                                case 1:
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((EntityMovementScript.direction), 0f, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        movePoint.position += new Vector3(EntityMovementScript.direction, 0f, 0f);
                                    }
                                    break;
                                case 2:
                                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (EntityMovementScript.direction) / 2, 0f), .2f, borderCheck|creatureCheck))
                                    {
                                        movePoint.position += new Vector3(0f, (EntityMovementScript.direction) / 2, 0f);
                                    }
                                    break;
                            }
                            break;


                        // Right Conveyor Tile Case
                        case 1:
                            EntityMovementScript.direction = tileDirection;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.inputCheck = false;
                                movePoint.position += new Vector3(1f, 0f, 0f);
                            }
                            else
                            {
                                EntityMovementScript.inputCheck = true;
                                specialTile = false;
                            }
                            break;


                        // Up Conveyor Tile Case
                        case 2:
                            EntityMovementScript.direction = tileDirection;
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, borderCheck|creatureCheck))
                            {
                                EntityMovementScript.inputCheck = false;
                                movePoint.position += new Vector3(0f, 1f, 0f);
                            }
                            else
                            {
                                EntityMovementScript.inputCheck = true;
                                specialTile = false;
                            }
                            break;


                        //Regular Tiles
                        case 3:
                            EntityMovementScript.inputCheck = true;
                            specialTile = false;
                            stopAnimation = false;
                            break;
                        }
                        if (tileDirection > -3 && tileDirection > -6)
                        {
                                EntityMovementScript.moveSpeed = 3;
                        }
                        pastGridCoordinate = gridCoordinate;
                    }


            }
        }
