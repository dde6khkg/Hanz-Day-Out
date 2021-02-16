using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnded = false;
    public float restartDelay = 3f;
    public GameObject GameOverText;
    //Next Room
    int enemiesLeft;
    public GameObject door;
    int levelNum = 1;
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
            GameOverText.SetActive(true);

            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        GameOverText.SetActive(false);
        SceneManager.LoadScene("Level_1");
        FindObjectOfType<Enemy>().shootDelay(1f);
        Time.timeScale = 1f;
    }

    public void Enemies()
    {
        enemiesLeft--;
    }

    public void loadNextLevel()
    {
        FindObjectOfType<PlayerMovement>().resetPos();
        SceneManager.LoadScene("Level_" + ++levelNum);
    }
}
