using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject cross;
    static GameObject menu;

    void Start()
    {
        menu = pauseMenu;
        isGamePaused = false;
        PauseGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = isGamePaused ? 0f : 1f;
        Cursor.lockState = isGamePaused? CursorLockMode.None : CursorLockMode.Locked;
        cross.SetActive(!isGamePaused);
        menu.SetActive(isGamePaused);
    }

    public void Resume()
    {
        isGamePaused = false;
        PauseGame();
    }
}