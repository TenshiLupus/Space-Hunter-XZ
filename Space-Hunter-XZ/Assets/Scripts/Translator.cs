using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{

    public Text highScoreText;
    public Text creditsText;
    public Text creditBackText;
    public Text highScoreButtonText;
    public Text scoreText;
    public Text gameOverText;
    public Text resetScoreButtonText;
    public Text startText;
    public Text exitText;
    public Text rButtonText;
    public Text bmButtonText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMenuTextEnglish(){
        exitText.text = "EXIT";
        startText.text = "START";
        scoreText.text = "Score: ";
        gameOverText.text = "Game Over!";
        rButtonText.text = "RESTART";
        bmButtonText.text = "MAIN MENU";
        Debug.Log("Changed");
    }

    public void ChangeMenuTextSwedish(){
        exitText.text = "Avsluta";
        startText.text = "Starta";  
        scoreText.text = "Poäng";
        gameOverText.text = "Slut!";
        rButtonText.text = "STARTA OM";
        bmButtonText.text = "HUVUD MENY";
       
        Debug.Log("Ändrad");
    }

     public void ChangeMainTextEnglish(){
        scoreText.text = "Score: ";
        gameOverText.text = "Game Over!";
        rButtonText.text = "RESTART";
        bmButtonText.text = "MAIN MENU";
        Debug.Log("Changed");
    }

    public void ChangeMainTextSwedish(){
        scoreText.text = "Poäng";
        gameOverText.text = "Slut!";
        rButtonText.text = "STARTA OM";
        bmButtonText.text = "HUVUD MENY";
        Debug.Log("Ändrad");
    }
}