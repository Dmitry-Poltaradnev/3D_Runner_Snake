using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("Balls");
        //scoreText.text = bestScore.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Work");
    }
}
