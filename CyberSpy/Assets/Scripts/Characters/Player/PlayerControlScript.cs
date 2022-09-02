using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    //Player input script

    private GameObject DestinationTile;
    [SerializeField]
    private GameObject Player; //refactor selectedTileIsAccesable to use this variable....

    public GameObject Manager;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,100))
        {
            if (hit.transform.tag == "Tile")
            {    
                if (Input.GetMouseButtonDown(0) && SelectedTileIsAccessable(hit.transform.gameObject))
                {
                    Manager.GetComponent<Manager>().MoveCounter++;
                    Player.GetComponent<Player>().CharacterMove(DestinationTile);
                }
            }
            
        }
    }

    private bool SelectedTileIsAccessable(GameObject SelectedTile)
    {
        bool b = false;

        if (!SelectedTile.GetComponent<TraversableTile>())
        {
            b = false;      
        }
        else
        {
            //This is very ugly (USE PLAYER VARIABLE!)
            
            int[] SelectedTileCoords = { SelectedTile.GetComponent<TraversableTile>().x, SelectedTile.GetComponent<TraversableTile>().y };
            int[] CurrentTileConnections = { GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentTile.GetComponent<TraversableTile>().x,
                                             GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentTile.GetComponent<TraversableTile>().y };

            if(SelectedTileCoords[0] == CurrentTileConnections[0] && SelectedTileCoords[1] == CurrentTileConnections[1] - 1 || SelectedTileCoords[0] == CurrentTileConnections[0] && SelectedTileCoords[1] == CurrentTileConnections[1] + 1)
            {
                b = true;
            }else if (SelectedTileCoords[1] == CurrentTileConnections[1] && SelectedTileCoords[0] == CurrentTileConnections[0] - 1 || SelectedTileCoords[1] == CurrentTileConnections[1] &&  SelectedTileCoords[0] == CurrentTileConnections[0] + 1)
            {
                b = true;
            }
            else
            {
                b = false;
            }
        }
        DestinationTile = SelectedTile;
        return b;
    }

}
