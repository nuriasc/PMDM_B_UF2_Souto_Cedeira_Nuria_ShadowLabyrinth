using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    const float MAX_LIFE = 100;
    float health;
    [SerializeField] GameObject LoseMenu;
    [SerializeField] Text txtHealth;
    void Start()
    {
        health = MAX_LIFE;
        ApplyDamage(0);
    }

    void ApplyDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage * Time.deltaTime;
            txtHealth.text = Mathf.FloorToInt(health).ToString();
        }
        else {
            PauseControl.isGamePaused = true;
            StartCoroutine("Lose");
        }
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(1f);
        LoseMenu.SendMessage("Lose");
    }
}
