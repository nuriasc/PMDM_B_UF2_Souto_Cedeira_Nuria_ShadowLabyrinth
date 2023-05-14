using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuButtonControl : MonoBehaviour
{
    Button btn;
    [SerializeField] PauseControl pauseControl;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(PauseControl.isGamePaused)
        {
            if (btn.tag == "btn-resume")
                pauseControl.Resume();
            else if (btn.tag == "btn-exit")
                StartCoroutine("GoToMainMenu");
        }
    }
    
    IEnumerator GoToMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu-00");
        while(!asyncLoad.isDone)
            yield return null;
    }
}
