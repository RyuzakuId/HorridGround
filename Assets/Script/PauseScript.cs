using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ExitMainMenu()
    {
        Cursor.visible = !Cursor.visible;
        //Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }

    void Pause()
    {
        Cursor.visible = !Cursor.visible;
        //Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }



}
