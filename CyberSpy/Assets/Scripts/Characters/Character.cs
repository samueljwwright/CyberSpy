using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject StartingTile; //Somewhat pointless... Could just assign current tile in inspector for game start
    public GameObject CurrentTile;


    //Rotation
    [Range(0, 3)]
    public int LookDirection; //0 = n, 1 = e, 2 = s , 3 = w



    private void Start()
    {
        CharacterMove(StartingTile);
        
        FaceDirectionOfMovement(InputToDegree());

    }

    public void CharacterMove(GameObject DestinationTile)
    {
        CurrentTile = DestinationTile;
        transform.position = new Vector3(
            DestinationTile.transform.position.x,
            DestinationTile.transform.position.y + transform.lossyScale.y, // (destinationtile.lossyscale.y / 2)
            DestinationTile.transform.position.z);
    }


    //Rotation

    private int InputToDegree()
    {
        switch (LookDirection)
        {
            case 0:
                return 0;
            case 1:
                return 90;
            case 2:
                return 180;
            case 3:
                return 270;
            default:
                Debug.Log("Rotate out of range" + " " + LookDirection);
                return 0;
        }
    }

    public void FaceDirectionOfMovement(int Rot)
    {
        this.transform.localRotation =  Quaternion.Euler(this.transform.localRotation.x, Rot, this.transform.localRotation.z);
    }



    private void FixedUpdate()
    {
        
    }

}
