using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public static PlayerReferences instance;

    public Transform SadHolder;
    public Transform PickableHolder;

    private void Awake()
    {
        instance = this;
    }
}
