using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    public GameObject highScoreMenu;
    public GameObject optionsMenu;
    public GameObject languageMenu;
    public GameObject translator;
    public GameObject gameModeMenu;
    public GameObject yesNoDialog;

    public Text scoreText;

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
        highScoreMenu.SetActive(false);
        yesNoDialog.SetActive(true);
    }

    public void No()
    {
        highScoreMenu.SetActive(true);
        yesNoDialog.SetActive(false);
    }
    public void Yes()
    {
        ResetScore();
        highScoreMenu.SetActive(true);
        yesNoDialog.SetActive(false);
        
    }

    private void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        scoreText.text = "0";
    }
    public void HideHighScore()
    {
        highScoreMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    public void ShowHighScore()
    {
        mainMenu.SetActive(false);
        highScoreMenu.SetActive(true);
    }
    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);

    }

    public void HideCredits()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void LoadOptionsMenu ()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu ()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadLanguageMenu()
    {
        optionsMenu.SetActive(false);
        languageMenu.SetActive(true);
    }

    public void ChangeToEnglish()
    {
        translator.GetComponent<Translator>().ChangeMenuTextEnglish();
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ChangeToSwedish()
    {
        translator.GetComponent<Translator>().ChangeMenuTextSwedish();
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void LoadGameModeMenu()
    {
        optionsMenu.SetActive(false);
        gameModeMenu.SetActive(true);
    }

    public void ChangeToNormal ()
    {
        gameModeMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ChangeToHard()
    {
        gameModeMenu.SetActive(false);
        optionsMenu.SetActive(true);
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
