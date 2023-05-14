using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] AudioClip sfxWalk;
    AudioSource sfx;
    Rigidbody rb;
    CapsuleCollider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        sfx = GetComponent<AudioSource>();
        sfx.loop = true;
    }

    void Update()
    {
        if(!PauseControl.isGamePaused)
        {
            Vector2 moveInput = Vector2.zero;
            moveInput.x = Input.GetAxis("Horizontal") * speed;
            moveInput.y = Input.GetAxis("Vertical") * speed;
            moveInput *= Time.deltaTime;
            transform.Translate(moveInput.x, 0, moveInput.y);

            if (!(moveInput.x == 0 && moveInput.y == 0))
                playWalk();
            else
                pauseWalk();
        
            if(Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }

    void playWalk() {
        if (!sfx.isPlaying)
        {
            sfx.clip = sfxWalk;
            sfx.loop = true;
            sfx.Play();
        }
    }

    void pauseWalk() {
        if (sfx.isPlaying)
            sfx.Stop();
    }
}
