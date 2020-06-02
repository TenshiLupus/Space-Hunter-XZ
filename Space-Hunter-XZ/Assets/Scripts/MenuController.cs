using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startButtonSound;
    public GameObject audioController;
    public GameObject mainMenu;
    public GameObject creditsMenu;

    public GameObject highScoreMenu;
    public GameObject optionsMenu;
    public GameObject languageMenu;
    public GameObject translator;
    public GameObject gameModeMenu;
    public GameObject yesNoDialog;
    public GameObject englishArrow;
    public GameObject swedishArrow;
    public GameObject japaneseArrow;
    public GameObject normalArrow;
    public GameObject hardArrow;

    public Text scoreText;

    public CanvasGroup canvasGroup;
    private string languageSelected; 

    public float elapsedTime;
    public float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioController.GetComponent<AudioSource>();
        Screen.orientation = ScreenOrientation.Portrait;
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "English");
        }
        if (!PlayerPrefs.HasKey("GameMode"))
        {
            PlayerPrefs.SetString("GameMode", "Normal");
        }
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

    public void StartGame(int i)
    {
        audioSource.PlayOneShot(startButtonSound,0.7f);
        Invoke("ChangeLevel(i)", 1f);
    }
    public void ChangeLevel(int i)
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
        if (PlayerPrefs.GetString("Language") == "English")
        {
            englishArrow.SetActive(true);
        }
        if (PlayerPrefs.GetString("Language") == "Swedish")
        {
            swedishArrow.SetActive(true);
        }

    }

    public void ChangeToEnglish()
    {
        translator.GetComponent<Translator>().ChangeMenuTextEnglish();
        swedishArrow.SetActive(false);
        japaneseArrow.SetActive(false);
        englishArrow.SetActive(true);
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ChangeToSwedish()
    {
        translator.GetComponent<Translator>().ChangeMenuTextSwedish();
        englishArrow.SetActive(false);
        japaneseArrow.SetActive(false);
        swedishArrow.SetActive(true);
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ChangeToJapanese()
    {
        translator.GetComponent<Translator>().ChangeMenuTextJapanese();
        englishArrow.SetActive(false);
        swedishArrow.SetActive(false);
        japaneseArrow.SetActive(true);
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void LoadGameModeMenu()
    {
        optionsMenu.SetActive(false);
        if (PlayerPrefs.GetString("GameMode") == "Normal")
        {
            normalArrow.SetActive(true);
        }
        if (PlayerPrefs.GetString("GameMode") == "Hard")
        {
            hardArrow.SetActive(true);
        }
        gameModeMenu.SetActive(true);
    }

    public void ChangeToNormal ()
    {
        PlayerPrefs.SetString("GameMode", "Normal");
        PlayerPrefs.Save();
        hardArrow.SetActive(false);
        normalArrow.SetActive(true);
        gameModeMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ChangeToHard()
    {
        PlayerPrefs.SetString("GameMode", "Hard");
        PlayerPrefs.Save();
        normalArrow.SetActive(false);
        hardArrow.SetActive(true);
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
