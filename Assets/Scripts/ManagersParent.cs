using UnityEngine;

public class ManagersParent : MonoBehaviour
{
    private static ManagersParent instance;

    void Awake()
    {
        // Ensure only one instance of ManagersParent exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object and its children from being destroyed
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate ManagersParent instances
        }
    }
}