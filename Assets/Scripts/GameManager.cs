using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnded = false;
    public GameObject GameOver;
    public GameObject BText;
    //Next Room
    public int enemiesLeft;
    public GameObject door;
    static int[] rooms = {2, 3, 4, 5};
    static List<int> r = new List<int>(rooms);

    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        if(enemiesLeft == 0)
        {
            Destroy(door);
        }
    }

    public void EndGame()
    {
        if(GameEnded == false)
        {
            GameEnded = true;
            Time.timeScale = 0;

            GameOver.SetActive(true);
            
            if(PlayerPrefs.GetInt("Achievement 1") == 1)
                BText.SetActive(true);
        }
    }

    public void loadNextLevel()
    {
        var rng = Random.Range(0, r.Count);

        FindObjectOfType<PlayerMovement>().resetPos();

        if(SceneManager.GetActiveScene().name == "Test_Level")
            SceneManager.LoadScene("Test_Level");
        else if(r.Count == 0)
        {
            SceneManager.LoadScene("Level_Boss");
            r = new List<int>(rooms);
        }
        else
        {
            SceneManager.LoadScene("Level_Boss");//"Level_" + r[rng]);

            //r.RemoveAt(rng);
        }
    }

    public IEnumerator Restart(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameEnded = false;
        PlayerPrefs.DeleteAll();
        
        if(SceneManager.GetActiveScene().name == "Test_Level")
        {
            SceneManager.LoadScene("Test_Level");
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("Restart...");
            SceneManager.LoadScene("Level_1");

            //Sets shoot delay so enemies don't shoot you when you spawn in
            FindObjectOfType<Enemy>().shootDelay(Random.Range(1f, 1.25f));

            Time.timeScale = 1;
        }
    }
}
