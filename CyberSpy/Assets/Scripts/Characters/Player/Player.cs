using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void KillEnemy()
    {
        for(int i=0; i < ManagerObject.GetComponent<Manager>().Enemies.Length; i++)
        {
            if(CurrentTile == ManagerObject.GetComponent<Manager>().Enemies[i].GetComponent<Character>().CurrentTile)
            {
                ManagerObject.GetComponent<Manager>().Enemies[i].GetComponent<Enemy>().DefendedTiles.Clear();
                ManagerObject.GetComponent<Manager>().Enemies[i].SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        KillEnemy();
    }
}
