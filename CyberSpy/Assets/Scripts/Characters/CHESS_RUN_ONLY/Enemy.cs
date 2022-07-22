using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public GameObject ManagerObject;

    public List<GameObject> DefendedTiles = new List<GameObject>();

    //Return all tiles the respective enemys current position covers
    public virtual void GetAllDefendedTiles()
    {
        
    }

    private void Awake()
    {
        ManagerObject = GameObject.FindWithTag("Manager");

        GetAllDefendedTiles();
    }
}
