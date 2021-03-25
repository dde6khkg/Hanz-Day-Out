using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnded = false;
    public float restartDelay = 2f;
    public GameObject GameOverText;
    //Next Room
    public int enemiesLeft;
    public GameObject door;
    int health;


    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        if(enemiesLeft == 0)
        {
            door.SetActive(false);
        }
    }

    public void EndGame()
    {
        if(GameEnded == false)
        {
            GameEnded = true;
            //GameOverText.SetActive(true);

            Time.timeScale = 1;
            StartCoroutine(Restart(restartDelay));
        }
    }

    public void Enemies()
    {
        enemiesLeft--;
    }

    public void loadNextLevel()
    {
        var rng = Random.Range(3, SceneManager.sceneCountInBuildSettings - 1);
        if(rng == SceneManager.GetActiveScene().name[6])
            rng = Random.Range(3, SceneManager.sceneCountInBuildSettings - 1);
        if(rng == SceneManager.GetActiveScene().name[6])
            rng = Random.Range(3, SceneManager.sceneCountInBuildSettings - 1);

        FindObjectOfType<PlayerMovement>().resetPos();

        if(SceneManager.GetActiveScene().name == "Test_Level")
            SceneManager.LoadScene("Test_Level");
        else
        {
            SceneManager.LoadScene(rng);
        }
    }

    public IEnumerator Restart(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameEnded = false;

        if(SceneManager.GetActiveScene().name == "Test_Level")
        {
            //GameOverText.SetActive(false);
            SceneManager.LoadScene("Test_Level");
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("Restart...");
            //GameOverText.SetActive(false);
            SceneManager.LoadScene("Level_1");
            FindObjectOfType<Enemy>().shootDelay(1f);
            Time.timeScale = 1;
        }
    }
}
