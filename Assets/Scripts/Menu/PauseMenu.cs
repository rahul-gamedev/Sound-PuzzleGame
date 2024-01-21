using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private Button resumeBtn;

    [SerializeField]
    private Button restartBtn;

    [SerializeField]
    private Button exitBtn;

    void Start() {
        resumeBtn.onClick.AddListener(Resume);
        restartBtn.onClick.AddListener(Restart);
        exitBtn.onClick.AddListener(Exit);
    }

    void Update()
    {
        if (InputManager.instance.PauseInput())
            isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Resume()
    {
        isPaused = false;
    }
    void Restart()
    {
        LevelManager.current.RestartLevel();
        Resume();
    }
    void Exit()
    {
        Application.Quit();
    }
}
