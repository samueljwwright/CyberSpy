using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraversableTile : TileObject
{
    //****TODO*****// THIS AND GETCONNECTINGTILES() IS UNNECESSARY AND CONVOLUTED JUST USE CONNECTING TILES[GAMEOBJECT]!!!
    public bool[] ConnectingTiles = new bool[4]; //0=-X, 1=+X, 2=-Z, 3=+Z

    public GameObject[] ConnectingTileObjects = new GameObject[4];

    private GameObject ManagerObject; 

    //TODO (COULD BE BASE METHODS)
    public GameObject GetConnectingTile(int Direction)
    {
        return this.gameObject;
    }

    public GameObject[] GetConnectingTiles()
    {
        if (ConnectingTiles[0]) //-x
        {
            // - ld 
            //ConnectingTileObjects[0] = ManagerObject.GetComponent<Manager>().AllTiles[];
        }
        if (ConnectingTiles[1]) //+x
        {
            // + ld
        }
        if (ConnectingTiles[2]) //-y
        {
            // - y
        }
        if (ConnectingTiles[3]) //+y
        {
            // + y
        }

        //for (<)
        //get managerlist(i)
        return new GameObject[1];
    }

    private void Awake()
    {
        ManagerObject = GameObject.FindWithTag("Manager");
    }
}
