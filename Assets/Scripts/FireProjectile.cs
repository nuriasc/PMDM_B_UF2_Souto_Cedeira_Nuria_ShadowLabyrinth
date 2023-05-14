using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float delay;
    void Update()
    {
        if(!PauseControl.isGamePaused)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
                Destroy(clone, delay);
            }
        }
    }
}
