using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
