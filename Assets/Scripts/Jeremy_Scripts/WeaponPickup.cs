using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public enum PickupObject {Gun, Missile_Launcher, Health_Pack, Bounce_Gun};
    public PickupObject currentObject;
    PlayerMovement player;



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if (currentObject == PickupObject.Missile_Launcher)
            {
                GameObject.Find("Player").GetComponent<Shooting>().Weapon = "Missile_Launcher";
                GameObject.Find("Player").GetComponent<Shooting>().fireRate = 2f;
            }
            else if (currentObject == PickupObject.Gun)
            {
                GameObject.Find("Player").GetComponent<Shooting>().Weapon = "Gun";
                GameObject.Find("Player").GetComponent<Shooting>().fireRate = 1f;
            }
            else if (currentObject == PickupObject.Health_Pack)
            {
                player = FindObjectOfType<PlayerMovement>();
                player.takeDamage(-1);
            }
            else if (currentObject == PickupObject.Bounce_Gun)
            {
                GameObject.Find("Player").GetComponent<Shooting>().Weapon = "Bounce_Gun";
                GameObject.Find("Player").GetComponent<Shooting>().fireRate = .05f;
            }
        }
        Destroy(gameObject);
    }
}
