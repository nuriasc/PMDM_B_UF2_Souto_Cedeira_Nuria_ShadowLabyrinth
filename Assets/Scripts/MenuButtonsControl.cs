using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonsControl: MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (btn.tag == "btn-start")
            StartCoroutine("StartGame");
        else if (btn.tag == "btn-exit")
            Application.Quit();
    }

    IEnumerator StartGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene-01");
        while(!asyncLoad.isDone)
            yield return null;
    }
}
