using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Adjacent : Enemy
{

    //Return tiles that are of the same row or column
    public  override void GetAllDefendedTiles()
    {
        for (int i=0; i < ManagerObject.GetComponent<Manager>().LevelDimensions; i ++)
        {
            if (ManagerObject.GetComponent<Manager>().AllTiles[this.CurrentTile.GetComponent<TileObject>().x * ManagerObject.GetComponent<Manager>().LevelDimensions + i].GetComponent<TraversableTile>())
            {
                DefendedTiles.Add(ManagerObject.GetComponent<Manager>().AllTiles[this.CurrentTile.GetComponent<TileObject>().x * ManagerObject.GetComponent<Manager>().LevelDimensions + i]);
            }
            else
            {
                if (i < this.CurrentTile.GetComponent<TileObject>().y) //have we passed current tile?
                {
                    //Clear List
                    for (int j = 0; j < i; j++)
                    {
                        DefendedTiles.Clear();
                    }
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = 0; i < ManagerObject.GetComponent<Manager>().LevelDimensions; i++) //given own for loop for temp testing
        {

            //get all connecting tiles with same Z value
            if(ManagerObject.GetComponent<Manager>().AllTiles[this.CurrentTile.GetComponent<TileObject>().y + (ManagerObject.GetComponent<Manager>().LevelDimensions * i)].GetComponent<TraversableTile>())
            {
                DefendedTiles.Add(ManagerObject.GetComponent<Manager>().AllTiles[this.CurrentTile.GetComponent<TileObject>().y + (ManagerObject.GetComponent<Manager>().LevelDimensions * i)]);
            }
            else
            {
                if(i < this.CurrentTile.GetComponent<TileObject>().x)
                {
                    //Clear List
                    for (int j = 0; j < i; j++)
                    {
                        DefendedTiles.RemoveAt(DefendedTiles.Count - 1 - j); //this is clearing all x connections aswell..........
                    }
                }
                else
                {
                    break;
                }
            }

        }
        //dimensions find (this.x.value, this.z.value+iterator) && inverse
        //if(current(x or z, i).x % leveldimensions - 1 == 0) we have reached the edge => stop 
    }

}
