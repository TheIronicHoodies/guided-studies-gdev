// using NUnit.Framework;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// public class ForcedMovementManager : MonoBehaviour
// {
//     public Transform player;
//     public Transform movePoint;
//     public LayerMask borderCheck;

//     [SerializeField]
//     private Tilemap map;

//     [SerializeField]
//     private List<TileBehaviour> tileTypes;

//     private Dictionary<TileBase, TileBehaviour> dataFromTiles;

<<<<<<< HEAD
//     private void Awake()
//     {
//         dataFromTiles = new Dictionary<TileBase, TileBehaviour>();

//         foreach (var tileBehaviour in tileTypes)
//         {
//             foreach (var tile in TileBehaviour.tiles)
//             {
//                 dataFromTiles.Add(tile, tileBehaviour);
//             }
//         }
//     }


//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }


//     // Update is called once per frame
//     void Update()
//     {
//         Vector3Int gridcoordinate = map.WorldToCell(player.position);
//         TileBase currentTile = map.GetTile(gridcoordinate);

//         int tileDirection = dataFromTiles[currentTile].direction;

//         if (PlayerController.arrived)
//         {
//             switch (tileDirection)
//             {


//                 // Down Conveyor Tile Case
//                 case -2:
//                     PlayerController.direction = tileDirection;
//                     if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, borderCheck))
//                     {
//                         PlayerController.inputCheck = false;
//                         movePoint.position += new Vector3(0f, -1f, 0f);
//                     }
//                     else
//                     {
//                         PlayerController.inputCheck = true;
//                     }
//                     break;


//                 //Left Conveyor Tile Case
//                 case -1:
//                     PlayerController.direction = tileDirection;
//                     if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, borderCheck))
//                     {
//                         PlayerController.inputCheck = false;
//                         movePoint.position += new Vector3(-1f, 0f, 0f);
//                     }
//                     else
//                     {
//                         PlayerController.inputCheck = true;
//                     }
//                     break;


//                 // Slide Tile case
//                 case 0:
//                     switch (PlayerController.direction)
//                     {
//                         case -2:
//                             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (PlayerController.direction) / 2, 0f), .2f, borderCheck))
//                             {
//                                 movePoint.position += new Vector3(0f, (PlayerController.direction) / 2, 0f);
//                             }
//                             break;
//                         case -1:
//                             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((PlayerController.direction), 0f, 0f), .2f, borderCheck))
//                             {
//                                 movePoint.position += new Vector3(PlayerController.direction, 0f, 0f);
//                             }
//                             break;
//                         case 1:
//                             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((PlayerController.direction), 0f, 0f), .2f, borderCheck))
//                             {
//                                 movePoint.position += new Vector3(PlayerController.direction, 0f, 0f);
//                             }
//                             break;
//                         case 2:
//                             if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (PlayerController.direction) / 2, 0f), .2f, borderCheck))
//                             {
//                                 movePoint.position += new Vector3(0f, (PlayerController.direction) / 2, 0f);
//                             }
//                             break;
//                     }
//                     break;


//                 // Right Conveyor Tile Case
//                 case 1:
//                     PlayerController.direction = tileDirection;
//                     if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, borderCheck))
//                     {
//                         PlayerController.inputCheck = false;
//                         movePoint.position += new Vector3(1f, 0f, 0f);
//                     }
//                     else
//                     {
//                         PlayerController.inputCheck = true;
//                     }
//                     break;


//                 // Up Conveyor Tile Case
//                 case 2:
//                     PlayerController.direction = tileDirection;
//                     if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, borderCheck))
//                     {
//                         PlayerController.inputCheck = false;
//                         movePoint.position += new Vector3(0f, 1f, 0f);
//                     }
//                     else
//                     {
//                         PlayerController.inputCheck = true;
//                     }
//                     break;


//                 //Regular Tiles
//                 case 3:
//                     PlayerController.inputCheck = true;
//                     break;
//             }
//         }
//     }
// }
