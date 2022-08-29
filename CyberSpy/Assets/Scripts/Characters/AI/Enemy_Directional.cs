using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Directional : Enemy
{

    public override void GetAllDefendedTiles()
    {
        //add while loop for Max defence range?
         switch (LookDirection)
        {
            case 0: //x * ld + z + 1 (tile.x == currtile.x) 
                if (ManagerObject.GetComponent<Manager>().AllTiles.Length >= findAdjacentTile(1))
                {
                    if (ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(1)].GetComponent<TraversableTile>()) //& on same column/row (add this for all)
                        DefendedTiles.Add(ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(1)]);
                }
                break;

            case 1: //x * ld + z + ld (check y)
                if (ManagerObject.GetComponent<Manager>().AllTiles.Length >= findAdjacentTile(Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length))))
                {
                    if (ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length)))].GetComponent<TraversableTile>())
                        DefendedTiles.Add(ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length)))]);                    
                }

                break;

            case 2: //x * ld + z - 1 (check x)
                if (ManagerObject.GetComponent<Manager>().AllTiles.Length >= findAdjacentTile(-1))
                {
                    if (ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(-1)].GetComponent<TraversableTile>())
                        DefendedTiles.Add(ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(-1)]);
                }

                break;

            case 3: // x * ld + z - ld (check y) 
                if (ManagerObject.GetComponent<Manager>().AllTiles.Length >= findAdjacentTile(Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length)) * -1))
                {
                    if (ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length)) * - 1)].GetComponent<TraversableTile>())
                        DefendedTiles.Add(ManagerObject.GetComponent<Manager>().AllTiles[findAdjacentTile(Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length)) * - 1)]);
                }

                break;

            default:
                
                break;
        }
    }

    private int findAdjacentTile(int a)
    {
        return this.CurrentTile.GetComponent<TileObject>().x * Mathf.RoundToInt(Mathf.Sqrt(ManagerObject.GetComponent<Manager>().AllTiles.Length))   + this.CurrentTile.GetComponent<TileObject>().y + a;
    }
}
