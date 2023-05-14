using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] GameObject cross;
    const float CLAMP_MIN = -45;
    const float CLAMP_MAX = 45;

    Animation anim;
    float lookSensitivity = 2;
    GameObject player;
    Vector3 posCam1P = new Vector3(0f, 1f, 0f);
    Vector3 posCam3P = new Vector3(0f, 10f, -15f);

    Vector2 rotation = Vector2.zero;
    Vector2 smoothRot = Vector2.zero;
    Vector2 velRot = Vector2.zero;

    void Start()
    {
        anim = GetComponent<Animation>();
        player = transform.parent.gameObject;
        anim.Play("Camera1P");
    }

    void Update()
    {
        if(!PauseControl.isGamePaused)
        {
            player.transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);
            rotation.y += Input.GetAxis("Mouse Y");
            rotation.y = Mathf.Clamp(rotation.y, CLAMP_MIN, CLAMP_MAX);
            smoothRot.y = Mathf.SmoothDamp(smoothRot.y, rotation.y, ref velRot.x, 0.1f);
            transform.localEulerAngles = new Vector3(-smoothRot.y, 0, 0);
        }
    }
}
