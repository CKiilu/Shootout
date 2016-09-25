using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject hazard, player;
    public Vector3 spawnValues;
    public int hazardCount;
    private int score;
    public float startWait, spawnWait, waveWait;
    private bool gameOver, restart;
    public GUIText scoreText, restartText, gameOverText;

    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        updateScore();
        StartCoroutine(spawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int x = 0; x < hazardCount; x++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart.";
                restart = true;
                break;
            }
        }
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void addScore(int addedScore)
    {
        score += addedScore;
        updateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
