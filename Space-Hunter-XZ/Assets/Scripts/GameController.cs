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

    public GameObject backToMenu;

    private PowerUpController powerUpController;

    private bool gameOver;
    private int score;
    private int wave;

    private int lifeCounter=0;
    private Text lifeText;

    private void Start()
    {
        powerUpController = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
        gameOver = false; ;
        gameOverText.text = "";
        score = 0;
        wave = 1;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        lifeText = GameObject.Find("LifeNumber").GetComponent<Text>();

    }

    private void Update() {
    lifeText.text="x " + lifeCounter;    
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            int hazardsIndex;
            bool powerUpSpawned = false;
            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver == false)
                {
                    hazardsIndex = Random.Range(0, hazards.Length);
                    GameObject hazard;
                    if (powerUpSpawned)
                    {
                        hazardsIndex = Random.Range(0, hazards.Length -2);
                    }
                    if (!powerUpSpawned && !powerUpController.shieldUpActive && powerUpController.laserUpActive)
                    {
                        hazardsIndex = Random.Range(0, hazards.Length);
                        if (hazardsIndex == 4)
                        {
                            hazardsIndex = 5;
                        }
                    }
                    if (!powerUpSpawned && powerUpController.shieldUpActive && !powerUpController.laserUpActive)
                    {
                        hazardsIndex = Random.Range(0, hazards.Length - 1);
                    }
                    if (!powerUpSpawned && powerUpController.shieldUpActive && powerUpController.laserUpActive)
                    {
                        hazardsIndex = Random.Range(0, hazards.Length - 2);
                    }
                    else
                    {
                        hazard = hazards[hazardsIndex];
                    }
                    hazard = hazards[hazardsIndex];
                    if (hazardsIndex == 4 || hazardsIndex == 5)
                    {
                        powerUpSpawned = true;
                    }
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
                backToMenu.SetActive(true);
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

    public void GiveLife(){
        lifeCounter++;
    }

    public void TakeLife(){
        lifeCounter--;
    }

    public int GetLife(){
        return lifeCounter;
    }

    
    public void MainScene(){
        SceneManager.LoadScene("Main");
        restartButton.SetActive(false);
    }

    public void Menuscene(){
        SceneManager.LoadScene("MainMenu");
        backToMenu.SetActive(false);
    }
}
