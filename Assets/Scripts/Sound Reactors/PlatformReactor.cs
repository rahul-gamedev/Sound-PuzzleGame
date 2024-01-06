using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformReactor : MonoBehaviour
{
    [SerializeField]
    private SceneSO EssentialScene;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        if (other.gameObject.CompareTag("Player"))
            SceneManager.MoveGameObjectToScene(
                other.gameObject,
                SceneManager.GetSceneByName(EssentialScene.SceneName)
            );
    }
}
