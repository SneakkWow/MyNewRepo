using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    public float turboBoost = 20f;  // Turbo boost force
    public ParticleSystem turboEffect;  // Reference to the particle effect

    public GameObject playerCamDir;

    public bool started = false;
    public Text messageText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !started)
        {
            messageText.gameObject.SetActive(false);
            Time.timeScale = 1f;
            started = true;
        }
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 cameraForward = playerCamDir.transform.forward;
            cameraForward.y = 0;  // Ignore vertical component
            cameraForward.Normalize();  // Make sure it's a unit vector

            // Apply an impulse force in the direction the camera is facing
            playerRb.AddForce(cameraForward * turboBoost, ForceMode.Impulse);

            // Play the turbo effect particle system
            if (turboEffect != null)
            {
                turboEffect.Play();
            }
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerupCooldown());
            hasPowerup = true;
            powerupIndicator.SetActive(true);
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
