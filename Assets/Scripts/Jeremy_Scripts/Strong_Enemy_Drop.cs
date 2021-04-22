using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strong_Enemy_Drop : Enemy_Drops
{
    public GameObject MachineGunPrefab;
    public GameObject RocketLauncherPrefab;

    public override void Dropitem()
    {
        float choice;
        choice = 10 % RNG;
        if (choice > 5)
        {
            DropHealth();
        }
        else if (choice > 1)
        {
            Vector3 Position = transform.position;
            Debug.Log("attempting to instantiate");
            GameObject.Instantiate(MachineGunPrefab, Position, Quaternion.identity);
        }
        else
        {
            Vector3 Position = transform.position;
            Debug.Log("attempting to instantiate");
            GameObject.Instantiate(RocketLauncherPrefab, Position, Quaternion.identity);
        }
    }



}

