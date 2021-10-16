using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore",0);
        highScoreText.text = highScore.ToString();
    }
    public void play() {
        SceneManager.LoadScene("Level");
    }
}
