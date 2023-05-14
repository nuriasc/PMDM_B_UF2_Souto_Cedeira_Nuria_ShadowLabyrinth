using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        gameObject.SetActive(false);
    }
}
