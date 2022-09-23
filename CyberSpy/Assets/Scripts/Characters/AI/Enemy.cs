using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    

    public List<GameObject> DefendedTiles = new List<GameObject>();

    //Return all tiles the respective enemys current position covers
    public virtual void GetAllDefendedTiles()
    {
        //clear list if exists :)
    }

    public void EnemyKillPlayer()
    {
        //Move enemy to player tile
        //CharacterMove(ManagerObject.GetComponent<Manager>().player.GetComponent<Character>().CurrentTile);
        //disable player commands

        //trigger UI

    }


    private void Update()
    {
        
    }

    private void Awake()
    {

        GetAllDefendedTiles(); //needs to be called after enemy has moved 
    }
}