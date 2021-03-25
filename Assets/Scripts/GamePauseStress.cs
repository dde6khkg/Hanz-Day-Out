using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseStress : MonoBehaviour
{

    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
            Time.timeScale = 0f;
    }
}
