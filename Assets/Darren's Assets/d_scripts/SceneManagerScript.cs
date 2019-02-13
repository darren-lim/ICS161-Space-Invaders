using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public Canvas GameOverCanvas;
    public TextMeshProUGUI scoreText;
    public Canvas PauseCanvas;
    public bool paused;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
        GameOverCanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrResume();
        }
    }

    public void PauseOrResume()
    {
        if (!paused)
        {
            paused = true;
            PauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            PauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver(bool win)
    {
        Time.timeScale = 0;
        GameOverCanvas.gameObject.SetActive(true);
        if (win)
        {
            gameOverText.text = "You Win";
        }
        else
        {
            gameOverText.text = "Game Over";
        }
        scoreText.text = "Final Score: " + ScoreScript.Score.ToString();
    }
}
