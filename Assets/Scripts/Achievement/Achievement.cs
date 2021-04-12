using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : Observer
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        
        foreach(var poi in FindObjectsOfType<POI>())
            poi.RegisterObserver(this);
    }
    
    public override void OnNotify(object value)
    {
        string key = "Achievement " + value;

        if(PlayerPrefs.GetInt(key) == 1)
            return;
        
        PlayerPrefs.SetInt(key, 1);
        Debug.Log("Unlocked " + key);
    }
}
