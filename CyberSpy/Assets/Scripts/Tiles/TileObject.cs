using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public int x, y;

    public void TileInitialization(int _x, int _y)
    {
        x = _x;
        y = _y;

        //object naming and config should be done here not on leveleditorscripts
    }

}
