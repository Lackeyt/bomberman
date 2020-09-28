using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestruct : MonoBehaviour
{
  public Tilemap tilemap;

  public Tile WoodPlank;
  public Tile RockWall;

  public GameObject explosionPrefab;

  public void Explode(Vector2 worldPos)
  {
    Vector3Int originCell = tilemap.WorldToCell(worldPos);

    ExplodeCell(originCell);
  }

  void ExplodeCell (Vector3Int cell)
  {
    Tile tile = tilemap.GetTile<Tile>(cell);

    if (tile == RockWall) //do not explode walls
    {
      return;
    }

    if (tile == WoodPlank) //destroy woodplanks
    {
      tilemap.SetTile(cell, null);
    }

    Vector3 pos = tilemap.GetCellCenterWorld(cell);
    Instantiate(explosionPrefab, pos, Quaternion.identity);
  }
}
