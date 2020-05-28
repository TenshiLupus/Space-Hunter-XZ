using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject creditsButton;
    public GameObject highScoreButton;
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject credits;
    public GameObject creditsBackButton;
    public Text scoreText;
    public GameObject highScoreText;
    public GameObject resetScoreButton;
    public GameObject scoreBackButton;
    public GameObject yesNoDialog;
    public CanvasGroup canvasGroup;
    private string languageSelected; 

    public float elapsedTime;
    public float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + PlayerPrefs.GetInt("score");
        Invoke("FadeInMenu", 0.5f);
    }

    private void FadeInMenu()
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
    public void Changelevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void YesOrNo()
    {
        creditsButton.SetActive(false);
        highScoreButton.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        highScoreText.SetActive(false);
        resetScoreButton.SetActive(false);
        scoreBackButton.SetActive(false);
        yesNoDialog.SetActive(true);
    }

    public void No()
    {
        highScoreText.SetActive(true);
        resetScoreButton.SetActive(true);
        scoreBackButton.SetActive(true);
        yesNoDialog.SetActive(false);
    }
    public void Yes()
    {
        ResetScore();
        highScoreText.SetActive(true);
        resetScoreButton.SetActive(true);
        scoreBackButton.SetActive(true);
        yesNoDialog.SetActive(false);
        
    }

    private void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        scoreText.text = "0";
    }
    public void HideHighScore()
    {
        creditsButton.SetActive(true);
        highScoreButton.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        highScoreText.SetActive(false);
        resetScoreButton.SetActive(false);
        scoreBackButton.SetActive(false);
    }
    
    public void ShowHighScore()
    {
        creditsButton.SetActive(false);
        highScoreButton.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        highScoreText.SetActive(true);
        resetScoreButton.SetActive(true);
        scoreBackButton.SetActive(true);
    }
    public void ShowCredits()
    {
        creditsButton.SetActive(false);
        highScoreButton.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        credits.SetActive(true);
        creditsBackButton.SetActive(true);

    }

    public void HideCredits()
    {
        creditsButton.SetActive(true);
        highScoreButton.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        credits.SetActive(false);
        creditsBackButton.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
