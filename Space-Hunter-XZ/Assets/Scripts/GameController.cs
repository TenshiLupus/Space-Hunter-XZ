using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameOverSound;
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
    public GameObject scoreObject;
    public GameObject lifeSystem
        ;
    public GameObject pausedText;
    public GameObject menuButton;
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject backToMenu;
    public CanvasGroup canvasGroup;

    private PowerUpController powerUpController;

    public int score;
    public float elapsedTime;
    public float fadeTime;

    private bool gameOver;
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
        StartCoroutine(AudioController.FadeIn(audioSource, 2.5f));
        lifeText = GameObject.Find("LifeNumber").GetComponent<Text>();
        Invoke("FadeIn", 1f);

    }

    private void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    IEnumerator DoFadeIn()
    {
        while (canvasGroup.alpha < 1)
        {

            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(0.0f + (elapsedTime / fadeTime));
            yield return null;
        }

        yield return null;
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
                Instantiate(advEnemy, new Vector3(spawnLeft.x, spawnLeft.y + Random.Range(-2, 2), spawnLeft.z), spawnRotation2);
                Instantiate(advEnemy, new Vector3(spawnRight.x, spawnRight.y + Random.Range(-2, 2), spawnRight.z), spawnRotation2);
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
        if (score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        if(PlayerPrefs.GetString("Language").Equals("English"))
        scoreText.text = "SCORE: " + score;
        else if(PlayerPrefs.GetString("Language").Equals("Swedish"))
        scoreText.text = "POÄNG: " + score;
    }

    public void GameOver()
    {
        StartCoroutine(AudioController.FadeIn(audioSource, 0.5f));
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverSound, 1f);
        gameOverText.text = "GAME OVER!";
        menuButton.SetActive(false);
        scoreObject.SetActive(false);
        lifeSystem.SetActive(false);
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

    public void Awake()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        pausedText.SetActive(true);
        continueButton.SetActive(true);
        restartButton.SetActive(true);
        backToMenu.SetActive(true);
        menuButton.SetActive(false);
        scoreObject.SetActive(false);
        lifeSystem.SetActive(false);
        Time.timeScale = 0.0f;
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        pausedText.SetActive(false);
        continueButton.SetActive(false);
        restartButton.SetActive(false);
        backToMenu.SetActive(false);
        menuButton.SetActive(true);
        scoreObject.SetActive(true);
        lifeSystem.SetActive(true);
        Time.timeScale = 1.0f;
        //enable the scripts again
    }

    public void MainScene(){
        SceneManager.LoadScene("Main");
        restartButton.SetActive(false);
    }

    public void Menuscene(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        backToMenu.SetActive(false);
    }
}
