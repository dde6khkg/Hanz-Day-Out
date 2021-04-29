using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drops : MonoBehaviour
{
    public GameObject HealthPrefab;
    public GameObject GunPrefab;
    public float RNG = 6;

       public virtual void Dropitem()
             {
        float choice;
       choice = 10 % RNG;
        if (choice < 1)
        {
           DropHealth();
        }
        else
        {
            Vector3 Position = transform.position;
            Debug.Log("attempting to instantiate");
            GameObject.Instantiate(GunPrefab, Position, Quaternion.identity);
        }
             }


        public void  DropHealth()
            {
        Vector3 Position = transform.position;
        Debug.Log("attempting to instantiate");
        GameObject.Instantiate(HealthPrefab, Position, Quaternion.identity);
             }


}
