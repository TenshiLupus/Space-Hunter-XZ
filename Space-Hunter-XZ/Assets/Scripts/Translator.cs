using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Translator : MonoBehaviour
{
    public Text credits;
    public Text creditsButtonText;
    public Text creditBackButtonText;
    public Text highScoreButtonText;
    public Text highScoreButtonBackText;
    public Text highScoreText;
    public Text scoreText;
    public Text scorePoints;
    public Text resetScoreButtonText;
    public Text gameOverText;
    public Text startText;
    public Text exitText;
    public Text rButtonText;
    public Text bmButtonText;
    public Text creditsMusicText;
    public Text optionsButtonText;
    public Text pausedText;
    public Text continueText;
    public Text menuButtonText;
    public Text languageButtonText;
    public Text gameModeButtonText;
    public Text normalButtonText;
    public Text hardButtonText;
    public Text optionsBackButtonText;
    public GameObject creditsButton;
    public GameObject highScoreButton;
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject exitButton;


    private float rectWidth;


    private string selectedLanguage;
    private Scene scene;
    private string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        selectedLanguage = PlayerPrefs.GetString("Language");
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        ChangeLanguage();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeLanguage()
    {
        if (currentScene.Equals("Main"))
        {
            if (selectedLanguage.Equals("English"))
            {
                ChangeMainTextEnglish();
            }
            else if (selectedLanguage.Equals("Swedish"))
            {
                ChangeMainTextSwedish();
            } else if (selectedLanguage.Equals("Japanese"))
            {
                ChangeMainTextJapanese();
            }
        }
        else if (currentScene.Equals("MainMenu"))
        {
            if (selectedLanguage.Equals("English")) ChangeMenuTextEnglish();
            else if (selectedLanguage.Equals("Swedish")) ChangeMenuTextSwedish();
            else if (selectedLanguage.Equals("Japanese")) ChangeMenuTextJapanese();
        }
    }

    public void SaveData(string language)
    {
        selectedLanguage = language;
        PlayerPrefs.SetString("Language", selectedLanguage);
        PlayerPrefs.Save();
    }

    public void ChangeMenuTextEnglish(){
        if (currentScene.Equals("MainMenu"))
        {
            credits.text = "GAME DEVELOPMENT";
            creditsMusicText.text = "MUSIC";
            creditsButtonText.text = "CREDITS";
            highScoreButtonText.text = "HIGH SCORE";
            startText.text = "START GAME";
            exitText.text = "EXIT";
            scoreText.text = "SCORE: ";
            creditBackButtonText.text = "BACK";
            highScoreText.text = "TOP SCORE";
            resetScoreButtonText.text = "RESET";
            highScoreButtonBackText.text = "BACK";
            languageButtonText.text = "LANGUAGE";
            languageButtonText.fontSize = 55;
            gameModeButtonText.text = "GAME MODE";
            gameModeButtonText.fontSize = 55;
            normalButtonText.text = "NORMAL";
            hardButtonText.text = "HARD";
            optionsBackButtonText.text = "BACK";
            optionsBackButtonText.fontSize = 55;
            optionsButtonText.text = "OPTIONS";
            optionsButtonText.resizeTextForBestFit = true;
            RectTransform transformCredits = creditsButton.GetComponent<RectTransform>();
            transformCredits.sizeDelta = new Vector2(430, 95);
            RectTransform transformScore = highScoreButton.GetComponent<RectTransform>();
            transformScore.sizeDelta = new Vector2(550, 95);
            RectTransform transformStart = startButton.GetComponent<RectTransform>();
            transformStart.sizeDelta = new Vector2(780, 95);
            RectTransform transformOptions = optionsButton.GetComponent<RectTransform>();
            transformOptions.sizeDelta = new Vector2(500, 95);
            RectTransform transformExit = exitButton.GetComponent<RectTransform>();
            transformExit.sizeDelta = new Vector2(550, 95);

            SaveData("English");
        }
    }

    public void ChangeMenuTextSwedish(){
        if (currentScene.Equals("MainMenu")){
            credits.text = "SPELUTVECKLING";
            creditsMusicText.text = "MUSIK";
            creditsButtonText.text = "MEDVERKANDE";
            highScoreButtonText.text = "HÖGSTA POÄNG";
            startText.text = "STARTA SPEL";
            exitText.text = "AVSLUTA";
            scoreText.text = "POÄNG: ";
            creditBackButtonText.text = "TILLBAKA";
            highScoreText.text = "HÖGSTA POÄNG";
            resetScoreButtonText.text = "NOLLSTÄLL";
            highScoreButtonBackText.text = "TILLBAKA";
            languageButtonText.text = "SPRÅK";
            languageButtonText.fontSize = 55;
            gameModeButtonText.text = "SVÅRIGHET";
            gameModeButtonText.fontSize = 55;
            normalButtonText.text = "NORMAL";
            hardButtonText.text = "SVÅR";
            optionsBackButtonText.text = "TILLBAKA";
            optionsBackButtonText.fontSize = 55;
            optionsButtonText.text = "INSTÄLLNINGAR";
            optionsButtonText.resizeTextForBestFit = true;
            RectTransform transformCredits = creditsButton.GetComponent<RectTransform>();
            transformCredits.sizeDelta = new Vector2(700, 95);
            RectTransform transformScore = highScoreButton.GetComponent<RectTransform>();
            transformScore.sizeDelta = new Vector2(694, 95);
            RectTransform transformStart = startButton.GetComponent<RectTransform>();
            transformStart.sizeDelta = new Vector2(780, 95);
            RectTransform transformOptions = optionsButton.GetComponent<RectTransform>();
            transformOptions.sizeDelta = new Vector2(800, 95);
            RectTransform transformExit = exitButton.GetComponent<RectTransform>();
            transformExit.sizeDelta = new Vector2(550, 95);
            SaveData("Swedish");
        }
    }

    public void ChangeMenuTextJapanese()
    {
        if (currentScene.Equals("MainMenu"))
        {
            credits.text = "開発者";
            creditsMusicText.text = "音楽";
            creditsButtonText.text = "創作";
            highScoreButtonText.text = "点数";
            startText.text = "開始";
            exitText.text = "終";
            scoreText.text = "点数: ";
            creditBackButtonText.text = "戻る";
            highScoreText.text = "最高点";
            resetScoreButtonText.text = "再設定";
            highScoreButtonBackText.text = "戻る";
            languageButtonText.text = "言葉";
            languageButtonText.fontSize = 65;
            gameModeButtonText.text = "難易度";
            gameModeButtonText.fontSize = 65;
            normalButtonText.text = "初級";
            hardButtonText.text = "上級";
            optionsBackButtonText.text = "戻る";
            optionsBackButtonText.fontSize = 65;
            optionsButtonText.text = "設定";
            optionsButtonText.fontSize = 80;
            optionsButtonText.resizeTextForBestFit = false;
            RectTransform transformCredits = creditsButton.GetComponent<RectTransform>();
            transformCredits.sizeDelta = new Vector2(550, 95);
            RectTransform transformScore = highScoreButton.GetComponent<RectTransform>();
            transformScore.sizeDelta = new Vector2(550, 95);
            RectTransform transformStart = startButton.GetComponent<RectTransform>();
            transformStart.sizeDelta = new Vector2(550, 95);
            RectTransform transformOptions = optionsButton.GetComponent<RectTransform>();
            transformOptions.sizeDelta = new Vector2(550, 95);
            RectTransform transformExit = exitButton.GetComponent<RectTransform>();
            transformExit.sizeDelta = new Vector2(550, 95);
            SaveData("Japanese");
        }
    }


    public void ChangeMainTextEnglish(){
        scoreText.text = "SCORE";
        menuButtonText.text = "MENU";
        continueText.text = "CONTINUE";
        rButtonText.text = "RESTART";
        bmButtonText.text = "MAIN MENU";
        SaveData("English");
    }

    public void ChangeMainTextSwedish(){
        scoreText.text = "POÄNG";
        menuButtonText.text = "MENY";
        continueText.text = "FORTSÄTT";
        rButtonText.text = "STARTA OM";
        bmButtonText.text = "HUVUDMENY";
        SaveData("Swedish");
    }

    public void ChangeMainTextJapanese()
    {
        scoreText.text = "点数";
        menuButtonText.text = "メニュー";
        continueText.text = "続く";
        rButtonText.text = "再起動";
        bmButtonText.text = "終";
        SaveData("Japanese");
    }
}