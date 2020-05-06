using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text playText;
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
        playText.text = "START";
        scoreText.text = "Score: ";
        gameOverText.text = "Game Over!";
        rButtonText.text = "RESTART";
        bmButtonText.text = "MAIN MENU";
        Debug.Log("Changed");
    }

    public void ChangeMenuTextSwedish(){
        exitText.text = "Avsluta";
        playText.text = "Starta";  
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
