using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public enum PickupObject {Gun, Missile_Launcher};
    public PickupObject currentObject;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(currentObject == PickupObject.Missile_Launcher)
            GameObject.Find("Player").GetComponent<Shooting>().Weapon = "Missile_Launcher";
        }
        Destroy(gameObject);
    }
}
