using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager current;

    private void Awake()
    {
        current = this;
    }

    public void LoadLevelAsync(SceneSO scene)
    {
        if (scene)
            SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Additive);
    }

    public void UnloadLevelAsync(SceneSO scene)
    {
        if (scene)
            SceneManager.UnloadSceneAsync(scene.SceneName);
    }
}
