using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //editor script cannot be used at runtime -> list of tiles is moved here after level is "completed" using editor window

    public void TileManagerInitialization(List<GameObject> ActiveTiles, int LevelDimensions, GameObject[,] tiles)
    {
        for (int x=0; x < LevelDimensions; x++)
        {
            for (int z=0; z < LevelDimensions; z++)
            {

            }
            
        }      
    }
}
