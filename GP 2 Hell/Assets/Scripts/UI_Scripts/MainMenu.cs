using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene("Level_Lust");
    }


    public void MainMenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Called when the player clicks on the "Quit" button in the game
    public void QuitGame() { 
        Debug.Log("Quit!");
        Application.Quit();
    }


}
