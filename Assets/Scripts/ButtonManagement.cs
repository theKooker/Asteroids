using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Button mainMenu, continueB;
    public void tryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        scoreText.text = "Score: " + GameData.score.ToString();
    }

    public void PauseGame()
    {
        mainMenu.gameObject.SetActive(true);
        continueB.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        mainMenu.gameObject.SetActive(false);
        continueB.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void GetBack()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("highScore", 0) < GameData.score)
            PlayerPrefs.SetInt("highScore", GameData.score);
        SceneManager.LoadScene("MainMenu");
    }


}
