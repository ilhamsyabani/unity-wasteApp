using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    private static DontDestroyOnLoadScript instance;

    private void Awake()
    {
        // Check if an instance of this script already exists.
        if (instance == null)
        {
            // If not, set this instance as the singleton.
            instance = this;

            // Make the GameObject this script is attached to persist across scene changes.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject.
            Destroy(gameObject);
        }
    }

    // Other code and functionality of this script.
}
