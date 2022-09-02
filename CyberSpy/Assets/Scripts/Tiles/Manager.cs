using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Manager : MonoBehaviour
{
    //editor script cannot be used at runtime -> list of tiles is moved here after level is "completed" using editor window

    //editor only variables
    [SerializeField]
    private List<GameObject> ConnectionNodes = new List<GameObject>(); //ONLY WORKS WHEN SERIALIZED (I DON'T KNOW WHY :D)
    private float TileMidPoint = 0.666f;

    //run-time variables'
    [SerializeField]
    //MULTIDEMENSIONAL ARRAYS CANNOT BE SERIALIZED...!
    public GameObject[] AllTiles;

    public int LevelDimensions;

    public List<GameObject>[] LevelSides = new List<GameObject>[4]; // N,E,S,W
    public List<GameObject> ExteriorWalls = new List<GameObject>(); //ADDED IN INSPECTOR ATM

    public int MoveCounter;



    public void TileManagerInitialization(List<GameObject> ActiveTiles, int levelDimensions, GameObject[,] tiles)
    {

        LevelDimensions = levelDimensions; //TEMP

        AllTiles = new GameObject[levelDimensions * levelDimensions];

        //MAKE DEDICATED METHOD FOR THIS TwoDimensionalArrToARETURN ARR -> PARAMS(ARR, 2DARR, LEVELDIMENSIONS(FROM ARR.LENGTH))
        for (int x = 0; x < levelDimensions; x++)
        {
            for (int z = 0; z < levelDimensions; z++)
            {
                AllTiles[x == 0 ? x + z : z + (levelDimensions * x)] = tiles[x, z];
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////// Could re-build the 2d array at runtime
        ///

        //GameObject[,] Test = ArrayToTwoDimensionalArray(AllTiles);         







        for (int x = 0; x < LevelDimensions; x++)
        {
            for (int z = 0; z < LevelDimensions; z++)
            {
                if (x != 0 && x < LevelDimensions && ActiveTiles.Contains(tiles[x, z]))
                {
                    if (ActiveTiles.Contains(tiles[x - 1, z])) //if -x is assigned
                    {
                        //REMOVE AFTER IMPLEMENTING GAMEOBJECT ARRAY// & DUPLICATED LINES BELOW
                        tiles[x, z].GetComponent<TraversableTile>().ConnectingTiles[0] = true;
                        tiles[x - 1, z].GetComponent<TraversableTile>().ConnectingTiles[1] = true;
                        //
                        tiles[x, z].GetComponent<TraversableTile>().ConnectingTileObjects[0] = tiles[x - 1, z];
                        tiles[x - 1, z].GetComponent<TraversableTile>().ConnectingTileObjects[1] = tiles[x, z];




                        //DRAW NODE X (repetetive)
                        GameObject ConnectionNode = Instantiate(Resources.Load("ConnectionNode")) as GameObject;
                        ConnectionNode.transform.position = new Vector3(tiles[x, z].transform.position.x - TileMidPoint,
                                                                        tiles[x, z].transform.position.y + 0.5f,
                                                                        tiles[x, z].transform.position.z);
                        ConnectionNode.transform.parent = this.gameObject.transform;
                        ConnectionNodes.Add(ConnectionNode);
                        //DRAW NODE X

                        //Debug.Log(tiles[x, z].name + " " + tiles[x-1, z].name);
                    }

                }

                if (z != 0 && z < LevelDimensions && ActiveTiles.Contains(tiles[x, z]))
                {
                    if (ActiveTiles.Contains(tiles[x, z - 1]))
                    {
                        //* REMOVE AFTER IMPLEMENTING OBJECTS
                        tiles[x, z].GetComponent<TraversableTile>().ConnectingTiles[2] = true;
                        tiles[x, z - 1].GetComponent<TraversableTile>().ConnectingTiles[3] = true;
                        //
                        tiles[x, z].GetComponent<TraversableTile>().ConnectingTileObjects[2] = tiles[x, z - 1];
                        tiles[x, z - 1].GetComponent<TraversableTile>().ConnectingTileObjects[3] = tiles[x, z];


                        //DRAW NODE Z
                        GameObject ConnectionNode = Instantiate(Resources.Load("ConnectionNode")) as GameObject;
                        ConnectionNode.transform.position = new Vector3(tiles[x, z].transform.position.x,
                                                                        tiles[x, z].transform.position.y + 0.5f,
                                                                        tiles[x, z].transform.position.z - TileMidPoint);
                        ConnectionNode.transform.parent = this.gameObject.transform;
                        ConnectionNodes.Add(ConnectionNode);
                        //DRAW NODE Z

                        //Debug.Log(tiles[x, z].name + " " + tiles[x, z - 1].name);
                    }
                }
            }

        }
    }

    //private GameObject[] TwoDimensionalArrayToArray()
    //{
    //
    //}

    public GameObject player;
    public GameObject[] Enemies;

    private void FixedUpdate()
    {
        //if (PlayerMove)
        //{
        //    return;
        //}
        //else
        //{
        //    for(int i=0; i < Enemies.Length; i++)
        //    {
        //if player tile is defended e.t.c
        //    }
        //}

        for (int i = 0; i < Enemies.Length; i++)
        {
            for (int j = 0; j < Enemies[i].GetComponent<Enemy>().DefendedTiles.Count; j++)
            {
                if (player.GetComponent<Character>().CurrentTile == Enemies[i].GetComponent<Enemy>().DefendedTiles[j])
                {
                    Debug.Log("CheckMate! " + Enemies[i].name); 
                }
            }
        }


        //Debug.Log(MoveCounter);
    }


    private void Awake()
    {
        for (int i = 0; i < ConnectionNodes.Count; i++) //DESTROY CONNECTION NODE OBJECTS
        {
            Destroy(ConnectionNodes[i]);
        }


        player = GameObject.FindGameObjectWithTag("Player");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
