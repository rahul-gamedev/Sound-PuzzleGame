using UnityEngine;

[CreateAssetMenu(fileName = "SceneSO", menuName = "SO/SceneSO", order = 0)]
public class SceneSO : ScriptableObject
{
    public string SceneName;
    public Vector3 EntryPosition;
    public Quaternion EntryRotation;
}
