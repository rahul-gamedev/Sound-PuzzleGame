using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField]
    private SceneSO ThisLevel;

    [SerializeField]
    private SceneSO NextLevel;

    public void LoadNextLevel()
    {
        LevelManager.current.LoadLevelAsync(NextLevel);
        LevelManager.current.UnloadLevelAsync(ThisLevel);
    }
}
