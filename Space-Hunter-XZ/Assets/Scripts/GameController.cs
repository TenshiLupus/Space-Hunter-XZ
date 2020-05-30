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
    public GameObject[] hazardsHard;
    public GameObject advEnemy;
    public GameObject advEnemyHard;
    public Vector3 spawnValues;
    public Vector3 spawnLeft;
    public Vector3 spawnRight;
    public int lifeCounter;
    public int score;
    public int hazardCount;
    public int waves;
    public int waveIncrease;
    public int wavesBeforeBreak;
    public int breakTime;
    public bool canShoot;
    public bool advancedWeapon;
    public float spawnWait;
    public float startWait;
    public float advWaveWait;
    public float waveWait;

    private Text lifeText;
    public Text scorePoints;
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
    private Coroutine waveCoroutine;

    public float elapsedTime;
    public float fadeTime;

    private bool gameOver;
    private bool hardMode;
    private int waveCounter;
    private int breakCounter;

    private void Start()
    {
        powerUpController = GameObject.FindWithTag("PowerUpController").GetComponent<PowerUpController>();
        if (PlayerPrefs.GetString("GameMode") == "Hard")
        {
            hardMode = true;
        } else
        {
            hardMode = false;
        }
        gameOver = false; ;
        gameOverText.text = "";
        lifeCounter = 0;
        score = 0;
        waveCounter = 0;
        breakCounter = 0;
        canShoot = true;
        advancedWeapon = false;
        UpdateScore();
        waveCoroutine = StartCoroutine(SpawnWaves());
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
            for (int i = 0; i < hazardCount; i++) // initiate first part of wave with random hazards
            {
                if (gameOver == false)
                {
                    hazardsIndex = Random.Range(0, hazards.Length);
                    GameObject hazard;
                    if (powerUpSpawned)
                    {
                        hazardsIndex = Random.Range(0, hazards.Length -3);
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
                        hazardsIndex = Random.Range(0, hazards.Length - 2);
                    }
                    if (!powerUpSpawned && powerUpController.shieldUpActive && powerUpController.laserUpActive) {
                        hazardsIndex = Random.Range(0, hazards.Length - 3);
                    } else {
                        if (hardMode) { hazard = hazardsHard[hazardsIndex]; } else { hazard = hazards[hazardsIndex]; }
                    }
                    if (hardMode) { hazard = hazardsHard[hazardsIndex]; } else { hazard = hazards[hazardsIndex]; }
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
            yield return new WaitForSeconds(advWaveWait); // wait before second part of wave
            breakCounter++;
            if (gameOver == false) // initiate second part of wave
            {
                GameObject sideEnemy;
                if (hardMode) { sideEnemy = advEnemyHard; } else { sideEnemy = advEnemy; }
                Quaternion spawnRotation2 = Quaternion.identity;
                Instantiate(sideEnemy, new Vector3(spawnLeft.x, spawnLeft.y + Random.Range(-2, 2), spawnLeft.z), spawnRotation2);
                Instantiate(sideEnemy, new Vector3(spawnRight.x, spawnRight.y + Random.Range(-2, 2), spawnRight.z), spawnRotation2);
                if (breakCounter == wavesBeforeBreak) // spawns extra 2 enemies for second part of wave every other wave
                {
                    yield return new WaitForSeconds(2);
                    Instantiate(sideEnemy, new Vector3(spawnLeft.x, spawnLeft.y + Random.Range(-2, 2), spawnLeft.z), spawnRotation2);
                    Instantiate(sideEnemy, new Vector3(spawnRight.x, spawnRight.y + Random.Range(-2, 2), spawnRight.z), spawnRotation2);

                }
                yield return new WaitForSeconds(waveWait);
            }
            if (gameOver == false && breakCounter == wavesBeforeBreak) // a short break for the player before next waves
            {
                canShoot = false;
                yield return new WaitForSeconds(breakTime);
                canShoot = true;
                breakCounter = 0;
            }
            waveCounter++;
            if (waveCounter == waves) // after set amount of waves = increases amount of random hazards in first part of wave
            {
                hazardCount += waveIncrease;
                waveCounter = 0;
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
         scorePoints.text = "" + score;
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
    void DestroyAllObjects()
    {

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
        backToMenu.SetActive(true);
        menuButton.SetActive(false);
        scoreObject.SetActive(false);
        lifeSystem.SetActive(false);
        pausedText.SetActive(true);
        continueButton.SetActive(true);
        restartButton.SetActive(true);
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
