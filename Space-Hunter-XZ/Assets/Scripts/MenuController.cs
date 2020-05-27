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
    public GameObject creditsText;
    public GameObject creditsBackButton;
    public GameObject highScoreText;
    public GameObject scoreBackButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Changelevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void HideHighScore()
    {
        creditsButton.SetActive(true);
        highScoreButton.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        highScoreText.SetActive(false);
        scoreBackButton.SetActive(false);
    }
    
    public void ShowHighScore()
    {
        creditsButton.SetActive(false);
        highScoreButton.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        highScoreText.SetActive(true);
        scoreBackButton.SetActive(true);
    }
    public void ShowCredits()
    {
        creditsButton.SetActive(false);
        highScoreButton.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        creditsText.SetActive(true);
        creditsBackButton.SetActive(true);

    }

    public void HideCredits()
    {
        creditsButton.SetActive(true);
        highScoreButton.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        creditsText.SetActive(false);
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
