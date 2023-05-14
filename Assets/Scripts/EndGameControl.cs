using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameControl : MonoBehaviour
{
    [SerializeField] GameObject endGameMenu;
    static GameObject menu;
    [SerializeField] Text txtHeader;

    void Start()
    {
        menu = endGameMenu;
        menu.SetActive(false);
    }

    void Win()
    {
        txtHeader.text = "You Win!";
        ShowMenu();
    }

    void Lose()
    {
        txtHeader.text = "You Died";
        ShowMenu();
    }

    void ShowMenu()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        menu.SetActive(true);
    }
}