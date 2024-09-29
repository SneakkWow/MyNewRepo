using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;

    public ParticleSystem explosion;
    public ParticleSystem dirt;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);

        playerAudio = GetComponent<AudioSource>();

        //Physics.gravity *= gravityModifier;

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    public void StopRunning()
    {
        playerAnimator.SetFloat("Speed_f", 0.0f);
    }
}
