using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager current;
    public SceneSO currentScene;
    private Transform Player;

    private void Awake()
    {
        current = this;
        Player = InputManager.instance.transform;
    }

    public void RestartLevel()
    {
        SceneManager.UnloadSceneAsync(currentScene.SceneName);
        Player.position = currentScene.EntryPosition;
        Player.rotation = currentScene.EntryRotation;
        SceneManager.LoadSceneAsync(currentScene.SceneName, LoadSceneMode.Additive);
    }
    public void LoadLevel(SceneSO scene)
    {
        SceneManager.LoadScene(scene.SceneName, LoadSceneMode.Single);
    }
    public void LoadLevelAsync(SceneSO scene)
    {
        if (!scene)
            return;
        SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Additive);
        currentScene = scene;
    }

    public void UnloadLevelAsync(SceneSO scene)
    {
        if (!scene)
            return;
        SceneManager.UnloadSceneAsync(scene.SceneName);
    }
}
