using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class LevelEditor : EditorWindow
{
    
    private const string LEVEL_OBJECT_NAME = "Level Grid";
    static int levelDimensions = 3;
    
    
    GameObject[,] Tiles = new GameObject[levelDimensions,levelDimensions];

    public List<GameObject> TraversableTiles = new List<GameObject>();

    GameObject SelectedTile;

    string TileManagerAssetPath = "Manager";
    string TileAssetPath = "Tile";
    float TilePadding = 1.333f; //distance between tiles (must equal wall-joint piece) //this could be moved to tile class

    GameObject manager;

    [MenuItem("Tools/Level Builder")]
    public static void init()
    {
        GetWindow(typeof(LevelEditor));
    }

    private void OnGUI()
    {
        //GUI INIT

        GUILayout.Label("Build Level Grid");

        levelDimensions = EditorGUILayout.IntField("Level Dimensions", levelDimensions);
        
        //Generate Level 

        if (GUILayout.Button("Generate"))
        {
            Generate();
        }


        if (GUILayout.Button("Assign Tile"))
        {
            if (Selection.activeGameObject)
            {
                //foreach (GameObject obj in Selection.gameObjects)
                //{
                    TraversableTiles.Add(SelectedTile);
                //}
            }
        }

        if (GUILayout.Button("Complete"))
        {
            for(int x=0; x < levelDimensions; x++)
            {
                for (int z=0; z < levelDimensions; z++)
                {
                    if (!TraversableTiles.Contains(Tiles[x, z]))
                    {
                        Tiles[x, z].AddComponent<NonTraversableTile>();
                        //ignore destroy -> add derived class from tileobject for non-assigned
                        //DestroyImmediate(Tiles[x,z]); //Dangerous!
                    }
                    else
                    {
                        Tiles[x, z].AddComponent<TraversableTile>();


                        //TESTING INHERITANCE! REMOVE AFTER
                        for (int i =0; i < Tiles[x,z].GetComponents<TileObject>().Length; i++)
                        {
                            Tiles[x, z].GetComponents<TileObject>()[i].x = x;
                        }
                    }
                    Tiles[x, z].GetComponent<TileObject>().TileInitialization(x, z); //->all but instantiation should take place on complete

                }
            }
            manager.GetComponent<Manager>().TileManagerInitialization(TraversableTiles, levelDimensions, Tiles);
        }



        

        SelectedTile = Selection.activeGameObject;
    }

    private void Generate()
    {

        //Pointless error logging because I am the only person using this :)
        if(levelDimensions <= 0)
        {
            Debug.LogError("Level Dimensions cannot be less than 1");
            return;
        }

        //Managment object
        manager = Instantiate(Resources.Load(TileManagerAssetPath) as GameObject);
        
       

        //Generate Tiles

        for(int x=0; x < levelDimensions; x++)
        {
            for(int y=0; y < levelDimensions; y++)
            {             
                GameObject newTile = Instantiate(Resources.Load (TileAssetPath) as GameObject);
                newTile.transform.position = new Vector3(x * (TilePadding), 0, y * (TilePadding));
                newTile.transform.SetParent(manager.transform);

                Tiles[x, y] = newTile;
                
                
            }
        }

        
        
    }
    
}
