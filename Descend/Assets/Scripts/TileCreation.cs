using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCreation : MonoBehaviour {

    public Tile highlightTile;
    public Tilemap highlightMap;
    Random rnd = new Random();
    int num;
    private Vector3Int previous;

    private void Start()
    {
        num = 1;
        rnd = new Random();
    }

    void CreateMap()
    {
        // get current grid location
        Vector3Int currentCell = highlightMap.WorldToCell(transform.position);
        // add one in a direction (you'll have to change this to match your directional control)
        currentCell.x += Random.Range(-10, 10);

        // if the position has changed
        if (currentCell != previous)
        {
            // set the new tile
            highlightMap.SetTile(currentCell, highlightTile);

            // erase previous
            highlightMap.SetTile(previous, null);

            // save the new position for next frame
            previous = currentCell;
        }
    }
}
