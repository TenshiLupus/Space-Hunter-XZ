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
    public Text resetText;
    public Text yes;
    public Text no;
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
        if (PlayerPrefs.GetString("Language") == null)
        {
            selectedLanguage = "English";
        } 
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
            } else if (selectedLanguage.Equals("French"))
            {
                ChangeMainTextFrench();
            }
        }
        else if (currentScene.Equals("MainMenu"))
        {
            if (selectedLanguage.Equals("English")) ChangeMenuTextEnglish();
            else if (selectedLanguage.Equals("Swedish")) ChangeMenuTextSwedish();
            else if (selectedLanguage.Equals("French")) ChangeMenuTextFrench();
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
            highScoreText.text = "HIGH SCORE";
            resetScoreButtonText.text = "RESET SCORE";
            resetText.text = "RESET SCORE";
            yes.text = "YES";
            no.text = "NO";
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
            resetText.text = "NOLLSTÄLL";
            yes.text = "JA";
            no.text = "NEJ";
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

    public void ChangeMenuTextFrench()
    {
        if (currentScene.Equals("MainMenu"))
        {
            credits.text = "DÉVELOPPEMENT DU JEU";
            creditsMusicText.text = "MUSIQUE";
            creditsButtonText.text = "CRÉDITS";
            highScoreButtonText.text = "RECORD";
            startText.text = "JOUER";
            exitText.text = "QUITTER";
            scoreText.text = "POINTS: ";
            creditBackButtonText.text = "RETOUR";
            highScoreText.text = "RECORD";
            resetScoreButtonText.text = "RÉINITIALISER";
            resetText.text = "RÉINITIALISER";
            yes.text = "OUI";
            no.text = "NON";
            highScoreButtonBackText.text = "RETOUR";
            languageButtonText.text = "LANGAGE";
            languageButtonText.fontSize = 65;
            gameModeButtonText.text = "NIVEAU";
            gameModeButtonText.fontSize = 65;
            normalButtonText.text = "NORMAL";
            hardButtonText.text = "DIFFICILE";
            optionsBackButtonText.text = "RETOUR";
            optionsBackButtonText.fontSize = 65;
            optionsButtonText.text = "OPTIONS";
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
            SaveData("French");
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

    public void ChangeMainTextFrench()
    {
        scoreText.text = "POINTS";
        menuButtonText.text = "MENU";
        continueText.text = "CONTINUER";
        rButtonText.text = "RECOMMENCER";
        bmButtonText.text = "MENU PRINCIPAL";
        SaveData("French");
    }
}