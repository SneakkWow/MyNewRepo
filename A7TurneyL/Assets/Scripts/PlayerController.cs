using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerUp;

    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator;

    public Text score;
    public Text lose;
    public Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            messageText.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -5f)
        {
            score.gameObject.SetActive(false);
            lose.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " +
                hasPowerUp);

            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
