using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject StartingTile; //Somewhat pointless... Could just assign current tile in inspector for game start
    public GameObject CurrentTile;

    private void Start()
    {
        CharacterMove(StartingTile);  
    }

    public void CharacterMove(GameObject DestinationTile)
    {
        CurrentTile = DestinationTile;
        transform.position = new Vector3(
            DestinationTile.transform.position.x,
            DestinationTile.transform.position.y + transform.lossyScale.y,
            DestinationTile.transform.position.z);
    }


    private void FixedUpdate()
    {
        
    }
}
