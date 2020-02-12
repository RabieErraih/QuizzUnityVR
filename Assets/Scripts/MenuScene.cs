using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToARCamera()
    {
        ScoreClass.PlayerScore = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
