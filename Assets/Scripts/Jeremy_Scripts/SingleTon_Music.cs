using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleTon_Music : MonoBehaviour
{

    public static SingleTon_Music instance;
    public AudioClip get_lucky;
    public AudioClip Sonic_Colors;
    public AudioClip Terran_2;

    private AudioSource audio1;



    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }




        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            audio1 = gameObject.GetComponent<AudioSource>();
            if (audio1.clip != Sonic_Colors)
            {
                audio1.clip = Sonic_Colors;
                audio1.Play();
            }
        }
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            audio1 = gameObject.GetComponent<AudioSource>();
            if (audio1.clip != get_lucky)
            {
                audio1.clip = get_lucky;
                audio1.Play();
            }
        }
        if (SceneManager.GetActiveScene().name == "Level_4" || SceneManager.GetActiveScene().name == "Level_3")
        {
            audio1 = gameObject.GetComponent<AudioSource>();
            if (audio1.clip != Terran_2)
            {
                audio1.clip = Terran_2;
                audio1.Play();
            }
        }

    }
}
