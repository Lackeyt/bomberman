﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestruct : MonoBehaviour
{
  public Tilemap tilemap;

  public Tile WoodPlank;
  public Tile RockWall;
  public Tile BorderBottom;
  public Tile BorderTop;
  public Tile BorderLeft;
  public Tile BorderRight;

  public GameObject explosionPrefab;

  public void Explode(Vector2 worldPos)
  {
    Vector3Int originCell = tilemap.WorldToCell(worldPos);

    ExplodeCell(originCell);
    if (ExplodeCell(originCell + new Vector3Int(1, 0, 0)))
    {
      ExplodeCell(originCell + new Vector3Int(2, 0, 0));
    };
    
    if(ExplodeCell(originCell + new Vector3Int(0, 1, 0)))
    {
      ExplodeCell(originCell + new Vector3Int(0, 2, 0));
    };
    
    if(ExplodeCell(originCell + new Vector3Int(-1, 0, 0)))
    {
      ExplodeCell(originCell + new Vector3Int(-2, 0, 0));
    };
    
    if(ExplodeCell(originCell + new Vector3Int(0, -1, 0)))
    {
      ExplodeCell(originCell + new Vector3Int(0, -2, 0));
    };
    
  }

  bool ExplodeCell (Vector3Int cell)
  {
    Tile tile = tilemap.GetTile<Tile>(cell);

    if (tile == RockWall || tile == BorderTop || tile == BorderBottom || tile == BorderLeft || tile == BorderRight) //do not explode walls
    {
      return false;
    }

    if (tile == WoodPlank) //destroy woodplanks
    {
      tilemap.SetTile(cell, null);
      Vector3 cpos = tilemap.GetCellCenterWorld(cell);
      Instantiate(explosionPrefab, cpos, Quaternion.identity);
      return false;
    }

    Vector3 pos = tilemap.GetCellCenterWorld(cell);
    Instantiate(explosionPrefab, pos, Quaternion.identity);

    return true;
  }
}
