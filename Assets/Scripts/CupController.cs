using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupController : MonoBehaviour
{
    Animator anim;
    AudioSource sfx;
    [SerializeField] GameObject winMenu;

    void Start()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        string element = other.gameObject.tag;
        if(element == "Player")
        {
            PauseControl.isGamePaused = true;
            StartCoroutine("Win");
        }
    }

    IEnumerator Win()
    {
        anim.SetBool("IsCupTouched", true);
        sfx.Play();
        yield return new WaitForSeconds(3f);
        winMenu.SendMessage("Win");
    }
}
