using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{

	public Text youWin;
	private bool gameOver = false;

    private void Update()
    {
		if (gameOver)
        {
			if (Input.GetKeyDown(KeyCode.R))
			{
				Scene currentScene = SceneManager.GetActiveScene();
				// Reload the scene
				SceneManager.LoadScene(currentScene.buildIndex);
			}
		}
	}

    void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag("Player"))
		{
			youWin.text = "You Win!";
			gameOver = true;
		}
	}
}
