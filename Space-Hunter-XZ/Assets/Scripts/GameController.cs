using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject advEnemy;
    public Vector3 spawnValues;
    public Vector3 spawnLeft;
    public Vector3 spawnRight;
    public int hazardCount;
    public int waveCount;
    public int waveIncrease;
    public float spawnWait;
    public float startWait;
    public float advWaveWait;
    public float waveWait;
    
    public Text scoreText;
    public Text gameOverText;
    public GameObject restartButton;

    private bool gameOver;
    private int score;
    private int wave;

    private void Start()
    {
        gameOver = false;;
        gameOverText.text = "";
        score = 0;
        wave = 1;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver == false)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            yield return new WaitForSeconds(advWaveWait);
            if (gameOver == false)
            {
                Quaternion spawnRotation2 = Quaternion.identity;
                Instantiate(advEnemy, spawnLeft, spawnRotation2);
                Instantiate(advEnemy, spawnRight, spawnRotation2);
                yield return new WaitForSeconds(waveWait);
            }
            wave++;
            if (wave == waveCount)
            {
                hazardCount += waveIncrease;
                wave = 0;
            }
            if (gameOver)
            {
                restartButton.SetActive(true);
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

    }

    
    public void NextScene()
    {
        SceneManager.LoadScene("Main");
        restartButton.SetActive(false);
    }
}
