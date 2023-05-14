using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhoulController : MonoBehaviour
{
    [SerializeField] float maxLife;
    public float health;
    Animation anim;
    AudioSource sfx;

    void Start()
    {
        anim = GetComponent<Animation>();
        sfx = GetComponent<AudioSource>();
        health = maxLife;
    }

    void OnCollisionEnter(Collision other)
    {
        string element = other.gameObject.tag;
        if(health > 0)
        {
            if(element == "bullet")
            {
                health -= 3;
                if(health <= 0)
                    StartCoroutine("Die");
            }
            if(element == "Player")
                anim.Play("Attack1");
        }
    }

    IEnumerator Die()
    {
        anim.Play("Death");
        if (sfx.isPlaying)
            sfx.Stop();
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
        yield return new WaitForSeconds(3f);
        GameObject.Destroy(gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        if(health > 0 && other.gameObject.tag == "Player")
            other.gameObject.SendMessage("ApplyDamage", 3);
    }

    void OnCollisionExit(Collision other)
    {
        if(health > 0 && other.gameObject.tag == "Player")
            anim.Play("Walk");
    }
}
