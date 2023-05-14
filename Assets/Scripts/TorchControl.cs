using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
    Light torchLight;
    void Start()
    {
        torchLight = GetComponent<Light>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
            torchLight.enabled = !torchLight.enabled;
    }
}
