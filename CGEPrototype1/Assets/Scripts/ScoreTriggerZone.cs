using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;
    public AudioClip triggerSound;
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            ScoreManager.score++;

            playerAudio.PlayOneShot(triggerSound, 1.0f);
        }
    }
}
