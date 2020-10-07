using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
  public Tilemap tilemap;

  public GameObject bombPrefab;
  public GameObject player;

  // Update is called once per frame
  void Update()
  {
    //centers bombs in the middle of the clicked cell
    if(Input.GetMouseButtonDown(0)) //on left mouse button click
    {
      Vector3 worldPos = player.transform.position; //mouse position
      Vector3Int cell = tilemap.WorldToCell(worldPos);                        //cell on tilemap
      Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);               //center of cell

      Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
    }
  }
}
