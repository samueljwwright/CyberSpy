using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //editor script cannot be used at runtime -> list of tiles is moved here after level is "completed" using editor window

    //editor only variables
    [SerializeField]
    private List<GameObject> ConnectionNodes = new List<GameObject>(); //ONLY WORKS WHEN SERIALIZED (I DON'T KNOW WHY :D)
    private float TileMidPoint = 0.666f;

    //run-time variables

    public void TileManagerInitialization(List<GameObject> ActiveTiles, int LevelDimensions, GameObject[,] tiles)
    {

        for (int x=0; x < LevelDimensions; x++)
        {
            for (int z=0; z < LevelDimensions; z++)
            {
                if (x != 0 && x < LevelDimensions && ActiveTiles.Contains(tiles[x, z])) 
                {
                    if (ActiveTiles.Contains(tiles[x - 1, z])) //if -x is assigned
                    {
                        tiles[x, z].GetComponent<TraversableTile>().ConnectingTiles[0] = true; //ERROR! SCRPT NOT ATTATCHED TO OBJECT AT TIME OF THIS _>problem with contil
                        tiles[x - 1, z].GetComponent<TraversableTile>().ConnectingTiles[1] = true;

                        //DRAW NODE X (repetetive)
                        GameObject ConnectionNode = Instantiate(Resources.Load("ConnectionNode")) as GameObject;
                        ConnectionNode.transform.position = new Vector3(tiles[x, z].transform.position.x - TileMidPoint,
                                                                        tiles[x, z].transform.position.y + 0.5f,
                                                                        tiles[x, z].transform.position.z);
                        ConnectionNode.transform.parent = this.gameObject.transform;
                        ConnectionNodes.Add(ConnectionNode);
                        //DRAW NODE X

                        Debug.Log(tiles[x, z].name + " " + tiles[x-1, z].name);
                    }
                    
                }

                if (z != 0 && z < LevelDimensions && ActiveTiles.Contains(tiles[x, z]))
                {
                    if (ActiveTiles.Contains(tiles[x, z - 1]))
                    {
                        tiles[x, z].GetComponent<TraversableTile>().ConnectingTiles[2] = true;
                        tiles[x, z - 1].GetComponent<TraversableTile>().ConnectingTiles[3] = true;

                        //DRAW NODE Z
                        GameObject ConnectionNode = Instantiate(Resources.Load("ConnectionNode")) as GameObject;
                        ConnectionNode.transform.position = new Vector3(tiles[x, z].transform.position.x,
                                                                        tiles[x, z].transform.position.y + 0.5f,
                                                                        tiles[x, z].transform.position.z - TileMidPoint);
                        ConnectionNode.transform.parent = this.gameObject.transform;
                        ConnectionNodes.Add(ConnectionNode);
                        //DRAW NODE Z

                        Debug.Log(tiles[x, z].name + " " + tiles[x, z - 1].name);
                    }
                }
            }
            
        }
    }

    private void Awake()
    {
        for (int i=0; i < ConnectionNodes.Count; i++)
        {
            Debug.Log(ConnectionNodes[i]);
            Destroy(ConnectionNodes[i]);
        }
    }
}
