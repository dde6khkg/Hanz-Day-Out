using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class POI : Subject
{
    void OnDestroy()
    {
        Notify(1);
    }
}
