using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int enemiesLeft;
    GameManager manager;

    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        if(enemiesLeft == 0)
        {
            manager.noEnemies = true;
        }
    }

     public void Enemies()
    {
        enemiesLeft--;
    }
}
