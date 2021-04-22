using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(Time.timeScale == 0f)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");

        if(FindObjectOfType<PlayerMovement>() != null)
            FindObjectOfType<PlayerMovement>().Destroy();
        
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        if(FindObjectOfType<PlayerMovement>() != null)
            FindObjectOfType<PlayerMovement>().Destroy();

        StartCoroutine(FindObjectOfType<GameManager>().Restart(1f));
    }
}
