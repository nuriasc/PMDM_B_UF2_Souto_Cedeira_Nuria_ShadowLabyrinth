using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMenuButtonControl : MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (btn.tag == "btn-exit")
            StartCoroutine("GoToMainMenu");
    }
    
    IEnumerator GoToMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu-00");
        while(!asyncLoad.isDone)
            yield return null;
    }
}
