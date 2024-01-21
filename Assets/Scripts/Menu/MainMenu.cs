using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button exitBtn;
    void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        exitBtn.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void ExitGame()
    {
        Application.Quit();
    }
}
