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

        this.name = TileName(x,y);
        //object naming and config should be done here not on leveleditorscripts


    }

    private string TileName(int x, int y)
    {
        string _name = "X" + x + "Y" + y;
        return _name;
    }
}
