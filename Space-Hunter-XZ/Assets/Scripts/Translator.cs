﻿using System.Collections;
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
    public Text optionsBackButtonText;


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
            }
        }
        else if (currentScene.Equals("MainMenu"))
        {
            if (selectedLanguage.Equals("English")) ChangeMenuTextEnglish();
            else if (selectedLanguage.Equals("Swedish")) ChangeMenuTextSwedish();
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
            credits.text = "GAME DEVELOPMENT:\n\n\n ANGEL CARDENAS MARTINEZ\n JACOB WIK\n SAMUEL SEGAWA";
            creditsMusicText.text = "MUSIC:\n\n THREE CHAIN LINKS\n threechainlinks.bandcamp.com\n ERIC MATYAS\n www.soundimage.org";
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
            gameModeButtonText.text = "GAME MODE";
            optionsBackButtonText.text = "BACK";
            optionsButtonText.text = "OPTIONS";
            SaveData("English");
        }
    }

    public void ChangeMenuTextSwedish(){
        if (currentScene.Equals("MainMenu")){
            credits.text = "SPELUTVECKLING:\n\n\n ANGEL CARDENAS MARTINEZ\n JACOB WIK\n SAMUEL SEGAWA";
            creditsMusicText.text = "MUSIK:\n\n THREE CHAIN LINKS\n threechainlinks.bandcamp.com\n ERIC MATYAS\n www.soundimage.org";
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
            gameModeButtonText.text = "SVÅRIGHET";
            optionsBackButtonText.text = "TILLBAKA";
            optionsButtonText.text = "INSTÄLLNINGAR";
            SaveData("Swedish");
        }
    }

     public void ChangeMainTextEnglish(){
        scoreText.text = "SCORE:";
        menuButtonText.text = "MENU";
        continueText.text = "CONTINUE";
        rButtonText.text = "RESTART";
        bmButtonText.text = "MAIN MENU";
        SaveData("English");
    }

    public void ChangeMainTextSwedish(){
        scoreText.text = "POÄNG:";
        menuButtonText.text = "MENY";
        continueText.text = "FORTSÄTT";
        rButtonText.text = "STARTA OM";
        bmButtonText.text = "HUVUDMENY";
        SaveData("Swedish");
    }
}