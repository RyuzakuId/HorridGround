using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;


    public void PlayGame()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OpenCreditPanel ()
    {
        creditPanel.SetActive(true);
    }

    public void CloseCreditPanel ()
    {
        creditPanel.SetActive(false);
    }

}
