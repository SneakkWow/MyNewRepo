using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes
using UnityEngine.UI;              // To work with UI elements

public class GameManager : MonoBehaviour
{
    // UI elements for the popup and buttons
    public GameObject levelSelectPanel;  // The panel with buttons for level selection
    public Button[] levelButtons;        // Array to hold the level buttons (1-6)

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the level select panel
        levelSelectPanel.SetActive(false);

        // Add listeners to each button for level selection
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Set level index 1 through 6
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed to toggle the level selection menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleLevelSelectPanel();
        }
    }

    // Toggle the level selection panel (popup)
    void ToggleLevelSelectPanel()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Show the level select panel
            Time.timeScale = 0f;  // Pause the game
            levelSelectPanel.SetActive(true);
        }
        else
        {
            // Hide the level select panel
            Time.timeScale = 1f;  // Resume the game
            levelSelectPanel.SetActive(false);
        }
    }

    // Load the selected level based on the button clicked
    public void LoadLevel(int levelIndex)
    {
        // Make sure the game is not paused when loading a new level
        Time.timeScale = 1f;  // Resume the game

        // Load the scene corresponding to the level (assuming levels are indexed 1-6)
        SceneManager.LoadScene("Finished 0" + levelIndex);  // This assumes your scene names are "Level1", "Level2", etc.
    }
}
