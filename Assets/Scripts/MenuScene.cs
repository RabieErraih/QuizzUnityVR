using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Application.LoadLevel("MenuScene");
    }

    public void GoToARCamera()
    {
        Application.LoadLevel("GameScene");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
